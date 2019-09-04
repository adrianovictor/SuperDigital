using SuperDigital.Api.Messages.Resource;
using SuperDigital.QueryProcessor.Query;

namespace SuperDigital.Api.Queries.Resources
{
    public class QueryAccountHolder : IQuery<AccountHolderResource>
    {
        public string AccountNumber { get; set; }
        public string AccountDigit { get; set; }
    }
}
