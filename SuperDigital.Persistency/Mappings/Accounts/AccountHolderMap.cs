using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperDigital.Domain.Model.Accounts;

namespace SuperDigital.Persistency.Mappings.Accounts
{
    public class AccountHolderMap : EntityMap<AccountHolder>
    {
        public AccountHolderMap(EntityTypeBuilder<AccountHolder> entity)
            : base(entity)
        {
            entity.HasKey(_ => _.Id);

            entity.Property(_ => _.Name).IsRequired().HasMaxLength(128).IsUnicode(false);
            entity.Property(_ => _.Document).IsRequired().HasMaxLength(32).IsUnicode(false);
            entity.Property(_ => _.Agency).IsRequired().HasMaxLength(16).IsUnicode(false);
            entity.Property(_ => _.Avatar).IsRequired().HasMaxLength(255).IsUnicode(false);
            entity.Property(_ => _.AccountNumber).IsRequired().HasMaxLength(16).IsUnicode(false);
            entity.Property(_ => _.AccountDigit).IsRequired().HasMaxLength(4).IsUnicode(false);
            entity.Property(_ => _.Status).IsRequired();
        }
    }
}
