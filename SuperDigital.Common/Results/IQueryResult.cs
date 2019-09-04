using System;

namespace SuperDigital.Common.Results
{
    public interface IQueryResult<out TData>
    {
        TData Data { get; }
        Exception Exception { get; }
    }
}
