//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persistencia.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class comentario
    {
        public int id { get; set; }
        public int idProyecto { get; set; }
        public int idUsuario { get; set; }
        public string contenido { get; set; }
    
        public virtual proyecto proyecto { get; set; }
        public virtual usuario usuario { get; set; }
    }
}