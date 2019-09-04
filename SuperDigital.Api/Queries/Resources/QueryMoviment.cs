using SuperDigital.Api.Messages.Resource;
using SuperDigital.QueryProcessor.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Api.Queries.Resources
{
    public class QueryMoviment : IQuery<MovimentResource>
    {
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountNumber { get; set; }
        public string AccountDigit { get; set; }
    }
}
