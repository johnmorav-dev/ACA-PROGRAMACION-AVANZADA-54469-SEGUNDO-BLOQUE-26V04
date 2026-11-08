using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Reglas de negocio del módulo de usuarios.</summary>
    public class UsuarioNegocio : NegocioBase
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

        public List<Usuario> Listar(string textoBusqueda = "")
        {
            return usuarioDAO.Listar(textoBusqueda?.Trim());
        }

        public void Registrar(Usuario usuario)
        {
            ValidarEntidad(usuario);

            if (usuarioDAO.ExisteDocumento(usuario.Documento))
            {
                throw new ReglaNegocioException(
                    $"Ya existe un usuario registrado con el documento {usuario.Documento}.");
            }

            Ejecutar(() => usuarioDAO.Insertar(usuario));
        }

        public void Actualizar(Usuario usuario)
        {
            if (usuario.IdUsuario <= 0 || !usuarioDAO.Existe(usuario.IdUsuario))
            {
                throw new ReglaNegocioException("Seleccione en la tabla el usuario que desea editar.");
            }

            ValidarEntidad(usuario);

            if (usuarioDAO.ExisteDocumento(usuario.Documento, usuario.IdUsuario))
            {
                throw new ReglaNegocioException(
                    $"El documento {usuario.Documento} ya pertenece a otro usuario.");
            }

            Ejecutar(() => usuarioDAO.Actualizar(usuario));
        }

        public void Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                throw new ReglaNegocioException("Seleccione en la tabla el usuario que desea eliminar.");
            }

            int prestamos = usuarioDAO.ContarPrestamos(idUsuario);
            if (prestamos > 0)
            {
                throw new ReglaNegocioException(
                    $"No se puede eliminar el usuario porque tiene {prestamos} préstamo(s) en su historial.");
            }

            Ejecutar(() => usuarioDAO.Eliminar(idUsuario));
        }
    }
}
