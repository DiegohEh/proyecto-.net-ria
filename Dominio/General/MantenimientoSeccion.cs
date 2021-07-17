
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
    public class MantenimientoSeccion
    {
        private SeccionMapper _mapperSeccion;

        public MantenimientoSeccion()
        {
            _mapperSeccion = new SeccionMapper();
        }


        public void CreateSeccion(DTOSeccion dtoseccion)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var seccion = _mapperSeccion.MapToEntity(dtoseccion);

                    uow.SeccionRepository.CreateSeccion(seccion);
                    uow.SaveChanges();
                }
            }
            catch (Exception) { throw; }
        }

        public DTOSeccion GetSeccion(int id)
        {
            using (var uow = new UnitOfWork())
            {
                return _mapperSeccion.MapToObject(uow.SeccionRepository.GetSeccion(id));
            }
        }

        public void UpdateSeccion(DTOSeccion dtoseccion)
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    uow.SeccionRepository.UpdateSeccion(_mapperSeccion.MapToEntity(dtoseccion));
                    uow.SaveChanges();
                }
            }
            catch (Exception) { throw; }
        }
    }
}
