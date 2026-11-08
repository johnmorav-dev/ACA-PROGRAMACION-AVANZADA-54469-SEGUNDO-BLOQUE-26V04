using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Reglas de negocio de préstamos y devoluciones.</summary>
    public class PrestamoNegocio : NegocioBase
    {
        private readonly PrestamoDAO prestamoDAO = new PrestamoDAO();
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();
        private readonly LibroDAO libroDAO = new LibroDAO();

        /// <summary>Opciones del filtro por estado en el formulario.</summary>
        public static readonly string[] FiltrosEstado =
            { "Todos", EstadoPrestamo.Prestado, EstadoPrestamo.Devuelto };

        public List<Prestamo> Listar(string filtroEstado = "Todos", string texto = "")
        {
            string estado = filtroEstado == "Todos" ? "" : filtroEstado;
            return prestamoDAO.Listar(estado, texto?.Trim());
        }

        /// <summary>RN: usuario y libro existentes, libro con existencias y sin duplicar préstamos activos.</summary>
        public void Registrar(Prestamo prestamo)
        {
            prestamo.Estado = EstadoPrestamo.Prestado;
            prestamo.FechaDevolucion = null;
            ValidarEntidad(prestamo);
            ValidarUsuarioYLibro(prestamo);

            if (prestamoDAO.ExistePrestamoActivo(prestamo.IdUsuario, prestamo.ISBN))
            {
                throw new ReglaNegocioException(
                    "El usuario ya tiene un préstamo activo de este libro. Registre primero la devolución.");
            }

            bool registrado = Ejecutar(() => prestamoDAO.Registrar(prestamo));
            if (!registrado)
            {
                throw new ReglaNegocioException("No hay existencias disponibles de este libro.");
            }
        }

        /// <summary>Solo se pueden editar préstamos activos (usuario, libro y fecha del préstamo).</summary>
        public void Actualizar(Prestamo prestamo)
        {
            Prestamo actual = ObtenerExistente(prestamo.IdPrestamo, "editar");

            if (!actual.EstaActivo)
            {
                throw new ReglaNegocioException(
                    "Solo se pueden editar préstamos en estado Prestado. Este préstamo ya fue devuelto.");
            }

            prestamo.Estado = EstadoPrestamo.Prestado;
            prestamo.FechaDevolucion = null;
            ValidarEntidad(prestamo);
            ValidarUsuarioYLibro(prestamo);

            if (prestamoDAO.ExistePrestamoActivo(prestamo.IdUsuario, prestamo.ISBN, prestamo.IdPrestamo))
            {
                throw new ReglaNegocioException("El usuario ya tiene otro préstamo activo de este libro.");
            }

            bool actualizado = Ejecutar(() => prestamoDAO.Actualizar(prestamo, actual.ISBN));
            if (!actualizado)
            {
                throw new ReglaNegocioException("El nuevo libro seleccionado no tiene existencias disponibles.");
            }
        }

        /// <summary>Cambia el estado a Devuelto, guarda la fecha y repone la existencia.</summary>
        public void RegistrarDevolucion(int idPrestamo, DateTime fechaDevolucion)
        {
            Prestamo actual = ObtenerExistente(idPrestamo, "registrar la devolución de");

            if (!actual.EstaActivo)
            {
                throw new ReglaNegocioException("Este préstamo ya fue devuelto.");
            }

            actual.FechaDevolucion = fechaDevolucion.Date;
            actual.Estado = EstadoPrestamo.Devuelto;
            ValidarEntidad(actual);

            bool devuelto = Ejecutar(() => prestamoDAO.RegistrarDevolucion(idPrestamo, fechaDevolucion));
            if (!devuelto)
            {
                throw new ReglaNegocioException("No fue posible registrar la devolución.");
            }
        }

        /// <summary>Elimina el préstamo; si estaba activo, el libro recupera la existencia.</summary>
        public void Eliminar(int idPrestamo)
        {
            ObtenerExistente(idPrestamo, "eliminar");
            Ejecutar(() => prestamoDAO.Eliminar(idPrestamo));
        }

        private Prestamo ObtenerExistente(int idPrestamo, string accion)
        {
            if (idPrestamo <= 0)
            {
                throw new ReglaNegocioException($"Seleccione en la tabla el préstamo que desea {accion}.");
            }

            Prestamo prestamo = prestamoDAO.ObtenerPorId(idPrestamo);
            if (prestamo == null)
            {
                throw new ReglaNegocioException("El préstamo seleccionado ya no existe.");
            }
            return prestamo;
        }

        private void ValidarUsuarioYLibro(Prestamo prestamo)
        {
            if (!usuarioDAO.Existe(prestamo.IdUsuario))
            {
                throw new ReglaNegocioException("El usuario seleccionado no existe en la base de datos.");
            }

            if (!libroDAO.ExisteIsbn(prestamo.ISBN))
            {
                throw new ReglaNegocioException("El libro seleccionado no existe en la base de datos.");
            }
        }
    }
}
