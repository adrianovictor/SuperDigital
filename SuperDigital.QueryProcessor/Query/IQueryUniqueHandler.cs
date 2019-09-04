using System.Threading.Tasks;

namespace SuperDigital.QueryProcessor.Query
{
    public interface IQueryUniqueHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
    {
        Task<TResult> Handle(TQuery query);
    }
}
