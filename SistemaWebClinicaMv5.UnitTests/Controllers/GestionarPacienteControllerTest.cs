using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaWebClinicaMvc5.Core.Interfaces.IPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinicaMv5.UnitTests.Controllers
{
    class GestionarPacienteControllerTest
    {
        private readonly IPacienteServicio _pacienteServicio;

        public GestionarPacienteControllerTest(IPacienteServicio pacienteServicio)
        {
            _pacienteServicio = pacienteServicio;
        }

        [TestMethod]
        public void RegistrarPaciente()
        {

        }
    }
}
