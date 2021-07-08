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
    public class TextoMapper
    {
        public DTOTexto MapToObject(texto texto)
        {
            if (texto == null) return null;

            return new DTOTexto()
            {
                Id = texto.id,
                IdSeccion = texto.idSeccion,
                Contenido = texto.contenido,
            };
        }
        public texto MapToEntity(DTOTexto texto)
        {
            if (texto == null)
                return null;

            return new texto()
            {
                id = texto.Id,
                idSeccion = texto.IdSeccion,
                contenido = texto.Contenido,
            };
        }
    }
}
