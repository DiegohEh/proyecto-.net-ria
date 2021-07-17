
using Common.DataTransferObjects;
using Dominio.DataModel;
using Dominio.Mappers;
using Dominio.Repositories;
using Persistencia.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.General
{
    public class MantenimientoProyecto
    {
        private ProyectoMapper _mapper;
        private ValoracionMapper _mapperValoracion;
        private SeccionMapper _mapperSeccion;
        private CategoriaMapper _mapperCategoria;
        private TagMapper _mapperTag;

        public MantenimientoProyecto()
        {
            _mapper = new ProyectoMapper();
            _mapperValoracion = new ValoracionMapper();
            _mapperSeccion = new SeccionMapper();
            _mapperTag = new TagMapper();
        }

        public void Create(DTOProyecto dtoProyecto, DTOTag dtoTags, DTOSeccion dtoSeccion)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {

                    var current = uow.ProyectoRepository.GetByTitulo(dtoProyecto.Titulo);
                    var current1 = uow.ProyectoRepository.GetByIdUsuario(dtoProyecto.IdUsuario);

                    if (current != null && current1 != null)
                        throw new Exception("Título del Proyecto existente.");

                    var pr = _mapper.MapToEntity(dtoProyecto);
                    var ta = _mapperTag.MapToEntity(dtoTags);
                    var se = _mapperSeccion.MapToEntity(dtoSeccion);

                    uow.ProyectoRepository.Create(pr, ta, se);

                    uow.SaveChanges();
                }
            }
            catch (Exception) 
            { 
                throw;
            }
        }

        public List<DTOProyecto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                var lista = uow.ProyectoRepository.GetAll();
                List<DTOProyecto> resultado = new List<DTOProyecto>();
                foreach (var proyecto in lista)
                {
                    resultado.Add(_mapper.MapToObject(proyecto));
                }
                return resultado;
            }
        }

        public List<DTOProyecto> GetBarraDeBusqueda(string busqueda)
        {
            using (var uow = new UnitOfWork())
            {
                var lista = uow.ProyectoRepository.GetBarraDeBusqueda(busqueda);
                List<DTOProyecto> resultado = new List<DTOProyecto>();
                foreach (var proyecto in lista)
                {
                    resultado.Add(_mapper.MapToObject(proyecto));
                }
                return resultado;
            }
        }

        public DTOProyecto GetByTitulo(string titulo)
        {
            using (var uow = new UnitOfWork())
            {
                return _mapper.MapToObject(uow.ProyectoRepository.GetByTitulo(titulo));
            }
        }

        public DTOProyecto Get(int id)
        {
            using (var uow = new UnitOfWork())
            {
                return _mapper.MapToObject(uow.ProyectoRepository.Get(id));
            }
        }

        public void Update(DTOProyecto proyecto)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.ProyectoRepository.Update(_mapper.MapToEntity(proyecto));

                    uow.SaveChanges();
                }
            }
            catch (Exception) { throw; }
        }
        
        public void UpdateVisitas(DTOProyecto proyecto)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.ProyectoRepository.UpdateVisitas(_mapper.MapToEntity(proyecto));
                    uow.SaveChanges();
                }
            }
            catch (Exception) { throw; }
        }

        public void UpdateValoraciones(DTOValoracion valoracion)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.ValoracionRepository.UpdateValoraciones(_mapperValoracion.MapToEntity(valoracion));
                    uow.SaveChanges();
                }
            }
            catch (Exception) { throw; }
        }

        public void Remove(int id)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.ProyectoRepository.Remove(id);

                    uow.SaveChanges();
                }
            }
            catch (Exception) { throw; }
        }
    }
}
