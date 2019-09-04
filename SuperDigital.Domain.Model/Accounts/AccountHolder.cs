using SuperDigital.Common.Exceptions;
using SuperDigital.Common.Extensions;
using SuperDigital.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Model.Accounts
{
    public class AccountHolder : Entity<AccountHolder>
    {
        public string Name { get; protected set; }
        public string Document { get; protected set; }
        public string Agency { get; protected set; }
        public string AccountNumber { get; protected set; }
        public string AccountDigit { get; protected set; }
        public string Avatar { get; protected set; }
        public AccountStatus Status { get; protected set; }
        public double AccountBalance { get; protected set; }

        protected AccountHolder() { }

        public AccountHolder(string name, string document, string agency, string avatar = null, double accountBalance = 0.00,
            AccountStatus status = AccountStatus.Active)
        {
            if (name.IsEmpty()) throw new ArgumentNullException(nameof(name));
            if (document.IsEmpty()) throw new ArgumentNullException(nameof(document));
            if (agency.IsEmpty()) throw new ArgumentNullException(nameof(agency));

            Name = name;
            Document = document;
            Agency = agency;
            Avatar = avatar;
            Status = status;
            AccountBalance = accountBalance;
        }

        public static AccountHolder Create(string name, string document, string agency, double accountBalance = 0.00)
        {
            return new AccountHolder(
                name: name, 
                document: document, 
                agency: agency, 
                accountBalance: accountBalance);
        }

        public void ChangeInfo(string name, string document)
        {
            if (name.IsEmpty()) throw new ArgumentNullException(nameof(name));
            if (document.IsEmpty()) throw new ArgumentNullException(nameof(document));

            Name = name;
            Document = document;
        }

        public void ChangeStatus(AccountStatus status)
        {
            if (Status == AccountStatus.Deleted)
                throw new CannotChangeStatusOfADeletedEntityException();

            Status = status;
        }

        public void ChangeAgency(CheckingAccount checkingAccount)
        {
            if (checkingAccount.IsNull()) throw new ArgumentNullException(nameof(checkingAccount));

            AccountNumber = checkingAccount.AccountNumber;
            AccountDigit = checkingAccount.AccountDigit;
        }

        public void ChangeAccountBalance(double value)
        {
            value = value;
        }
    }
}
