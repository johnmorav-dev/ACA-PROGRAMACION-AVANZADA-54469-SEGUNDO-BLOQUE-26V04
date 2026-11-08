namespace AcaBiblioteca
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Cualquier error no controlado se muestra con un mensaje claro
            Application.ThreadException += (sender, e) =>
                MessageBox.Show("Ocurrió un error inesperado:\n" + e.Exception.Message,
                    "Biblioteca", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Run(new FrmPrincipal());
        }
    }
}
