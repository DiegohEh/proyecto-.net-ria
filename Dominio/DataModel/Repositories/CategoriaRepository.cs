using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DataModel.DbConstants;
using Dominio.General;
using Dominio.Mappers;
using Persistencia.ADO.NET;
using Persistencia.Database;

namespace Dominio.Repositories
{
    public class CategoriaRepository
    {
        private readonly designProEntities _context;

        public CategoriaRepository(designProEntities context)
        {
            this._context = context;
        }

        public categoria GetCategoria(string nombre)
        {
            return this._context.categoria.FirstOrDefault(a => a.nombre == nombre);
        }
    }
}
