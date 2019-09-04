using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Domain.Common
{
    public interface IEntity<in TEntity> : IAudit
        where TEntity: class
    {
    }
}
