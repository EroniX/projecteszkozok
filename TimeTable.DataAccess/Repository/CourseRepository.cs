using EroniX.Core.DataAccess;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.DataAccess.Repository
{
    /// <summary>
    /// A tanfolyamokért felelős repository
    /// </summary>
    public class CourseRepository : EntityRepository<Course>, ICourseRepository
    {
        public CourseRepository(TimeTableContext context) : base(context)
        {
        }
    }
}
