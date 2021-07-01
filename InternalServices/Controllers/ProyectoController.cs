using Common.DataTransferObjects;
using Dominio.General;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InternalServices.Controllers
{
    public class ProyectoController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<DTOProyecto> GetAll()
        {
            MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
            return mantenimiento.GetAll();

        }
        public IHttpActionResult GetByTitulo(string titulo)
        {
            MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
            var proyecto = mantenimiento.Get(titulo);

            if (proyecto == null)
                return NotFound();

            return Ok(proyecto);

        }
        public IHttpActionResult Get(int id)
        {
            MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
            var proyecto = mantenimiento.Get(id);

            if (proyecto == null)
                return NotFound();

            return Ok(proyecto);

        }

        [HttpPost]
        public IHttpActionResult Create(DTOProyecto proyecto)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
                mantenimiento.Create(proyecto);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;

                logger.Error(ex, "ProyectoController/Create");
            }

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult Update(DTOProyecto proyecto)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
                mantenimiento.Update(proyecto);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult Remove([FromBody] int id)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
                mantenimiento.Remove(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }

            return Ok(response);
        }
    }
}
