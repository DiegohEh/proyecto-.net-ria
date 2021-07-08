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

        public void Create(proyecto proyecto)
        {
            this._context.proyecto.Add(proyecto);
        }

        public List<proyecto> GetAll()
        {
            return this._context.proyecto.Select(a => a).ToList();
        }

        public List<proyecto> GetRecientes()
        {
            return this._context.proyecto.Select(a => a).ToList();
        }

        public List<proyecto> GetMayorValorado()
        {
            return this._context.proyecto.Select(a => a).ToList();
        }

        public proyecto GetByTitulo(string titulo)
        {
            return this._context.proyecto.FirstOrDefault(a => a.titulo == titulo);
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
            entity.visitas = proyecto.visitas;
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

            //LogAction(entity, LogActionsDb.Eliminacion);
        }

        public void CreateSeccion(seccion seccion, imagen imagen, texto texto, video video)
        {
            this._context.seccion.Add(seccion);
            this._context.imagen.Add(imagen);
            this._context.texto.Add(texto);
            this._context.video.Add(video);
        }

        public seccion GetSeccion(int id)
        {
            return this._context.seccion.FirstOrDefault(a => a.id == id);
        }

        public void UpdateSeccion(seccion seccion, imagen imagen, texto texto, video video)
        {
            var entity = this.GetSeccion(seccion.id);

            entity.idProyecto = seccion.idProyecto;
            imagen.idSeccion = seccion.id;
            imagen.rutaUrl = imagen.rutaUrl;
            texto.idSeccion = seccion.id;
            texto.contenido = texto.contenido;
            video.idSeccion = seccion.id;
            video.rutaUrl = video.rutaUrl;
        }
    }
}
