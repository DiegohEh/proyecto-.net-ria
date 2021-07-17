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
    public class ValoracionRepository
    {
        private readonly designProEntities _context;

        public ValoracionRepository(designProEntities context)
        {
            this._context = context;
        }

        public valoracion Get(int id)
        {
            return this._context.valoracion.FirstOrDefault(a => a.idProyecto == id);
        }

        public void UpdateValoraciones(valoracion valoracion)
        {
            var entity = this.Get(valoracion.idProyecto);
            entity.idUsuario = valoracion.idUsuario;
            entity.valoracion1 = valoracion.valoracion1;
        }
    }
}
