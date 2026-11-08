namespace AcaBiblioteca.Utilidades
{
    /// <summary>Configuración común de los DataGridView del sistema.</summary>
    public static class EstiloTabla
    {
        public static void Aplicar(DataGridView tabla)
        {
            tabla.ReadOnly = true;
            tabla.AllowUserToAddRows = false;
            tabla.AllowUserToDeleteRows = false;
            tabla.MultiSelect = false;
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.BackgroundColor = Color.White;
            tabla.RowHeadersVisible = false;
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        }

        /// <summary>Oculta columnas que no se deben mostrar (si existen).</summary>
        public static void OcultarColumnas(DataGridView tabla, params string[] columnas)
        {
            foreach (string columna in columnas)
            {
                if (tabla.Columns.Contains(columna))
                {
                    tabla.Columns[columna].Visible = false;
                }
            }
        }

        /// <summary>Muestra las columnas en el orden indicado.</summary>
        public static void Ordenar(DataGridView tabla, params string[] columnas)
        {
            int posicion = 0;
            foreach (string columna in columnas)
            {
                if (tabla.Columns.Contains(columna))
                {
                    tabla.Columns[columna].DisplayIndex = posicion++;
                }
            }
        }

        /// <summary>Cambia el texto del encabezado de una columna (si existe).</summary>
        public static void Encabezado(DataGridView tabla, string columna, string texto)
        {
            if (tabla.Columns.Contains(columna))
            {
                tabla.Columns[columna].HeaderText = texto;
            }
        }
    }
}
