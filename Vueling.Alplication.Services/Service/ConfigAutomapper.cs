using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vueling.Aplication.Dto;
using Vueling.Domain.Models;
using Vueling.Infrastruture.Repository.DataModel;

namespace Vueling.Common.Layer
{
    public static class ServiceConfigAutomapper
    {
        public static MapperConfiguration configEscribir;

        public static MapperConfiguration configLeer;
        static ServiceConfigAutomapper()
        {
            configEscribir = new MapperConfiguration(cfg => cfg.CreateMap<ClientesDto, ClientesEntity>());

            configLeer = new MapperConfiguration(cfg => cfg.CreateMap<ClientesDto, ClientesEntity>());
        }
    }
}
