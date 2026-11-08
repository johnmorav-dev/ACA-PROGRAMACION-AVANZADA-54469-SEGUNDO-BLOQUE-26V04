using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    /// <summary>Pantalla de inicio con los indicadores generales de la biblioteca.</summary>
    public partial class FrmInicio : Form
    {
        private readonly ReporteNegocio reporteNegocio = new ReporteNegocio();

        public FrmInicio()
        {
            InitializeComponent();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            CargarResumen();
        }

        private void CargarResumen()
        {
            try
            {
                ResumenBiblioteca resumen = reporteNegocio.ObtenerResumen();

                lblLibrosValor.Text = resumen.TotalLibros.ToString();
                lblEjemplaresValor.Text = resumen.EjemplaresDisponibles.ToString();
                lblUsuariosValor.Text = resumen.TotalUsuarios.ToString();
                lblAutoresValor.Text = resumen.TotalAutores.ToString();
                lblEditorialesValor.Text = resumen.TotalEditoriales.ToString();
                lblPrestamosValor.Text = resumen.PrestamosActivos.ToString();
                lblDevueltos.Text = $"Préstamos devueltos: {resumen.PrestamosDevueltos}";
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar el resumen de la biblioteca", ex);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarResumen();
        }
    }
}
