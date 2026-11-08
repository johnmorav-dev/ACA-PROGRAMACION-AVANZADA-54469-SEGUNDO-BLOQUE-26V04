using Microsoft.Data.SqlClient;
using AcaBiblioteca.Entidades;

namespace AcaBiblioteca.Negocio
{
    /// <summary>Funcionalidad común a todas las clases de la capa de negocio.</summary>
    public abstract class NegocioBase
    {
        /// <summary>
        /// Valida cualquier entidad del sistema. Gracias al polimorfismo se
        /// ejecuta el método Validar() propio de cada clase (Libro, Usuario, Autor...).
        /// </summary>
        protected static void ValidarEntidad(EntidadBase entidad)
        {
            List<string> errores = entidad.Validar();

            if (errores.Count > 0)
            {
                throw new ReglaNegocioException(string.Join(Environment.NewLine, errores));
            }
        }

        /// <summary>
        /// Ejecuta una operación de base de datos y convierte los errores de
        /// integridad de SQL Server en mensajes comprensibles para el usuario.
        /// </summary>
        protected static T Ejecutar<T>(Func<T> operacion)
        {
            try
            {
                return operacion();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new ReglaNegocioException(
                    "Ya existe un registro con esos datos (restricción de unicidad).");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new ReglaNegocioException(
                    "La operación no se puede realizar porque afecta registros relacionados " +
                    "o incumple una restricción de la base de datos.");
            }
        }
    }
}
