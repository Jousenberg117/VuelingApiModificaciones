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

namespace Vueling.Alplication.Services.Service
{
    public static class HttpPolizasService 
    {
        static HttpClient client;

        static HttpPolizasService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("Polizas"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<PolizasDtoLista> GetPolizas()
        {
            PolizasDtoLista polizasDtoLista = null;
            try
            {
                HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    var polizaJsonString = await response.Content.ReadAsStringAsync();
                    polizasDtoLista = JsonConvert.DeserializeObject<PolizasDtoLista>(polizaJsonString);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return polizasDtoLista;
        }
    }
}
