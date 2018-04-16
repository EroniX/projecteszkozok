using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EroniX.Core.Domain;

namespace EroniX.Core.DataAccess
{
    public abstract class EntityRepository<E> : Repository<E>, IEntityRepository<E>
        where E : class, IEntity
    {
        protected EntityRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public virtual E Get(int id, Includes<E> includes = null)
        {
            if (includes == null)
                return Context.Set<E>().Find(id);

            var get = Context.Set<E>().Where(e => e.Id == id);
            get = includes.ApplyIncludes(get);

            return get.SingleOrDefault();
        }

        public virtual E GetSimpleIncludes(int id, string[] includes = null)
        {
            if (includes == null)
                return Context.Set<E>().Find(id);

            var get = Context.Set<E>().Where(e => e.Id == id);

            foreach (var include in includes)
            {
                get = get.Include(include);
            }

            return get.SingleOrDefault();
        }
    }
}
