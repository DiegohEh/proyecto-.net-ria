using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dominio.General;
using Common.DataTransferObjects;
using DesignProNamespace.Services;

namespace DesignProNamespace.Models
{
    public class ManejadorMensaje
    {
        public DTOMensaje MapToDto(Mensaje mensaje)
        {
            if (mensaje == null) return null;

            return new DTOMensaje()
            {
                Id = mensaje.Id,
                IdUsuarioEmisor = mensaje.IdUsuarioEmisor,
                IdUsuarioReceptor = mensaje.IdUsuarioReceptor,
                Contenido = mensaje.Contenido,
                Leido = mensaje.Leido,
            };
        }
        public Mensaje MapToMensaje(DTOMensaje mensaje)
        {
            if (mensaje == null) return null;

            return new Mensaje()
            {
                Id = mensaje.Id,
                IdUsuarioEmisor = mensaje.IdUsuarioEmisor,
                IdUsuarioReceptor = mensaje.IdUsuarioReceptor,
                Contenido = mensaje.Contenido,
                Leido = mensaje.Leido,
            };
        }

        public void Create(Mensaje mensaje)
        {
            MensajeServices service = new MensajeServices();
            service.Create(this.MapToDto(mensaje));
        }

        public List<Mensaje> GetConversation(int id)
        {
            MensajeServices service = new MensajeServices();

            var mensajes = service.GetConversation(id);

            List<Mensaje> resultados = new List<Mensaje>();

            foreach (var mensaje in mensajes)
            {
                resultados.Add(this.MapToMensaje(mensaje));
            }
            return resultados;
        }

        public Mensaje Get(int id)
        {
            MensajeServices service = new MensajeServices();
            return this.MapToMensaje(service.Get(id));
        }
    }
}