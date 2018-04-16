using EroniX.Core.DataAccess;

namespace EroniX.Core.Audit.Reader
{
    public class AuditUnitOfWork : UnitOfWork<AuditContext>
    {
        private BusinessAuditRepository _businessAuditRepository;
        private DiagnosticAuditRepository _diagnosticAuditRepository;

        protected override AuditContext GetContext(string connectionString)
        {
            return new AuditContext(connectionString);
        }

        public BusinessAuditRepository BusinessAuditRepository => (_businessAuditRepository = _businessAuditRepository ?? new BusinessAuditRepository(Context));

        public DiagnosticAuditRepository DiagnosticAuditRepository => (_diagnosticAuditRepository = _diagnosticAuditRepository ?? new DiagnosticAuditRepository(Context));
    }
}
