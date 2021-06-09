using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaShop.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Visitas { get; set; }
        public string RutaImgPortada { get; set; }
        public double? PromedioValoraciones { get; set; }
        public DateTime FechaCreado { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
    }
}