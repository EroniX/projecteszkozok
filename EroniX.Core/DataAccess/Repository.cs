using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EroniX.Core.DataAccess
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected DbContext Context;

        public IQueryable<TEntity> DbSet => Context.Set<TEntity>();

        protected Repository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Attach(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
        }

        public virtual IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> predicate = null, Includes<TEntity> includes = null, IOrdering<TEntity>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false, bool keepLazy = false)
        {
            var where = Context.Set<TEntity>().Where(predicate ?? (x => true));

            if(includes!= null)
            {
                where = includes.ApplyIncludes(where);
            }
            
            if(orderBys!= null)
            {
                var isFirst = false;
                foreach (var orderBy in orderBys)
                {
                    where = orderBy.ApplyOrdering(where, isFirst);
                    isFirst = true;
                }
            }

            if (skip.HasValue)
                where = where.Skip(skip.Value);
            if (take.HasValue)
                where = where.Take(take.Value);

            if (noTracking)
                where = where.AsNoTracking();

            if (!keepLazy)
                return where.ToList();

            return where;
        }

        public virtual IEnumerable<TEntity> ListSimpleIncludes(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, IOrdering<TEntity>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false, bool keepLazy = false)
        {
            var where = Context.Set<TEntity>().Where(predicate ?? (x => true));

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    where = where.Include(include);
                }
            }

            if (orderBys != null)
            {
                var isFirst = false;
                foreach (var orderBy in orderBys)
                {
                    where = orderBy.ApplyOrdering(where, isFirst);
                    isFirst = true;
                }
            }

            if (skip.HasValue)
                where = where.Skip(skip.Value);
            if (take.HasValue)
                where = where.Take(take.Value);

            if (noTracking)
                where = where.AsNoTracking();

            if (!keepLazy)
                return where.ToList();

            return where;
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, Includes<TEntity> includes = null, IOrdering<TEntity>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false)
        {
            var list = (IQueryable<TEntity>)List(predicate, includes, orderBys, skip, take, noTracking, true);
            return await list.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ListSimpleIncludesAsync(Expression<Func<TEntity, bool>> predicate, string[] includes = null, IOrdering<TEntity>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false)
        {
            var list = (IQueryable<TEntity>)ListSimpleIncludes(predicate, includes, orderBys, skip, take, noTracking, true);
            return await list.ToListAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Context.Set<TEntity>().Count(predicate ?? (x => true));
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await Context.Set<TEntity>().CountAsync(predicate ?? (x => true));
        }
    }
}
