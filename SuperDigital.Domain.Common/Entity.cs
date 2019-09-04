using System;

namespace SuperDigital.Domain.Common
{
    public abstract class Entity<TEntity> : IEntity<TEntity>
        where TEntity: class
    {
        #region Properties
        public int Id { get; set; }

        #region Audit
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        #endregion

        #endregion
    }
}
