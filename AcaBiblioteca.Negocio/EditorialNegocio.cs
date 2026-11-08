using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Reglas de negocio del módulo de editoriales.</summary>
    public class EditorialNegocio : NegocioBase
    {
        private readonly EditorialDAO editorialDAO = new EditorialDAO();

        public List<Editorial> Listar(string textoBusqueda = "")
        {
            return editorialDAO.Listar(textoBusqueda?.Trim());
        }

        public void Registrar(Editorial editorial)
        {
            ValidarEntidad(editorial);

            if (editorialDAO.ExisteNombre(editorial.Nombre))
            {
                throw new ReglaNegocioException($"La editorial {editorial.Nombre} ya está registrada.");
            }

            Ejecutar(() => editorialDAO.Insertar(editorial));
        }

        public void Actualizar(Editorial editorial)
        {
            if (editorial.IdEditorial <= 0 || !editorialDAO.Existe(editorial.IdEditorial))
            {
                throw new ReglaNegocioException("Seleccione en la tabla la editorial que desea editar.");
            }

            ValidarEntidad(editorial);

            if (editorialDAO.ExisteNombre(editorial.Nombre, editorial.IdEditorial))
            {
                throw new ReglaNegocioException($"Ya existe otra editorial llamada {editorial.Nombre}.");
            }

            Ejecutar(() => editorialDAO.Actualizar(editorial));
        }

        public void Eliminar(int idEditorial)
        {
            if (idEditorial <= 0)
            {
                throw new ReglaNegocioException("Seleccione en la tabla la editorial que desea eliminar.");
            }

            int libros = editorialDAO.ContarLibros(idEditorial);
            if (libros > 0)
            {
                throw new ReglaNegocioException(
                    $"No se puede eliminar la editorial porque tiene {libros} libro(s) registrado(s).");
            }

            Ejecutar(() => editorialDAO.Eliminar(idEditorial));
        }
    }
}
