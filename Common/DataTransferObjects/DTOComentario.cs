using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class DTOComentario
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
        public string Contenido { get; set; }
    }
}
