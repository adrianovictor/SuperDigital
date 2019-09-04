using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperDigital.Domain.Model.Accounts;

namespace SuperDigital.Persistency.Mappings.Accounts
{
    public class DepositMap : EntityMap<Deposit>
    {
        public DepositMap(EntityTypeBuilder<Deposit> entity)
            : base(entity)
        {
            entity.HasKey(_ => _.Id);

            entity.Property(_ => _.AccountHolderId).IsRequired();
            entity.Property(_ => _.Value).IsRequired();
            entity.Property(_ => _.Bank).IsRequired().HasMaxLength(4).IsUnicode(false);
            entity.Property(_ => _.Agency).IsRequired().HasMaxLength(8).IsUnicode(false);
            entity.Property(_ => _.Account).IsRequired().HasMaxLength(16).IsUnicode(false);
        }
    }
}
