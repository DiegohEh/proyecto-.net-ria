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
    public class CategoriaMapper
    {
        public DTOCategoria MapToObject(categoria categoria)
        {
            if (categoria == null) return null;

            return new DTOCategoria()
            {
                Id = categoria.id,
                Nombre = categoria.nombre,
    };
        }
        public categoria MapToEntity(DTOCategoria categoria)
        {
            if (categoria == null)
                return null;

            return new categoria()
            {
                id = categoria.Id,
                nombre = categoria.Nombre,
            };
        }
    }
}
