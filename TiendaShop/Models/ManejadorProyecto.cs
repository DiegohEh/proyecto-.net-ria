using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dominio.General;
using Common.DataTransferObjects;
using TiendaShop.Services;

namespace TiendaShop.Models
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

        public void Create(Proyecto proyecto)
        {
            ProyectoServices service = new ProyectoServices();
            service.Create(this.MapToDto(proyecto));
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

        public void Update(Proyecto proyecto)
        {
            ProyectoServices service = new ProyectoServices();
            service.Update(this.MapToDto(proyecto));
        }

        public void Remove(int id)
        {
            ProyectoServices service = new ProyectoServices();
            service.Remove(id);
        }
    }
}