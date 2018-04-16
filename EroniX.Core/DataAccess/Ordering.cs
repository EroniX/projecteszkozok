using System;
using System.Linq;
using System.Linq.Expressions;

namespace EroniX.Core.DataAccess
{
    public class Ordering<E, Key> : IOrdering<E>
    {
        private readonly Expression<Func<E, Key>> _orderFunc;
        private readonly Direction _direction;

        public Ordering(Expression<Func<E, Key>> orderFunc, Direction direction = Direction.Ascending)
        {
            _orderFunc = orderFunc;
            _direction = direction;
        }

        IQueryable<E> IOrdering<E>.ApplyOrdering(IQueryable<E> @where, bool isFirst)
        {
            if (!isFirst)
            {
                return _direction == Direction.Ascending
                    ? where.OrderBy(_orderFunc)
                    : where.OrderByDescending(_orderFunc);
            }
            else
            {
                return _direction == Direction.Ascending
                    ? ((IOrderedQueryable<E>)where).ThenBy(_orderFunc)
                    : ((IOrderedQueryable<E>)where).ThenByDescending(_orderFunc);
            }
        }
    }
}
