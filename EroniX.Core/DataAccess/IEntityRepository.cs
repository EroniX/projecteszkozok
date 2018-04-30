using EroniX.Core.Domain;

namespace EroniX.Core.DataAccess
{
    public interface IEntityRepository<E> : IRepository<E>
        where E: class, IEntity
    {
        E Get(int id, Includes<E> includes = null);
        E GetSimpleIncludes(int id, string[] includes = null);
    }
}
