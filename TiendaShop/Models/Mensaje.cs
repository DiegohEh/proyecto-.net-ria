using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignProNamespace.Models
{
    public class Mensaje
    {
        public int Id { get; set; }
        public int IdUsuarioEmisor { get; set; }
        public int IdUsuarioReceptor { get; set; }
        public string Contenido { get; set; }
        public bool? Leido { get; set; }
    }
}