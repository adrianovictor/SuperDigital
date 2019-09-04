using SuperDigital.Domain.Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDigital.Persistency.Repositories.Accounts
{
    public class AccountHolderRepository : IAccountHolderRepository
    {
        private readonly IRepository _repository;

        public AccountHolderRepository(IRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<AccountHolder> GetAll()
        {
            return _repository.GetAll<AccountHolder>();
        }
    }
}
