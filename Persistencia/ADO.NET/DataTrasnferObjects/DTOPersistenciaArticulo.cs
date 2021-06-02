using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ADO.NET.DataTrasnferObjects
{
    public class DTOPersistenciaArticulo
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }
}
