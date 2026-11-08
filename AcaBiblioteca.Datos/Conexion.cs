using Microsoft.Data.SqlClient;

namespace AcaBiblioteca.Datos
{
    /// <summary>
    /// Gestiona la cadena de conexión con SQL Server.
    /// Es la única clase del sistema que conoce los datos del servidor.
    /// </summary>
    public class Conexion
    {
        /// <summary>
        /// Cadena de conexión con la instancia SQL2022 instalada en clase.
        /// - Server=.\SQL2022            -> instancia SQL2022 del equipo local.
        ///   (Si instaló la instancia predeterminada use Server=localhost).
        /// - Database=AcaBiblioteca      -> base de datos creada con el script.
        /// - Integrated Security=true    -> autenticación de Windows.
        /// - TrustServerCertificate=true -> confía en el certificado local
        ///   (equivale a "Certificado de servidor de confianza" en SSMS).
        /// </summary>
        private readonly string cadenaConexion =
            "Server=.\\SQL2022;Database=AcaBiblioteca;Integrated Security=true;TrustServerCertificate=true;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        /// <summary>Intenta abrir la conexión para verificar que el servidor responde.</summary>
        public bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();
                    mensaje = $"Conectado a {cn.DataSource} / {cn.Database}";
                    return true;
                }
            }
            catch (SqlException ex)
            {
                mensaje = "Sin conexión con SQL Server: " + ex.Message;
                return false;
            }
        }
    }
}
