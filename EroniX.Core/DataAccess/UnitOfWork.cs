using System.Data.Entity;
using System.Threading.Tasks;

namespace EroniX.Core.DataAccess
{
    public abstract class UnitOfWork<EfContext> : BaseUnitOfWork
        where EfContext : DbContext
    {
        protected EfContext Context;

        protected UnitOfWork()
        {
            Database.SetInitializer<EfContext>(null);
            // dirty trick to make reference copy
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected UnitOfWork(string connectionString) :this()
        {
            Setup(connectionString);
        }

        public override void Setup(string connectionString)
        {
            Context = GetContext(connectionString);

            Context.Configuration.ValidateOnSaveEnabled = false;
        }

        protected abstract EfContext GetContext(string connectionString);

        public override void SaveChanges()
        {
            Context.SaveChanges();
        }

        public override async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public string GetCreationScript()
        {
            return ((System.Data.Entity.Infrastructure.IObjectContextAdapter)Context).ObjectContext.CreateDatabaseScript();
        }

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context?.Dispose();
                    DisposeTranScope();
                }

                _disposed = true;
            }
        }
    }
}
