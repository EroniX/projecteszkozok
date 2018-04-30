using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EroniX.Core.DataAccess
{
    public interface IRepository<E>
        where E: class
    {
        IQueryable<E> DbSet { get; }

        void Add(E entity);

        void Update(E entity);

        void Delete(E entity);

        void Attach(E entity);

        IEnumerable<E> List(Expression<Func<E, bool>> predicate = null, Includes<E> includes = null, IOrdering<E>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false, bool keepLazy = false);
        IEnumerable<E> ListSimpleIncludes(Expression<Func<E, bool>> predicate = null, string[] includes = null, IOrdering<E>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false, bool keepLazy = false);

        Task<IEnumerable<E>> ListAsync(Expression<Func<E, bool>> predicate = null, Includes<E> includes = null, IOrdering<E>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false);
        Task<IEnumerable<E>> ListSimpleIncludesAsync(Expression<Func<E, bool>> predicate = null, string[] includes = null, IOrdering<E>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false);

        int Count(Expression<Func<E, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<E, bool>> predicate = null);
    }
}
