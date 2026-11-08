namespace AcaBiblioteca.Negocio
{
    /// <summary>
    /// Excepción propia del sistema. Se lanza cuando una operación incumple una
    /// regla de negocio o una validación (por ejemplo, ISBN repetido o libro sin
    /// existencias). Hereda de Exception, así los formularios pueden distinguir
    /// un error de validación (advertencia) de un error inesperado.
    /// </summary>
    public class ReglaNegocioException : Exception
    {
        public ReglaNegocioException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
