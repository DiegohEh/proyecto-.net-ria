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
    public class MensajeMapper
    {
        public DTOMensaje MapToObject(mensaje mensaje)
        {
            if (mensaje == null) return null;

            return new DTOMensaje()
            {
                Id = mensaje.id,
                IdUsuarioEmisor = mensaje.idUsuarioEmisor,
                IdUsuarioReceptor = mensaje.idUsuarioReceptor,
                Contenido = mensaje.contenido,
                Leido = mensaje.leido,
            };
        }
        public mensaje MapToEntity(DTOMensaje mensaje)
        {
            if (mensaje == null)
                return null;

            return new mensaje()
            {
                id = mensaje.Id,
                idUsuarioEmisor = mensaje.IdUsuarioEmisor,
                idUsuarioReceptor = mensaje.IdUsuarioReceptor,
                contenido = mensaje.Contenido,
                leido = mensaje.Leido,
            };
        }
    }
}
