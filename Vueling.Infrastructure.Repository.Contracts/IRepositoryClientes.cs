using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Infrastructure.Repository.Contracts
{
    public interface IRepositoryClientes<T>
    {
        T Add(T model);
        List<T> GetAll();
        T GetById(string Id);
        List<T> GetByName(string name);

    }
}
