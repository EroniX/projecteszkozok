using EroniX.Core.DataAccess;

namespace EroniX.Core.Audit.Reader
{
    public class AuditUnitOfWorkFactory : UnitOfWorkFactory<AuditUnitOfWork, AuditUnitOfWork>
    {
        public AuditUnitOfWorkFactory(string connectionString) : base(connectionString)
        {
        }
    }
}
