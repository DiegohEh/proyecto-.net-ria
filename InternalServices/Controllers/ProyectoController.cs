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

        [HttpPost]
        [Route("Proyecto/Create")]
        public IHttpActionResult Create(DTOProyecto proyecto, DTOTag tags, DTOSeccion seccion)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
                mantenimiento.Create(proyecto, tags, seccion);
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

        public IEnumerable<DTOProyecto> GetAll()
        {
            MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
            return mantenimiento.GetAll();
        }

        [Route("Proyecto/GetBarraDeBusqueda")]
        public IHttpActionResult GetBarraDeBusqueda(string busqueda)
        {
            MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
            return Ok(mantenimiento.GetBarraDeBusqueda(busqueda));
        }

        public IHttpActionResult GetByTitulo(string titulo)
        {
            MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
            var proyecto = mantenimiento.GetByTitulo(titulo);
            UpdateVisitas(proyecto);

            if (proyecto == null)
                return NotFound();

            return Ok(proyecto);
        }

        public IHttpActionResult Get(int id)
        {
            MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
            var proyecto = mantenimiento.Get(id);
            UpdateVisitas(proyecto);

            if (proyecto == null)
                return NotFound();

            return Ok(proyecto);
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
        public IHttpActionResult UpdateVisitas(DTOProyecto proyecto)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
                mantenimiento.UpdateVisitas(proyecto);
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
        public IHttpActionResult UpdateValoraciones(DTOValoracion valoracion)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                MantenimientoProyecto mantenimiento = new MantenimientoProyecto();
                mantenimiento.UpdateValoraciones(valoracion);
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

                logger.Error(ex, "ProyectoController/CreateSeccion");
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
