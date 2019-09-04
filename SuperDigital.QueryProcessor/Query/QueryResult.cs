using SuperDigital.Common.Results;
using System;

namespace SuperDigital.QueryProcessor.Query
{
    public class QueryResult<TData> : IQueryResult<TData>
    {
        public TData Data { get; private set; }
        public Exception Exception { get; private set; }

        public static QueryResult<TData> WithData(TData data)
        {
            return new QueryResult<TData> { Data = data };
        }

        public static QueryResult<TData> WithException(Exception exception)
        {
            return new QueryResult<TData> { Exception = exception };
        }
    }
}
