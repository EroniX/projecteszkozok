using System.Data.Entity;

namespace EroniX.Core.Audit.Reader
{
    public class AuditContext : DbContext
    {
        public AuditContext(string connectionString) : base(connectionString)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessAuditEntry>().ToTable("BusinessAudit");
            modelBuilder.Entity<DiagnosticAuditEntry>().ToTable("DiagnosticAudit");
        }

        public DbSet<BusinessAuditEntry> BusinessAudit { get; }
        public DbSet<DiagnosticAuditEntry> DiagnosticAudit { get; }
    }
}
