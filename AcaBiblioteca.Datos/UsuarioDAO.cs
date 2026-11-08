using System.Data;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Datos
{
    /// <summary>Operaciones CRUD de la tabla Usuarios.</summary>
    public class UsuarioDAO : DaoBase
    {
        public List<Usuario> Listar(string textoBusqueda = "")
        {
            string consulta = @"SELECT IdUsuario, Nombre, Apellido, Documento, Telefono, Correo
                                FROM Usuarios
                                WHERE @Texto = ''
                                   OR Nombre + ' ' + Apellido LIKE '%' + @Texto + '%'
                                   OR Documento LIKE '%' + @Texto + '%'
                                ORDER BY Nombre, Apellido";

            DataTable tabla = EjecutarConsulta(consulta, Parametro("@Texto", textoBusqueda ?? ""));

            List<Usuario> usuarios = new List<Usuario>();
            foreach (DataRow fila in tabla.Rows)
            {
                usuarios.Add(new Usuario(
                    Convert.ToInt32(fila["IdUsuario"]),
                    fila["Nombre"].ToString(),
                    fila["Apellido"].ToString(),
                    fila["Documento"].ToString(),
                    fila["Telefono"].ToString(),
                    fila["Correo"].ToString()));
            }
            return usuarios;
        }

        public int Insertar(Usuario usuario)
        {
            string consulta = @"INSERT INTO Usuarios (Nombre, Apellido, Documento, Telefono, Correo)
                                VALUES (@Nombre, @Apellido, @Documento, @Telefono, @Correo)";

            return EjecutarComando(consulta,
                Parametro("@Nombre", usuario.Nombre),
                Parametro("@Apellido", usuario.Apellido),
                Parametro("@Documento", usuario.Documento),
                Parametro("@Telefono", TextoONulo(usuario.Telefono)),
                Parametro("@Correo", TextoONulo(usuario.Correo)));
        }

        public int Actualizar(Usuario usuario)
        {
            string consulta = @"UPDATE Usuarios
                                SET Nombre = @Nombre,
                                    Apellido = @Apellido,
                                    Documento = @Documento,
                                    Telefono = @Telefono,
                                    Correo = @Correo
                                WHERE IdUsuario = @IdUsuario";

            return EjecutarComando(consulta,
                Parametro("@Nombre", usuario.Nombre),
                Parametro("@Apellido", usuario.Apellido),
                Parametro("@Documento", usuario.Documento),
                Parametro("@Telefono", TextoONulo(usuario.Telefono)),
                Parametro("@Correo", TextoONulo(usuario.Correo)),
                Parametro("@IdUsuario", usuario.IdUsuario));
        }

        public int Eliminar(int idUsuario)
        {
            return EjecutarComando("DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario",
                Parametro("@IdUsuario", idUsuario));
        }

        public bool Existe(int idUsuario)
        {
            return EjecutarEscalar("SELECT COUNT(*) FROM Usuarios WHERE IdUsuario = @IdUsuario",
                Parametro("@IdUsuario", idUsuario)) > 0;
        }

        /// <summary>Verifica la restricción UNIQUE del documento antes de guardar.</summary>
        public bool ExisteDocumento(string documento, int idExcluir = 0)
        {
            return EjecutarEscalar(
                "SELECT COUNT(*) FROM Usuarios WHERE Documento = @Documento AND IdUsuario <> @IdExcluir",
                Parametro("@Documento", documento),
                Parametro("@IdExcluir", idExcluir)) > 0;
        }

        public int ContarPrestamos(int idUsuario)
        {
            return EjecutarEscalar("SELECT COUNT(*) FROM Prestamos WHERE IdUsuario = @IdUsuario",
                Parametro("@IdUsuario", idUsuario));
        }
    }
}
