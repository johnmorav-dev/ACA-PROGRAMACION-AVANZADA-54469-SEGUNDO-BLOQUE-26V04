using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Reglas de negocio del módulo de autores.</summary>
    public class AutorNegocio : NegocioBase
    {
        private readonly AutorDAO autorDAO = new AutorDAO();

        public List<Autor> Listar(string textoBusqueda = "")
        {
            return autorDAO.Listar(textoBusqueda?.Trim());
        }

        public void Registrar(Autor autor)
        {
            ValidarEntidad(autor);

            if (autorDAO.ExisteDuplicado(autor.Nombre, autor.Apellido))
            {
                throw new ReglaNegocioException($"El autor {autor.NombreCompleto} ya está registrado.");
            }

            Ejecutar(() => autorDAO.Insertar(autor));
        }

        public void Actualizar(Autor autor)
        {
            if (autor.IdAutor <= 0 || !autorDAO.Existe(autor.IdAutor))
            {
                throw new ReglaNegocioException("Seleccione en la tabla el autor que desea editar.");
            }

            ValidarEntidad(autor);

            if (autorDAO.ExisteDuplicado(autor.Nombre, autor.Apellido, autor.IdAutor))
            {
                throw new ReglaNegocioException($"Ya existe otro autor llamado {autor.NombreCompleto}.");
            }

            Ejecutar(() => autorDAO.Actualizar(autor));
        }

        public void Eliminar(int idAutor)
        {
            if (idAutor <= 0)
            {
                throw new ReglaNegocioException("Seleccione en la tabla el autor que desea eliminar.");
            }

            int libros = autorDAO.ContarLibros(idAutor);
            if (libros > 0)
            {
                throw new ReglaNegocioException(
                    $"No se puede eliminar el autor porque tiene {libros} libro(s) registrado(s). " +
                    "Elimine o reasigne primero esos libros.");
            }

            Ejecutar(() => autorDAO.Eliminar(idAutor));
        }
    }
}
