using Dominio.Repositories;
using Persistencia.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DataModel
{
    public class UnitOfWork : IDisposable
    {
        protected readonly TiendaDB _context;

        private ArticuloRepository _articuloRepository;

        public ArticuloRepository ArticuloRepository
        {
            get
            {
                if (this._articuloRepository == null)
                    this._articuloRepository = new ArticuloRepository(this._context);

                return this._articuloRepository;
            }
        }

        public UnitOfWork()
        {
            this._context = new TiendaDB();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public virtual int SaveChanges()
        {
            return this._context.SaveChanges();
        }

    }
}
