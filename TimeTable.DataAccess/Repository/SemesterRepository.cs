using EroniX.Core.DataAccess;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.DataAccess.Repository
{
    public class SemesterRepository : EntityRepository<TimeTable>, ISemesterRepository
    {
        public SemesterRepository(TimeTableContext context) : base(context)
        {
        }
    }
}
