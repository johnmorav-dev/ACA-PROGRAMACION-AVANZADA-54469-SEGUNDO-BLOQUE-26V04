using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    /// <summary>Capa de presentación del módulo de usuarios.</summary>
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private int idUsuarioSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            EstiloTabla.Aplicar(dgvUsuarios);
            txtNombre.MaxLength = 100;
            txtApellido.MaxLength = 100;
            txtDocumento.MaxLength = 15;
            txtTelefono.MaxLength = 20;
            txtCorreo.MaxLength = 150;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = usuarioNegocio.Listar();
                EstiloTabla.OcultarColumnas(dgvUsuarios, "NombreCompleto");
                EstiloTabla.Ordenar(dgvUsuarios, "IdUsuario", "Nombre", "Apellido", "Documento", "Telefono", "Correo");
                EstiloTabla.Encabezado(dgvUsuarios, "IdUsuario", "Id");
                EstiloTabla.Encabezado(dgvUsuarios, "Telefono", "Teléfono");
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar los usuarios", ex);
            }
        }

        private Usuario LeerFormulario()
        {
            return new Usuario(idUsuarioSeleccionado, txtNombre.Text, txtApellido.Text,
                txtDocumento.Text, txtTelefono.Text, txtCorreo.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idUsuarioSeleccionado != 0)
                {
                    Mensajes.Advertencia("Está editando un usuario existente. Use el botón Editar o presione Nuevo.");
                    return;
                }

                usuarioNegocio.Registrar(LeerFormulario());
                Mensajes.Informacion("Usuario guardado correctamente.");
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("guardar el usuario", ex);
            }
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvUsuarios.Rows[e.RowIndex].DataBoundItem is Usuario usuario)
            {
                idUsuarioSeleccionado = usuario.IdUsuario;
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtDocumento.Text = usuario.Documento;
                txtTelefono.Text = usuario.Telefono;
                txtCorreo.Text = usuario.Correo;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioNegocio.Actualizar(LeerFormulario());
                Mensajes.Informacion("Usuario actualizado correctamente.");
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("actualizar el usuario", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idUsuarioSeleccionado == 0)
                {
                    Mensajes.Advertencia("Haga doble clic sobre el usuario que desea eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar($"¿Está seguro de eliminar al usuario {txtNombre.Text} {txtApellido.Text}?"))
                    return;

                usuarioNegocio.Eliminar(idUsuarioSeleccionado);
                Mensajes.Informacion("Usuario eliminado correctamente.");
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("eliminar el usuario", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idUsuarioSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dgvUsuarios.ClearSelection();
            txtNombre.Focus();
        }
    }
}
