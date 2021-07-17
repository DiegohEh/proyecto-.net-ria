using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignProNamespace.Models
{
    public class Seccion
    {
        public int Id { get; set; }
        public int? IdProyecto { get; set; }
        public string contenidoTexto { get; set; }
        public string rutaUrlImagen { get; set; }
        public string rutaUrlVideo { get; set; }
    }
}