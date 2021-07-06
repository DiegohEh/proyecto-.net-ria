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
    public class MensajeRepository
    {
        private readonly designProEntities _context;

        public MensajeRepository(designProEntities context)
        {
            this._context = context;
        }
        
        public mensaje Get(int id)
        {
            return this._context.mensaje.FirstOrDefault(a => a.id == id);
        }
        public List<mensaje> GetConversation(int id)
        {
            return this._context.mensaje.Select(a => a).ToList();
        }

        public void Create(mensaje mensaje)
        {
            this._context.mensaje.Add(mensaje);
        }
    }
}
