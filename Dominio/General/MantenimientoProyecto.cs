
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

        public MantenimientoProyecto()
        {
            _mapper = new ProyectoMapper();
        }

        public void Create(DTOProyecto dtoProyecto)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {

                    var current = uow.ProyectoRepository.Get(dtoProyecto.Titulo);

                    if (current != null)
                        throw new Exception("Título del Proyecto existente.");

                    var proyecto = _mapper.MapToEntity(dtoProyecto);

                    uow.ProyectoRepository.Create(proyecto);

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

        public List<DTOProyecto> GetRecientes()
        {
            using (var uow = new UnitOfWork())
            {
                var lista = uow.ProyectoRepository.GetRecientes();
                List<DTOProyecto> resultado = new List<DTOProyecto>();
                foreach (var proyecto in lista)
                {
                    resultado.Add(_mapper.MapToObject(proyecto));
                }
                return resultado;
            }
        }

        public List<DTOProyecto> GetMayorValorado()
        {
            using (var uow = new UnitOfWork())
            {
                var lista = uow.ProyectoRepository.GetMayorValorado();
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
                return _mapper.MapToObject(uow.ProyectoRepository.Get(titulo));
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
            catch (Exception){throw;}
        }
        
        public void UpdateVisitas(DTOProyecto proyecto)
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

        public void UpdateValoraciones(DTOProyecto proyecto)
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
