using System;
using System.Collections.Generic;
using System.Text;
using SuperDigital.Common.Extensions;
using SuperDigital.Common.Results;
using SuperDigital.QueryProcessor.Query;

namespace SuperDigital.QueryProcessor.Dispatcher
{
    public class QueryDispatcher : IQueryDispatcher
    {
        public IQueryResult<IEnumerable<TResult>> ProcessList<TResult>(IQuery<TResult> query)
        {
            if (query.IsNull()) throw new ArgumentNullException("query");

            //return TryExecute(query);
            return null;
        }

        //private IQueryResult<IEnumerable<TResult>> TryExecute<TResult>(IQuery<TResult> query)
        //{
        //    var result = default(QueryResult<IEnumerable<TResult>>);

        //    try
        //    {
        //        var invoker = new QueryInvoker<TResult>(typeof(IQueryListHandler<,>), "HandleList", query.GetType());
        //        var data = invoker.List(query);

        //        result = QueryResult<IEnumerable<TResult>>.WithData(data);
        //    }
        //    catch (Exception exception)
        //    {
        //        result = QueryResult<IEnumerable<TResult>>.WithException(exception);
        //    }

        //    return result;
        //}
    }
}
