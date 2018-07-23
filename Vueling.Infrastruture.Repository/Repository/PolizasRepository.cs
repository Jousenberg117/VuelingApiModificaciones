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
    public class PolizasRepository : IRepositoryPolizas<PolizasEntity>
    {
        private readonly VuelingEntities db;

        public PolizasRepository() : this(new VuelingEntities())
        {
        }
        public PolizasRepository(
          VuelingEntities vuelingEntities)
        {
            this.db = vuelingEntities;
        }
        public PolizasEntity Add(PolizasEntity model)
        {
            Polizas poliza = null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PolizasEntity, Polizas>());
            IMapper iMapper = config.CreateMapper();
            poliza = iMapper.Map<PolizasEntity, Polizas>(model);
            try
            {
                if (db.Polizas.Find(poliza.id) == null)
                    db.Polizas.Add(poliza);
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

        public List<PolizasEntity> GetAll()
        {
            List<PolizasEntity> polizasEntity;
            IQueryable<Polizas> listaPolizas;
            

                listaPolizas = db.Polizas;
            
            IMapper iMapper = RepositoryConfigAutomapper.configLeer.CreateMapper();

            polizasEntity = iMapper.Map<List<PolizasEntity>>(listaPolizas);

            return polizasEntity;
        }

        public PolizasEntity GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
