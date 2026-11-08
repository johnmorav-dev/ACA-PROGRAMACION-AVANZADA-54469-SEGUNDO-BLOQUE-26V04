using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    /// <summary>
    /// Capa de presentación de préstamos y devoluciones. Las reglas (existencias,
    /// fechas, estado) y las transacciones están en PrestamoNegocio / PrestamoDAO.
    /// </summary>
    public partial class FrmPrestamos : Form
    {
        private readonly PrestamoNegocio prestamoNegocio = new PrestamoNegocio();
        private readonly UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private readonly LibroNegocio libroNegocio = new LibroNegocio();

        // Préstamo seleccionado en la tabla (null = ninguno)
        private Prestamo prestamoSeleccionado;

        public FrmPrestamos()
        {
            InitializeComponent();
        }

        private void FrmPrestamos_Load(object sender, EventArgs e)
        {
            EstiloTabla.Aplicar(dgvPrestamos);
            dtpFechaPrestamo.MaxDate = DateTime.Today;
            dtpFechaDevolucion.MaxDate = DateTime.Today;

            cmbFiltroEstado.DataSource = PrestamoNegocio.FiltrosEstado;

            CargarUsuarios();
            CargarLibros();
            CargarPrestamos();
            LimpiarFormulario();
        }

        private void CargarUsuarios()
        {
            try
            {
                // DisplayMember vacío: el ComboBox usa Usuario.ToString() (polimorfismo)
                cmbUsuario.DataSource = usuarioNegocio.Listar();
                cmbUsuario.ValueMember = "IdUsuario";
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar los usuarios", ex);
            }
        }

        private void CargarLibros()
        {
            try
            {
                cmbLibro.DataSource = libroNegocio.Listar();
                cmbLibro.ValueMember = "ISBN";
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar los libros", ex);
            }
        }

        private void CargarPrestamos()
        {
            try
            {
                dgvPrestamos.DataSource = prestamoNegocio.Listar(cmbFiltroEstado.Text, txtBuscar.Text);
                EstiloTabla.OcultarColumnas(dgvPrestamos, "IdUsuario", "EstaActivo");
                EstiloTabla.Encabezado(dgvPrestamos, "IdPrestamo", "Id");
                EstiloTabla.Encabezado(dgvPrestamos, "NombreUsuario", "Usuario");
                EstiloTabla.Encabezado(dgvPrestamos, "TituloLibro", "Libro");
                EstiloTabla.Encabezado(dgvPrestamos, "FechaPrestamo", "Fecha préstamo");
                EstiloTabla.Encabezado(dgvPrestamos, "FechaDevolucion", "Fecha devolución");

                if (dgvPrestamos.Columns.Contains("NombreUsuario"))
                {
                    dgvPrestamos.Columns["NombreUsuario"].DisplayIndex = 1;
                    dgvPrestamos.Columns["TituloLibro"].DisplayIndex = 2;
                }

                ColorearEstados();
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar los préstamos", ex);
            }
        }

        /// <summary>Resalta los préstamos activos para diferenciarlos de los devueltos.</summary>
        private void ColorearEstados()
        {
            foreach (DataGridViewRow fila in dgvPrestamos.Rows)
            {
                if (fila.DataBoundItem is Prestamo prestamo)
                {
                    fila.DefaultCellStyle.ForeColor = prestamo.EstaActivo ? Color.DarkRed : Color.DarkGreen;
                }
            }
        }

        private void cmbLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDisponibles.Text = cmbLibro.SelectedItem is Libro libro
                ? $"Disponibles: {libro.Existencias}"
                : "Disponibles: -";
        }

        private Prestamo LeerFormulario()
        {
            if (!(cmbUsuario.SelectedItem is Usuario usuario))
            {
                throw new ReglaNegocioException("Seleccione un usuario.");
            }

            if (!(cmbLibro.SelectedItem is Libro libro))
            {
                throw new ReglaNegocioException("Seleccione un libro.");
            }

            Prestamo prestamo = new Prestamo(usuario.IdUsuario, libro.ISBN, dtpFechaPrestamo.Value);
            prestamo.IdPrestamo = prestamoSeleccionado?.IdPrestamo ?? 0;
            return prestamo;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        /// <summary>Registra un préstamo nuevo.</summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (prestamoSeleccionado != null)
                {
                    Mensajes.Advertencia("Tiene un préstamo seleccionado. Presione Nuevo para registrar otro préstamo.");
                    return;
                }

                prestamoNegocio.Registrar(LeerFormulario());
                Mensajes.Informacion("Préstamo registrado correctamente. Se descontó una existencia del libro.");
                RecargarTodo();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("registrar el préstamo", ex);
            }
        }

        private void dgvPrestamos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (!(dgvPrestamos.Rows[e.RowIndex].DataBoundItem is Prestamo prestamo))
                return;

            prestamoSeleccionado = prestamo;

            cmbUsuario.SelectedValue = prestamo.IdUsuario;
            cmbLibro.SelectedValue = prestamo.ISBN;
            dtpFechaPrestamo.Value = prestamo.FechaPrestamo;

            if (prestamo.FechaDevolucion.HasValue)
            {
                dtpFechaDevolucion.Value = prestamo.FechaDevolucion.Value;
                dtpFechaDevolucion.Checked = true;
            }
            else
            {
                dtpFechaDevolucion.Value = DateTime.Today;
                dtpFechaDevolucion.Checked = false;
            }

            lblSeleccion.Text = $"Préstamo seleccionado: N.° {prestamo.IdPrestamo} - {prestamo.TituloLibro} " +
                                $"({prestamo.NombreUsuario}) - Estado: {prestamo.Estado}";
        }

        /// <summary>Edita usuario, libro o fecha de un préstamo activo.</summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (prestamoSeleccionado == null)
                {
                    Mensajes.Advertencia("Haga doble clic sobre el préstamo que desea editar.");
                    return;
                }

                prestamoNegocio.Actualizar(LeerFormulario());
                Mensajes.Informacion("Préstamo actualizado correctamente.");
                RecargarTodo();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("actualizar el préstamo", ex);
            }
        }

        /// <summary>Registra la devolución del préstamo seleccionado.</summary>
        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                if (prestamoSeleccionado == null)
                {
                    Mensajes.Advertencia("Haga doble clic sobre el préstamo que desea devolver.");
                    return;
                }

                if (!prestamoSeleccionado.EstaActivo)
                {
                    Mensajes.Advertencia("Este préstamo ya fue devuelto.");
                    return;
                }

                if (!dtpFechaDevolucion.Checked)
                {
                    Mensajes.Advertencia("Marque la casilla de Fecha Devolución y seleccione la fecha.");
                    return;
                }

                if (!Mensajes.Confirmar($"¿Registrar la devolución de \"{prestamoSeleccionado.TituloLibro}\"?"))
                    return;

                prestamoNegocio.RegistrarDevolucion(prestamoSeleccionado.IdPrestamo, dtpFechaDevolucion.Value);
                Mensajes.Informacion("Devolución registrada correctamente. El libro vuelve a estar disponible.");
                RecargarTodo();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("registrar la devolución", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (prestamoSeleccionado == null)
                {
                    Mensajes.Advertencia("Haga doble clic sobre el préstamo que desea eliminar.");
                    return;
                }

                string aviso = prestamoSeleccionado.EstaActivo
                    ? "\nEl préstamo está activo: el ejemplar volverá a estar disponible."
                    : "";

                if (!Mensajes.Confirmar("¿Está seguro de eliminar este préstamo?" + aviso))
                    return;

                prestamoNegocio.Eliminar(prestamoSeleccionado.IdPrestamo);
                Mensajes.Informacion("Préstamo eliminado correctamente.");
                RecargarTodo();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("eliminar el préstamo", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPrestamos();
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cmbFiltroEstado.SelectedIndex = 0;
            CargarPrestamos();
        }

        private void cmbFiltroEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarPrestamos();
        }

        /// <summary>Después de cada operación se recargan las existencias y la tabla.</summary>
        private void RecargarTodo()
        {
            CargarLibros();
            CargarPrestamos();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            prestamoSeleccionado = null;
            cmbUsuario.SelectedIndex = -1;
            cmbLibro.SelectedIndex = -1;
            dtpFechaPrestamo.Value = DateTime.Today;
            dtpFechaDevolucion.Value = DateTime.Today;
            dtpFechaDevolucion.Checked = false;
            lblDisponibles.Text = "Disponibles: -";
            lblSeleccion.Text = "Ningún préstamo seleccionado (doble clic en la tabla para seleccionar).";
            dgvPrestamos.ClearSelection();
        }
    }
}
