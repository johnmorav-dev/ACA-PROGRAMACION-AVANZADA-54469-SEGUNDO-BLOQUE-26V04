namespace AcaBiblioteca.Entidades
{
    /// <summary>Representa a un autor de libros (tabla Autores).</summary>
    public class Autor : Persona
    {
        public int IdAutor { get; set; }

        public Autor()
        {
        }

        public Autor(int idAutor, string nombre, string apellido)
            : base(nombre, apellido)
        {
            IdAutor = idAutor;
        }

        // Autor usa la validación heredada de Persona (Nombre y Apellido).
    }
}
