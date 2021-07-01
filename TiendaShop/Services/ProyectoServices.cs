using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TiendaShop.Services
{
    public class ProyectoServices
    {

        public List<DTOProyecto> GetAll()
        {
            try
            {
                string metodo = "proyecto/GetAll";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<List<DTOProyecto>>(jsonResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DTOProyecto Get(string titulo)
        {
            try
            {
                string metodo = $"proyecto/GetByTitulo?titulo={titulo}";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<DTOProyecto>(jsonResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DTOProyecto Get(int id)
        {
            try
            {
                string metodo = $"proyecto/Get/{id}";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<DTOProyecto>(jsonResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Create(DTOProyecto proyecto)
        {
            string metodo = $"proyecto/Create";
            var json = new JavaScriptSerializer().Serialize(proyecto);
            ApiService services = new ApiService();
            var response = services.PostServices(metodo, json);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");

            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);
            if (!baseResponse.Success)
                throw new Exception(baseResponse.Error);
        }
        public void Update(DTOProyecto proyecto)
        {
            string metodo = $"proyecto/Update";
            var json = new JavaScriptSerializer().Serialize(proyecto);
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
            string metodo = $"proyecto/Remove";
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