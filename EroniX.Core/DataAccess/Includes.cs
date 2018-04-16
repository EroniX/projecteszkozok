using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EroniX.Core.DataAccess
{
    public class Includes<E>
    {
        internal Expression<Func<E, object>>[] Incls { get; }

        public Includes(params Expression<Func<E, object>>[] includes)
        {
            Incls = includes;
        }

        internal IQueryable<E> ApplyIncludes(IQueryable<E> where)
        {
            foreach (var include in Incls)
            {
                where = where.Include(include);
            }

            return where;
        }
    }
}
