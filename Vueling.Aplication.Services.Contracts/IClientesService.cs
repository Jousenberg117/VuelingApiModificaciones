﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Aplication.Services.Contracts
{
    public interface IClientesService<T>
    {
        T Add(T model);
        List<T> GetAll();
        T GetById(Guid Id);
        List<T> GetByName(string name);
        T GetByEmail(string email);
    }
}
