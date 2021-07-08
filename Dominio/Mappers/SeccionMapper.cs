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
    public class SeccionMapper
    {
        public DTOSeccion MapToObject(seccion seccion)
        {
            if (seccion == null) return null;

            return new DTOSeccion()
            {
                Id = seccion.id,
                IdProyecto = seccion.idProyecto
            };
        }
        public seccion MapToEntity(DTOSeccion seccion)
        {
            if (seccion == null)
                return null;

            return new seccion()
            {
                id = seccion.Id,
                idProyecto = seccion.IdProyecto
            };
        }
    }
}
