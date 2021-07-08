
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
    public class MantenimientoMensaje
    {
        private MensajeMapper _mapper;

        public MantenimientoMensaje()
        {
            _mapper = new MensajeMapper();
        }

        public void Create(DTOMensaje dtoMensaje)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var current = uow.MensajeRepository.Get(dtoMensaje.Id);
                    var mensaje = _mapper.MapToEntity(dtoMensaje);
                    uow.MensajeRepository.Create(mensaje);
                    uow.SaveChanges();
                }
            }
            catch (Exception) { throw; }
        }

        public List<DTOMensaje> GetConversation(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var lista = uow.MensajeRepository.GetConversation(id);
                List<DTOMensaje> resultado = new List<DTOMensaje>();
                foreach (var mensaje in lista)
                {
                    resultado.Add(_mapper.MapToObject(mensaje));
                }
                return resultado;
            }
        }

        public DTOMensaje Get(int id)
        {
            using (var uow = new UnitOfWork())
            {
                return _mapper.MapToObject(uow.MensajeRepository.Get(id));
            }
        }
    }
}
