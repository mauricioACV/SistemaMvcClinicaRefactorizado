using SistemaWebClinicaMvc5.Core.Entidades;
using System.Collections.Generic;

namespace SistemaWebClinicaMvc5.Core.Interfaces.IPaciente
{
    public interface IPacienteRepositorio
    {
        List<Paciente> ListarPacientes();

        bool RegistrarPaciente(Paciente objPaciente);

        bool EliminarPaciente(int id);

        bool ActualizarPaciente(Paciente objPaciente);

        Paciente BuscarPacientePorDni(string dni);
    }
}
