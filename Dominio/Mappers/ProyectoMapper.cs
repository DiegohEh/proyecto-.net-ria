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
    public class ProyectoMapper
    {
        public DTOProyecto MapToObject(proyecto proyecto)
        {
            if (proyecto == null) return null;

            return new DTOProyecto()
            {
                Id = proyecto.id,
                Titulo = proyecto.titulo,
                Visitas = proyecto.visitas ?? 0,
                RutaImgPortada = proyecto.rutaImgPortada,
                PromedioValoraciones = proyecto.promedioValoraciones,
                FechaCreado = proyecto.fechaCreado,
                IdCategoria = proyecto.idCategoria ?? 0,
                IdUsuario = proyecto.idUsuario ?? 0,
            };
        }
        public proyecto MapToEntity(DTOProyecto proyecto)
        {
            if (proyecto == null)
                return null;

            return new proyecto()
            {
                id = proyecto.Id,
                titulo = proyecto.Titulo,
                visitas = proyecto.Visitas,
                rutaImgPortada = proyecto.RutaImgPortada,
                promedioValoraciones = proyecto.PromedioValoraciones,
                fechaCreado = proyecto.FechaCreado,
                idCategoria = proyecto.IdCategoria,
                idUsuario = proyecto.IdUsuario,
            };
        }
    }
}
