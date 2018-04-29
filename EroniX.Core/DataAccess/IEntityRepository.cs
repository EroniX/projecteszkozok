using EroniX.Core.Domain;

namespace EroniX.Core.DataAccess
{
    public interface IEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity: class, IEntity
    {
        TEntity Get(int id, Includes<TEntity> includes = null);
        TEntity GetSimpleIncludes(int id, string[] includes = null);
    }
}
