using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinicaMvc5.Data
{
    public class Conexion
    {
        #region "Singleton"
        private static Conexion conexion = null;
        private Conexion() { }
        public static Conexion ObtenerInstancia()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }

        #endregion

        public SqlConnection ObtenerConexionBd()
        {
            SqlConnection conexion = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DbConexion"].ToString() 
            };
            return conexion;
        }
    }
}
