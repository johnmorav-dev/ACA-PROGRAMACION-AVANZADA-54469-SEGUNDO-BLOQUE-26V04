using System.Globalization;
using AcaBiblioteca.Negocio;

namespace AcaBiblioteca
{
    /// <summary>
    /// Formulario principal: menú lateral de navegación y panel donde se
    /// abren los módulos del sistema.
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        private Form formularioActivo;

        public FrmPrincipal()
        {
            InitializeComponent();

            CultureInfo cultura = new CultureInfo("es-CO");
            string fecha = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy", cultura);
            lblFecha.Text = char.ToUpper(fecha[0]) + fecha.Substring(1);

            VerificarConexion();
            AbrirFormulario(new FrmInicio(), "Inicio");
        }

        /// <summary>Muestra en la barra inferior si hay conexión con SQL Server.</summary>
        private void VerificarConexion()
        {
            bool conectado = new ReporteNegocio().ProbarConexion(out string mensaje);
            lblEstadoConexion.Text = (conectado ? "● " : "✖ ") + mensaje;
            lblEstadoConexion.ForeColor = conectado ? Color.DarkGreen : Color.DarkRed;
        }

        /// <summary>Abre un formulario dentro del panel de contenido.</summary>
        private void AbrirFormulario(Form formulario, string nombreModulo)
        {
            formularioActivo?.Close();
            pnlContenido.Controls.Clear();

            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(formulario);
            formulario.Show();

            lblModulo.Text = nombreModulo;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmInicio(), "Inicio");
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmLibros(), "Libros");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUsuarios(), "Usuarios");
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAutores(), "Autores");
        }

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEditoriales(), "Editoriales");
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmPrestamos(), "Préstamos y devoluciones");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmReportes(), "Reportes");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Biblioteca",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
