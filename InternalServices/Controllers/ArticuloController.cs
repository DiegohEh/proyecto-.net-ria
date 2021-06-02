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
    public class ArticuloController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<DTOArticulo> GetAll()
        {
            MantenimientoArticulo mantenimiento = new MantenimientoArticulo();
            return mantenimiento.GetAll();

        }
        public IHttpActionResult GetByCodigo(string codigo)
        {
            MantenimientoArticulo mantenimiento = new MantenimientoArticulo();
            var articulo = mantenimiento.Get(codigo);

            if (articulo == null)
                return NotFound();

            return Ok(articulo);

        }
        public IHttpActionResult Get(long id)
        {
            MantenimientoArticulo mantenimiento = new MantenimientoArticulo();
            var articulo = mantenimiento.Get(id);

            if (articulo == null)
                return NotFound();

            return Ok(articulo);

        }

        [HttpPost]
        public IHttpActionResult Create(DTOArticulo articulo)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoArticulo mantenimiento = new MantenimientoArticulo();
                mantenimiento.Create(articulo);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;

                logger.Error(ex, "ArticuloController/Create");
            }

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult Update(DTOArticulo articulo)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoArticulo mantenimiento = new MantenimientoArticulo();
                mantenimiento.Update(articulo);
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
        public IHttpActionResult Remove([FromBody] long id)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoArticulo mantenimiento = new MantenimientoArticulo();
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
