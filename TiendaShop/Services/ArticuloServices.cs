using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TiendaShop.Services
{
    public class ArticuloServices
    {

        public List<DTOArticulo> GetAll()
        {
            try
            {
                string metodo = "articulo/GetAll";

                ApiService services = new ApiService();

                var response = services.GetServices(metodo);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                return new JavaScriptSerializer().Deserialize<List<DTOArticulo>>(jsonResponse);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DTOArticulo Get(string codigo)
        {
            try
            {
                string metodo = $"articulo/GetByCodigo?codigo={codigo}";

                ApiService services = new ApiService();

                var response = services.GetServices(metodo);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                return new JavaScriptSerializer().Deserialize<DTOArticulo>(jsonResponse);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DTOArticulo Get(long id)
        {
            try
            {
                string metodo = $"articulo/Get/{id}";

                ApiService services = new ApiService();

                var response = services.GetServices(metodo);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                return new JavaScriptSerializer().Deserialize<DTOArticulo>(jsonResponse);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Create(DTOArticulo articulo)
        {
            string metodo = $"articulo/Create";

            var json = new JavaScriptSerializer().Serialize(articulo);

            ApiService services = new ApiService();

            var response = services.PostServices(metodo, json);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
            }

            string jsonResponse = response.Content.ReadAsStringAsync().Result;

            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);

            if (!baseResponse.Success)
            {
                throw new Exception(baseResponse.Error);
            }

        }
        public void Update(DTOArticulo articulo)
        {
            string metodo = $"articulo/Update";

            var json = new JavaScriptSerializer().Serialize(articulo);

            ApiService services = new ApiService();

            var response = services.PostServices(metodo, json);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
            }

            string jsonResponse = response.Content.ReadAsStringAsync().Result;

            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);

            if (!baseResponse.Success)
            {
                throw new Exception(baseResponse.Error);
            }

        }
        public void Remove(long id)
        {
            string metodo = $"articulo/Remove";

            var json = new JavaScriptSerializer().Serialize(id);

            ApiService services = new ApiService();

            var response = services.PostServices(metodo, json);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
            }

            string jsonResponse = response.Content.ReadAsStringAsync().Result;

            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);

            if (!baseResponse.Success)
            {
                throw new Exception(baseResponse.Error);
            }

        }

    }
}