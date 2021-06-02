using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Modelo;
using Persistencia.ADO.NET.DataTrasnferObjects;

namespace Dominio.Mappers
{
    public class ArticuloMapper
    {
        public DTOPersistenciaArticulo MapToEntity(Articulo articulo)
        {
            if (articulo == null)
                return null;

            return new DTOPersistenciaArticulo()
            {
                Id = articulo.Id,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio
            };
        }
        public Articulo MapToObject(DTOPersistenciaArticulo articulo)
        {
            if (articulo == null)
                return null;

            return new Articulo()
            {
                Id = articulo.Id,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio
            };
        }
    }
}
