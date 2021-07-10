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
    public class ManejadorUsuario
    {
        private DTOUsuario MapToDto(Usuario usuario)
        {
            if (usuario == null)
                return null;

            return new DTOUsuario()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Contrasenia = usuario.Contrasenia,
                Apellido = usuario.Apellido,
                FechaNac = usuario.FechaNac,
                Pais = usuario.Pais,
                Ciudad = usuario.Ciudad,
                RutaImgPerfil = usuario.RutaImgPerfil,
                Profesion = usuario.Profesion,
                Empresa = usuario.Empresa,
                UrlSitioWebProfesional = usuario.UrlSitioWebProfesional,
                Descripcion = usuario.Descripcion,
                VisitasTotales = usuario.VisitasTotales,
                PromedioValoraciones = usuario.PromedioValoraciones,
            };
        }
        private Usuario MapToUsuario(DTOUsuario usuario)
        {
            if (usuario == null)
                return null;

            return new Usuario()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Contrasenia = usuario.Contrasenia,
                Apellido = usuario.Apellido,
                FechaNac = usuario.FechaNac,
                Pais = usuario.Pais,
                Ciudad = usuario.Ciudad,
                RutaImgPerfil = usuario.RutaImgPerfil,
                Profesion = usuario.Profesion,
                Empresa = usuario.Empresa,
                UrlSitioWebProfesional = usuario.UrlSitioWebProfesional,
                Descripcion = usuario.Descripcion,
                VisitasTotales = usuario.VisitasTotales,
                PromedioValoraciones = usuario.PromedioValoraciones,
            };
        }

        public void Create(Usuario usuario)
        {
            UsuarioServices service = new UsuarioServices();

            service.Create(this.MapToDto(usuario));
        }

        public List<Usuario> GetAll()
        {
            UsuarioServices service = new UsuarioServices();

            var usuarios = service.GetAll();

            List<Usuario> resultados = new List<Usuario>();

            foreach (var usuario in usuarios)
            {
                resultados.Add(this.MapToUsuario(usuario));
            }

            return resultados;
        }

        public Usuario GetByEmail(string email)
        {
            UsuarioServices service = new UsuarioServices();
            return this.MapToUsuario(service.GetByEmail(email));

        }

        public Usuario Get(int id)
        {
            UsuarioServices service = new UsuarioServices();
            return this.MapToUsuario(service.Get(id));

        }

        public void Update(Usuario usuario)
        {
            UsuarioServices service = new UsuarioServices();
            service.Update(this.MapToDto(usuario));

        }

        public void Remove(int id)
        {
            UsuarioServices service = new UsuarioServices();
            service.Remove(id);
        }
    }
}