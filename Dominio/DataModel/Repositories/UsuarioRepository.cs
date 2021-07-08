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
    public class UsuarioRepository
    {
        private readonly designProEntities _context;

        public UsuarioRepository(designProEntities context)
        {
            this._context = context;
        }

        public void Create(usuario usuario)
        {
            this._context.usuario.Add(usuario);
        }

        public List<usuario> GetAll()
        {
            return this._context.usuario.Select(a => a).ToList();
        }

        public usuario Get(int id)
        {
            return this._context.usuario.FirstOrDefault(a => a.id == id);

        }

        public usuario GetByEmail(string email)
        {
            return this._context.usuario.FirstOrDefault(a => a.email == email);
        }

        public void Update(usuario usuario)
        {
            var entity = this.Get(usuario.id);
            entity.email = usuario.email;
            entity.contrasenia = usuario.contrasenia;
            entity.nombre = usuario.nombre;
            entity.apellido = usuario.apellido;
            entity.fechaNac = usuario.fechaNac;
            entity.pais = usuario.pais;
            entity.ciudad = usuario.ciudad;
            entity.rutaImgPerfil = usuario.rutaImgPerfil;
            entity.profesion = usuario.profesion;
            entity.empresa = usuario.empresa;
            entity.urlSitioWebProfesional = usuario.urlSitioWebProfesional;
            entity.descripcionPersonal = usuario.descripcionPersonal;
            entity.visitasTotales = usuario.visitasTotales;
            entity.promedioValoraciones = usuario.promedioValoraciones;
            //LogAction(usuario, LogActionsDb.Edicion);
        }

        public void UpdateValoraciones(usuario usuario)
        {
            var entity = this.Get(usuario.id);
            entity.email = usuario.email;
            entity.contrasenia = usuario.contrasenia;
            entity.nombre = usuario.nombre;
            entity.apellido = usuario.apellido;
            entity.fechaNac = usuario.fechaNac;
            entity.pais = usuario.pais;
            entity.ciudad = usuario.ciudad;
            entity.rutaImgPerfil = usuario.rutaImgPerfil;
            entity.profesion = usuario.profesion;
            entity.empresa = usuario.empresa;
            entity.urlSitioWebProfesional = usuario.urlSitioWebProfesional;
            entity.descripcionPersonal = usuario.descripcionPersonal;
            entity.visitasTotales = usuario.visitasTotales;
            entity.promedioValoraciones = usuario.promedioValoraciones;
        }

        public void Remove(int id)
        {
            var entity = this.Get(id);
            this._context.usuario.Remove(entity);

            //LogAction(entity, LogActionsDb.Eliminacion);
        }

        /*public void LogAction(Usuario usuario, string accion)
        {
            var log = new LogUsuarios()
            {
                Accion = accion,
                Codigo = usuario.Codigo,
                Descripcion = usuario.Descripcion,
                Fecha = DateTime.Now,
                IdUsuario = usuario.Id,
                Precio = usuario.Precio
            };

            this._context.LogUsuarios.Add(log);
        }*/
    }
}
