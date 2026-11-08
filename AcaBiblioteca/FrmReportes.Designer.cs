namespace AcaBiblioteca
{
    partial class FrmReportes
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
            lblTipoReporte = new Label();
            cmbTipoReporte = new ComboBox();
            btnGenerar = new Button();
            btnLimpiar = new Button();
            btnExportar = new Button();
            lblTotal = new Label();
            dgvReportes = new DataGridView();
            pnlDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
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
            lblTitulo.Text = "GESTIÓN DE REPORTES";
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(lblTotal);
            pnlDatos.Controls.Add(btnExportar);
            pnlDatos.Controls.Add(btnLimpiar);
            pnlDatos.Controls.Add(btnGenerar);
            pnlDatos.Controls.Add(cmbTipoReporte);
            pnlDatos.Controls.Add(lblTipoReporte);
            pnlDatos.BackColor = Color.WhiteSmoke;
            pnlDatos.Dock = DockStyle.Top;
            pnlDatos.Size = new Size(1344, 260);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.TabIndex = 1;
            // 
            // lblTipoReporte
            // 
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTipoReporte.Location = new Point(360, 50);
            lblTipoReporte.Text = "Tipo De Reporte:";
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.TabIndex = 0;
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.Font = new Font("Segoe UI", 11F);
            cmbTipoReporte.Location = new Point(600, 47);
            cmbTipoReporte.Size = new Size(460, 38);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.TabIndex = 1;
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = Color.White;
            btnGenerar.Font = new Font("Segoe UI", 11F);
            btnGenerar.Location = new Point(430, 115);
            btnGenerar.Size = new Size(200, 55);
            btnGenerar.Text = "Generar Reporte";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Cursor = Cursors.Hand;
            btnGenerar.Name = "btnGenerar";
            btnGenerar.TabIndex = 2;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.Font = new Font("Segoe UI", 11F);
            btnLimpiar.Location = new Point(650, 115);
            btnLimpiar.Size = new Size(170, 55);
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.White;
            btnExportar.Font = new Font("Segoe UI", 11F);
            btnExportar.Location = new Point(840, 115);
            btnExportar.Size = new Size(170, 55);
            btnExportar.Text = "Exportar CSV";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Cursor = Cursors.Hand;
            btnExportar.Name = "btnExportar";
            btnExportar.TabIndex = 4;
            btnExportar.Click += btnExportar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F);
            lblTotal.Location = new Point(360, 200);
            lblTotal.Text = "Seleccione un reporte y presione Generar Reporte.";
            lblTotal.ForeColor = Color.MidnightBlue;
            lblTotal.Name = "lblTotal";
            lblTotal.TabIndex = 5;
            // 
            // dgvReportes
            // 
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Dock = DockStyle.Fill;
            dgvReportes.RowHeadersWidth = 62;
            dgvReportes.Name = "dgvReportes";
            dgvReportes.TabIndex = 2;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1344, 950);
            Controls.Add(dgvReportes);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulo);
            Name = "FrmReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmReportes";
            Load += FrmReportes_Load;
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Label lblTitulo;
        private Panel pnlDatos;
        private Label lblTipoReporte;
        private ComboBox cmbTipoReporte;
        private Button btnGenerar;
        private Button btnLimpiar;
        private Button btnExportar;
        private Label lblTotal;
        private DataGridView dgvReportes;
    }
}
