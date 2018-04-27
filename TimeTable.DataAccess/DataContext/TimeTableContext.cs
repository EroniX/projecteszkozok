using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.DataAccess.DataContext
{
    using System.Data.Entity;

    public partial class TimeTableContext : DbContext
    {
        public TimeTableContext(string connectionString)
            : base(connectionString)
        { }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeTable>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.TimeTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TimeTables)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
