using System.Data.Entity;
using System.Linq;
using EroniX.Core.Domain;

namespace EroniX.Core.DataAccess
{
    public abstract class EntityWithStringIdRepository<TEntity> : Repository<TEntity>, IEntityWithStringIdRepository<TEntity>
        where TEntity : class, IEntityWithStringId
    {
        protected EntityWithStringIdRepository(DbContext dbContext) : base(dbContext)
        { }

        public virtual TEntity Get(string id, Includes<TEntity> includes = null)
        {
            if (includes == null)
                return Context.Set<TEntity>().Find(id);

            var get = Context.Set<TEntity>().Where(e => e.Id == id);
            get = includes.ApplyIncludes(get);

            return get.SingleOrDefault();
        }

        public virtual TEntity GetSimpleIncludes(string id, string[] includes = null)
        {
            if (includes == null)
                return Context.Set<TEntity>().Find(id);

            var get = Context.Set<TEntity>().Where(e => e.Id == id);

            foreach (var include in includes)
            {
                get = get.Include(include);
            }

            return get.SingleOrDefault();
        }
    }
}
