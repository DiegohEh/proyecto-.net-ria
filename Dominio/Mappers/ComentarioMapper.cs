using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.General;
using Persistencia.ADO.NET.DataTrasnferObjects;
using Persistencia.Database;
using Common.DataTransferObjects;

namespace Dominio.Mappers
{
    public class ComentarioMapper
    {
        public DTOComentario MapToObject(comentario comentario)
        {
            if (comentario == null) return null;

            return new DTOComentario()
            {
                Id = comentario.id,
                IdProyecto = comentario.idProyecto,
                IdUsuario = comentario.idUsuario,
                Contenido = comentario.contenido,
            };
        }
        public comentario MapToEntity(DTOComentario comentario)
        {
            if (comentario == null)
                return null;

            return new comentario()
            {
                id = comentario.Id,
                idProyecto = comentario.IdProyecto,
                idUsuario = comentario.IdUsuario,
                contenido = comentario.Contenido,
            };
        }
    }
}
