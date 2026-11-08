namespace AcaBiblioteca.Entidades
{
    /// <summary>Indicadores generales que se muestran en el formulario de Inicio.</summary>
    public class ResumenBiblioteca
    {
        public int TotalLibros { get; set; }
        public int EjemplaresDisponibles { get; set; }
        public int TotalUsuarios { get; set; }
        public int TotalAutores { get; set; }
        public int TotalEditoriales { get; set; }
        public int PrestamosActivos { get; set; }
        public int PrestamosDevueltos { get; set; }
    }
}
