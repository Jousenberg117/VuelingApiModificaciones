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
    public class ClientesService : IClientesService<ClientesDto>
    {
        private readonly IRepositoryClientes<ClientesEntity> clienteRepository;

        static MapperConfiguration configEscribir;

        static MapperConfiguration configLeer;

        static ClientesService()
        {
            configEscribir = new MapperConfiguration(cfg => cfg.CreateMap<ClientesDto, ClientesEntity>());;

            configLeer = new MapperConfiguration(cfg => cfg.CreateMap<ClientesDto, ClientesEntity>()
            .ForMember(dest => dest.id, sou => sou.Ignore())
            .ForMember(dest => dest.role, sou => sou.Ignore()));
        }
        public ClientesService() : this(new ClienteRepository())
        {
        }
        public ClientesService(
          ClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        
        public ClientesDto Add(ClientesDto model)
        {
            ClientesEntity clienteEntity = null;
            IMapper iMapper = configEscribir.CreateMapper();

            clienteEntity = iMapper.Map<ClientesDto, ClientesEntity>(model);

            try
            {
                clienteRepository.Add(clienteEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<ClientesDto> GetAll()
        {
            List<ClientesDto> listaClientesDtos;
            List<ClientesEntity> listaClientesRepositoryEntry;
            listaClientesRepositoryEntry = clienteRepository.GetAll();
            IMapper iMapper = configLeer.CreateMapper();

            listaClientesDtos = iMapper.Map<List<ClientesDto>>(listaClientesRepositoryEntry);
            return listaClientesDtos;
        }

        public ClientesDto GetById(string Id)
        {
            ClientesDto cliente;
            ClientesEntity clientesEntityEntry;
            clientesEntityEntry = clienteRepository.GetById(Id);
            IMapper iMapper = configLeer.CreateMapper();
            cliente = iMapper.Map<ClientesDto>(clientesEntityEntry);
            return cliente;
        }
        public List<ClientesDto> GetByName(string name)
        {
            List<ClientesDto> cliente;
            List<ClientesEntity> clientesEntityEntry;
            clientesEntityEntry = clienteRepository.GetByName(name);
            IMapper iMapper = configLeer.CreateMapper();
            cliente = iMapper.Map<List<ClientesDto>>(clientesEntityEntry);
            return cliente;
        }
    }
}
