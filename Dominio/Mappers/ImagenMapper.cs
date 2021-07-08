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
    public class ImagenMapper
    {
        public DTOImagen MapToObject(imagen imagen)
        {
            if (imagen == null) return null;

            return new DTOImagen()
            {
                Id = imagen.id,
                IdSeccion = imagen.idSeccion,
                RutaUrl = imagen.rutaUrl,
            };
        }
        public imagen MapToEntity(DTOImagen imagen)
        {
            if (imagen == null)
                return null;

            return new imagen()
            {
                id = imagen.Id,
                idSeccion = imagen.IdSeccion,
                rutaUrl = imagen.RutaUrl,
            };
        }
    }
}
