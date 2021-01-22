using SistemaWebClinicaMvc5.Core.Entidades;
using SistemaWebClinicaMvc5.Core.Interfaces;
using SistemaWebClinicaMvc5.Core.Interfaces.IEmpleado;
using System;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebClinicaMvc5.Front.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AutorizaRol : AuthorizeAttribute
    {
        private readonly IEmpleadoServicio _empleadoServicio;
        private Empleado rolUsuarioSession;
        private readonly int Rol;

        public AutorizaRol(int rol = 0)
        {
            Rol = rol;
        }
        public AutorizaRol(IEmpleadoServicio empleadoServicio)
        {
            _empleadoServicio = empleadoServicio;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                rolUsuarioSession = (Empleado)HttpContext.Current.Session["Usuario"];
                var UsuarioBaseDatos = rolUsuarioSession.IdTipoEmpleado;

                if (UsuarioBaseDatos == 3)
                {
                    filterContext.Result = new RedirectResult("~/Error/Unauthorized?msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/Unauthorized?msjeErrorExcepcion=" + ex.Message);
            }
        }
    }
}