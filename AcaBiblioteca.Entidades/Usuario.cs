using System.Text.RegularExpressions;

namespace AcaBiblioteca.Entidades
{
    /// <summary>Representa a un usuario de la biblioteca (tabla Usuarios).</summary>
    public class Usuario : Persona
    {
        private string documento = string.Empty;
        private string telefono = string.Empty;
        private string correo = string.Empty;

        public int IdUsuario { get; set; }

        public string Documento
        {
            get { return documento; }
            set { documento = Limpiar(value); }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = Limpiar(value); }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = Limpiar(value).ToLower(); }
        }

        public Usuario()
        {
        }

        public Usuario(int idUsuario, string nombre, string apellido,
            string documento, string telefono, string correo)
            : base(nombre, apellido)
        {
            IdUsuario = idUsuario;
            Documento = documento;
            Telefono = telefono;
            Correo = correo;
        }

        /// <summary>
        /// Sobrescribe la validación de Persona (polimorfismo): primero valida
        /// Nombre y Apellido con base.Validar() y luego agrega sus propios campos.
        /// </summary>
        public override List<string> Validar()
        {
            List<string> errores = base.Validar();

            ValidarTexto(errores, Documento, "Documento", 30);
            if (Documento.Length > 0 && !Regex.IsMatch(Documento, @"^[0-9]{5,15}$"))
            {
                errores.Add("El documento debe contener solo números (entre 5 y 15 dígitos).");
            }

            ValidarTexto(errores, Telefono, "Teléfono", 30, obligatorio: false);
            if (Telefono.Length > 0 && !Regex.IsMatch(Telefono, @"^[0-9 +\-]{7,20}$"))
            {
                errores.Add("El teléfono solo puede contener números, espacios, + y - (mínimo 7 caracteres).");
            }

            ValidarTexto(errores, Correo, "Correo", 150, obligatorio: false);
            if (Correo.Length > 0 && !Regex.IsMatch(Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errores.Add("El correo electrónico no tiene un formato válido (ejemplo: nombre@dominio.com).");
            }

            return errores;
        }

        /// <summary>Texto que se muestra en los ComboBox de préstamos.</summary>
        public override string ToString()
        {
            return $"{NombreCompleto} - {Documento}";
        }
    }
}
