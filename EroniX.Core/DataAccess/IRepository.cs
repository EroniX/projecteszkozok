using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EroniX.Core.DataAccess
{
    public interface IRepository<TEntity>
        where TEntity: class
    {
        IQueryable<TEntity> DbSet { get; }

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Attach(TEntity entity);

        IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate = null, Includes<TEntity> includes = null, IOrdering<TEntity>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false, bool keepLazy = false);
        IEnumerable<TEntity> ListSimpleIncludes(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, IOrdering<TEntity>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false, bool keepLazy = false);

        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate = null, Includes<TEntity> includes = null, IOrdering<TEntity>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false);
        Task<IEnumerable<TEntity>> ListSimpleIncludesAsync(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, IOrdering<TEntity>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false);

        int Count(Expression<Func<TEntity, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
