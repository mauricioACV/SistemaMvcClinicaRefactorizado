using SistemaWebClinicaMvc5.Core.Interfaces;
using SistemaWebClinicaMvc5.Core.Interfaces.IEmpleado;
using SistemaWebClinicaMvc5.Core.Interfaces.IPaciente;
using System.Data.SqlClient;

namespace SistemaWebClinicaMvc5.Data.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection _conexion;
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly IEmpleadoRepositorio _empleadoRepositorio;

        public UnitOfWork()
        {
            _conexion = Conexion.ObtenerInstancia().ObtenerConexionBd();
        }

        public IPacienteRepositorio PacienteRepositorio => _pacienteRepositorio ?? new PacienteRepositorio(_conexion);

        public IEmpleadoRepositorio EmpleadoRepositorio => _empleadoRepositorio ?? new EmpleadoRepositorio(_conexion);

        public void Dispose()
        {
            //if (_conexion != null)
            //{
                _conexion?.Dispose();
            //}
        }
    }
}
