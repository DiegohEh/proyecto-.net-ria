using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignProNamespace.Models
{
    public class Valoracion
    {
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
        public double? Valor { get; set; }
    }
}