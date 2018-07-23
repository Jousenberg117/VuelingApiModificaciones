using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Vueling.Alplication.Services.Service;
using Vueling.Aplication.Dto;
using Vueling.Aplication.Services.Contracts;
using Vueling.Common.Layer;
using Vueling.Facade.Api.Models;

namespace Vueling.Facade.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/clientes")]
    public class ClientesApiController : ApiController
    {
        private readonly IClientesService<ClientesDto> clientesService;

        public ClientesApiController() : this(new ClientesService())
        {

        }
        public ClientesApiController(
            ClientesService clientesService)
        {
            this.clientesService = clientesService;
        }

        [HttpGet]
        [Authorize(Users = "admin, user")]
        // GET: api/ClientesApi
        public IEnumerable<ClientesDto> Get()
        {
                return clientesService.GetAll();
        }

        [HttpGet]
        [Authorize(Users = "admin, user")]
        // GET: api/ClientesApi/5
        public ClientesDto Get(string id)
        {
                return clientesService.GetById(id);
        }

        [HttpGet]
        [Authorize(Users = "admin, user")]
        public List<ClientesDto> GetByName(string name)
        {
            return clientesService.GetByName(name);
        }

        // POST: api/ClientesApi
        [ResponseType(typeof(ClientesDto))]
        public IHttpActionResult Post(ClientesDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientesDto clienteDtoInsert = null;

            try
            {
                clienteDtoInsert = clientesService.Add(model);
            }
            catch (VuelingException ex)
            {
                VuelingLogger.Logger(ex);
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return CreatedAtRoute("DefaultApi",
                new { id = clienteDtoInsert.id }, clienteDtoInsert);
        }

    }
}
