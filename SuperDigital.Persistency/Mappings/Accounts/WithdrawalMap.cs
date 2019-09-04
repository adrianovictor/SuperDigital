using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperDigital.Domain.Model.Accounts;

namespace SuperDigital.Persistency.Mappings.Accounts
{
    public class WithdrawalMap : EntityMap<Withdrawal>
    {
        public WithdrawalMap(EntityTypeBuilder<Withdrawal> entity)
            : base(entity)
        {
            entity.HasKey(_ => _.Id);

            entity.Property(_ => _.AccountHolderId).IsRequired();
            entity.Property(_ => _.Value).IsRequired();
            entity.Property(_ => _.Equipament).IsRequired().HasMaxLength(16).IsUnicode(false);
        }
    }
}
