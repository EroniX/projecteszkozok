using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.DataAccess.DataContext
{
    using System.Data.Entity;

    public partial class TimeTableContext : DbContext
    {
        public TimeTableContext(string connectionString)
            : base(connectionString)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BusinessAudit> BusinessAudits { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<DiagnosticAudit> DiagnosticAudits { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.TimeTable)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusinessAudit>()
                .Property(e => e.User)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAudit>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAudit>()
                .Property(e => e.Machine)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAudit>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAudit>()
                .Property(e => e.Method)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessAudit>()
                .Property(e => e.TestStringValue)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticAudit>()
                .Property(e => e.User)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticAudit>()
                .Property(e => e.EventType)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticAudit>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticAudit>()
                .Property(e => e.Machine)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticAudit>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticAudit>()
                .Property(e => e.Method)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticAudit>()
                .Property(e => e.ExceptionType)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticAudit>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<DiagnosticAudit>()
                .Property(e => e.StackTrace)
                .IsUnicode(false);

            modelBuilder.Entity<TimeTable>()
                .HasMany(e => e.Course)
                .WithRequired(e => e.TimeTable)
                .WillCascadeOnDelete(false);
        }
    }
}
