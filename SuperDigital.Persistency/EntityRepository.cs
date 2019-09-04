using SuperDigital.Domain.Common;
using SuperDigital.Persistency.DataContexts;
using SuperDigital.Persistency.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDigital.Persistency
{
    public class EntityRepository : IRepository
    {
        private readonly SuperDigitalContext _context;

        public EntityRepository(SuperDigitalContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll<T>() where T : class, IEntity<T>
        {
            return _context.Set<T>();
        }
    }
}
