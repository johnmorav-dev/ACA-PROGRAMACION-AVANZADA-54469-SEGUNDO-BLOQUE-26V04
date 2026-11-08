using System.Data;
using AcaBiblioteca.Datos;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Coordina la generación de reportes y los indicadores de Inicio.</summary>
    public class ReporteNegocio : NegocioBase
    {
        private readonly ReporteDAO reporteDAO = new ReporteDAO();

        /// <summary>
        /// Colección (diccionario) que relaciona el nombre de cada reporte con el
        /// método que lo genera. Para agregar un reporte basta con añadir una línea.
        /// </summary>
        private readonly Dictionary<string, Func<DataTable>> reportes;

        public ReporteNegocio()
        {
            reportes = new Dictionary<string, Func<DataTable>>
            {
                { "Préstamos activos", reporteDAO.PrestamosActivos },
                { "Préstamos devueltos", reporteDAO.PrestamosDevueltos },
                { "Historial de préstamos", reporteDAO.HistorialPrestamos },
                { "Inventario de libros", reporteDAO.InventarioLibros },
                { "Libros disponibles", reporteDAO.LibrosDisponibles },
                { "Libros más prestados", reporteDAO.LibrosMasPrestados },
                { "Usuarios registrados", reporteDAO.UsuariosRegistrados },
                { "Usuarios con préstamos activos", reporteDAO.UsuariosConPrestamosActivos },
                { "Autores y cantidad de libros", reporteDAO.AutoresConLibros },
                { "Editoriales y cantidad de libros", reporteDAO.EditorialesConLibros }
            };
        }

        public List<string> TiposReporte()
        {
            return reportes.Keys.ToList();
        }

        public DataTable Generar(string tipoReporte)
        {
            if (string.IsNullOrWhiteSpace(tipoReporte) || !reportes.ContainsKey(tipoReporte))
            {
                throw new ReglaNegocioException("Seleccione un tipo de reporte.");
            }

            return reportes[tipoReporte]();
        }

        public ResumenBiblioteca ObtenerResumen()
        {
            return reporteDAO.ObtenerResumen();
        }

        /// <summary>Verifica la conexión con SQL Server (barra de estado del menú principal).</summary>
        public bool ProbarConexion(out string mensaje)
        {
            return new Conexion().ProbarConexion(out mensaje);
        }
    }
}
