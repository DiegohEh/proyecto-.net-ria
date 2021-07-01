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
    public class ProyectoRepository
    {
        private readonly designProEntities _context;

        public ProyectoRepository(designProEntities context)
        {
            this._context = context;
        }

        public proyecto Get(int id)
        {
            return this._context.proyecto.FirstOrDefault(a => a.id == id);

        }

        public proyecto Get(string titulo)
        {
            return this._context.proyecto.FirstOrDefault(a => a.titulo == titulo);
        }

        public List<proyecto> GetAll()
        {
            return this._context.proyecto.Select(a => a).ToList();
        }

        public void Create(proyecto proyecto)
        {
            this._context.proyecto.Add(proyecto);
        }

        public void Update(proyecto proyecto)
        {
            var entity = this.Get(proyecto.id);
            entity.titulo = proyecto.titulo;
            entity.visitas = proyecto.visitas;
            entity.rutaImgPortada = proyecto.rutaImgPortada;
            entity.promedioValoraciones = proyecto.promedioValoraciones;
            entity.fechaCreado = proyecto.fechaCreado;
            entity.idCategoria = proyecto.idCategoria;
            entity.idUsuario = proyecto.idUsuario;

            //LogAction(proyecto, LogActionsDb.Edicion);
        }

        public void Remove(int id)
        {
            var entity = this.Get(id);
            this._context.proyecto.Remove(entity);

            //LogAction(entity, LogActionsDb.Eliminacion);
        }

        /*public void LogAction(Proyecto proyecto, string accion)
        {
            var log = new LogProyectos()
            {
                Accion = accion,
                Codigo = proyecto.Codigo,
                Descripcion = proyecto.Descripcion,
                Fecha = DateTime.Now,
                IdProyecto = proyecto.Id,
                Precio = proyecto.Precio
            };

            this._context.LogProyectos.Add(log);
        }*/
    }
}
