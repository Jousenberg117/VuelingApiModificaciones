using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vueling.Aplication.Dto;

namespace Vueling.Alplication.Services.Service
{
    public class ClientesDtoLista
    {
        [JsonProperty("clients")]
        public IEnumerable<ClientesDto> clientesDto { get; set; }
    }
}
