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
    public class VideoMapper
    {
        public DTOVideo MapToObject(video video)
        {
            if (video == null) return null;

            return new DTOVideo()
            {
                Id = video.id,
                IdSeccion = video.idSeccion,
                RutaUrl = video.rutaUrl,
            };
        }
        public video MapToEntity(DTOVideo video)
        {
            if (video == null)
                return null;

            return new video()
            {
                id = video.Id,
                idSeccion = video.IdSeccion,
                rutaUrl = video.RutaUrl,
            };
        }
    }
}
