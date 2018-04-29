using System;
using EroniX.Core.Domain;

namespace EroniX.Core.DataAccess
{
    public interface IEntityWithStringIdRepository<TEntity> : IRepository<TEntity>
        where TEntity: class, IEntityWithStringId
    {
        TEntity Get(string id, Includes<TEntity> includes = null);
        TEntity GetSimpleIncludes(string id, string[] includes = null);
    }
}
