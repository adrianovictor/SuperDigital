using SuperDigital.Api.Messages.Resource;
using SuperDigital.Api.Queries.Resources;
using SuperDigital.Common.Extensions;
using SuperDigital.Domain.Model.Accounts;
using SuperDigital.QueryProcessor.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Api.Queries.Handlers
{
    public class AccountHolderQueryUniqueHandler : IQueryUniqueHandler<QueryAccountHolder, AccountHolderResource>
    {
        private readonly IAccountHolderRepository _repository;

        public AccountHolderQueryUniqueHandler(IAccountHolderRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountHolderResource> Handle(QueryAccountHolder query)
        {
            var result = _repository
                .GetAll()
                .ByCheckintAccount(new CheckingAccount(
                    query.AccountNumber, 
                    query.AccountDigit)
                 );

            return result != null ? await CreateResource(result) : default(AccountHolderResource);
        }

        private async Task<AccountHolderResource> CreateResource(AccountHolder resource)
        {
            return await Task.FromResult(new AccountHolderResource
            {
                Id = resource.Id,
                Name = resource.Name,
                Document = resource.Document,
                AccountNumber = resource.AccountNumber,
                AccountDigit = resource.AccountDigit,
                AccountBalance = resource.AccountBalance
            });
        }
    }
}
