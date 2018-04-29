using EroniX.Core.DataAccess;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.DataAccess.Repository;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Shared.Access.UnitOfWork;

namespace TimeTableDesigner.DataAccess.UnitOfWork
{
    public class TimeTableUnitOfWork : UnitOfWork<TimeTableContext>, ITimeTableUnitOfWork
    {
        private ITimeTableRepository _timeTableRepository;
        private ICourseRepository _courseRepository;

        public TimeTableUnitOfWork()
        { }

        public TimeTableUnitOfWork(string connectionString) 
            : base(connectionString)
        { }

        protected override TimeTableContext GetContext(string connectionString)
        {
            return new TimeTableContext(connectionString);
        }

        public ITimeTableRepository TimeTableRepository => 
            _timeTableRepository = _timeTableRepository ?? new TimeTableRepository(Context);

        public ICourseRepository CourseRepository => 
            _courseRepository = _courseRepository ?? new CourseRepository(Context);
    }
}
