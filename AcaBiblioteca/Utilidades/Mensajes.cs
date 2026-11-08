namespace AcaBiblioteca.Utilidades
{
    /// <summary>Centraliza los cuadros de mensaje para que todos sean iguales.</summary>
    public static class Mensajes
    {
        private const string TituloAplicacion = "Biblioteca";

        public static void Informacion(string mensaje)
        {
            MessageBox.Show(mensaje, TituloAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Advertencia(string mensaje)
        {
            MessageBox.Show(mensaje, TituloAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string accion, Exception ex)
        {
            MessageBox.Show($"Error al {accion}:\n{ex.Message}", TituloAplicacion,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirmar(string pregunta)
        {
            return MessageBox.Show(pregunta, TituloAplicacion, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
