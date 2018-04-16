using System.Linq;

namespace EroniX.Core.DataAccess
{
    public interface IOrdering<E>
    {
        IQueryable<E> ApplyOrdering(IQueryable<E> where, bool isFirst);
    }
}
