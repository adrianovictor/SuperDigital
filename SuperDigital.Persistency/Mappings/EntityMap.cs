using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperDigital.Domain.Common;

namespace SuperDigital.Persistency.Mappings
{
    public abstract class EntityMap<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        public EntityMap(EntityTypeBuilder<TEntity> entity)
        {
            entity.Property(_ => _.CreatedAt).IsRequired();
            entity.Property(_ => _.CreatedBy).IsRequired();
            entity.Property(_ => _.UpdatedAt);
            entity.Property(_ => _.UpdatedBy);
        }
    }
}
