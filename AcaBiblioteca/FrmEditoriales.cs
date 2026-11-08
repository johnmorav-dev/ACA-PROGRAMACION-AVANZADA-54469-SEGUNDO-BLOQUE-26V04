using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    /// <summary>Capa de presentación del módulo de editoriales.</summary>
    public partial class FrmEditoriales : Form
    {
        private readonly EditorialNegocio editorialNegocio = new EditorialNegocio();
        private int idEditorialSeleccionada = 0;

        public FrmEditoriales()
        {
            InitializeComponent();
        }

        private void FrmEditoriales_Load(object sender, EventArgs e)
        {
            EstiloTabla.Aplicar(dgvEditoriales);
            txtNombre.MaxLength = 150;
            CargarEditoriales();
        }

        private void CargarEditoriales()
        {
            try
            {
                dgvEditoriales.DataSource = editorialNegocio.Listar();
                EstiloTabla.Encabezado(dgvEditoriales, "IdEditorial", "Id");
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar las editoriales", ex);
            }
        }

        private Editorial LeerFormulario()
        {
            return new Editorial(idEditorialSeleccionada, txtNombre.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idEditorialSeleccionada != 0)
                {
                    Mensajes.Advertencia("Está editando una editorial existente. Use el botón Editar o presione Nuevo.");
                    return;
                }

                editorialNegocio.Registrar(LeerFormulario());
                Mensajes.Informacion("Editorial guardada correctamente.");
                CargarEditoriales();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("guardar la editorial", ex);
            }
        }

        private void dgvEditoriales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvEditoriales.Rows[e.RowIndex].DataBoundItem is Editorial editorial)
            {
                idEditorialSeleccionada = editorial.IdEditorial;
                txtNombre.Text = editorial.Nombre;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                editorialNegocio.Actualizar(LeerFormulario());
                Mensajes.Informacion("Editorial actualizada correctamente.");
                CargarEditoriales();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("actualizar la editorial", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idEditorialSeleccionada == 0)
                {
                    Mensajes.Advertencia("Haga doble clic sobre la editorial que desea eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar($"¿Está seguro de eliminar la editorial {txtNombre.Text}?"))
                    return;

                editorialNegocio.Eliminar(idEditorialSeleccionada);
                Mensajes.Informacion("Editorial eliminada correctamente.");
                CargarEditoriales();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("eliminar la editorial", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idEditorialSeleccionada = 0;
            txtNombre.Clear();
            dgvEditoriales.ClearSelection();
            txtNombre.Focus();
        }
    }
}
