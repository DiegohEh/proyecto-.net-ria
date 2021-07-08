using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TiendaShop.Services
{
    public class MensajeServices
    {
        public void Create(DTOMensaje mensaje)
        {
            string metodo = $"mensaje/Create";
            var json = new JavaScriptSerializer().Serialize(mensaje);
            ApiService services = new ApiService();
            var response = services.PostServices(metodo, json);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");

            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);
            if (!baseResponse.Success)
                throw new Exception(baseResponse.Error);
        }

        public List<DTOMensaje> GetConversation()
        {
            try
            {
                string metodo = "mensaje/GetConversation";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<List<DTOMensaje>>(jsonResponse);
            }
            catch (Exception) { throw; }
        }
        public DTOMensaje Get(int id)
        {
            try
            {
                string metodo = $"mensaje/Get/{id}";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<DTOMensaje>(jsonResponse);
            }
            catch (Exception) { throw; }
        }
    }
}