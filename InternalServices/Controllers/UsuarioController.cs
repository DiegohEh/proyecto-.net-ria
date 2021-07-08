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
    public class UsuarioController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        public IHttpActionResult Create(DTOUsuario usuario)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoUsuario mantenimiento = new MantenimientoUsuario();
                mantenimiento.Create(usuario);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;

                logger.Error(ex, "UsuarioController/Create");
            }

            return Ok(response);
        }

        public IEnumerable<DTOUsuario> GetAll()
        {
            MantenimientoUsuario mantenimiento = new MantenimientoUsuario();
            return mantenimiento.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            MantenimientoUsuario mantenimiento = new MantenimientoUsuario();
            var usuario = mantenimiento.Get(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        public IHttpActionResult GetByEmail(string email)
        {
            MantenimientoUsuario mantenimiento = new MantenimientoUsuario();
            var usuario = mantenimiento.GetByEmail(email);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);

        }

        [HttpPost]
        public IHttpActionResult Update(DTOUsuario usuario)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoUsuario mantenimiento = new MantenimientoUsuario();
                mantenimiento.Update(usuario);
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
        public IHttpActionResult UpdateValoraciones(DTOUsuario usuario)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoUsuario mantenimiento = new MantenimientoUsuario();
                mantenimiento.Update(usuario);
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
                MantenimientoUsuario mantenimiento = new MantenimientoUsuario();
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
