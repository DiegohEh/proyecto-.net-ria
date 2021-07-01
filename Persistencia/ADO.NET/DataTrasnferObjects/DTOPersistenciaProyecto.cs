using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ADO.NET.DataTrasnferObjects
{
    public class DTOPersistenciaProyecto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Visitas { get; set; }
        public string RutaImgPortada { get; set; }
        public double? PromedioValoraciones { get; set; }
        public DateTime? FechaCreado { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
    }
}
