namespace AcaBiblioteca.Entidades
{
    /// <summary>Representa una editorial (tabla Editoriales).</summary>
    public class Editorial : EntidadBase
    {
        private string nombre = string.Empty;

        public int IdEditorial { get; set; }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = Limpiar(value); }
        }

        public Editorial()
        {
        }

        public Editorial(int idEditorial, string nombre)
        {
            IdEditorial = idEditorial;
            Nombre = nombre;
        }

        public override List<string> Validar()
        {
            List<string> errores = new List<string>();
            ValidarTexto(errores, Nombre, "Nombre de la editorial", 150);
            return errores;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
