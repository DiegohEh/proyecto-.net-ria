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
        protected readonly designProEntities _context;

        private ProyectoRepository _proyectoRepository;
        private ValoracionRepository _valoracionRepository;
        private UsuarioRepository _usuarioRepository;
        private MensajeRepository _mensajeRepository;
        private ComentarioRepository _comentarioRepository;
        private SeccionRepository _seccionRepository;
        private CategoriaRepository _categoriaRepository;

        public ProyectoRepository ProyectoRepository
        {
            get
            {
                if (this._proyectoRepository == null)
                    this._proyectoRepository = new ProyectoRepository(this._context);

                return this._proyectoRepository;
            }
        }

        public CategoriaRepository CategoriaRepository
        {
            get
            {
                if (this._categoriaRepository == null)
                    this._categoriaRepository = new CategoriaRepository(this._context);

                return this._categoriaRepository;
            }
        }

        public ValoracionRepository ValoracionRepository
        {
            get
            {
                if (this._valoracionRepository == null)
                    this._valoracionRepository = new ValoracionRepository(this._context);

                return this._valoracionRepository;
            }
        }

        public UsuarioRepository UsuarioRepository
        {
            get
            {
                if (this._usuarioRepository == null)
                    this._usuarioRepository = new UsuarioRepository(this._context);

                return this._usuarioRepository;
            }
        }

        public SeccionRepository SeccionRepository
        {
            get
            {
                if (this._seccionRepository == null)
                    this._seccionRepository = new SeccionRepository(this._context);

                return this._seccionRepository;
            }
        }

        public ComentarioRepository ComentarioRepository
        {
            get
            {
                if (this._comentarioRepository == null)
                    this._comentarioRepository = new ComentarioRepository(this._context);

                return this._comentarioRepository;
            }
        }

        public MensajeRepository MensajeRepository
        {
            get
            {
                if (this._mensajeRepository == null)
                    this._mensajeRepository = new MensajeRepository(this._context);

                return this._mensajeRepository;
            }
        }

        public UnitOfWork()
        {
            this._context = new designProEntities();
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
