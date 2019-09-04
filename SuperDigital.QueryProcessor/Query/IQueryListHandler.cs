using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.QueryProcessor.Query
{
    public interface IQueryListHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
    {
        Task<IEnumerable<TResult>> Handle(TQuery query);
    }
}
