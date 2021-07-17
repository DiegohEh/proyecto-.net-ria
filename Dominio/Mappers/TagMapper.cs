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
    public class TagMapper
    {
        public DTOTag MapToObject(tag tag)
        {
            if (tag == null) return null;

            return new DTOTag()
            {
                Id = tag.id,
                IdProyecto = tag.idProyecto,
                Nombre = tag.nombre,
            };
        }
        public tag MapToEntity(DTOTag tag)
        {
            if (tag == null)
                return null;

            return new tag()
            {
                id = tag.Id,
                idProyecto = tag.IdProyecto,
                nombre = tag.Nombre,
            };
        }
    }
}
