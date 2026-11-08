namespace AcaBiblioteca
{
    partial class FrmPrestamos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            pnlDatos = new Panel();
            lblUsuario = new Label();
            cmbUsuario = new ComboBox();
            lblLibro = new Label();
            cmbLibro = new ComboBox();
            lblDisponibles = new Label();
            lblFechaPrestamo = new Label();
            dtpFechaPrestamo = new DateTimePicker();
            lblFechaDevolucion = new Label();
            dtpFechaDevolucion = new DateTimePicker();
            lblAyudaDevolucion = new Label();
            lblSeleccion = new Label();
            pnlBotones = new Panel();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnDevolucion = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            lblFiltroEstado = new Label();
            cmbFiltroEstado = new ComboBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnVerTodos = new Button();
            dgvPrestamos = new DataGridView();
            pnlBotones.SuspendLayout();
            pnlDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.BackColor = Color.RoyalBlue;
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Size = new Size(1344, 70);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Text = "GESTIÓN DE PRÉSTAMOS";
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(btnVerTodos);
            pnlDatos.Controls.Add(btnBuscar);
            pnlDatos.Controls.Add(txtBuscar);
            pnlDatos.Controls.Add(lblBuscar);
            pnlDatos.Controls.Add(cmbFiltroEstado);
            pnlDatos.Controls.Add(lblFiltroEstado);
            pnlDatos.Controls.Add(pnlBotones);
            pnlDatos.Controls.Add(lblSeleccion);
            pnlDatos.Controls.Add(lblAyudaDevolucion);
            pnlDatos.Controls.Add(dtpFechaDevolucion);
            pnlDatos.Controls.Add(lblFechaDevolucion);
            pnlDatos.Controls.Add(dtpFechaPrestamo);
            pnlDatos.Controls.Add(lblFechaPrestamo);
            pnlDatos.Controls.Add(lblDisponibles);
            pnlDatos.Controls.Add(cmbLibro);
            pnlDatos.Controls.Add(lblLibro);
            pnlDatos.Controls.Add(cmbUsuario);
            pnlDatos.Controls.Add(lblUsuario);
            pnlDatos.BackColor = Color.WhiteSmoke;
            pnlDatos.Dock = DockStyle.Top;
            pnlDatos.Size = new Size(1344, 440);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUsuario.Location = new Point(380, 25);
            lblUsuario.Text = "Usuario:";
            lblUsuario.Name = "lblUsuario";
            lblUsuario.TabIndex = 0;
            // 
            // cmbUsuario
            // 
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.Font = new Font("Segoe UI", 11F);
            cmbUsuario.Location = new Point(640, 22);
            cmbUsuario.Size = new Size(440, 38);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.TabIndex = 1;
            // 
            // lblLibro
            // 
            lblLibro.AutoSize = true;
            lblLibro.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLibro.Location = new Point(380, 80);
            lblLibro.Text = "Libro:";
            lblLibro.Name = "lblLibro";
            lblLibro.TabIndex = 2;
            // 
            // cmbLibro
            // 
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLibro.Font = new Font("Segoe UI", 11F);
            cmbLibro.Location = new Point(640, 77);
            cmbLibro.Size = new Size(440, 38);
            cmbLibro.Name = "cmbLibro";
            cmbLibro.TabIndex = 3;
            cmbLibro.SelectedIndexChanged += cmbLibro_SelectedIndexChanged;
            // 
            // lblDisponibles
            // 
            lblDisponibles.AutoSize = true;
            lblDisponibles.Font = new Font("Segoe UI", 10F);
            lblDisponibles.Location = new Point(1095, 82);
            lblDisponibles.Text = "Disponibles: -";
            lblDisponibles.Name = "lblDisponibles";
            lblDisponibles.TabIndex = 4;
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFechaPrestamo.Location = new Point(380, 135);
            lblFechaPrestamo.Text = "Fecha Préstamo:";
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.TabIndex = 5;
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Font = new Font("Segoe UI", 11F);
            dtpFechaPrestamo.Format = DateTimePickerFormat.Short;
            dtpFechaPrestamo.Location = new Point(640, 132);
            dtpFechaPrestamo.Size = new Size(300, 37);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.TabIndex = 6;
            // 
            // lblFechaDevolucion
            // 
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFechaDevolucion.Location = new Point(380, 190);
            lblFechaDevolucion.Text = "Fecha Devolución:";
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            lblFechaDevolucion.TabIndex = 7;
            // 
            // dtpFechaDevolucion
            // 
            dtpFechaDevolucion.Checked = false;
            dtpFechaDevolucion.Font = new Font("Segoe UI", 11F);
            dtpFechaDevolucion.Format = DateTimePickerFormat.Short;
            dtpFechaDevolucion.Location = new Point(640, 187);
            dtpFechaDevolucion.ShowCheckBox = true;
            dtpFechaDevolucion.Size = new Size(300, 37);
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.TabIndex = 8;
            // 
            // lblAyudaDevolucion
            // 
            lblAyudaDevolucion.AutoSize = true;
            lblAyudaDevolucion.Font = new Font("Segoe UI", 9F);
            lblAyudaDevolucion.Location = new Point(955, 192);
            lblAyudaDevolucion.Text = "Marque la casilla para registrar la devolución";
            lblAyudaDevolucion.ForeColor = Color.DimGray;
            lblAyudaDevolucion.Name = "lblAyudaDevolucion";
            lblAyudaDevolucion.TabIndex = 9;
            // 
            // lblSeleccion
            // 
            lblSeleccion.AutoSize = true;
            lblSeleccion.Font = new Font("Segoe UI", 10F);
            lblSeleccion.Location = new Point(380, 240);
            lblSeleccion.Text = "Ningún préstamo seleccionado (doble clic en la tabla para seleccionar).";
            lblSeleccion.ForeColor = Color.MidnightBlue;
            lblSeleccion.Name = "lblSeleccion";
            lblSeleccion.TabIndex = 10;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Controls.Add(btnDevolucion);
            pnlBotones.Controls.Add(btnEditar);
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnNuevo);
            pnlBotones.Location = new Point(150, 280);
            pnlBotones.Size = new Size(1040, 70);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.TabIndex = 11;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.White;
            btnNuevo.Font = new Font("Segoe UI", 11F);
            btnNuevo.Location = new Point(10, 9);
            btnNuevo.Size = new Size(146, 50);
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Name = "btnNuevo";
            btnNuevo.TabIndex = 0;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.White;
            btnGuardar.Font = new Font("Segoe UI", 11F);
            btnGuardar.Location = new Point(180, 9);
            btnGuardar.Size = new Size(146, 50);
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.TabIndex = 1;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.White;
            btnEditar.Font = new Font("Segoe UI", 11F);
            btnEditar.Location = new Point(350, 9);
            btnEditar.Size = new Size(146, 50);
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Name = "btnEditar";
            btnEditar.TabIndex = 2;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnDevolucion
            // 
            btnDevolucion.BackColor = Color.White;
            btnDevolucion.Font = new Font("Segoe UI", 11F);
            btnDevolucion.Location = new Point(520, 9);
            btnDevolucion.Size = new Size(146, 50);
            btnDevolucion.Text = "Devolución";
            btnDevolucion.UseVisualStyleBackColor = false;
            btnDevolucion.Cursor = Cursors.Hand;
            btnDevolucion.Name = "btnDevolucion";
            btnDevolucion.TabIndex = 3;
            btnDevolucion.Click += btnDevolucion_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 11F);
            btnEliminar.Location = new Point(690, 9);
            btnEliminar.Size = new Size(146, 50);
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.TabIndex = 4;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.Font = new Font("Segoe UI", 11F);
            btnCancelar.Location = new Point(860, 9);
            btnCancelar.Size = new Size(146, 50);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.TabIndex = 5;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblFiltroEstado
            // 
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFiltroEstado.Location = new Point(160, 383);
            lblFiltroEstado.Text = "Estado:";
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.TabIndex = 12;
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.Font = new Font("Segoe UI", 11F);
            cmbFiltroEstado.Location = new Point(250, 378);
            cmbFiltroEstado.Size = new Size(180, 38);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.TabIndex = 13;
            cmbFiltroEstado.SelectionChangeCommitted += cmbFiltroEstado_SelectionChangeCommitted;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.Location = new Point(460, 383);
            lblBuscar.Text = "Buscar:";
            lblBuscar.Name = "lblBuscar";
            lblBuscar.TabIndex = 14;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(550, 378);
            txtBuscar.PlaceholderText = "Usuario, título o ISBN";
            txtBuscar.Size = new Size(330, 37);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.TabIndex = 15;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Font = new Font("Segoe UI", 11F);
            btnBuscar.Location = new Point(900, 375);
            btnBuscar.Size = new Size(130, 50);
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Name = "btnBuscar";
            btnBuscar.TabIndex = 16;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnVerTodos
            // 
            btnVerTodos.BackColor = Color.White;
            btnVerTodos.Font = new Font("Segoe UI", 11F);
            btnVerTodos.Location = new Point(1045, 375);
            btnVerTodos.Size = new Size(130, 50);
            btnVerTodos.Text = "Ver todos";
            btnVerTodos.UseVisualStyleBackColor = false;
            btnVerTodos.Cursor = Cursors.Hand;
            btnVerTodos.Name = "btnVerTodos";
            btnVerTodos.TabIndex = 17;
            btnVerTodos.Click += btnVerTodos_Click;
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Dock = DockStyle.Fill;
            dgvPrestamos.RowHeadersWidth = 62;
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.TabIndex = 2;
            dgvPrestamos.CellDoubleClick += dgvPrestamos_CellDoubleClick;
            // 
            // FrmPrestamos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1344, 950);
            Controls.Add(dgvPrestamos);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulo);
            Name = "FrmPrestamos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPrestamos";
            Load += FrmPrestamos_Load;
            pnlBotones.ResumeLayout(false);
            pnlBotones.PerformLayout();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Label lblTitulo;
        private Panel pnlDatos;
        private Label lblUsuario;
        private ComboBox cmbUsuario;
        private Label lblLibro;
        private ComboBox cmbLibro;
        private Label lblDisponibles;
        private Label lblFechaPrestamo;
        private DateTimePicker dtpFechaPrestamo;
        private Label lblFechaDevolucion;
        private DateTimePicker dtpFechaDevolucion;
        private Label lblAyudaDevolucion;
        private Label lblSeleccion;
        private Panel pnlBotones;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnDevolucion;
        private Button btnEliminar;
        private Button btnCancelar;
        private Label lblFiltroEstado;
        private ComboBox cmbFiltroEstado;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnVerTodos;
        private DataGridView dgvPrestamos;
    }
}
