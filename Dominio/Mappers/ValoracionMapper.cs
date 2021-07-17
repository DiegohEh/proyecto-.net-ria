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
    public class ValoracionMapper
    {
        public DTOValoracion MapToObject(valoracion valoracion)
        {
            if (valoracion == null) return null;

            return new DTOValoracion()
            {
                IdProyecto = valoracion.idProyecto,
                IdUsuario = valoracion.idUsuario,
                Valor = valoracion.valoracion1
            };
        }
        public valoracion MapToEntity(DTOValoracion valoracion)
        {
            if (valoracion == null)
                return null;

            return new valoracion()
            {
                idProyecto = valoracion.IdProyecto,
                idUsuario = valoracion.IdUsuario,
                valoracion1 = valoracion.Valor
            };
        }
    }
}
