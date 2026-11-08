using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    /// <summary>
    /// Capa de presentación del módulo de autores. Solo captura datos y muestra
    /// resultados; las reglas y el acceso a la base de datos están en AutorNegocio.
    /// </summary>
    public partial class FrmAutores : Form
    {
        private readonly AutorNegocio autorNegocio = new AutorNegocio();

        // Autor seleccionado en la tabla (0 = ninguno)
        private int idAutorSeleccionado = 0;

        public FrmAutores()
        {
            InitializeComponent();
        }

        private void FrmAutores_Load(object sender, EventArgs e)
        {
            EstiloTabla.Aplicar(dgvAutores);
            txtNombre.MaxLength = 100;
            txtApellido.MaxLength = 100;
            CargarAutores();
        }

        private void CargarAutores()
        {
            try
            {
                dgvAutores.DataSource = autorNegocio.Listar();
                EstiloTabla.OcultarColumnas(dgvAutores, "NombreCompleto");
                EstiloTabla.Ordenar(dgvAutores, "IdAutor", "Nombre", "Apellido");
                EstiloTabla.Encabezado(dgvAutores, "IdAutor", "Id");
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar los autores", ex);
            }
        }

        /// <summary>Crea un objeto Autor con los datos del formulario.</summary>
        private Autor LeerFormulario()
        {
            return new Autor(idAutorSeleccionado, txtNombre.Text, txtApellido.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idAutorSeleccionado != 0)
                {
                    Mensajes.Advertencia("Está editando un autor existente. Use el botón Editar o presione Nuevo para registrar uno nuevo.");
                    return;
                }

                autorNegocio.Registrar(LeerFormulario());
                Mensajes.Informacion("Autor guardado correctamente.");
                CargarAutores();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("guardar el autor", ex);
            }
        }

        private void dgvAutores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvAutores.Rows[e.RowIndex].DataBoundItem is Autor autor)
            {
                idAutorSeleccionado = autor.IdAutor;
                txtNombre.Text = autor.Nombre;
                txtApellido.Text = autor.Apellido;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                autorNegocio.Actualizar(LeerFormulario());
                Mensajes.Informacion("Autor actualizado correctamente.");
                CargarAutores();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("actualizar el autor", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idAutorSeleccionado == 0)
                {
                    Mensajes.Advertencia("Haga doble clic sobre el autor que desea eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar($"¿Está seguro de eliminar al autor {txtNombre.Text} {txtApellido.Text}?"))
                    return;

                autorNegocio.Eliminar(idAutorSeleccionado);
                Mensajes.Informacion("Autor eliminado correctamente.");
                CargarAutores();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("eliminar el autor", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idAutorSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            dgvAutores.ClearSelection();
            txtNombre.Focus();
        }
    }
}
