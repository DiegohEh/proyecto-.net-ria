using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DataModel.DbConstants;
using Dominio.General;
using Dominio.Mappers;
using Persistencia.ADO.NET;
using Persistencia.Database;

namespace Dominio.Repositories
{
    public class ProyectoRepository
    {
        private readonly designProEntities _context;

        public ProyectoRepository(designProEntities context)
        {
            this._context = context;
        }

        public void Create(proyecto pro, tag tag, seccion sec)
        {
            AccesoBaseProyecto persistencia = new AccesoBaseProyecto();
            persistencia.Create(pro,tag,sec);
            /*this._context.proyecto.Add(proyecto);
            this._context.tag.Add(tag);
            this._context.categoria.Add(cat);
            this._context.seccion.Add(sec);*/
        }

        public List<proyecto> GetAll()
        {
            return this._context.proyecto.Select(a => a).ToList();
        }

        public List<proyecto> GetBarraDeBusqueda(string busqueda)
        {
            AccesoBaseProyecto persistencia = new AccesoBaseProyecto();
            List<proyecto> lista = new List<proyecto>();
            lista = persistencia.GetBarraDeBusqueda(busqueda);

            /*List<proyecto> lista = new List<proyecto>();

            string[] recipients = busqueda.Split(' ');
            foreach (string recipient in recipients)
            {
                lista.Add(persistencia.GetBarraDeBusqueda(recipient));
            }*/

            return lista;
        }

        public proyecto GetByTitulo(string titulo)
        {
            return this._context.proyecto.FirstOrDefault(a => a.titulo == titulo);
        }

        public proyecto GetByIdUsuario(int idUsuario)
        {
            return this._context.proyecto.FirstOrDefault(a => a.idUsuario == idUsuario);
        }

        public proyecto Get(int id)
        {
            return this._context.proyecto.FirstOrDefault(a => a.id == id);
        }

        public void Update(proyecto proyecto)
        {
            var entity = this.Get(proyecto.id);
            entity.titulo = proyecto.titulo;
            entity.visitas = proyecto.visitas;
            entity.rutaImgPortada = proyecto.rutaImgPortada;
            entity.promedioValoraciones = proyecto.promedioValoraciones;
            entity.fechaCreado = proyecto.fechaCreado;
            entity.idCategoria = proyecto.idCategoria;
            entity.idUsuario = proyecto.idUsuario;
        }

        public void UpdateVisitas(proyecto proyecto)
        {
            var entity = this.Get(proyecto.id);
            entity.titulo = proyecto.titulo;
            entity.visitas = proyecto.visitas + 1;
            entity.rutaImgPortada = proyecto.rutaImgPortada;
            entity.promedioValoraciones = proyecto.promedioValoraciones;
            entity.fechaCreado = proyecto.fechaCreado;
            entity.idCategoria = proyecto.idCategoria;
            entity.idUsuario = proyecto.idUsuario;
        }

        public void UpdateValoraciones(proyecto proyecto)
        {
            var entity = this.Get(proyecto.id);
            entity.titulo = proyecto.titulo;
            entity.visitas = proyecto.visitas;
            entity.rutaImgPortada = proyecto.rutaImgPortada;
            entity.promedioValoraciones = proyecto.promedioValoraciones;
            entity.fechaCreado = proyecto.fechaCreado;
            entity.idCategoria = proyecto.idCategoria;
            entity.idUsuario = proyecto.idUsuario;
        }

        public void Remove(int id)
        {
            var entity = this.Get(id);
            this._context.proyecto.Remove(entity);
        }
    }
}
