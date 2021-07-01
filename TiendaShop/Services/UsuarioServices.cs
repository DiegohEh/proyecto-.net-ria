using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TiendaShop.Services
{
    public class UsuarioServices
    {

        public List<DTOUsuario> GetAll()
        {
            try
            {
                string metodo = "usuario/GetAll";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<List<DTOUsuario>>(jsonResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DTOUsuario Get(string email)
        {
            try
            {
                string metodo = $"usuario/GetByEmail?email={email}";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<DTOUsuario>(jsonResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DTOUsuario Get(int id)
        {
            try
            {
                string metodo = $"usuario/Get/{id}";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<DTOUsuario>(jsonResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Create(DTOUsuario usuario)
        {
            string metodo = $"usuario/Create";
            var json = new JavaScriptSerializer().Serialize(usuario);
            ApiService services = new ApiService();
            var response = services.PostServices(metodo, json);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");

            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);
            if (!baseResponse.Success)
                throw new Exception(baseResponse.Error);
        }
        public void Update(DTOUsuario usuario)
        {
            string metodo = $"usuario/Update";
            var json = new JavaScriptSerializer().Serialize(usuario);
            ApiService services = new ApiService();
            var response = services.PostServices(metodo, json);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);
            if (!baseResponse.Success)
                throw new Exception(baseResponse.Error);
        }
        public void Remove(int id)
        {
            string metodo = $"usuario/Remove";
            var json = new JavaScriptSerializer().Serialize(id);
            ApiService services = new ApiService();
            var response = services.PostServices(metodo, json);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");

            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);
            if (!baseResponse.Success)
                throw new Exception(baseResponse.Error);
        }
    }
}