using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EroniX.Core.DataAccess
{
    public abstract class Repository<E> : IRepository<E>
        where E : class
    {
        protected DbContext Context;

        public IQueryable<E> DbSet => Context.Set<E>();

        protected Repository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public virtual void Add(E entity)
        {
            Context.Set<E>().Add(entity);
        }

        public virtual void Update(E entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(E entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Attach(E entity)
        {
            Context.Set<E>().Attach(entity);
        }

        public virtual IEnumerable<E> List(Expression<Func<E, bool>> predicate = null, Includes<E> includes = null, IOrdering<E>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false, bool keepLazy = false)
        {
            var where = Context.Set<E>().Where(predicate ?? (x => true));

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

        public virtual IEnumerable<E> ListSimpleIncludes(Expression<Func<E, bool>> predicate = null, string[] includes = null, IOrdering<E>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false, bool keepLazy = false)
        {
            var where = Context.Set<E>().Where(predicate ?? (x => true));

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

        public async Task<IEnumerable<E>> ListAsync(Expression<Func<E, bool>> predicate, Includes<E> includes = null, IOrdering<E>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false)
        {
            var list = (IQueryable<E>)List(predicate, includes, orderBys, skip, take, noTracking, true);
            return await list.ToListAsync();
        }

        public async Task<IEnumerable<E>> ListSimpleIncludesAsync(Expression<Func<E, bool>> predicate, string[] includes = null, IOrdering<E>[] orderBys = null, int? skip = null, int? take = null, bool noTracking = false)
        {
            var list = (IQueryable<E>)ListSimpleIncludes(predicate, includes, orderBys, skip, take, noTracking, true);
            return await list.ToListAsync();
        }

        public int Count(Expression<Func<E, bool>> predicate = null)
        {
            return Context.Set<E>().Count(predicate ?? (x => true));
        }

        public async Task<int> CountAsync(Expression<Func<E, bool>> predicate = null)
        {
            return await Context.Set<E>().CountAsync(predicate ?? (x => true));
        }
    }
}
