﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignProNamespace.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public int IdUsuario { get; set; }
        public string Contenido { get; set; }
    }
}