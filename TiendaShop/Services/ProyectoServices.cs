using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DesignProNamespace.Services
{
    public class ProyectoServices
    {
        public void Create(DTOProyecto proyecto, DTOTag tag, DTOSeccion sec)
        {
            string metodo = $"proyecto/Create";
            ApiService services = new ApiService();

            var json = new JavaScriptSerializer().Serialize(proyecto);
            var json2 = new JavaScriptSerializer().Serialize(tag);
            var json3 = new JavaScriptSerializer().Serialize(sec);

            var response = services.PostServices(metodo, json);
            var response2 = services.PostServices(metodo, json2);
            var response3 = services.PostServices(metodo, json3);
            
            /*if (!response.IsSuccessStatusCode)
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");

            if (!response2.IsSuccessStatusCode)
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");

            if (!response3.IsSuccessStatusCode)
                throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
            */
            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            DTOBaseResponse baseResponse = new JavaScriptSerializer().Deserialize<DTOBaseResponse>(jsonResponse);
            if (!baseResponse.Success)
                throw new Exception(baseResponse.Error);
        }

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
            catch (Exception) { throw; }
        }

        public List<DTOProyecto> GetRecientes()
        {
            try
            {
                string metodo = "proyecto/GetRecientes";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<List<DTOProyecto>>(jsonResponse);
            }
            catch (Exception) { throw; }
        }

        public List<DTOProyecto> GetMayorValorado()
        {
            try
            {
                string metodo = "proyecto/GetMayorValorado";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<List<DTOProyecto>>(jsonResponse);
            }
            catch (Exception) { throw; }
        }

        public DTOProyecto GetByTitulo(string titulo)
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

        public List<DTOProyecto> GetBarraDeBusqueda(string busqueda)
        {
            try
            {
                string metodo = $"proyecto/GetBarraDeBusqueda?busqueda={busqueda}";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize < List<DTOProyecto>>(jsonResponse);
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
            catch (Exception) { throw; }
        }

        public DTOValoracion GetValoracionId(int id)
        {
            try
            {
                string metodo = $"proyecto/GetValoracion/{id}";
                ApiService services = new ApiService();
                var response = services.GetServices(metodo);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error, status: {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync()}");
                }

                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                return new JavaScriptSerializer().Deserialize<DTOValoracion>(jsonResponse);
            }
            catch (Exception) { throw; }
        }

        public void Update(DTOProyecto proyecto)
        {
            string metodo = $"Proyecto/Update";
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

        public void UpdateValoraciones(DTOValoracion valoracion)
        {
            string metodo = $"Proyecto/UpdateValoraciones";
            var json = new JavaScriptSerializer().Serialize(valoracion);
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