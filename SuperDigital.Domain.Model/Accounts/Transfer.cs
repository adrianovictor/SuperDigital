using SuperDigital.Common.Extensions;
using SuperDigital.Domain.Common;
using System;

namespace SuperDigital.Domain.Model.Accounts
{
    public class Transfer : Entity<Transfer>
    {
        public int AccountHolderId { get; protected set; }
        public double Value { get; protected set; }
        public string Bank { get; protected set; }
        public string Agency { get; protected set; }
        public string Account { get; protected set; }

        protected Transfer() { }

        public Transfer(int accountHolderId, double value, string bank, string agency, string account)
        {
            if (accountHolderId.IsNull()) throw new ArgumentNullException(nameof(accountHolderId));
            if (bank.IsEmpty()) throw new ArgumentNullException(nameof(bank));
            if (agency.IsEmpty()) throw new ArgumentNullException(nameof(agency));
            if (account.IsEmpty()) throw new ArgumentNullException(nameof(account));

            AccountHolderId = accountHolderId;
            Value = value;
            Bank = bank;
            Agency = agency;
            Account = account;
        }
    }
}
