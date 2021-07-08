using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace TiendaShop.Services
{
    public class ApiService
    {
        private static readonly HttpClient _client = new HttpClient();
        private string _uri;

        public ApiService()
        {
            _uri = ConfigurationManager.AppSettings["TIENDASHOP.ENDPOINT.INTERNAL"];
        }

        public HttpResponseMessage PostServices(string method, string jsonData)
        {
            try
            {
                var adress = new Uri($"{_uri}{method}");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, adress);
                request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                return _client.SendAsync(request).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HttpResponseMessage GetServices(string method)
        {
            try
            {
                var adress = new Uri($"{_uri}{method}");
                return _client.GetAsync(adress).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}