using SistemaWebClinicaMvc5.Core.Interfaces.IEmpleado;
using System;
using System.Web.Mvc;

namespace SistemaWebClinicaMvc5.Front.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IEmpleadoServicio _empleadoServicio;

        public AccesoController(IEmpleadoServicio empleadoServicio)
        {
            _empleadoServicio = empleadoServicio;
        }

        // GET: Acceso
        public ActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            try
            {
                var _User = _empleadoServicio.AccesoEmpleadoSistema(User, Pass);
                if (_User.Estado)
                {
                    Session["Usuario"] = _User;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Error = "Ha ocurrido un error...";
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Ha ocurrido un error...";
                return View();
            }
        }

    }
}