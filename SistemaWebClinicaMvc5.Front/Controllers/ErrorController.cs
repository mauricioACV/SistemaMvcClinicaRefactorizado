using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebClinicaMvc5.Front.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult Unauthorized(string msjeErrorExcepcion)
        {
            ViewBag.msjeErrorExcepcion = msjeErrorExcepcion;
            return View();
        }
    }
}