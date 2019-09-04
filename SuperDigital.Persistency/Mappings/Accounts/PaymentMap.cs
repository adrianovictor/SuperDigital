using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperDigital.Domain.Model.Accounts;

namespace SuperDigital.Persistency.Mappings.Accounts
{
    public class PaymentMap : EntityMap<Payment>
    {
        public PaymentMap(EntityTypeBuilder<Payment> entity)
            : base(entity)
        {
            entity.HasKey(_ => _.Id);

            entity.Property(_ => _.AccountHolderId).IsRequired();
            entity.Property(_ => _.Value).IsRequired();
            entity.Property(_ => _.Recipient).IsRequired().HasMaxLength(64).IsUnicode(false);
        }
    }
}
