using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ADO.NET.DataTrasnferObjects
{
    public class DTOPersistenciaValoracion
    {
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
        public double? Valor { get; set; }
    }
}
