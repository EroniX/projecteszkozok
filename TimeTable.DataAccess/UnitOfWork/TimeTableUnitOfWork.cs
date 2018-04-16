using EroniX.Core.DataAccess;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.DataAccess.Repository;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Shared.Access.UnitOfWork;

namespace TimeTableDesigner.DataAccess.UnitOfWork
{
    public class TimeTableUnitOfWork : UnitOfWork<TimeTableContext>, ITimeTableUnitOfWork
    {
        private IUserRepository _userRepository;
        private ISemesterRepository _semesterRepository;
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

        public IUserRepository UserRepository => 
            _userRepository = _userRepository ?? new UserRepository(Context);

        public ISemesterRepository SemesterRepository => 
            _semesterRepository = _semesterRepository ?? new SemesterRepository(Context);

        public ICourseRepository CourseRepository => 
            _courseRepository = _courseRepository ?? new CourseRepository(Context);
    }
}
