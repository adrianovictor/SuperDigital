using System.Threading;
using System.Threading.Tasks;

namespace SuperDigital.Domain.Common
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
