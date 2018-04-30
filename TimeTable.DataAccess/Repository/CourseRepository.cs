///Fájl neve: CourseRepository.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.DataAccess.Repository
{
    using EroniX.Core.DataAccess;
    using TimeTableDesigner.DataAccess.DataContext;
    using TimeTableDesigner.Shared.Access.Repository;
    using TimeTableDesigner.Shared.Entity.Database;

    /// <summary>
    /// A kurzusokért felelős repository
    /// </summary>
    public class CourseRepository : EntityRepository<Course>, ICourseRepository
    {
        /// <summary>
        /// A konstruktor, ami létrehoz egy CourseRepository objektumot
        /// </summary>
        /// <param name="context">A TimeTableContext</param>
        public CourseRepository(TimeTableContext context) : base(context)
        {
        }
    }
}
