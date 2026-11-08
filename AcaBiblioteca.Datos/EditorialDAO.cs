using System.Data;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Datos
{
    /// <summary>Operaciones CRUD de la tabla Editoriales.</summary>
    public class EditorialDAO : DaoBase
    {
        public List<Editorial> Listar(string textoBusqueda = "")
        {
            string consulta = @"SELECT IdEditorial, Nombre
                                FROM Editoriales
                                WHERE @Texto = '' OR Nombre LIKE '%' + @Texto + '%'
                                ORDER BY Nombre";

            DataTable tabla = EjecutarConsulta(consulta, Parametro("@Texto", textoBusqueda ?? ""));

            List<Editorial> editoriales = new List<Editorial>();
            foreach (DataRow fila in tabla.Rows)
            {
                editoriales.Add(new Editorial(
                    Convert.ToInt32(fila["IdEditorial"]),
                    fila["Nombre"].ToString()));
            }
            return editoriales;
        }

        public int Insertar(Editorial editorial)
        {
            return EjecutarComando("INSERT INTO Editoriales (Nombre) VALUES (@Nombre)",
                Parametro("@Nombre", editorial.Nombre));
        }

        public int Actualizar(Editorial editorial)
        {
            return EjecutarComando(
                "UPDATE Editoriales SET Nombre = @Nombre WHERE IdEditorial = @IdEditorial",
                Parametro("@Nombre", editorial.Nombre),
                Parametro("@IdEditorial", editorial.IdEditorial));
        }

        public int Eliminar(int idEditorial)
        {
            return EjecutarComando("DELETE FROM Editoriales WHERE IdEditorial = @IdEditorial",
                Parametro("@IdEditorial", idEditorial));
        }

        public bool Existe(int idEditorial)
        {
            return EjecutarEscalar("SELECT COUNT(*) FROM Editoriales WHERE IdEditorial = @IdEditorial",
                Parametro("@IdEditorial", idEditorial)) > 0;
        }

        public bool ExisteNombre(string nombre, int idExcluir = 0)
        {
            return EjecutarEscalar(
                "SELECT COUNT(*) FROM Editoriales WHERE Nombre = @Nombre AND IdEditorial <> @IdExcluir",
                Parametro("@Nombre", nombre),
                Parametro("@IdExcluir", idExcluir)) > 0;
        }

        public int ContarLibros(int idEditorial)
        {
            return EjecutarEscalar("SELECT COUNT(*) FROM Libros WHERE IdEditorial = @IdEditorial",
                Parametro("@IdEditorial", idEditorial));
        }
    }
}
