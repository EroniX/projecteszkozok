using System.Threading.Tasks;
using System.Transactions;

namespace EroniX.Core.DataAccess
{
    public abstract class BaseUnitOfWork : IUnitOfWork
    {
        private TransactionScope _transactionScope;

        public abstract void Setup(string connectionString);

        public void BeginTransaction()
        {
            _transactionScope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);
        }

        public void Commit()
        {
            SaveChanges();
            _transactionScope?.Complete();
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
            _transactionScope?.Complete();
        }

        public abstract void SaveChanges();

        public abstract Task SaveChangesAsync();

        public void Rollback()
        {
            DisposeTranScope();
        }

        protected void DisposeTranScope()
        {
            _transactionScope?.Dispose();
            _transactionScope = null;
        }

        protected abstract void Dispose(bool disposing);

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
