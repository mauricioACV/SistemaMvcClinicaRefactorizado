using SistemaWebClinicaMvc5.Core.Entidades;

namespace SistemaWebClinicaMvc5.Core.Interfaces.IEmpleado
{
    public interface IEmpleadoServicio
    {
        Empleado AccesoEmpleadoSistema(string user, string password);
    }
}
