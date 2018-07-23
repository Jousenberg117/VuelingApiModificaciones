using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vueling.Domain.Models;
using Vueling.Infrastruture.Repository.DataModel;

namespace Vueling.Common.Layer
{
    public static class RepositoryConfigAutomapper
    {
        public static MapperConfiguration configEscribir;

        public static MapperConfiguration configLeer;
        static RepositoryConfigAutomapper()
        {
            configEscribir = new MapperConfiguration(cfg => cfg.CreateMap<Clientes, ClientesEntity>()); ;

            configLeer = new MapperConfiguration(cfg => cfg.CreateMap<Clientes, ClientesEntity>()
            .ForMember(dest => dest.id, sou => sou.UseValue("Privado")));
        }
    }
}
