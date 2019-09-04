using Microsoft.Extensions.DependencyInjection;
using SuperDigital.QueryProcessor.Query;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SuperDigital.QueryProcessor.Dispatcher
{
    public class QueryInvoker<TResult> 
        where TResult: class
    {
        private readonly MethodInfo _handleMethod;
        private readonly Func<object> _builderHandlerInstance;

        public QueryInvoker(Type queryHandlerType, string handlerMethodName, Type queryType)
        {
            var handlerType = queryHandlerType.MakeGenericType(queryType, typeof(TResult));
            _handleMethod = GetHandlerMethod(handlerType, handlerMethodName, queryType);            
        }

        public TResult Unique(IQuery<TResult> query)
        {
            return (TResult)_handleMethod.Invoke(_builderHandlerInstance(), new[] { query });
        }

        public IEnumerable<TResult> List(IQuery<TResult> query)
        {
            return (IEnumerable<TResult>)_handleMethod.Invoke(_builderHandlerInstance(), new[] { query });
        }

        private MethodInfo GetHandlerMethod(Type handlerType, string handlerMethodName, Type queryType)
        {
            return handlerType.GetMethod(handlerMethodName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod, null,
                CallingConventions.HasThis, new[] { queryType }, null);
        }
    }
}
