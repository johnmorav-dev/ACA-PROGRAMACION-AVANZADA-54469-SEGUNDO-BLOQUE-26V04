using System.Data;
using Microsoft.Data.SqlClient;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Operaciones de la tabla Prestamos. Registrar, editar, devolver y eliminar
    /// también modifican las existencias del libro, por eso se ejecutan dentro de
    /// una transacción: o se guardan todos los cambios o no se guarda ninguno.
    /// </summary>
    public class PrestamoDAO : DaoBase
    {
        private const string ConsultaBase = @"
            SELECT p.IdPrestamo, p.IdUsuario, p.ISBN, p.FechaPrestamo, p.FechaDevolucion, p.Estado,
                   u.Nombre + ' ' + u.Apellido AS NombreUsuario,
                   l.Titulo AS TituloLibro
            FROM Prestamos p
            INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario
            INNER JOIN Libros l ON p.ISBN = l.ISBN";

        /// <summary>
        /// Lista los préstamos filtrando por estado ("" = todos) y por un texto
        /// que puede coincidir con el usuario, el título o el ISBN.
        /// </summary>
        public List<Prestamo> Listar(string estado = "", string texto = "")
        {
            string consulta = ConsultaBase + @"
                WHERE (@Estado = '' OR p.Estado = @Estado)
                  AND (@Texto = ''
                       OR u.Nombre + ' ' + u.Apellido LIKE '%' + @Texto + '%'
                       OR l.Titulo LIKE '%' + @Texto + '%'
                       OR p.ISBN LIKE '%' + @Texto + '%')
                ORDER BY p.IdPrestamo DESC";

            DataTable tabla = EjecutarConsulta(consulta,
                Parametro("@Estado", estado ?? ""),
                Parametro("@Texto", texto ?? ""));

            List<Prestamo> prestamos = new List<Prestamo>();
            foreach (DataRow fila in tabla.Rows)
            {
                prestamos.Add(ConvertirFila(fila));
            }
            return prestamos;
        }

        public Prestamo ObtenerPorId(int idPrestamo)
        {
            DataTable tabla = EjecutarConsulta(ConsultaBase + " WHERE p.IdPrestamo = @IdPrestamo",
                Parametro("@IdPrestamo", idPrestamo));

            return tabla.Rows.Count > 0 ? ConvertirFila(tabla.Rows[0]) : null;
        }

        /// <summary>Indica si el usuario ya tiene un préstamo activo de ese libro.</summary>
        public bool ExistePrestamoActivo(int idUsuario, string isbn, int idExcluir = 0)
        {
            string consulta = @"SELECT COUNT(*) FROM Prestamos
                                WHERE IdUsuario = @IdUsuario AND ISBN = @ISBN
                                  AND Estado = 'Prestado' AND IdPrestamo <> @IdExcluir";

            return EjecutarEscalar(consulta,
                Parametro("@IdUsuario", idUsuario),
                Parametro("@ISBN", isbn),
                Parametro("@IdExcluir", idExcluir)) > 0;
        }

        /// <summary>
        /// Registra el préstamo y descuenta una existencia del libro.
        /// Devuelve false si el libro se quedó sin existencias.
        /// </summary>
        public bool Registrar(Prestamo prestamo)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        // 1. Descontar una existencia solo si hay ejemplares
                        if (!DescontarExistencia(cn, transaccion, prestamo.ISBN))
                        {
                            transaccion.Rollback();
                            return false;
                        }

                        // 2. Registrar el préstamo
                        string consulta = @"INSERT INTO Prestamos
                                                (IdUsuario, ISBN, FechaPrestamo, FechaDevolucion, Estado)
                                            VALUES
                                                (@IdUsuario, @ISBN, @FechaPrestamo, NULL, 'Prestado')";

                        using (SqlCommand comando = new SqlCommand(consulta, cn, transaccion))
                        {
                            comando.Parameters.AddWithValue("@IdUsuario", prestamo.IdUsuario);
                            comando.Parameters.AddWithValue("@ISBN", prestamo.ISBN);
                            comando.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo.Date);
                            comando.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Edita un préstamo activo (usuario, libro o fecha). Si cambia el libro,
        /// devuelve la existencia al libro anterior y la descuenta del nuevo.
        /// Devuelve false si el nuevo libro no tiene existencias.
        /// </summary>
        public bool Actualizar(Prestamo prestamo, string isbnAnterior)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        if (isbnAnterior != prestamo.ISBN)
                        {
                            if (!DescontarExistencia(cn, transaccion, prestamo.ISBN))
                            {
                                transaccion.Rollback();
                                return false;
                            }
                            SumarExistencia(cn, transaccion, isbnAnterior);
                        }

                        string consulta = @"UPDATE Prestamos
                                            SET IdUsuario = @IdUsuario,
                                                ISBN = @ISBN,
                                                FechaPrestamo = @FechaPrestamo
                                            WHERE IdPrestamo = @IdPrestamo AND Estado = 'Prestado'";

                        using (SqlCommand comando = new SqlCommand(consulta, cn, transaccion))
                        {
                            comando.Parameters.AddWithValue("@IdUsuario", prestamo.IdUsuario);
                            comando.Parameters.AddWithValue("@ISBN", prestamo.ISBN);
                            comando.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo.Date);
                            comando.Parameters.AddWithValue("@IdPrestamo", prestamo.IdPrestamo);
                            comando.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Registra la devolución: cambia el estado a Devuelto, guarda la fecha
        /// y suma una existencia al libro.
        /// </summary>
        public bool RegistrarDevolucion(int idPrestamo, DateTime fechaDevolucion)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        string isbn = ObtenerIsbnActivo(cn, transaccion, idPrestamo);
                        if (isbn == null)
                        {
                            transaccion.Rollback();
                            return false;
                        }

                        string consulta = @"UPDATE Prestamos
                                            SET FechaDevolucion = @FechaDevolucion,
                                                Estado = 'Devuelto'
                                            WHERE IdPrestamo = @IdPrestamo";

                        using (SqlCommand comando = new SqlCommand(consulta, cn, transaccion))
                        {
                            comando.Parameters.AddWithValue("@FechaDevolucion", fechaDevolucion.Date);
                            comando.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                            comando.ExecuteNonQuery();
                        }

                        SumarExistencia(cn, transaccion, isbn);

                        transaccion.Commit();
                        return true;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Elimina el préstamo. Si todavía estaba activo, el ejemplar vuelve
        /// a quedar disponible.
        /// </summary>
        public bool Eliminar(int idPrestamo)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            {
                cn.Open();
                using (SqlTransaction transaccion = cn.BeginTransaction())
                {
                    try
                    {
                        string isbnActivo = ObtenerIsbnActivo(cn, transaccion, idPrestamo);

                        int filas;
                        using (SqlCommand comando = new SqlCommand(
                            "DELETE FROM Prestamos WHERE IdPrestamo = @IdPrestamo", cn, transaccion))
                        {
                            comando.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                            filas = comando.ExecuteNonQuery();
                        }

                        if (isbnActivo != null)
                        {
                            SumarExistencia(cn, transaccion, isbnActivo);
                        }

                        transaccion.Commit();
                        return filas > 0;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        // ---------------- Métodos privados de apoyo ----------------

        private static bool DescontarExistencia(SqlConnection cn, SqlTransaction transaccion, string isbn)
        {
            // La condición Existencias > 0 evita que dos préstamos simultáneos
            // dejen las existencias en negativo.
            string consulta = @"UPDATE Libros
                                SET Existencias = Existencias - 1
                                WHERE ISBN = @ISBN AND Existencias > 0";

            using (SqlCommand comando = new SqlCommand(consulta, cn, transaccion))
            {
                comando.Parameters.AddWithValue("@ISBN", isbn);
                return comando.ExecuteNonQuery() > 0;
            }
        }

        private static void SumarExistencia(SqlConnection cn, SqlTransaction transaccion, string isbn)
        {
            using (SqlCommand comando = new SqlCommand(
                "UPDATE Libros SET Existencias = Existencias + 1 WHERE ISBN = @ISBN", cn, transaccion))
            {
                comando.Parameters.AddWithValue("@ISBN", isbn);
                comando.ExecuteNonQuery();
            }
        }

        /// <summary>Devuelve el ISBN si el préstamo existe y está activo; si no, null.</summary>
        private static string ObtenerIsbnActivo(SqlConnection cn, SqlTransaction transaccion, int idPrestamo)
        {
            using (SqlCommand comando = new SqlCommand(
                "SELECT ISBN FROM Prestamos WHERE IdPrestamo = @IdPrestamo AND Estado = 'Prestado'",
                cn, transaccion))
            {
                comando.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                object resultado = comando.ExecuteScalar();
                return resultado == null || resultado == DBNull.Value ? null : resultado.ToString();
            }
        }

        private static Prestamo ConvertirFila(DataRow fila)
        {
            return new Prestamo
            {
                IdPrestamo = Convert.ToInt32(fila["IdPrestamo"]),
                IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                ISBN = fila["ISBN"].ToString(),
                FechaPrestamo = Convert.ToDateTime(fila["FechaPrestamo"]),
                FechaDevolucion = fila["FechaDevolucion"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(fila["FechaDevolucion"]),
                Estado = fila["Estado"].ToString(),
                NombreUsuario = fila["NombreUsuario"].ToString(),
                TituloLibro = fila["TituloLibro"].ToString()
            };
        }
    }
}
