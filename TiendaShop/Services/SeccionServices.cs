using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DesignProNamespace.Services
{
    public class SeccionServices
    {
        public void CreateSeccion(DTOSeccion dtoseccion)
        {
            string metodo = $"proyecto/CreateSeccion";
            var json = new JavaScriptSerializer().Serialize(dtoseccion);

            ApiService services = new ApiService();
            var response = services.PostServices(metodo, json);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");

            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);
            if (!baseResponse.Success)
                throw new Exception(baseResponse.Error);
        }

        public DTOSeccion GetSeccion(int id)
        {
            try
            {
                string metodo = $"Proyecto/GetSeccion/{id}";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<DTOSeccion>(jsonResponse);
            }
            catch (Exception) { throw; }
        }

        public void UpdateSeccion(DTOSeccion dtoseccion)
        {
            string metodo = $"proyecto/UpdateSeccion";
            var json = new JavaScriptSerializer().Serialize(dtoseccion);

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