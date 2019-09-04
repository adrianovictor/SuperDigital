using SuperDigital.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDigital.Persistency.Repositories
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : class, IEntity<T>;
    }
}
