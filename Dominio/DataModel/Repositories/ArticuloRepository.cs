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
    public class ArticuloRepository
    {
        private readonly TiendaDB _context;

        public ArticuloRepository(TiendaDB context)
        {
            this._context = context;
        }

        public Articulo Get(long id)
        {
            return this._context.Articulos.FirstOrDefault(a => a.Id == id);

        }

        public Articulo Get(string codigo)
        {
            return this._context.Articulos.FirstOrDefault(a => a.Codigo == codigo);
        }

        public List<Articulo> GetAll()
        {
            return this._context.Articulos.Select(a => a).ToList();
        }

        public void Create(Articulo articulo)
        {
            this._context.Articulos.Add(articulo);
        }

        public void Update(Articulo articulo)
        {
            var entity = this.Get(articulo.Id);

            entity.Codigo = articulo.Codigo;
            entity.Descripcion = articulo.Descripcion;
            entity.Precio = articulo.Precio;

            LogAction(articulo, LogActionsDb.Edicion);
        }

        public void Remove(long id)
        {
            var entity = this.Get(id);
            this._context.Articulos.Remove(entity);

            LogAction(entity, LogActionsDb.Eliminacion);
        }

        public void LogAction(Articulo articulo, string accion)
        {
            var log = new LogArticulos()
            {
                Accion = accion,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Fecha = DateTime.Now,
                IdArticulo = articulo.Id,
                Precio = articulo.Precio
            };

            this._context.LogArticulos.Add(log);
        }
    }
}
