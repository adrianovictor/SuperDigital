using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDigital.Domain.Model.Accounts
{
    public interface IAccountHolderRepository
    {
        IQueryable<AccountHolder> GetAll();
    }

    public static class AccountHolderRepositoryExtensions
    {
        public static AccountHolder ByDocument(this IQueryable<AccountHolder> accountHolders, string document)
        {
            return accountHolders.FirstOrDefault(_ => _.Document == document);
        }

        public static AccountHolder ByCheckintAccount(this IQueryable<AccountHolder> accountHolders, CheckingAccount checkingAccount)
        {
            return accountHolders.FirstOrDefault(_ => _.AccountNumber == checkingAccount.AccountNumber && _.AccountDigit == checkingAccount.AccountDigit);
        }
    }
}
