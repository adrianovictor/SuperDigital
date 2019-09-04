using SuperDigital.Common.Extensions;
using SuperDigital.Domain.Common;
using System;

namespace SuperDigital.Domain.Model.Accounts
{
    public class Payment : Entity<Payment>
    {
        public int AccountHolderId { get; protected set; }
        public double Value { get; protected set; }
        public string Recipient { get; protected set; }

        public Payment(int accountHolderId, double value, string recipient)
        {
            if (AccountHolderId.IsNull()) throw new ArgumentNullException(nameof(accountHolderId));
            if (recipient.IsEmpty()) throw new ArgumentNullException(nameof(recipient));

            AccountHolderId = accountHolderId;
            Value = value;
            Recipient = recipient;
        }
    }
}
