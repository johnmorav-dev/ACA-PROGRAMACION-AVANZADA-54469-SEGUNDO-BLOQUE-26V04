namespace AcaBiblioteca
{
    partial class FrmInicio
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
            pnlResumen = new Panel();
            lblSubtitulo = new Label();
            pnlLibros = new Panel();
            lblLibrosValor = new Label();
            lblLibrosTexto = new Label();
            pnlEjemplares = new Panel();
            lblEjemplaresValor = new Label();
            lblEjemplaresTexto = new Label();
            pnlUsuarios = new Panel();
            lblUsuariosValor = new Label();
            lblUsuariosTexto = new Label();
            pnlAutores = new Panel();
            lblAutoresValor = new Label();
            lblAutoresTexto = new Label();
            pnlEditoriales = new Panel();
            lblEditorialesValor = new Label();
            lblEditorialesTexto = new Label();
            pnlPrestamos = new Panel();
            lblPrestamosValor = new Label();
            lblPrestamosTexto = new Label();
            lblDevueltos = new Label();
            btnActualizar = new Button();
            pnlEditoriales.SuspendLayout();
            pnlUsuarios.SuspendLayout();
            pnlTitulo.SuspendLayout();
            pnlLibros.SuspendLayout();
            pnlResumen.SuspendLayout();
            pnlAutores.SuspendLayout();
            pnlPrestamos.SuspendLayout();
            pnlEjemplares.SuspendLayout();
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
            lblTitulo.Text = "BIENVENIDO AL SISTEMA DE GESTIÓN DE BIBLIOTECA";
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            // 
            // pnlResumen
            // 
            pnlResumen.Controls.Add(btnActualizar);
            pnlResumen.Controls.Add(lblDevueltos);
            pnlResumen.Controls.Add(pnlPrestamos);
            pnlResumen.Controls.Add(pnlEditoriales);
            pnlResumen.Controls.Add(pnlAutores);
            pnlResumen.Controls.Add(pnlUsuarios);
            pnlResumen.Controls.Add(pnlEjemplares);
            pnlResumen.Controls.Add(pnlLibros);
            pnlResumen.Controls.Add(lblSubtitulo);
            pnlResumen.BackColor = Color.WhiteSmoke;
            pnlResumen.Dock = DockStyle.Fill;
            pnlResumen.Name = "pnlResumen";
            pnlResumen.TabIndex = 1;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F);
            lblSubtitulo.Location = new Point(150, 30);
            lblSubtitulo.Text = "Resumen general de la biblioteca. Use el menú de la izquierda para ingresar a cada módulo.";
            lblSubtitulo.ForeColor = Color.DimGray;
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.TabIndex = 0;
            // 
            // pnlLibros
            // 
            pnlLibros.Controls.Add(lblLibrosTexto);
            pnlLibros.Controls.Add(lblLibrosValor);
            pnlLibros.BackColor = Color.RoyalBlue;
            pnlLibros.Location = new Point(150, 100);
            pnlLibros.Size = new Size(320, 160);
            pnlLibros.Name = "pnlLibros";
            pnlLibros.TabIndex = 1;
            // 
            // lblLibrosValor
            // 
            lblLibrosValor.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblLibrosValor.ForeColor = Color.White;
            lblLibrosValor.Location = new Point(10, 5);
            lblLibrosValor.Size = new Size(300, 95);
            lblLibrosValor.Text = "0";
            lblLibrosValor.TextAlign = ContentAlignment.MiddleCenter;
            lblLibrosValor.Name = "lblLibrosValor";
            lblLibrosValor.TabIndex = 0;
            // 
            // lblLibrosTexto
            // 
            lblLibrosTexto.Font = new Font("Segoe UI", 12F);
            lblLibrosTexto.ForeColor = Color.White;
            lblLibrosTexto.Location = new Point(10, 100);
            lblLibrosTexto.Size = new Size(300, 50);
            lblLibrosTexto.Text = "Títulos registrados";
            lblLibrosTexto.TextAlign = ContentAlignment.MiddleCenter;
            lblLibrosTexto.Name = "lblLibrosTexto";
            lblLibrosTexto.TabIndex = 1;
            // 
            // pnlEjemplares
            // 
            pnlEjemplares.Controls.Add(lblEjemplaresTexto);
            pnlEjemplares.Controls.Add(lblEjemplaresValor);
            pnlEjemplares.BackColor = Color.SeaGreen;
            pnlEjemplares.Location = new Point(510, 100);
            pnlEjemplares.Size = new Size(320, 160);
            pnlEjemplares.Name = "pnlEjemplares";
            pnlEjemplares.TabIndex = 2;
            // 
            // lblEjemplaresValor
            // 
            lblEjemplaresValor.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblEjemplaresValor.ForeColor = Color.White;
            lblEjemplaresValor.Location = new Point(10, 5);
            lblEjemplaresValor.Size = new Size(300, 95);
            lblEjemplaresValor.Text = "0";
            lblEjemplaresValor.TextAlign = ContentAlignment.MiddleCenter;
            lblEjemplaresValor.Name = "lblEjemplaresValor";
            lblEjemplaresValor.TabIndex = 0;
            // 
            // lblEjemplaresTexto
            // 
            lblEjemplaresTexto.Font = new Font("Segoe UI", 12F);
            lblEjemplaresTexto.ForeColor = Color.White;
            lblEjemplaresTexto.Location = new Point(10, 100);
            lblEjemplaresTexto.Size = new Size(300, 50);
            lblEjemplaresTexto.Text = "Ejemplares disponibles";
            lblEjemplaresTexto.TextAlign = ContentAlignment.MiddleCenter;
            lblEjemplaresTexto.Name = "lblEjemplaresTexto";
            lblEjemplaresTexto.TabIndex = 1;
            // 
            // pnlUsuarios
            // 
            pnlUsuarios.Controls.Add(lblUsuariosTexto);
            pnlUsuarios.Controls.Add(lblUsuariosValor);
            pnlUsuarios.BackColor = Color.DarkOrange;
            pnlUsuarios.Location = new Point(870, 100);
            pnlUsuarios.Size = new Size(320, 160);
            pnlUsuarios.Name = "pnlUsuarios";
            pnlUsuarios.TabIndex = 3;
            // 
            // lblUsuariosValor
            // 
            lblUsuariosValor.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblUsuariosValor.ForeColor = Color.White;
            lblUsuariosValor.Location = new Point(10, 5);
            lblUsuariosValor.Size = new Size(300, 95);
            lblUsuariosValor.Text = "0";
            lblUsuariosValor.TextAlign = ContentAlignment.MiddleCenter;
            lblUsuariosValor.Name = "lblUsuariosValor";
            lblUsuariosValor.TabIndex = 0;
            // 
            // lblUsuariosTexto
            // 
            lblUsuariosTexto.Font = new Font("Segoe UI", 12F);
            lblUsuariosTexto.ForeColor = Color.White;
            lblUsuariosTexto.Location = new Point(10, 100);
            lblUsuariosTexto.Size = new Size(300, 50);
            lblUsuariosTexto.Text = "Usuarios registrados";
            lblUsuariosTexto.TextAlign = ContentAlignment.MiddleCenter;
            lblUsuariosTexto.Name = "lblUsuariosTexto";
            lblUsuariosTexto.TabIndex = 1;
            // 
            // pnlAutores
            // 
            pnlAutores.Controls.Add(lblAutoresTexto);
            pnlAutores.Controls.Add(lblAutoresValor);
            pnlAutores.BackColor = Color.SlateBlue;
            pnlAutores.Location = new Point(150, 300);
            pnlAutores.Size = new Size(320, 160);
            pnlAutores.Name = "pnlAutores";
            pnlAutores.TabIndex = 4;
            // 
            // lblAutoresValor
            // 
            lblAutoresValor.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblAutoresValor.ForeColor = Color.White;
            lblAutoresValor.Location = new Point(10, 5);
            lblAutoresValor.Size = new Size(300, 95);
            lblAutoresValor.Text = "0";
            lblAutoresValor.TextAlign = ContentAlignment.MiddleCenter;
            lblAutoresValor.Name = "lblAutoresValor";
            lblAutoresValor.TabIndex = 0;
            // 
            // lblAutoresTexto
            // 
            lblAutoresTexto.Font = new Font("Segoe UI", 12F);
            lblAutoresTexto.ForeColor = Color.White;
            lblAutoresTexto.Location = new Point(10, 100);
            lblAutoresTexto.Size = new Size(300, 50);
            lblAutoresTexto.Text = "Autores";
            lblAutoresTexto.TextAlign = ContentAlignment.MiddleCenter;
            lblAutoresTexto.Name = "lblAutoresTexto";
            lblAutoresTexto.TabIndex = 1;
            // 
            // pnlEditoriales
            // 
            pnlEditoriales.Controls.Add(lblEditorialesTexto);
            pnlEditoriales.Controls.Add(lblEditorialesValor);
            pnlEditoriales.BackColor = Color.Teal;
            pnlEditoriales.Location = new Point(510, 300);
            pnlEditoriales.Size = new Size(320, 160);
            pnlEditoriales.Name = "pnlEditoriales";
            pnlEditoriales.TabIndex = 5;
            // 
            // lblEditorialesValor
            // 
            lblEditorialesValor.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblEditorialesValor.ForeColor = Color.White;
            lblEditorialesValor.Location = new Point(10, 5);
            lblEditorialesValor.Size = new Size(300, 95);
            lblEditorialesValor.Text = "0";
            lblEditorialesValor.TextAlign = ContentAlignment.MiddleCenter;
            lblEditorialesValor.Name = "lblEditorialesValor";
            lblEditorialesValor.TabIndex = 0;
            // 
            // lblEditorialesTexto
            // 
            lblEditorialesTexto.Font = new Font("Segoe UI", 12F);
            lblEditorialesTexto.ForeColor = Color.White;
            lblEditorialesTexto.Location = new Point(10, 100);
            lblEditorialesTexto.Size = new Size(300, 50);
            lblEditorialesTexto.Text = "Editoriales";
            lblEditorialesTexto.TextAlign = ContentAlignment.MiddleCenter;
            lblEditorialesTexto.Name = "lblEditorialesTexto";
            lblEditorialesTexto.TabIndex = 1;
            // 
            // pnlPrestamos
            // 
            pnlPrestamos.Controls.Add(lblPrestamosTexto);
            pnlPrestamos.Controls.Add(lblPrestamosValor);
            pnlPrestamos.BackColor = Color.Firebrick;
            pnlPrestamos.Location = new Point(870, 300);
            pnlPrestamos.Size = new Size(320, 160);
            pnlPrestamos.Name = "pnlPrestamos";
            pnlPrestamos.TabIndex = 6;
            // 
            // lblPrestamosValor
            // 
            lblPrestamosValor.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblPrestamosValor.ForeColor = Color.White;
            lblPrestamosValor.Location = new Point(10, 5);
            lblPrestamosValor.Size = new Size(300, 95);
            lblPrestamosValor.Text = "0";
            lblPrestamosValor.TextAlign = ContentAlignment.MiddleCenter;
            lblPrestamosValor.Name = "lblPrestamosValor";
            lblPrestamosValor.TabIndex = 0;
            // 
            // lblPrestamosTexto
            // 
            lblPrestamosTexto.Font = new Font("Segoe UI", 12F);
            lblPrestamosTexto.ForeColor = Color.White;
            lblPrestamosTexto.Location = new Point(10, 100);
            lblPrestamosTexto.Size = new Size(300, 50);
            lblPrestamosTexto.Text = "Préstamos activos";
            lblPrestamosTexto.TextAlign = ContentAlignment.MiddleCenter;
            lblPrestamosTexto.Name = "lblPrestamosTexto";
            lblPrestamosTexto.TabIndex = 1;
            // 
            // lblDevueltos
            // 
            lblDevueltos.AutoSize = true;
            lblDevueltos.Font = new Font("Segoe UI", 11F);
            lblDevueltos.Location = new Point(150, 520);
            lblDevueltos.Text = "Préstamos devueltos: 0";
            lblDevueltos.Name = "lblDevueltos";
            lblDevueltos.TabIndex = 7;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.White;
            btnActualizar.Font = new Font("Segoe UI", 11F);
            btnActualizar.Location = new Point(970, 510);
            btnActualizar.Size = new Size(160, 50);
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Name = "btnActualizar";
            btnActualizar.TabIndex = 8;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1344, 950);
            Controls.Add(pnlResumen);
            Controls.Add(pnlTitulo);
            Name = "FrmInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmInicio";
            Load += FrmInicio_Load;
            pnlEditoriales.ResumeLayout(false);
            pnlEditoriales.PerformLayout();
            pnlUsuarios.ResumeLayout(false);
            pnlUsuarios.PerformLayout();
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlLibros.ResumeLayout(false);
            pnlLibros.PerformLayout();
            pnlResumen.ResumeLayout(false);
            pnlResumen.PerformLayout();
            pnlAutores.ResumeLayout(false);
            pnlAutores.PerformLayout();
            pnlPrestamos.ResumeLayout(false);
            pnlPrestamos.PerformLayout();
            pnlEjemplares.ResumeLayout(false);
            pnlEjemplares.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Label lblTitulo;
        private Panel pnlResumen;
        private Label lblSubtitulo;
        private Panel pnlLibros;
        private Label lblLibrosValor;
        private Label lblLibrosTexto;
        private Panel pnlEjemplares;
        private Label lblEjemplaresValor;
        private Label lblEjemplaresTexto;
        private Panel pnlUsuarios;
        private Label lblUsuariosValor;
        private Label lblUsuariosTexto;
        private Panel pnlAutores;
        private Label lblAutoresValor;
        private Label lblAutoresTexto;
        private Panel pnlEditoriales;
        private Label lblEditorialesValor;
        private Label lblEditorialesTexto;
        private Panel pnlPrestamos;
        private Label lblPrestamosValor;
        private Label lblPrestamosTexto;
        private Label lblDevueltos;
        private Button btnActualizar;
    }
}
