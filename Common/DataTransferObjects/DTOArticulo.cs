using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class DTOArticulo
    {
        public long? Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }

        public string NAM { get; set; }


    }
}
