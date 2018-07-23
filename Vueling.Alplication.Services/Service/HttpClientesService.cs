using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Net.Http;
using System.Text;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Vueling.Aplication.Dto;
using Vueling.Common.Layer;
using System.Net;

namespace Vueling.Alplication.Services.Service
{
    public static class HttpClientesService 
    {
        static HttpClient client;

        static HttpClientesService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("Clientes"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<ClientesDtoLista> GetClientes()
        {
            ClientesDtoLista clientesDtoLista = null;
            try
            {
                HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    var clienteJsonString = await response.Content.ReadAsStringAsync();
                    clientesDtoLista = JsonConvert.DeserializeObject<ClientesDtoLista>(clienteJsonString);
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            return clientesDtoLista;
        }
    }
}
