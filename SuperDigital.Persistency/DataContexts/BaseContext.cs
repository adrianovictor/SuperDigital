using Microsoft.EntityFrameworkCore;
using SuperDigital.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperDigital.Persistency.DataContexts
{
    public abstract class BaseContext<TContext> : DbContext, IUnitOfWork
        where TContext: DbContext
    {
        public BaseContext(DbContextOptions<TContext> options) 
            : base(options)
        {

        }

        public override int SaveChanges()
        {
            return Save(() =>
            {
                var affectedRows = base.SaveChanges();
                return Task.FromResult(affectedRows);
            }).Result;
        }

        public Task<int> SaveChangesAsync()
        {
            return Save(async () =>
            {
                return await base.SaveChangesAsync().ContinueWith(task =>
                {
                    return task.Result;
                });
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Save(async () =>
            {
                return await base.SaveChangesAsync(cancellationToken).ContinueWith(task =>
                {
                    return task.Result;
                }, cancellationToken);
            });
        }

        protected virtual async Task<int> Save(Func<Task<int>> action)
        {
            var affectedRows = 0;

            return affectedRows;
        }
    }
}
