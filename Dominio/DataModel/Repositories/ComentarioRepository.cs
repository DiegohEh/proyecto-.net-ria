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
    public class ComentarioRepository
    {
        private readonly designProEntities _context;

        public ComentarioRepository(designProEntities context)
        {
            this._context = context;
        }

        public void Create(comentario comentario)
        {
            this._context.comentario.Add(comentario);
        }

        public List<comentario> GetByProyecto(int id)
        {
            return this._context.comentario.Select(a => a).ToList();
        }

        public comentario Get(int id)
        {
            return this._context.comentario.FirstOrDefault(a => a.id == id);
        }
    }
}
