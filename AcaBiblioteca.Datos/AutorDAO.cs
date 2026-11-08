using System.Data;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Datos
{
    /// <summary>Operaciones CRUD de la tabla Autores.</summary>
    public class AutorDAO : DaoBase
    {
        public List<Autor> Listar(string textoBusqueda = "")
        {
            string consulta = @"SELECT IdAutor, Nombre, Apellido
                                FROM Autores
                                WHERE @Texto = ''
                                   OR Nombre + ' ' + Apellido LIKE '%' + @Texto + '%'
                                ORDER BY Nombre, Apellido";

            DataTable tabla = EjecutarConsulta(consulta, Parametro("@Texto", textoBusqueda ?? ""));

            List<Autor> autores = new List<Autor>();
            foreach (DataRow fila in tabla.Rows)
            {
                autores.Add(new Autor(
                    Convert.ToInt32(fila["IdAutor"]),
                    fila["Nombre"].ToString(),
                    fila["Apellido"].ToString()));
            }
            return autores;
        }

        public int Insertar(Autor autor)
        {
            string consulta = @"INSERT INTO Autores (Nombre, Apellido)
                                VALUES (@Nombre, @Apellido)";

            return EjecutarComando(consulta,
                Parametro("@Nombre", autor.Nombre),
                Parametro("@Apellido", autor.Apellido));
        }

        public int Actualizar(Autor autor)
        {
            string consulta = @"UPDATE Autores
                                SET Nombre = @Nombre,
                                    Apellido = @Apellido
                                WHERE IdAutor = @IdAutor";

            return EjecutarComando(consulta,
                Parametro("@Nombre", autor.Nombre),
                Parametro("@Apellido", autor.Apellido),
                Parametro("@IdAutor", autor.IdAutor));
        }

        public int Eliminar(int idAutor)
        {
            return EjecutarComando("DELETE FROM Autores WHERE IdAutor = @IdAutor",
                Parametro("@IdAutor", idAutor));
        }

        public bool Existe(int idAutor)
        {
            return EjecutarEscalar("SELECT COUNT(*) FROM Autores WHERE IdAutor = @IdAutor",
                Parametro("@IdAutor", idAutor)) > 0;
        }

        /// <summary>Verifica si ya existe un autor con el mismo nombre y apellido.</summary>
        public bool ExisteDuplicado(string nombre, string apellido, int idExcluir = 0)
        {
            string consulta = @"SELECT COUNT(*) FROM Autores
                                WHERE Nombre = @Nombre AND Apellido = @Apellido
                                  AND IdAutor <> @IdExcluir";

            return EjecutarEscalar(consulta,
                Parametro("@Nombre", nombre),
                Parametro("@Apellido", apellido),
                Parametro("@IdExcluir", idExcluir)) > 0;
        }

        /// <summary>Cantidad de libros asociados (para proteger la integridad al eliminar).</summary>
        public int ContarLibros(int idAutor)
        {
            return EjecutarEscalar("SELECT COUNT(*) FROM Libros WHERE IdAutor = @IdAutor",
                Parametro("@IdAutor", idAutor));
        }
    }
}
