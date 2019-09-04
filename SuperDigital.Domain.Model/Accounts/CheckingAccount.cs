using SuperDigital.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Model.Accounts
{
    public class CheckingAccount
    {
        public string AccountNumber { get; protected set; }
        public string AccountDigit { get; protected set; }

        public CheckingAccount(string accountNumber, string accountDigit)
        {
            if (accountNumber.IsEmpty()) throw new ArgumentNullException(nameof(accountNumber));
            if (accountDigit.IsEmpty()) throw new ArgumentNullException(nameof(accountDigit));

            AccountNumber = accountNumber;
            AccountDigit = accountDigit;
        }
    }
}
