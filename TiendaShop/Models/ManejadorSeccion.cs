using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dominio.General;
using Common.DataTransferObjects;
using DesignProNamespace.Services;

namespace DesignProNamespace.Models
{
    public class ManejadorSeccion
    {
        public DTOSeccion MapToDto(Seccion seccion)
        {
            if (seccion == null) return null;

            return new DTOSeccion()
            {
                Id = seccion.Id,
                IdProyecto = seccion.IdProyecto,
                contenidoTexto = seccion.contenidoTexto,
                rutaUrlImagen = seccion.rutaUrlImagen,
                rutaUrlVideo = seccion.rutaUrlVideo,
            };
        }

        public Seccion MapToSeccion(DTOSeccion seccion)
        {
            if (seccion == null) return null;

            return new Seccion()
            {
                Id = seccion.Id,
                IdProyecto = seccion.IdProyecto,
                contenidoTexto = seccion.contenidoTexto,
                rutaUrlImagen = seccion.rutaUrlImagen,
                rutaUrlVideo = seccion.rutaUrlVideo,
            };
        }

        public void Create(Seccion seccion)
        {
            SeccionServices service = new SeccionServices();
            service.CreateSeccion(this.MapToDto(seccion));
        }

        public Seccion GetSeccion(int id)
        {
            SeccionServices service = new SeccionServices();
            return this.MapToSeccion(service.GetSeccion(id));
        }

        public void UpdateSeccion(Seccion seccion)
        {
            SeccionServices service = new SeccionServices();
            service.UpdateSeccion(this.MapToDto(seccion));
        }
    }
}