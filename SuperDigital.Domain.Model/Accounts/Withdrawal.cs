using SuperDigital.Common.Extensions;
using SuperDigital.Domain.Common;
using System;

namespace SuperDigital.Domain.Model.Accounts
{
    public class Withdrawal : Entity<Withdrawal>
    {
        public int AccountHolderId { get; protected set; }
        public double Value { get; protected set; }
        public string Equipament { get; protected set; }

        public Withdrawal(int accountHolderId, double value, string equipament)
        {
            if (AccountHolderId.IsNull()) throw new ArgumentNullException(nameof(accountHolderId));
            if (equipament.IsEmpty()) throw new ArgumentNullException(nameof(equipament));

            AccountHolderId = accountHolderId;
            Value = value;
            Equipament = equipament;
        }
    }
}
