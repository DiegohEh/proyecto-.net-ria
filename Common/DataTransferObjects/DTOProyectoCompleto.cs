using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class DTOProyectoCompleto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string RutaImgPortada { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string contenidoTexto { get; set; }
        public string rutaUrlImagen { get; set; }
        public string rutaUrlVideo { get; set; }
    }
}
