using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebClinicaMvc5.Front.Controllers
{
    public class CerrarSesionController : Controller
    {
        // GET: CerraSesion
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("LoginIndex", "Acceso");
        }
    }
}