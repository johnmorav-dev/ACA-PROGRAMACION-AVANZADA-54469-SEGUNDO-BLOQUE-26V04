namespace AcaBiblioteca.Entidades
{
    /// <summary>
    /// Clase abstracta que agrupa los datos comunes de una persona.
    /// Justificación de la herencia: Autor y Usuario comparten Nombre y Apellido,
    /// su validación y la forma de construir el nombre completo.
    /// </summary>
    public abstract class Persona : EntidadBase
    {
        // Campos privados: solo se modifican a través de las propiedades (encapsulamiento)
        private string nombre = string.Empty;
        private string apellido = string.Empty;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = Limpiar(value); }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = Limpiar(value); }
        }

        /// <summary>Nombre y apellido en una sola cadena (propiedad calculada).</summary>
        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}".Trim(); }
        }

        protected Persona()
        {
        }

        protected Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        /// <summary>
        /// Validación común de Nombre y Apellido. Es virtual para que
        /// cada clase hija pueda ampliarla con sus propios campos.
        /// </summary>
        public override List<string> Validar()
        {
            List<string> errores = new List<string>();
            ValidarTexto(errores, Nombre, "Nombre", 100);
            ValidarTexto(errores, Apellido, "Apellido", 100);
            return errores;
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
