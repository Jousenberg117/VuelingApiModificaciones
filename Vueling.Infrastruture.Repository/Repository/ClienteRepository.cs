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
        
        public ClientesEntity Add(ClientesEntity model)
        {
            Clientes cliente = null;
            IMapper iMapper = RepositoryConfigAutomapper.configEscribir.CreateMapper();

            cliente = iMapper.Map<ClientesEntity, Clientes>(model);

            try
            {
                if (db.Clientes.Find(cliente.id) == null)
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                VuelingLogger.Logger(ex);
                throw new VuelingException(Resources.DbUpdateConcurrencyException, ex);
            }
            catch (DbUpdateException ex)
            {
                VuelingLogger.Logger(ex);
                throw new VuelingException(Resources.DbUpdateException, ex);
            }
            catch (DbEntityValidationException ex)
            {
                VuelingLogger.Logger(ex);
                throw new VuelingException(Resources.DbEntityValidationException, ex);
            }
            catch (NotSupportedException ex)
            {
                VuelingLogger.Logger(ex);
                throw new VuelingException(Resources.NotSupportedException, ex);
            }
            catch (ObjectDisposedException ex)
            {
                VuelingLogger.Logger(ex);
                throw new VuelingException(Resources.ObjectDisposedException, ex);
            }
            catch (InvalidOperationException ex)
            {
                VuelingLogger.Logger(ex);
                throw new VuelingException(Resources.InvalidOperationException, ex);
            }
            return model;
        }

        public List<ClientesEntity> GetAll()
        {
            List<ClientesEntity> clienteEntity;
            IQueryable<Clientes> listaClientes;

                listaClientes = db.Clientes;

            IMapper iMapper = RepositoryConfigAutomapper.configLeer.CreateMapper();

            clienteEntity = iMapper.Map<List<ClientesEntity>>(listaClientes);

            return clienteEntity;
        }

        public ClientesEntity GetById(string Id)
        {
            ClientesEntity clienteEntity;
            Clientes cliente;

            IMapper iMapper = RepositoryConfigAutomapper.configLeer.CreateMapper();
            

                cliente = db.Clientes.Find(Id);


            clienteEntity = iMapper.Map<ClientesEntity>(cliente);
            return clienteEntity;
        }
        public List<ClientesEntity> GetByName(string name)
        {
            List<ClientesEntity> clienteEntity;
            IQueryable<Clientes> cliente;

            IMapper iMapper = RepositoryConfigAutomapper.configLeer.CreateMapper();


                cliente = db.Clientes
                        .Where(b => b.name == name);


            clienteEntity = iMapper.Map<List<ClientesEntity>>(cliente);
            return clienteEntity;
        }
    }
}
