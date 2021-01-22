using SistemaWebClinicaMvc5.Core.Interfaces.IEmpleado;
using SistemaWebClinicaMvc5.Core.Interfaces.IPaciente;
using System;

namespace SistemaWebClinicaMvc5.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IPacienteRepositorio PacienteRepositorio { get; }
        IEmpleadoRepositorio EmpleadoRepositorio { get; }
    }
}
