namespace AcaBiblioteca.Entidades
{
    /// <summary>
    /// Clase base abstracta de todas las entidades del sistema.
    /// Obliga a cada entidad a implementar su propia validación (polimorfismo):
    /// la capa de negocio llama a Validar() sin conocer el tipo concreto.
    /// </summary>
    public abstract class EntidadBase
    {
        /// <summary>
        /// Valida los datos propios de la entidad (campos obligatorios,
        /// longitudes y formatos) y devuelve la lista de errores encontrados.
        /// </summary>
        /// <returns>Lista vacía si la entidad es válida.</returns>
        public abstract List<string> Validar();

        /// <summary>Indica si la entidad no tiene errores de validación.</summary>
        public bool EsValida()
        {
            return Validar().Count == 0;
        }

        /// <summary>
        /// Método auxiliar para validar un texto obligatorio y su longitud máxima.
        /// Es protected: solo lo usan las clases derivadas (encapsulamiento).
        /// </summary>
        protected static void ValidarTexto(List<string> errores, string valor,
            string nombreCampo, int longitudMaxima, bool obligatorio = true)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                if (obligatorio)
                {
                    errores.Add($"El campo {nombreCampo} es obligatorio.");
                }
                return;
            }

            if (valor.Length > longitudMaxima)
            {
                errores.Add($"El campo {nombreCampo} admite máximo {longitudMaxima} caracteres.");
            }
        }

        /// <summary>Quita espacios al inicio y al final; convierte null en cadena vacía.</summary>
        protected static string Limpiar(string valor)
        {
            return valor?.Trim() ?? string.Empty;
        }
    }
}
