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
    public class MensajeController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<DTOMensaje> GetConversation(int id)
        {
            MantenimientoMensaje mantenimiento = new MantenimientoMensaje();
            return mantenimiento.GetConversation(id);
        }

        public IHttpActionResult Get(int id)
        {
            MantenimientoMensaje mantenimiento = new MantenimientoMensaje();
            var mensaje = mantenimiento.Get(id);

            if (mensaje == null)
                return NotFound();

            return Ok(mensaje);
        }

        [HttpPost]
        public IHttpActionResult Create(DTOMensaje mensaje)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoMensaje mantenimiento = new MantenimientoMensaje();
                mantenimiento.Create(mensaje);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                logger.Error(ex, "MensajeController/Create");
            }
            return Ok(response);
        }
    }
}
