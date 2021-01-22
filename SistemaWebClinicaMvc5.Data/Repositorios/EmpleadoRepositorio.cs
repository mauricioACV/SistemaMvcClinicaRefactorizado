using SistemaWebClinicaMvc5.Core.Entidades;
using SistemaWebClinicaMvc5.Core.Interfaces.IEmpleado;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaWebClinicaMvc5.Data.Repositorios
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly SqlConnection _conexion;
        public EmpleadoRepositorio(SqlConnection ConexionDb)
        {
            _conexion = ConexionDb;
        }

        public Empleado AccesoEmpleadoSistema(string user, string password)
        {
            var Usuario = user.ToUpper();
            SqlCommand cmd = null;
            Empleado objEmpleado = null;
            SqlDataReader dr = null;

            try
            {
                cmd = new SqlCommand("spAccesoSistema", _conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@prmUser", Usuario);
                cmd.Parameters.AddWithValue("@prmPass", password);
                _conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objEmpleado = new Empleado
                    {
                        Id = Convert.ToInt32(dr["idEmpleado"].ToString()),
                        Usuario = dr["usuario"].ToString(),
                        Clave = dr["clave"].ToString(),
                        Nombre = dr["nombres"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        Estado = Convert.ToBoolean(dr["estado"]),
                        IdTipoEmpleado = Convert.ToInt32(dr["idTipoEmpleado"])
                    };
                }
            }
            catch (Exception ex)
            {
                objEmpleado = null;
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return objEmpleado;
        }

    }
}
