using System.Data;
using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Clase base de los DAO (Data Access Object). Reúne el código repetido
    /// para ejecutar consultas parametrizadas, de modo que cada DAO solo
    /// escribe su SQL. Todas las clases DAO heredan de ella.
    /// </summary>
    public abstract class DaoBase
    {
        protected readonly Conexion conexion = new Conexion();

        /// <summary>Ejecuta un SELECT y devuelve el resultado en un DataTable.</summary>
        protected DataTable EjecutarConsulta(string consulta, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, cn))
            {
                comando.Parameters.AddRange(parametros);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
        }

        /// <summary>Ejecuta INSERT, UPDATE o DELETE y devuelve las filas afectadas.</summary>
        protected int EjecutarComando(string consulta, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, cn))
            {
                comando.Parameters.AddRange(parametros);
                cn.Open();
                return comando.ExecuteNonQuery();
            }
        }

        /// <summary>Ejecuta una consulta que devuelve un único valor (COUNT, SUM...).</summary>
        protected int EjecutarEscalar(string consulta, params SqlParameter[] parametros)
        {
            using (SqlConnection cn = conexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(consulta, cn))
            {
                comando.Parameters.AddRange(parametros);
                cn.Open();
                object resultado = comando.ExecuteScalar();
                return resultado == null || resultado == DBNull.Value ? 0 : Convert.ToInt32(resultado);
            }
        }

        /// <summary>Crea un parámetro convirtiendo null en DBNull.Value.</summary>
        protected static SqlParameter Parametro(string nombre, object valor)
        {
            return new SqlParameter(nombre, valor ?? DBNull.Value);
        }

        /// <summary>Convierte un texto vacío en NULL para las columnas opcionales.</summary>
        protected static object TextoONulo(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor;
        }
    }
}
