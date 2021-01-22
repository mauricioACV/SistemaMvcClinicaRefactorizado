using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinicaMvc5.Core.Entidades
{
    public class Empleado
    {
        public int Id { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }
        public int IdTipoEmpleado {get;set;}
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string NroDocumento { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}
