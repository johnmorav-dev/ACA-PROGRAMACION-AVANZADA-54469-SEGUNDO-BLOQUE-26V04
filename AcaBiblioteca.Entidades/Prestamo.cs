namespace AcaBiblioteca.Entidades
{
    /// <summary>Estados posibles de un préstamo (coinciden con el CHECK de la BD).</summary>
    public static class EstadoPrestamo
    {
        public const string Prestado = "Prestado";
        public const string Devuelto = "Devuelto";
    }

    /// <summary>Representa el préstamo de un libro a un usuario (tabla Prestamos).</summary>
    public class Prestamo : EntidadBase
    {
        public int IdPrestamo { get; set; }
        public int IdUsuario { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public DateTime FechaPrestamo { get; set; } = DateTime.Today;
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; } = EstadoPrestamo.Prestado;

        // Datos de solo lectura que llegan de los JOIN
        public string NombreUsuario { get; set; } = string.Empty;
        public string TituloLibro { get; set; } = string.Empty;

        /// <summary>Un préstamo está activo mientras el libro no se haya devuelto.</summary>
        public bool EstaActivo
        {
            get { return Estado == EstadoPrestamo.Prestado; }
        }

        public Prestamo()
        {
        }

        public Prestamo(int idUsuario, string isbn, DateTime fechaPrestamo)
        {
            IdUsuario = idUsuario;
            ISBN = isbn;
            FechaPrestamo = fechaPrestamo.Date;
            Estado = EstadoPrestamo.Prestado;
        }

        public override List<string> Validar()
        {
            List<string> errores = new List<string>();

            if (IdUsuario <= 0)
            {
                errores.Add("Debe seleccionar un usuario.");
            }

            if (string.IsNullOrWhiteSpace(ISBN))
            {
                errores.Add("Debe seleccionar un libro.");
            }

            if (FechaPrestamo.Date > DateTime.Today)
            {
                errores.Add("La fecha del préstamo no puede ser posterior a la fecha actual.");
            }

            if (FechaDevolucion.HasValue)
            {
                if (FechaDevolucion.Value.Date < FechaPrestamo.Date)
                {
                    errores.Add("La fecha de devolución no puede ser anterior a la fecha del préstamo.");
                }

                if (FechaDevolucion.Value.Date > DateTime.Today)
                {
                    errores.Add("La fecha de devolución no puede ser posterior a la fecha actual.");
                }
            }

            if (Estado != EstadoPrestamo.Prestado && Estado != EstadoPrestamo.Devuelto)
            {
                errores.Add("El estado del préstamo solo puede ser Prestado o Devuelto.");
            }

            return errores;
        }

        public override string ToString()
        {
            return $"Préstamo {IdPrestamo}: {TituloLibro} - {NombreUsuario} ({Estado})";
        }
    }
}
