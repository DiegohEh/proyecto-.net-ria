using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignProNamespace.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int? IdProyecto { get; set; }
        public string Nombre { get; set; }
    }
}