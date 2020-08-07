using SistemaWebClinicaMvc5.Core.Interfaces.IPaciente;
using System;
using System.Collections.Generic;
using SistemaWebClinicaMvc5.Core.Entidades;

namespace SistemaWebClinicaMvc5.Negocio.Servicios
{
    public class PacienteServicio: IPacienteServicio
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        public PacienteServicio(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }   

        public List<Paciente> ListarPacientes()
        {
            //aqui irán las validaciones a cumplir antes de realizar la opreacion en base de datos y retornar el resultado
            return _pacienteRepositorio.ListarPacientes();
        }

        public Paciente BuscarPacientePorDni(string dni)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarPaciente(Paciente objPaciente)
        {
            //aqui irán las validaciones a cumplir antes de realizar la opreacion en base de datos y retornar el resultado
            return _pacienteRepositorio.RegistrarPaciente(objPaciente);
        }

        public bool EliminarPaciente(int id)
        {
            throw new NotImplementedException();
        }

        public bool ActualizarPaciente(Paciente objActualizaPaciente)
        {
            return _pacienteRepositorio.ActualizarPaciente(objActualizaPaciente);
        }
    }
}
