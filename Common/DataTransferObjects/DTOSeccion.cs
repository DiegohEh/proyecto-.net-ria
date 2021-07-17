﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class DTOSeccion
    {
        public int Id { get; set; }
        public int? IdProyecto { get; set; }
        public string contenidoTexto { get; set; }
        public string rutaUrlImagen { get; set; }
        public string rutaUrlVideo { get; set; }
    }
}
