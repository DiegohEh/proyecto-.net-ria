
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
    public class MantenimientoComentario
    {
        private ComentarioMapper _mapper;

        public MantenimientoComentario()
        {
            _mapper = new ComentarioMapper();
        }

        public void Create(DTOComentario dtoComentario)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var current = uow.ComentarioRepository.Get(dtoComentario.Id);
                    var comentario = _mapper.MapToEntity(dtoComentario);
                    uow.ComentarioRepository.Create(comentario);
                    uow.SaveChanges();
                }
            }
            catch (Exception) { throw; }
        }

        public List<DTOComentario> GetByProyecto(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var lista = uow.ComentarioRepository.GetByProyecto(id);
                List<DTOComentario> resultado = new List<DTOComentario>();
                foreach (var comentario in lista)
                {
                    resultado.Add(_mapper.MapToObject(comentario));
                }
                return resultado;
            }
        }

        public DTOComentario Get(int id)
        {
            using (var uow = new UnitOfWork())
            {
                return _mapper.MapToObject(uow.ComentarioRepository.Get(id));
            }
        }
    }
}
