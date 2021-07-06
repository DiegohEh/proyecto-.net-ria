
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
    public class MantenimientoUsuario
    {
        private UsuarioMapper _mapper;

        public MantenimientoUsuario()
        {
            _mapper = new UsuarioMapper();
        }

        public void Create(DTOUsuario dtoUsuario)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {

                    var current = uow.UsuarioRepository.Get(dtoUsuario.Email);

                    if (current != null)
                        throw new Exception("Email de usuario existente.");

                    var usuario = _mapper.MapToEntity(dtoUsuario);

                    uow.UsuarioRepository.Create(usuario);

                    uow.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DTOUsuario> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                var lista = uow.UsuarioRepository.GetAll();
                List<DTOUsuario> resultado = new List<DTOUsuario>();
                foreach (var usuario in lista)
                {
                    resultado.Add(_mapper.MapToObject(usuario));
                }
                return resultado;
            }
        }

        public DTOUsuario Get(string email)
        {
            using (var uow = new UnitOfWork())
            {
                return _mapper.MapToObject(uow.UsuarioRepository.Get(email));
            }
        }

        public DTOUsuario Get(int id)
        {
            using (var uow = new UnitOfWork())
            {
                return _mapper.MapToObject(uow.UsuarioRepository.Get(id));
            }
        }

        public void Update(DTOUsuario usuario)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.UsuarioRepository.Update(_mapper.MapToEntity(usuario));

                    uow.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Remove(int id)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.UsuarioRepository.Remove(id);

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
