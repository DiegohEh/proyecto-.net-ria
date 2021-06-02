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
    public class ArticuloMapper
    {
        public DTOArticulo MapToObject(Articulo articulo)
        {
            if (articulo == null)
                return null;

            return new DTOArticulo()
            {
                Id = articulo.Id,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio
            };
        }
        public Articulo MapToEntity(DTOArticulo articulo)
        {
            if (articulo == null)
                return null;

            return new Articulo()
            {
                Id = articulo.Id ?? 0,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio
            };
        }
    }
}
