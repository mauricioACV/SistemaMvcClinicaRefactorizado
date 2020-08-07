﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinicaMvc5.Data
{
    public class Conexion
    {
        #region "Patron Singleton"
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
                ConnectionString = "Data Source=EXTDV-MCAMPUSAN\\SQLEXPRESS;Initial Catalog=DBClinica;User ID=sa;Password=Javieraamanda1"
            };
            return conexion;
        }
    }
}
