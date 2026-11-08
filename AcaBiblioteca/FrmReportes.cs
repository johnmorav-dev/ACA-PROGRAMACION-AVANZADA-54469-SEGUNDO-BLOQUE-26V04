using System.Data;
using System.Text;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    /// <summary>Capa de presentación del módulo de reportes.</summary>
    public partial class FrmReportes : Form
    {
        private readonly ReporteNegocio reporteNegocio = new ReporteNegocio();

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            EstiloTabla.Aplicar(dgvReportes);
            CargarTiposReporte();
        }

        private void CargarTiposReporte()
        {
            cmbTipoReporte.DataSource = reporteNegocio.TiposReporte();
            cmbTipoReporte.SelectedIndex = -1;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tabla = reporteNegocio.Generar(cmbTipoReporte.Text);
                dgvReportes.DataSource = tabla;
                lblTotal.Text = $"{cmbTipoReporte.Text}: {tabla.Rows.Count} registro(s) - generado el {DateTime.Now:dd/MM/yyyy HH:mm}";
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("generar el reporte", ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbTipoReporte.SelectedIndex = -1;
            dgvReportes.DataSource = null;
            lblTotal.Text = "Seleccione un reporte y presione Generar Reporte.";
        }

        /// <summary>Guarda el reporte visible en un archivo CSV que se abre con Excel.</summary>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (!(dgvReportes.DataSource is DataTable tabla) || tabla.Rows.Count == 0)
            {
                Mensajes.Advertencia("Genere primero un reporte con datos para exportarlo.");
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Archivo CSV (*.csv)|*.csv";
                dialogo.FileName = $"Reporte - {cmbTipoReporte.Text} - {DateTime.Now:yyyyMMdd}.csv";

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    StringBuilder csv = new StringBuilder();
                    csv.AppendLine(string.Join(";", tabla.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));

                    foreach (DataRow fila in tabla.Rows)
                    {
                        csv.AppendLine(string.Join(";", fila.ItemArray.Select(valor =>
                            valor is DateTime fecha ? fecha.ToString("dd/MM/yyyy")
                                                    : valor?.ToString().Replace(";", ","))));
                    }

                    File.WriteAllText(dialogo.FileName, csv.ToString(), new UTF8Encoding(true));
                    Mensajes.Informacion("Reporte exportado correctamente.");
                }
                catch (Exception ex)
                {
                    Mensajes.Error("exportar el reporte", ex);
                }
            }
        }
    }
}
