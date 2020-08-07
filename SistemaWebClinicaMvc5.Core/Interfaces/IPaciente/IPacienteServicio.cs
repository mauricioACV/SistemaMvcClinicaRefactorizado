using SistemaWebClinicaMvc5.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinicaMvc5.Core.Interfaces.IPaciente
{
    public interface IPacienteServicio
    {
        List<Paciente> ListarPacientes();

        bool RegistrarPaciente(Paciente objPaciente);

        bool EliminarPaciente(int id);

        bool ActualizarPaciente(Paciente objPaciente);

        Paciente BuscarPacientePorDni(string dni);
    }
}
