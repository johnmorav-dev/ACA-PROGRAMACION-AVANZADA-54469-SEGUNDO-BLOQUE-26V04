using AcaBiblioteca.Entidades;
using AcaBiblioteca.Negocio;
using AcaBiblioteca.Utilidades;

namespace AcaBiblioteca
{
    /// <summary>Capa de presentación del módulo de libros.</summary>
    public partial class FrmLibros : Form
    {
        private readonly LibroNegocio libroNegocio = new LibroNegocio();
        private readonly AutorNegocio autorNegocio = new AutorNegocio();
        private readonly EditorialNegocio editorialNegocio = new EditorialNegocio();

        // true cuando se cargó un libro de la tabla (el ISBN ya no se puede cambiar)
        private bool modoEdicion = false;

        public FrmLibros()
        {
            InitializeComponent();
            Load += FrmLibros_Load;
        }

        private void FrmLibros_Load(object sender, EventArgs e)
        {
            EstiloTabla.Aplicar(dgvLibros);

            txtISBN.MaxLength = 17;      // 13 dígitos + guiones
            txtTitulo.MaxLength = 200;
            txtCategoria.MaxLength = 100;
            txtAnio.MaxLength = 4;
            txtExistencias.MaxLength = 5;

            cmbCriterio.DataSource = LibroNegocio.CriteriosBusqueda;

            CargarAutores();
            CargarEditoriales();
            CargarLibros();
            LimpiarFormulario();
        }

        private void CargarLibros()
        {
            try
            {
                MostrarLibros(libroNegocio.Listar());
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar los libros", ex);
            }
        }

        private void MostrarLibros(List<Libro> libros)
        {
            dgvLibros.DataSource = libros;
            EstiloTabla.OcultarColumnas(dgvLibros, "IdAutor", "IdEditorial", "EstaDisponible");
            EstiloTabla.Ordenar(dgvLibros, "ISBN", "Titulo", "NombreAutor", "NombreEditorial", "Categoria", "Anio", "Existencias");
            EstiloTabla.Encabezado(dgvLibros, "Titulo", "Título");
            EstiloTabla.Encabezado(dgvLibros, "Categoria", "Categoría");
            EstiloTabla.Encabezado(dgvLibros, "Anio", "Año");
            EstiloTabla.Encabezado(dgvLibros, "NombreAutor", "Autor");
            EstiloTabla.Encabezado(dgvLibros, "NombreEditorial", "Editorial");
        }

        private void CargarAutores()
        {
            try
            {
                cmbAutor.DataSource = autorNegocio.Listar();
                cmbAutor.DisplayMember = "NombreCompleto";
                cmbAutor.ValueMember = "IdAutor";
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar los autores", ex);
            }
        }

        private void CargarEditoriales()
        {
            try
            {
                cmbEditorial.DataSource = editorialNegocio.Listar();
                cmbEditorial.DisplayMember = "Nombre";
                cmbEditorial.ValueMember = "IdEditorial";
            }
            catch (Exception ex)
            {
                Mensajes.Error("cargar las editoriales", ex);
            }
        }

        /// <summary>
        /// Lee los controles y construye un Libro. Valida que Año y Existencias
        /// sean números; las demás reglas las valida la capa de negocio.
        /// </summary>
        private Libro LeerFormulario()
        {
            int? anio = null;
            if (!string.IsNullOrWhiteSpace(txtAnio.Text))
            {
                if (!int.TryParse(txtAnio.Text.Trim(), out int anioLeido))
                {
                    throw new ReglaNegocioException("El año debe ser un número entero (ejemplo: 1967).");
                }
                anio = anioLeido;
            }

            if (!int.TryParse(txtExistencias.Text.Trim(), out int existencias))
            {
                throw new ReglaNegocioException("Las existencias deben ser un número entero mayor o igual a 0.");
            }

            int idAutor = cmbAutor.SelectedValue is int autor ? autor : 0;
            int idEditorial = cmbEditorial.SelectedValue is int editorial ? editorial : 0;

            return new Libro(txtISBN.Text, txtTitulo.Text, idAutor, idEditorial,
                txtCategoria.Text, anio, existencias);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    Mensajes.Advertencia("Escriba el texto que desea buscar.");
                    return;
                }

                List<Libro> resultado = libroNegocio.Buscar(cmbCriterio.Text, txtBuscar.Text);
                MostrarLibros(resultado);

                if (resultado.Count == 0)
                {
                    Mensajes.Informacion("No se encontraron libros con ese criterio.");
                }
                else if (resultado.Count == 1)
                {
                    MostrarEnFormulario(resultado[0]);
                }
            }
            catch (Exception ex)
            {
                Mensajes.Error("buscar libros", ex);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarLibros();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modoEdicion)
                {
                    Mensajes.Advertencia("Está editando un libro existente. Use el botón Editar o presione Nuevo para registrar otro.");
                    return;
                }

                libroNegocio.Registrar(LeerFormulario());
                Mensajes.Informacion("Libro guardado correctamente.");
                CargarLibros();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("guardar el libro", ex);
            }
        }

        private void dgvLibros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvLibros.Rows[e.RowIndex].DataBoundItem is Libro libro)
            {
                MostrarEnFormulario(libro);
            }
        }

        private void MostrarEnFormulario(Libro libro)
        {
            txtISBN.Text = libro.ISBN;
            txtTitulo.Text = libro.Titulo;
            cmbAutor.SelectedValue = libro.IdAutor;
            cmbEditorial.SelectedValue = libro.IdEditorial;
            txtCategoria.Text = libro.Categoria;
            txtAnio.Text = libro.Anio?.ToString() ?? "";
            txtExistencias.Text = libro.Existencias.ToString();

            modoEdicion = true;
            txtISBN.Enabled = false;   // el ISBN es la clave primaria
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modoEdicion)
                {
                    Mensajes.Advertencia("Haga doble clic sobre el libro que desea editar.");
                    return;
                }

                libroNegocio.Actualizar(LeerFormulario());
                Mensajes.Informacion("Libro actualizado correctamente.");
                CargarLibros();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("actualizar el libro", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modoEdicion)
                {
                    Mensajes.Advertencia("Haga doble clic sobre el libro que desea eliminar.");
                    return;
                }

                if (!Mensajes.Confirmar($"¿Está seguro de eliminar el libro \"{txtTitulo.Text}\"?"))
                    return;

                libroNegocio.Eliminar(txtISBN.Text.Trim());
                Mensajes.Informacion("Libro eliminado correctamente.");
                CargarLibros();
                LimpiarFormulario();
            }
            catch (ReglaNegocioException ex)
            {
                Mensajes.Advertencia(ex.Message);
            }
            catch (Exception ex)
            {
                Mensajes.Error("eliminar el libro", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtISBN.Clear();
            txtTitulo.Clear();
            txtCategoria.Clear();
            txtAnio.Clear();
            txtExistencias.Clear();
            cmbAutor.SelectedIndex = -1;
            cmbEditorial.SelectedIndex = -1;

            modoEdicion = false;
            txtISBN.Enabled = true;
            dgvLibros.ClearSelection();
            txtISBN.Focus();
        }
    }
}
