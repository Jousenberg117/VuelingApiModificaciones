using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ExceptionHandling;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vueling.Alplication.Services.Service;
using Vueling.Aplication.Dto;
using Vueling.Facade.Api.Controllers;
using System.Net;

namespace Vueling.Facade.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ClientesApiController clientesApi = new ClientesApiController();
            ClientesDtoLista CdtoLista = new ClientesDtoLista();

                CdtoLista = HttpClientesService.GetClientes().Result;
           
            foreach (ClientesDto clientes in CdtoLista.clientesDto)
            {
                clientesApi.Post(clientes);
            }


            PolizasApiController polizasApi = new PolizasApiController();
            PolizasDtoLista PdtoLista = new PolizasDtoLista();

            PdtoLista = HttpPolizasService.GetPolizas().Result;

            foreach (PolizasDto polizas in PdtoLista.polizasDto)
            {
                polizasApi.Post(polizas);
            }
        }
    }
}
