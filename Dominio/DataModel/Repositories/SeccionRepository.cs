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
    public class SeccionRepository
    {
        private readonly designProEntities _context;

        public SeccionRepository(designProEntities context)
        {
            this._context = context;
        }

        public void CreateSeccion(seccion seccion)
        {
            this._context.seccion.Add(seccion);
        }

        public seccion GetSeccion(int id)
        {
            return this._context.seccion.FirstOrDefault(a => a.id == id);
        }

        public void UpdateSeccion(seccion seccion)
        {
            var entity = this.GetSeccion(seccion.id);
            entity.contenidoTexto = seccion.contenidoTexto;
            entity.rutaUrlImagen = seccion.rutaUrlImagen;
            entity.rutaUrlVideo = seccion.rutaUrlImagen;
        }
    }
}
