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
    public class ManejadorArticulo
    {
        private DTOArticulo MapToDto(Articulo articulo)
        {
            if (articulo == null)
                return null;

            return new DTOArticulo()
            {
                Id = articulo.Id,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio
            };
        }
        private Articulo MapToArticulo(DTOArticulo articulo)
        {
            if (articulo == null)
                return null;

            return new Articulo()
            {
                Id = articulo.Id ?? 0,
                Codigo = articulo.Codigo,
                Descripcion = articulo.Descripcion,
                Precio = articulo.Precio
            };
        }

        public void Create(Articulo articulo)
        {
            ArticuloServices service = new ArticuloServices();

            service.Create(this.MapToDto(articulo));
        }

        public List<Articulo> GetAll()
        {
            ArticuloServices service = new ArticuloServices();

            var articulos = service.GetAll();

            List<Articulo> resultados = new List<Articulo>();

            foreach (var articulo in articulos)
            {
                resultados.Add(this.MapToArticulo(articulo));
            }

            return resultados;
        }

        public Articulo Get(string codigo)
        {
            ArticuloServices service = new ArticuloServices();
            return this.MapToArticulo(service.Get(codigo));

        }

        public Articulo Get(long id)
        {
            ArticuloServices service = new ArticuloServices();
            return this.MapToArticulo(service.Get(id));

        }

        public void Update(Articulo articulo)
        {
            ArticuloServices service = new ArticuloServices();
            service.Update(this.MapToDto(articulo));

        }

        public void Remove(long id)
        {
            ArticuloServices service = new ArticuloServices();
            service.Remove(id);
        }
    }
}