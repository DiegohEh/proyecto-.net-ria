using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ADO.NET.DataTrasnferObjects
{
    public class DTOPersistenciaTexto
    {
        public int Id { get; set; }
        public int? IdSeccion { get; set; }
        public string Contenido { get; set; }
    }
}
