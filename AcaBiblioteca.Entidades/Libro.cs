using System.Text.RegularExpressions;

namespace AcaBiblioteca.Entidades
{
    /// <summary>Representa un libro de la biblioteca (tabla Libros).</summary>
    public class Libro : EntidadBase
    {
        private string isbn = string.Empty;
        private string titulo = string.Empty;
        private string categoria = string.Empty;

        /// <summary>Código único del libro (clave primaria).</summary>
        public string ISBN
        {
            get { return isbn; }
            set { isbn = Limpiar(value).Replace("-", "").Replace(" ", ""); }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = Limpiar(value); }
        }

        public int IdAutor { get; set; }
        public int IdEditorial { get; set; }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = Limpiar(value); }
        }

        /// <summary>Año de publicación (opcional).</summary>
        public int? Anio { get; set; }

        /// <summary>Ejemplares disponibles para préstamo.</summary>
        public int Existencias { get; set; }

        // Datos de solo lectura que llegan de los JOIN con Autores y Editoriales
        public string NombreAutor { get; set; } = string.Empty;
        public string NombreEditorial { get; set; } = string.Empty;

        /// <summary>Indica si hay al menos un ejemplar para prestar.</summary>
        public bool EstaDisponible
        {
            get { return Existencias > 0; }
        }

        public Libro()
        {
        }

        public Libro(string isbn, string titulo, int idAutor, int idEditorial,
            string categoria, int? anio, int existencias)
        {
            ISBN = isbn;
            Titulo = titulo;
            IdAutor = idAutor;
            IdEditorial = idEditorial;
            Categoria = categoria;
            Anio = anio;
            Existencias = existencias;
        }

        public override List<string> Validar()
        {
            List<string> errores = new List<string>();

            ValidarTexto(errores, ISBN, "ISBN", 20);
            if (ISBN.Length > 0 && !Regex.IsMatch(ISBN, @"^(\d{9}[\dXx]|\d{13})$"))
            {
                errores.Add("El ISBN debe tener 10 o 13 dígitos (se permiten guiones).");
            }

            ValidarTexto(errores, Titulo, "Título", 200);

            if (IdAutor <= 0)
            {
                errores.Add("Debe seleccionar un autor.");
            }

            if (IdEditorial <= 0)
            {
                errores.Add("Debe seleccionar una editorial.");
            }

            ValidarTexto(errores, Categoria, "Categoría", 100, obligatorio: false);

            if (Anio.HasValue && (Anio < 1000 || Anio > DateTime.Today.Year))
            {
                errores.Add($"El año de publicación debe estar entre 1000 y {DateTime.Today.Year}.");
            }

            if (Existencias < 0)
            {
                errores.Add("Las existencias no pueden ser negativas.");
            }

            return errores;
        }

        public override string ToString()
        {
            return $"{Titulo} ({Existencias} disp.)";
        }
    }
}
