using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinicaMvc5.Core.Entidades
{
    public class TipoEmpleado
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}
