///F�jl neve: TimeTableContext.cs
///D�tum: 2018. 04. 24.

using System.Data.Entity;

namespace TimeTableDesigner.DataAccess.DataContext
{
    using TimeTableDesigner.Shared.Entity.Database;

    /// <summary>
    /// A TimeTableContext oszt�ly
    /// </summary>
    public partial class TimeTableContext : DbContext
    {
        /// <summary>
        /// A konstruktor, ami l�trehoz egy TimeTableContext objektumot
        /// </summary>
        /// <param name="connectionString">A connection string</param>
        public TimeTableContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// A "Courses" virtu�lis adattag (GETTER, SETTER)
        /// </summary>
        public virtual DbSet<Course> Courses { get; set; }

        /// <summary>
        /// A "TimeTables" virtu�lis adattag (GETTER, SETTER)
        /// </summary>
        public virtual DbSet<TimeTable> TimeTables { get; set; }

        /// <summary>
        /// A "Users" virtu�lis adattag (GETTER, SETTER)
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// A context inicializ�l�s�t megval�s�t� f�ggv�ny
        /// </summary>
        /// <param name="modelBuilder">A DbModelBuilder</param>
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
