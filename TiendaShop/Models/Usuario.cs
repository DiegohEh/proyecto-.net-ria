using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaShop.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNac { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string RutaImgPerfil { get; set; }
        public string Profesion { get; set; }
        public string Empresa { get; set; }
        public string UrlSitioWebProfesional { get; set; }
        public string Descripcion { get; set; }
        public int? VisitasTotales { get; set; }
        public double? PromedioValoraciones { get; set; }
    }
}