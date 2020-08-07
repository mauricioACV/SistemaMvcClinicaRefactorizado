using SistemaWebClinicaMvc5.Core.Entidades;
using SistemaWebClinicaMvc5.Core.Interfaces.IPaciente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinicaMvc5.Data.Repositorios
{
    public class PacienteRepositorio: IPacienteRepositorio
    {
        private readonly SqlConnection _conexion;
        public PacienteRepositorio()
        {
            _conexion = Conexion.ObtenerInstancia().ObtenerConexionBd();
        }

        public List<Paciente> ListarPacientes()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Paciente> lista = new List<Paciente>();

            try
            {
                var query = @"SELECT p.idPaciente,p.nombres,p.apPaterno,p.apMaterno,p.edad,p.sexo,p.nroDocumento,p.direccion, p.telefono,p.estado
                               FROM Paciente p WHERE p.estado=1";
                cmd = new SqlCommand(query, _conexion);
                _conexion.Open();
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    Paciente objPaciente = new Paciente
                    {
                        IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString()),
                        Nombres = dr["nombres"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        ApMaterno = dr["apMaterno"].ToString(),
                        Edad = Convert.ToInt32(dr["edad"].ToString()),
                        Sexo = Convert.ToChar(dr["sexo"].ToString()),
                        NroDocumento = dr["nroDocumento"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Estado = true
                    };

                    lista.Add(objPaciente);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return lista;
        }

        public bool RegistrarPaciente(Paciente objPaciente)
        {
            SqlCommand cmd = null;
            bool response = false;

            try
            {
                var query = @"INSERT INTO Paciente 
                        (nombres, apPaterno, apMaterno, edad, sexo, nroDocumento, direccion, telefono, estado)
                        VALUES 
                        ('" + objPaciente.Nombres + "','" + objPaciente.ApPaterno + "','" + objPaciente.ApMaterno + "'," +
                        "'" + objPaciente.Edad + "','" + objPaciente.Sexo + "','" + objPaciente.NroDocumento + "'," +
                        "'" + objPaciente.Direccion + "','" + objPaciente.Telefono + "','" + objPaciente.Estado + "')";

                cmd = new SqlCommand(query, _conexion);
                _conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) { response = true; }
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return response;
        }

        public bool EliminarPaciente(int id)
        {
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                var query = @"DELETE from Paciente WHERE idPaciente='" + id + "' ";

                cmd = new SqlCommand(query, _conexion);
                _conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) { response = true; }
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                _conexion.Close();
            }

            return response;
        }

        public bool ActualizarPaciente(Paciente objActualizaPaciente)
        {
            bool response = false;
            SqlCommand cmd = null;

            try
            {
                var query = @"UPDATE Paciente SET 
                            nombres = '" + objActualizaPaciente.Nombres + "', " +
                            "apPaterno = '" + objActualizaPaciente.ApPaterno + "', " +
                            "apMaterno = '" + objActualizaPaciente.ApMaterno + "', " +
                            "telefono = '" + objActualizaPaciente.Telefono + "', " +
                            "direccion ='" + objActualizaPaciente.Direccion + "' " +
                            "WHERE idPaciente = '" + objActualizaPaciente.IdPaciente + "'";

                cmd = new SqlCommand(query, _conexion);
                _conexion.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) { response = true; }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _conexion.Close();
            }
            return response;
        }

        public Paciente BuscarPacientePorDni(string dni)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Paciente objPaciente = null;

            try
            {
                var query = @"SELECT p.idPaciente,p.nombres,p.apPaterno,p.apMaterno,p.edad,p.sexo,p.nroDocumento,p.direccion, p.telefono,p.estado
                               FROM Paciente p WHERE p.nroDocumento = '" + dni + "' ";

                cmd = new SqlCommand(query, _conexion);
                _conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objPaciente = new Paciente
                    {
                        IdPaciente = Convert.ToInt32(dr["idPaciente"]),
                        Nombres = dr["nombres"].ToString(),
                        ApPaterno = dr["apPaterno"].ToString(),
                        ApMaterno = dr["apMaterno"].ToString(),
                        Telefono = dr["telefono"].ToString(),
                        Edad = Convert.ToInt32(dr["edad"].ToString()),
                        Sexo = Convert.ToChar(dr["sexo"].ToString())
                    };

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _conexion.Close();
            }

            return objPaciente;
        }
    }
}
