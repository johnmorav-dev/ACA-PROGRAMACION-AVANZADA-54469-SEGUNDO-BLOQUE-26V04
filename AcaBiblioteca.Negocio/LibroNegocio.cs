using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Reglas de negocio del módulo de libros.</summary>
    public class LibroNegocio : NegocioBase
    {
        private readonly LibroDAO libroDAO = new LibroDAO();
        private readonly AutorDAO autorDAO = new AutorDAO();
        private readonly EditorialDAO editorialDAO = new EditorialDAO();

        /// <summary>Criterios de búsqueda que ofrece el formulario de libros.</summary>
        public static readonly string[] CriteriosBusqueda = { "Título", "ISBN", "Autor" };

        public List<Libro> Listar()
        {
            return libroDAO.Listar();
        }

        public List<Libro> ListarDisponibles()
        {
            return libroDAO.ListarDisponibles();
        }

        public List<Libro> Buscar(string criterio, string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return libroDAO.Listar();
            }

            string criterioSql = criterio == "ISBN" || criterio == "Autor" ? criterio : "Titulo";
            string textoLimpio = criterio == "ISBN" ? texto.Trim().Replace("-", "") : texto.Trim();

            return libroDAO.Buscar(criterioSql, textoLimpio);
        }

        public Libro ObtenerPorIsbn(string isbn)
        {
            return libroDAO.ObtenerPorIsbn(isbn);
        }

        public void Registrar(Libro libro)
        {
            ValidarLibro(libro);

            if (libroDAO.ExisteIsbn(libro.ISBN))
            {
                throw new ReglaNegocioException($"Ya existe un libro con el ISBN {libro.ISBN}.");
            }

            Ejecutar(() => libroDAO.Insertar(libro));
        }

        public void Actualizar(Libro libro)
        {
            if (!libroDAO.ExisteIsbn(libro.ISBN))
            {
                throw new ReglaNegocioException(
                    "Seleccione en la tabla el libro que desea editar. El ISBN no se puede modificar.");
            }

            ValidarLibro(libro);
            Ejecutar(() => libroDAO.Actualizar(libro));
        }

        public void Eliminar(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ReglaNegocioException("Seleccione en la tabla el libro que desea eliminar.");
            }

            int prestamos = libroDAO.ContarPrestamos(isbn);
            if (prestamos > 0)
            {
                throw new ReglaNegocioException(
                    $"No se puede eliminar el libro porque tiene {prestamos} préstamo(s) registrado(s).");
            }

            Ejecutar(() => libroDAO.Eliminar(isbn));
        }

        /// <summary>Validaciones propias del libro y existencia de autor y editorial.</summary>
        private void ValidarLibro(Libro libro)
        {
            ValidarEntidad(libro);

            if (!autorDAO.Existe(libro.IdAutor))
            {
                throw new ReglaNegocioException("El autor seleccionado no existe en la base de datos.");
            }

            if (!editorialDAO.Existe(libro.IdEditorial))
            {
                throw new ReglaNegocioException("La editorial seleccionada no existe en la base de datos.");
            }
        }
    }
}
