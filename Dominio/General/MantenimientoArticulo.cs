
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
    public class MantenimientoArticulo
    {
        private ArticuloMapper _mapper;

        public MantenimientoArticulo()
        {
            _mapper = new ArticuloMapper();
        }

        public void Create(DTOArticulo dtoArticulo)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {

                    var current = uow.ArticuloRepository.Get(dtoArticulo.Codigo);

                    if (current != null)
                        throw new Exception("Código de artículo existente.");

                    var articulo = _mapper.MapToEntity(dtoArticulo);

                    uow.ArticuloRepository.Create(articulo);

                    uow.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DTOArticulo> GetAll()
        {
            using (var uow = new UnitOfWork())
            {

                var lista = uow.ArticuloRepository.GetAll();

                List<DTOArticulo> resultado = new List<DTOArticulo>();

                foreach (var articulo in lista)
                {
                    resultado.Add(_mapper.MapToObject(articulo));
                }

                return resultado;
            }

        }

        public DTOArticulo Get(string codigo)
        {
            using (var uow = new UnitOfWork())
            {
                return _mapper.MapToObject(uow.ArticuloRepository.Get(codigo));
            }
        }

        public DTOArticulo Get(long id)
        {
            using (var uow = new UnitOfWork())
            {
                return _mapper.MapToObject(uow.ArticuloRepository.Get(id));
            }
        }

        public void Update(DTOArticulo articulo)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.ArticuloRepository.Update(_mapper.MapToEntity(articulo));

                    uow.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Remove(long id)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.ArticuloRepository.Remove(id);

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
