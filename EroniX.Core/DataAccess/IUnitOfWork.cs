using System;
using System.Threading.Tasks;

namespace EroniX.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void SaveChanges();

        Task SaveChangesAsync();

        void Commit();

        Task CommitAsync();

        void Rollback();
    }
}
