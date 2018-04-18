using EroniX.Core.DataAccess;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.DataAccess.Repository
{
    public class TimeTableRepository : EntityRepository<TimeTable>, ITimeTableRepository
    {
        public TimeTableRepository(TimeTableContext context) : base(context)
        {
        }
    }
}
