using SistemaWebClinicaMvc5.Core.Entidades;
using SistemaWebClinicaMvc5.Core.Interfaces;
using SistemaWebClinicaMvc5.Core.Interfaces.IEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinicaMvc5.Negocio.Servicios
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpleadoServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Empleado AccesoEmpleadoSistema(string user, string password)
        {
            return _unitOfWork.EmpleadoRepositorio.AccesoEmpleadoSistema(user, password);
        }
    }
}
