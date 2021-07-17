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
    public class SeccionController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        public IHttpActionResult CreateSeccion(DTOSeccion dtoseccion)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoSeccion mantenimiento = new MantenimientoSeccion();
                mantenimiento.CreateSeccion(dtoseccion);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;

                logger.Error(ex, "SeccionController/CreateSeccion");
            }

            return Ok(response);
        }

        public IHttpActionResult GetSeccion(int id)
        {
            MantenimientoSeccion mantenimiento = new MantenimientoSeccion();
            var seccion = mantenimiento.GetSeccion(id);

            if (seccion == null)
                return NotFound();

            return Ok(seccion);
        }

        [HttpPost]
        public IHttpActionResult UpdateSeccion(DTOSeccion dtoseccion)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoSeccion mantenimiento = new MantenimientoSeccion();
                mantenimiento.UpdateSeccion(dtoseccion);
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
