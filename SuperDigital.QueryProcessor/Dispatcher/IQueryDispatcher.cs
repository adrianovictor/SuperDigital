using SuperDigital.Common.Results;
using SuperDigital.QueryProcessor.Query;
using System.Collections.Generic;

namespace SuperDigital.QueryProcessor.Dispatcher
{
    public interface IQueryDispatcher
    {
        IQueryResult<IEnumerable<TResult>> ProcessList<TResult>(IQuery<TResult> query);
    }
}
