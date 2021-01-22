using SistemaWebClinicaMvc5.Core.Entidades;
using SistemaWebClinicaMvc5.Front.Controllers;
using System;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebClinicaMvc5.Front.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private Empleado Usuario;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                Usuario = (Empleado)HttpContext.Current.Session["Usuario"];

                if (Usuario == null)
                {
                    if(filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Acceso/Login");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }
            
        }
    }
}