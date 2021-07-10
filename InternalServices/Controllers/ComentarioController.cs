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
    public class ComentarioController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<DTOComentario> GetByProyecto(int id)
        {
            MantenimientoComentario mantenimiento = new MantenimientoComentario();
            return mantenimiento.GetByProyecto(id);
        }

        public IHttpActionResult Get(int id)
        {
            MantenimientoComentario mantenimiento = new MantenimientoComentario();
            var comentario = mantenimiento.Get(id);

            if (comentario == null)
                return NotFound();

            return Ok(comentario);
        }

        [HttpPost]
        public IHttpActionResult Create(DTOComentario comentario)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoComentario mantenimiento = new MantenimientoComentario();
                mantenimiento.Create(comentario);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                logger.Error(ex, "ComentarioController/Create");
            }
            return Ok(response);
        }
    }
}
