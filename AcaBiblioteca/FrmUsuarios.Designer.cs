namespace AcaBiblioteca
{
    partial class FrmUsuarios
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
            btnCancelar = new FontAwesome.Sharp.IconButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnEditar = new FontAwesome.Sharp.IconButton();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            btnNuevo = new FontAwesome.Sharp.IconButton();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            txtDocumento = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            lblCorreo = new Label();
            lblTelefono = new Label();
            lblDocumento = new Label();
            lblApellido = new Label();
            lblNombre = new Label();
            dgvUsuarios = new DataGridView();
            pnlBotones = new Panel();
            pnlTitulo.SuspendLayout();
            pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.RoyalBlue;
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(1401, 70);
            pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(507, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(416, 48);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE USUARIOS";
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(pnlBotones);
            pnlDatos.Controls.Add(txtCorreo);
            pnlDatos.Controls.Add(txtTelefono);
            pnlDatos.Controls.Add(txtDocumento);
            pnlDatos.Controls.Add(txtApellido);
            pnlDatos.Controls.Add(txtNombre);
            pnlDatos.Controls.Add(lblCorreo);
            pnlDatos.Controls.Add(lblTelefono);
            pnlDatos.Controls.Add(lblDocumento);
            pnlDatos.Controls.Add(lblApellido);
            pnlDatos.Controls.Add(lblNombre);
            pnlDatos.Dock = DockStyle.Top;
            pnlDatos.Location = new Point(0, 70);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(1401, 417);
            pnlDatos.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Transparent;
            btnCancelar.Font = new Font("Segoe Fluent Icons", 12F);
            btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancelar.IconSize = 25;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(695, 9);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(146, 42);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.Font = new Font("Segoe Fluent Icons", 12F);
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.IconSize = 25;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(537, 9);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(146, 42);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Transparent;
            btnEditar.Font = new Font("Segoe Fluent Icons", 12F);
            btnEditar.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            btnEditar.IconColor = Color.Black;
            btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEditar.IconSize = 25;
            btnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditar.Location = new Point(368, 9);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(146, 42);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.Font = new Font("Segoe Fluent Icons", 12F);
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.IconSize = 25;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(200, 9);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(146, 42);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Transparent;
            btnNuevo.Font = new Font("Segoe Fluent Icons", 12F);
            btnNuevo.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            btnNuevo.IconColor = Color.Black;
            btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNuevo.IconSize = 25;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(27, 9);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(146, 42);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo";
            btnNuevo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(663, 272);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(342, 31);
            txtCorreo.TabIndex = 9;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(663, 218);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(342, 31);
            txtTelefono.TabIndex = 8;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(663, 164);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(342, 31);
            txtDocumento.TabIndex = 7;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(663, 107);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(342, 31);
            txtApellido.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(663, 54);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(342, 31);
            txtNombre.TabIndex = 5;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(475, 278);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(75, 25);
            lblCorreo.TabIndex = 4;
            lblCorreo.Text = "Correo: ";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(475, 224);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(88, 25);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Teléfono: ";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(475, 170);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(110, 25);
            lblDocumento.TabIndex = 2;
            lblDocumento.Text = "Documento:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(475, 113);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(87, 25);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido: ";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(475, 60);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(87, 513);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 62;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(1398, 406);
            dgvUsuarios.TabIndex = 2;
            dgvUsuarios.CellDoubleClick += dgvUsuarios_CellDoubleClick;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnNuevo);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Controls.Add(btnEditar);
            pnlBotones.Location = new Point(325, 334);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(855, 60);
            pnlBotones.TabIndex = 15;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1401, 950);
            Controls.Add(dgvUsuarios);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulo);
            Name = "FrmUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmUsuarios";
            WindowState = FormWindowState.Maximized;
            Load += FrmUsuarios_Load;
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Panel pnlDatos;
        private Label lblTitulo;
        private Label lblNombre;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label lblCorreo;
        private Label lblTelefono;
        private Label lblDocumento;
        private Label lblApellido;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private DataGridView dgvUsuarios;
        private Panel pnlBotones;
    }
}