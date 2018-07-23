using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Aplication.Dto;
using Vueling.Aplication.Services.Contracts;
using Vueling.Common.Layer;
using Vueling.Domain.Models;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastruture.Repository.Repository;

namespace Vueling.Alplication.Services.Service
{
    public class PolizasService : IPolizasService<PolizasDto>
    {
        private readonly IRepositoryPolizas<PolizasEntity> polizaRepository;

        public PolizasService() : this(new PolizasRepository())
        {
        }
        public PolizasService(
          PolizasRepository polizaRepository)
        {
            this.polizaRepository = polizaRepository;
        }

        static MapperConfiguration configEscribir;

        static MapperConfiguration configLeer;

        static PolizasService()
        {
            configEscribir = new MapperConfiguration(cfg => cfg.CreateMap<PolizasDto, PolizasEntity>());;

            configLeer = new MapperConfiguration(cfg => cfg.CreateMap<PolizasDto, PolizasEntity>()
            .ForMember(dest => dest.id, sou => sou.Ignore())
            .ForMember(dest => dest.inceptionDate, sou => sou.Ignore())
            .ForMember(dest => dest.installmentPayment, sou => sou.Ignore()));
        }
       

        
        public PolizasDto Add(PolizasDto model)
        {
            PolizasEntity polizaEntity = null;
            IMapper iMapper = configEscribir.CreateMapper();

            polizaEntity = iMapper.Map<PolizasDto, PolizasEntity>(model);

            try
            {
                polizaRepository.Add(polizaEntity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<PolizasDto> GetAll()
        {
            List<PolizasDto> listaPolizasDtos;
            List<PolizasEntity> listaClientesRepositoryEntry;
            listaClientesRepositoryEntry = polizaRepository.GetAll();
            IMapper iMapper = configLeer.CreateMapper();

            listaPolizasDtos = iMapper.Map<List<PolizasDto>>(listaClientesRepositoryEntry);
            return listaPolizasDtos;
        }

        public PolizasDto GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public PolizasDto Update(PolizasDto model)
        {
            throw new NotImplementedException();
        }
    }
}
