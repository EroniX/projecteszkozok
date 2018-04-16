using System.Data.Entity;
using EroniX.Core.DataAccess;

namespace EroniX.Core.Audit.Reader
{
    public class BusinessAuditRepository : EntityRepository<BusinessAuditEntry>
    {
        public BusinessAuditRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
