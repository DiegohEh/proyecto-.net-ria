using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaShop.Models
{
    public class Texto
    {
        public int Id { get; set; }
        public int? IdSeccion { get; set; }
        public string Contenido{ get; set; }
    }
}