using SistemaWebClinicaMvc5.Core.Entidades;

namespace SistemaWebClinicaMvc5.Core.Interfaces.IEmpleado
{
    public interface IEmpleadoRepositorio
    {
        Empleado AccesoEmpleadoSistema(string user, string password);
    }
}
