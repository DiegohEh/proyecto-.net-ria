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

        /// <summary>
        /// Crea un articulo en base de datos
        /// </summary>
        /// <param name="articulo"></param>
        /// <returns></returns>
        public void Create(Articulo articulo)
        {
            ArticuloServices service = new ArticuloServices();

            service.Create(this.MapToDto(articulo));
        }

        /// <summary>
        /// Retorna la lista de todos los articulos disponibles
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Devuelve el articulo encontrado
        /// </summary>
        /// <param name="codigo"> Codigo de articulo a buscar</param>
        /// <returns></returns>
        public Articulo Get(string codigo)
        {
            ArticuloServices service = new ArticuloServices();
            return this.MapToArticulo(service.Get(codigo));

        }
        /// <summary>
        /// Devuelve el articulo encontrado
        /// </summary>
        /// <param name="id"> Id de articulo a buscar</param>
        /// <returns></returns>
        public Articulo Get(long id)
        {
            ArticuloServices service = new ArticuloServices();
            return this.MapToArticulo(service.Get(id));

        }

        /// <summary>
        /// Actualiza los campos de un articulo
        /// </summary>
        /// <param name="articulo"> Articulo modificado, Id requerido</param>
        /// <returns></returns>
        public void Update(Articulo articulo)
        {
            ArticuloServices service = new ArticuloServices();
            service.Update(this.MapToDto(articulo));

        }

        /// <summary>
        /// Elimina un articulo en base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void Remove(long id)
        {
            ArticuloServices service = new ArticuloServices();
            service.Remove(id);
        }



    }
}