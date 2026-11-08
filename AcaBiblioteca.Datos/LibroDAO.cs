using System.Data;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Datos
{
    /// <summary>Operaciones CRUD y búsquedas de la tabla Libros.</summary>
    public class LibroDAO : DaoBase
    {
        // Consulta base: une Libros con Autores y Editoriales para mostrar los nombres
        private const string ConsultaBase = @"
            SELECT l.ISBN, l.Titulo, l.IdAutor, l.IdEditorial, l.Categoria, l.Anio, l.Existencias,
                   a.Nombre + ' ' + a.Apellido AS NombreAutor,
                   e.Nombre AS NombreEditorial
            FROM Libros l
            INNER JOIN Autores a ON l.IdAutor = a.IdAutor
            INNER JOIN Editoriales e ON l.IdEditorial = e.IdEditorial";

        public List<Libro> Listar()
        {
            return ConvertirLista(EjecutarConsulta(ConsultaBase + " ORDER BY l.Titulo"));
        }

        /// <summary>Libros con al menos un ejemplar disponible (para registrar préstamos).</summary>
        public List<Libro> ListarDisponibles()
        {
            return ConvertirLista(EjecutarConsulta(
                ConsultaBase + " WHERE l.Existencias > 0 ORDER BY l.Titulo"));
        }

        /// <summary>
        /// Busca libros por ISBN, título o autor. El texto siempre viaja como
        /// parámetro; el criterio solo elige entre consultas fijas (sin concatenar SQL).
        /// </summary>
        public List<Libro> Buscar(string criterio, string texto)
        {
            string filtro;
            switch (criterio)
            {
                case "ISBN":
                    filtro = " WHERE l.ISBN LIKE '%' + @Texto + '%'";
                    break;
                case "Autor":
                    filtro = " WHERE a.Nombre + ' ' + a.Apellido LIKE '%' + @Texto + '%'";
                    break;
                default:
                    filtro = " WHERE l.Titulo LIKE '%' + @Texto + '%'";
                    break;
            }

            return ConvertirLista(EjecutarConsulta(
                ConsultaBase + filtro + " ORDER BY l.Titulo",
                Parametro("@Texto", texto ?? "")));
        }

        public Libro ObtenerPorIsbn(string isbn)
        {
            List<Libro> libros = ConvertirLista(EjecutarConsulta(
                ConsultaBase + " WHERE l.ISBN = @ISBN",
                Parametro("@ISBN", isbn)));

            return libros.Count > 0 ? libros[0] : null;
        }

        public int Insertar(Libro libro)
        {
            string consulta = @"INSERT INTO Libros
                                    (ISBN, Titulo, IdAutor, IdEditorial, Categoria, Anio, Existencias)
                                VALUES
                                    (@ISBN, @Titulo, @IdAutor, @IdEditorial, @Categoria, @Anio, @Existencias)";

            return EjecutarComando(consulta, ParametrosLibro(libro));
        }

        public int Actualizar(Libro libro)
        {
            string consulta = @"UPDATE Libros
                                SET Titulo = @Titulo,
                                    IdAutor = @IdAutor,
                                    IdEditorial = @IdEditorial,
                                    Categoria = @Categoria,
                                    Anio = @Anio,
                                    Existencias = @Existencias
                                WHERE ISBN = @ISBN";

            return EjecutarComando(consulta, ParametrosLibro(libro));
        }

        public int Eliminar(string isbn)
        {
            return EjecutarComando("DELETE FROM Libros WHERE ISBN = @ISBN",
                Parametro("@ISBN", isbn));
        }

        public bool ExisteIsbn(string isbn)
        {
            return EjecutarEscalar("SELECT COUNT(*) FROM Libros WHERE ISBN = @ISBN",
                Parametro("@ISBN", isbn)) > 0;
        }

        public int ContarPrestamos(string isbn)
        {
            return EjecutarEscalar("SELECT COUNT(*) FROM Prestamos WHERE ISBN = @ISBN",
                Parametro("@ISBN", isbn));
        }

        public int ContarPrestamosActivos(string isbn)
        {
            return EjecutarEscalar(
                "SELECT COUNT(*) FROM Prestamos WHERE ISBN = @ISBN AND Estado = 'Prestado'",
                Parametro("@ISBN", isbn));
        }

        private static Microsoft.Data.SqlClient.SqlParameter[] ParametrosLibro(Libro libro)
        {
            return new[]
            {
                Parametro("@ISBN", libro.ISBN),
                Parametro("@Titulo", libro.Titulo),
                Parametro("@IdAutor", libro.IdAutor),
                Parametro("@IdEditorial", libro.IdEditorial),
                Parametro("@Categoria", TextoONulo(libro.Categoria)),
                Parametro("@Anio", libro.Anio.HasValue ? (object)libro.Anio.Value : DBNull.Value),
                Parametro("@Existencias", libro.Existencias)
            };
        }

        private static List<Libro> ConvertirLista(DataTable tabla)
        {
            List<Libro> libros = new List<Libro>();

            foreach (DataRow fila in tabla.Rows)
            {
                Libro libro = new Libro(
                    fila["ISBN"].ToString(),
                    fila["Titulo"].ToString(),
                    Convert.ToInt32(fila["IdAutor"]),
                    Convert.ToInt32(fila["IdEditorial"]),
                    fila["Categoria"].ToString(),
                    fila["Anio"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["Anio"]),
                    Convert.ToInt32(fila["Existencias"]));

                libro.NombreAutor = fila["NombreAutor"].ToString();
                libro.NombreEditorial = fila["NombreEditorial"].ToString();
                libros.Add(libro);
            }

            return libros;
        }
    }
}
