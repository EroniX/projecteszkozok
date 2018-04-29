using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EroniX.Core.DataAccess
{
    public class Includes<TEntity>
    {
        internal Expression<Func<TEntity, object>>[] Incls { get; }

        public Includes(params Expression<Func<TEntity, object>>[] includes)
        {
            Incls = includes;
        }

        internal IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> where)
        {
            foreach (var include in Incls)
            {
                where = where.Include(include);
            }

            return where;
        }
    }
}
