using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Layer;
using Vueling.Domain.Models;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastruture.Repository.DataModel;

namespace Vueling.Infrastruture.Repository.Repository
{
    public class ClienteRepository : IRepositoryClientes<ClientesEntity>
    {
        private readonly VuelingEntities db;

        public ClienteRepository() : this(new VuelingEntities())
        {
        }
        public ClienteRepository(
          VuelingEntities vuelingEntities)
        {
            this.db = vuelingEntities;
        }
        static MapperConfiguration configEscribir;

        static MapperConfiguration configLeer;
        static ClienteRepository()
        {
            configEscribir = new MapperConfiguration(cfg => cfg.CreateMap<Clientes, ClientesEntity>()); ;

            configLeer = new MapperConfiguration(cfg => cfg.CreateMap<Clientes, ClientesEntity>()
            .ForMember(dest => dest.id, sou => sou.Ignore())
            .ForMember(dest => dest.role, sou => sou.Ignore()));
        }
        public ClientesEntity Add(ClientesEntity model)
        {
            Clientes cliente = null;
            IMapper iMapper = configEscribir.CreateMapper();
            cliente = iMapper.Map<ClientesEntity, Clientes>(model);

            try
            {
                if (db.Clientes.Find(cliente.id) == null)
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new VuelingException(Resources.DbUpdateConcurrencyException, ex);
            }
            catch (DbUpdateException ex)
            {
                throw new VuelingException(Resources.DbUpdateException, ex);
            }
            catch (DbEntityValidationException ex)
            {
                throw new VuelingException(Resources.DbEntityValidationException, ex);
            }
            catch (NotSupportedException ex)
            {
                throw new VuelingException(Resources.NotSupportedException, ex);
            }
            catch (ObjectDisposedException ex)
            {
                throw new VuelingException(Resources.ObjectDisposedException, ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new VuelingException(Resources.InvalidOperationException, ex);
            }
            return model;
        }

        public List<ClientesEntity> GetAll()
        {
            List<ClientesEntity> clienteEntity;
            IQueryable<Clientes> listaClientes;

            try
            {
                listaClientes = db.Clientes;
            }
            catch (Exception ex)

            {
                VuelingLogger.Logger(ex);
                throw ex;
            }

            IMapper iMapper = configLeer.CreateMapper();

            clienteEntity = iMapper.Map<List<ClientesEntity>>(listaClientes);

            return clienteEntity;
        }

        public ClientesEntity GetById(string Id)
        {
            ClientesEntity clienteEntity;
            Clientes cliente;

            IMapper iMapper = configLeer.CreateMapper();


            try
            {
                cliente = db.Clientes.Find(Id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            clienteEntity = iMapper.Map<ClientesEntity>(cliente);
            return clienteEntity;
        }
        public List<ClientesEntity> GetByName(string name)
        {
            List<ClientesEntity> clienteEntity;
            IQueryable<Clientes> cliente;

            IMapper iMapper = configLeer.CreateMapper();


            try
            {
                cliente = db.Clientes
                        .Where(b => b.name == name);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            clienteEntity = iMapper.Map<List<ClientesEntity>>(cliente);
            return clienteEntity;
        }
    }
}
