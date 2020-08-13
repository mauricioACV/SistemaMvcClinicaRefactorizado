using SistemaWebClinicaMvc5.Core.Interfaces.IPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinicaMvc5.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IPacienteRepositorio PacienteRepositorio { get; }
    }
}
