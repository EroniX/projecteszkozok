using System.Data.Entity;
using EroniX.Core.DataAccess;

namespace EroniX.Core.Audit.Reader
{
    public class DiagnosticAuditRepository : EntityRepository<DiagnosticAuditEntry>
    {
        public DiagnosticAuditRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
