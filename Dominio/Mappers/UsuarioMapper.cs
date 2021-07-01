using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.General;
using Persistencia.ADO.NET.DataTrasnferObjects;
using Persistencia.Database;
using Common.DataTransferObjects;

namespace Dominio.Mappers
{
    public class UsuarioMapper
    {
        public DTOUsuario MapToObject(usuario usuario)
        {
            if (usuario == null) return null;

            return new DTOUsuario()
            {
                Id = usuario.id,
                Email = usuario.email,
                Contrasenia = usuario.contrasenia,
                Nombre = usuario.nombre,
                Apellido = usuario.apellido,
                FechaNac = usuario.fechaNac,
                Pais = usuario.pais,
                Ciudad = usuario.ciudad,
                RutaImgPerfil = usuario.rutaImgPerfil,
                Profesion = usuario.profesion,
                Empresa = usuario.empresa,
                UrlSitioWebProfesional = usuario.urlSitioWebProfesional,
                Descripcion = usuario.descripcionPersonal,
                VisitasTotales = usuario.visitasTotales,
                PromedioValoraciones = usuario.promedioValoraciones,
            };
        }
        public usuario MapToEntity(DTOUsuario usuario)
        {
            if (usuario == null)
                return null;

            return new usuario()
            {
                id = usuario.Id,
                email = usuario.Email,
                contrasenia = usuario.Contrasenia,
                nombre = usuario.Nombre,
                apellido = usuario.Apellido,
                fechaNac = usuario.FechaNac,
                pais = usuario.Pais,
                ciudad = usuario.Ciudad,
                rutaImgPerfil = usuario.RutaImgPerfil,
                profesion = usuario.Profesion,
                empresa = usuario.Empresa,
                urlSitioWebProfesional = usuario.UrlSitioWebProfesional,
                descripcionPersonal = usuario.Descripcion,
                visitasTotales = usuario.VisitasTotales,
                promedioValoraciones = usuario.PromedioValoraciones,
            };
        }
    }
}
