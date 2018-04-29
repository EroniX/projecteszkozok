using System;
using System.Linq;
using System.Linq.Expressions;

namespace EroniX.Core.DataAccess
{
    public class Ordering<TEntity, TKey> : IOrdering<TEntity>
    {
        private readonly Expression<Func<TEntity, TKey>> _orderFunc;
        private readonly Direction _direction;

        public Ordering(Expression<Func<TEntity, TKey>> orderFunc, Direction direction = Direction.Ascending)
        {
            _orderFunc = orderFunc;
            _direction = direction;
        }

        IQueryable<TEntity> IOrdering<TEntity>.ApplyOrdering(IQueryable<TEntity> @where, bool isFirst)
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
                    ? ((IOrderedQueryable<TEntity>)where).ThenBy(_orderFunc)
                    : ((IOrderedQueryable<TEntity>)where).ThenByDescending(_orderFunc);
            }
        }
    }
}
