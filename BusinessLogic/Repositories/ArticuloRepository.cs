using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Mappers;
using Dominio.Modelo;
using Persistencia.ADO.NET;
using Persistencia.ADO.NET.DataTrasnferObjects;

namespace Dominio.Repositories
{
    public class ArticuloRepository
    {
        private ArticuloMapper _mapper;

        public ArticuloRepository()
        {
            _mapper = new ArticuloMapper();
        }

        /// <summary>
        /// Crea un articulo en base de datos
        /// </summary>
        /// <param name="articulo"></param>
        /// <returns></returns>
        public int Create(Articulo articulo)
        {
            AccesoBaseArticulos accesoBaseArticulos = new AccesoBaseArticulos();
            return accesoBaseArticulos.Create(_mapper.MapToEntity(articulo));
        }

        /// <summary>
        /// Retorna la lista de todos los articulos disponibles
        /// </summary>
        /// <returns></returns>
        public List<Articulo> GetAll()
        {
            AccesoBaseArticulos accesoBaseArticulos = new AccesoBaseArticulos();
            var articulos = accesoBaseArticulos.GetAll();

            List<Articulo> resultados = new List<Articulo>();

            foreach (var articulo in articulos)
            {
                resultados.Add(_mapper.MapToObject(articulo));
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
            AccesoBaseArticulos accesoBaseArticulos = new AccesoBaseArticulos();
            return _mapper.MapToObject(accesoBaseArticulos.Get(codigo));

        }
        /// <summary>
        /// Devuelve el articulo encontrado
        /// </summary>
        /// <param name="id"> Id de articulo a buscar</param>
        /// <returns></returns>
        public Articulo Get(long id)
        {
            AccesoBaseArticulos accesoBaseArticulos = new AccesoBaseArticulos();
            return _mapper.MapToObject(accesoBaseArticulos.Get(id));

        }

        /// <summary>
        /// Actualiza los campos de un articulo
        /// </summary>
        /// <param name="articulo"> Articulo modificado, Id requerido</param>
        /// <returns></returns>
        public int Update(Articulo articulo)
        {
            AccesoBaseArticulos accesoBaseArticulos = new AccesoBaseArticulos();
            return accesoBaseArticulos.Update(_mapper.MapToEntity(articulo));

        }

        /// <summary>
        /// Elimina un articulo en base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(long id)
        {
            AccesoBaseArticulos accesoBaseArticulos = new AccesoBaseArticulos();
            return accesoBaseArticulos.Remove(id);
        }



    }
}
