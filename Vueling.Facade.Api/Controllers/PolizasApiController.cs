using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vueling.Alplication.Services.Service;
using Vueling.Aplication.Dto;
using Vueling.Aplication.Services.Contracts;
using Vueling.Common.Layer;

namespace Vueling.Facade.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/polizas")]
    public class PolizasApiController : ApiController
    {
        private readonly IPolizasService<PolizasDto> polizasService;

        public PolizasApiController() : this(new PolizasService())
        {

        }
        public PolizasApiController(
            PolizasService polizasService)
        {
            this.polizasService = polizasService;
        }

        // GET: api/PolizasApi
        public IEnumerable<PolizasDto> Get()
        {
            try
            {
                return polizasService.GetAll();
            }
            catch (VuelingException ex)
            {

                throw;
            }
        }

        // GET: api/PolizasApi/5
        public PolizasDto Get(int id)
        {
            return polizasService.GetById(id);
        }

        // POST: api/PolizasApi
        [ResponseType(typeof(PolizasDto))]
        public IHttpActionResult Post(PolizasDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PolizasDto polizasDtoInsert = null;

            try
            {
                polizasDtoInsert = polizasService.Add(model);
            }
            catch (VuelingException ex)
            {
                throw ex;
            }
            return CreatedAtRoute("DefaultApi",
                new { id = polizasDtoInsert.id }, polizasDtoInsert);
        }

            // PUT: api/PolizasApi/5
            public IHttpActionResult Put(int id, PolizasDto model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                polizasService.Update(model);
                return StatusCode(HttpStatusCode.NoContent);
            }

        // DELETE: api/PolizasApi/5
        public IHttpActionResult Delete(int id)
        {
            return Ok(polizasService.Remove(id));
        }
    }
}
