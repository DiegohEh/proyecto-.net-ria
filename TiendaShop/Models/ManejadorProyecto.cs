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
    public class ManejadorProyecto
    {
        private DTOProyecto MapToDto(Proyecto proyecto)
        {
            if (proyecto == null)
                return null;

            return new DTOProyecto()
            {
                Id = proyecto.Id,
                Titulo = proyecto.Titulo,
                Visitas = proyecto.Visitas,
                RutaImgPortada = proyecto.RutaImgPortada,
                PromedioValoraciones = proyecto.PromedioValoraciones,
                FechaCreado = proyecto.FechaCreado,
                IdCategoria = proyecto.IdCategoria,
                IdUsuario = proyecto.IdUsuario,
            };
        }

        private DTOTag MapToTag(Tag tag)
        {
            if (tag == null)
                return null;

            return new DTOTag()
            {
                Id = tag.Id,
                IdProyecto = tag.IdProyecto,
                Nombre = tag.Nombre,
            };
        }

        private DTOSeccion MapToSeccion(Seccion sec)
        {
            if (sec == null)
                return null;

            return new DTOSeccion()
            {
                Id = sec.Id,
                IdProyecto = sec.IdProyecto,
                contenidoTexto = sec.contenidoTexto,
                rutaUrlImagen = sec.rutaUrlImagen,
                rutaUrlVideo = sec.rutaUrlVideo,
            };
        }

        private DTOValoracion MapToDtoValoracion(Valoracion valoracion)
        {
            if (valoracion == null)
                return null;

            return new DTOValoracion()
            {
                IdProyecto = valoracion.IdProyecto,
                IdUsuario = valoracion.IdUsuario,
                Valor = valoracion.Valor,
            };
        }

        private Valoracion MapToValoracion(DTOValoracion valoracion)
        {
            if (valoracion == null)
                return null;

            return new Valoracion()
            {
                IdProyecto = valoracion.IdProyecto,
                IdUsuario = valoracion.IdUsuario,
                Valor = valoracion.Valor,
            };
        }

        private Proyecto MapToProyecto(DTOProyecto proyecto)
        {
            if (proyecto == null)
                return null;

            return new Proyecto()
            {
                Id = proyecto.Id,
                Titulo = proyecto.Titulo,
                Visitas = proyecto.Visitas,
                RutaImgPortada = proyecto.RutaImgPortada,
                PromedioValoraciones = proyecto.PromedioValoraciones,
                FechaCreado = proyecto.FechaCreado,
                IdCategoria = proyecto.IdCategoria,
                IdUsuario = proyecto.IdUsuario,
            };
        }

        public void Create(Proyecto proyecto, Tag tag, Seccion seccion)
        {
            ProyectoServices service = new ProyectoServices();
            service.Create(this.MapToDto(proyecto), this.MapToTag(tag), this.MapToSeccion(seccion));
        }

        public List<Proyecto> GetAll()
        {
            ProyectoServices service = new ProyectoServices();

            var proyectos = service.GetAll();

            List<Proyecto> resultados = new List<Proyecto>();

            foreach (var proyecto in proyectos)
            {
                resultados.Add(this.MapToProyecto(proyecto));
            }
            return resultados;
        }

        public List<Proyecto> GetRecientes()
        {
            ProyectoServices service = new ProyectoServices();

            var proyectos = service.GetAll();

            List<Proyecto> resultados = new List<Proyecto>();

            foreach (var proyecto in proyectos)
            {
                resultados.Add(this.MapToProyecto(proyecto));
            }
            return resultados;
        }

        public List<Proyecto> GetMayorValorado()
        {
            ProyectoServices service = new ProyectoServices();
            var proyectos = service.GetAll();
            List<Proyecto> resultados = new List<Proyecto>();
            foreach (var proyecto in proyectos)
            {
                resultados.Add(this.MapToProyecto(proyecto));
            }
            return resultados;
        }

        public List<Proyecto> GetBarraDeBusqueda(string busqueda)
        {
            ProyectoServices service = new ProyectoServices();
            var proyectos = service.GetBarraDeBusqueda(busqueda);
            List<Proyecto> resultados = new List<Proyecto>();
            foreach (var proyecto in proyectos)
            {
                resultados.Add(this.MapToProyecto(proyecto));
            }
            return resultados;
        }

        public Proyecto GetByTitulo(string titulo)
        {
            ProyectoServices service = new ProyectoServices();
            return this.MapToProyecto(service.GetByTitulo(titulo));
        }

        public Proyecto Get(int id)
        {
            ProyectoServices service = new ProyectoServices();
            return this.MapToProyecto(service.Get(id));
        }

        public Valoracion GetValoracionId(int id)
        {
            ProyectoServices service = new ProyectoServices();
            return this.MapToValoracion(service.GetValoracionId(id));
        }

        public void Update(Proyecto proyecto)
        {
            ProyectoServices service = new ProyectoServices();
            service.Update(this.MapToDto(proyecto));
        }

        public void UpdateValoraciones(Valoracion valoracion)
        {
            ProyectoServices service = new ProyectoServices();
            service.UpdateValoraciones(this.MapToDtoValoracion(valoracion));
        }

        public void Remove(int id)
        {
            ProyectoServices service = new ProyectoServices();
            service.Remove(id);
        }
    }
}