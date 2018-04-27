using System.Data.Entity;
using System.Threading.Tasks;

namespace EroniX.Core.DataAccess
{
    public abstract class UnitOfWork<TEfContext> : BaseUnitOfWork
        where TEfContext : DbContext
    {
        protected TEfContext Context;

        protected UnitOfWork()
        {
            Database.SetInitializer<TEfContext>(null);
            // dirty trick to make reference copy
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected UnitOfWork(string connectionString) :this()
        {
            Setup(connectionString);
        }

        public sealed override void Setup(string connectionString)
        {
            Context = GetContext(connectionString);

            Context.Configuration.ValidateOnSaveEnabled = false;
        }

        protected abstract TEfContext GetContext(string connectionString);

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
