using SistemaWebClinicaMvc5.Core.Interfaces.IPaciente;
using System;
using System.Collections.Generic;
using SistemaWebClinicaMvc5.Core.Entidades;
using SistemaWebClinicaMvc5.Core.Interfaces;

namespace SistemaWebClinicaMvc5.Negocio.Servicios
{
    public class PacienteServicio: IPacienteServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public PacienteServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Paciente> ListarPacientes()
        {
            //aqui irán las validaciones (reglas de negocios) antes de realizar la opreacion en base de datos y retornar el resultado
            return _unitOfWork.PacienteRepositorio.ListarPacientes();
        }

        public Paciente BuscarPacientePorDni(string dni)
        {
            throw new NotImplementedException();
        }

        public bool RegistrarPaciente(Paciente objPaciente)
        {
            //aqui irán las validaciones (reglas de negocios) antes de realizar la opreacion en base de datos y retornar el resultado
            return _unitOfWork.PacienteRepositorio.RegistrarPaciente(objPaciente);
        }

        public bool EliminarPaciente(int? id)
        {
            if (id==null)
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public bool ActualizarPaciente(Paciente objActualizaPaciente)
        {
            //aqui irán las validaciones (reglas de negocios) antes de realizar la opreacion en base de datos y retornar el resultado
            return _unitOfWork.PacienteRepositorio.ActualizarPaciente(objActualizaPaciente);
        }
    }
}
