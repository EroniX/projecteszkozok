using System.Linq;

namespace EroniX.Core.DataAccess
{
    public interface IOrdering<TEntity>
    {
        IQueryable<TEntity> ApplyOrdering(IQueryable<TEntity> where, bool isFirst);
    }
}
