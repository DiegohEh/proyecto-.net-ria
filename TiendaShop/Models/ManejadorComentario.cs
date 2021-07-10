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
    public class ManejadorComentario
    {
        public DTOComentario MapToDto(Comentario comentario)
        {
            if (comentario == null) return null;

            return new DTOComentario()
            {
                Id = comentario.Id,
                IdProyecto = comentario.IdProyecto,
                IdUsuario = comentario.IdUsuario,
                Contenido = comentario.Contenido,
            };
        }
        public Comentario MapToComentario(DTOComentario comentario)
        {
            if (comentario == null) return null;

            return new Comentario()
            {
                Id = comentario.Id,
                IdProyecto = comentario.IdProyecto,
                IdUsuario = comentario.IdUsuario,
                Contenido = comentario.Contenido,
            };
        }

        public void Create(Comentario comentario)
        {
            ComentarioServices service = new ComentarioServices();
            service.Create(this.MapToDto(comentario));
        }

        /*public List<DTOComentario> GetConversation(int id)
        {
            ComentarioServices service = new ComentarioServices();

            var comentarios = service.GetConversation(id);

            List<Comentario> resultados = new List<Comentario>();

            foreach (var comentario in comentarios)
            {
                resultados.Add(this.MapToComentario(comentario));
            }
            return resultados;
        }*/

        public Comentario Get(int id)
        {
            ComentarioServices service = new ComentarioServices();
            return this.MapToComentario(service.Get(id));
        }
    }
}