using SistemaWebClinicaMvc5.Core.Entidades;
using SistemaWebClinicaMvc5.Core.Interfaces.IPaciente;
using SistemaWebClinicaMvc5.Front.Responses;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaWebClinicaMvc.front.Controllers
{
    public class GestionarPacienteController : Controller
    {
        private readonly IPacienteServicio _pacienteServicio;

        public GestionarPacienteController(IPacienteServicio pacienteServicio)
        {
            _pacienteServicio = pacienteServicio;
        }
        // GET: GestionarPaciente
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListarPacientes()
        {
            var ListaPacientes = _pacienteServicio.ListarPacientes();
            var response = new FrontResponse<IEnumerable<Paciente>>(ListaPacientes);
            return Json(new { data = ListaPacientes });
        }

        [HttpPost]
        public ActionResult RegistrarPaciente(Paciente objPaciente)
        {
            bool registrarPacientes = _pacienteServicio.RegistrarPaciente(objPaciente);
            var response = new FrontResponse<bool>(registrarPacientes);
            return Json(response);
        }

        [HttpPost]
        public ActionResult ActualizarPaciente(Paciente objActualizaPaciente)
        {
            bool actualizarPacientes = _pacienteServicio.ActualizarPaciente(objActualizaPaciente);
            var response = new FrontResponse<bool>(actualizarPacientes);
            return Json(response);
        }

    }
}