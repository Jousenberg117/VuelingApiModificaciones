using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Infrastructure.Repository.Contracts
{
    public interface IRepositoryPolizas<T>
    {
        T Add(T model);
        List<T> GetAll();
        T GetById(Guid Id);

    }
}
