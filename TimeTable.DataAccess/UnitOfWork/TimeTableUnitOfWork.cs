///Fájl neve: TimeTableUnitOfWork.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.DataAccess.UnitOfWork
{
    using EroniX.Core.DataAccess;
    using TimeTableDesigner.DataAccess.DataContext;
    using TimeTableDesigner.DataAccess.Repository;
    using TimeTableDesigner.Shared.Access.Repository;
    using TimeTableDesigner.Shared.Access.UnitOfWork;

    /// <summary>
    /// A TimeTableUnitOfWork osztály
    /// </summary>
    public class TimeTableUnitOfWork : UnitOfWork<TimeTableContext>, ITimeTableUnitOfWork
    {
        /// <summary>
        /// Az "_userRepository" adattag
        /// </summary>
        private IUserRepository _userRepository;

        /// <summary>
        /// A "_timeTableRepository" adattag
        /// </summary>
        private ITimeTableRepository _timeTableRepository;

        /// <summary>
        /// A "_courseRepository" adattag
        /// </summary>
        private ICourseRepository _courseRepository;

        /// <summary>
        /// A konstruktor, ami létrehoz egy TimeTableUnitOfWork objektumot
        /// </summary>
        public TimeTableUnitOfWork()
        {
        }

        /// <summary>
        /// A konstruktor, ami létrehoz egy TimeTableUnitOfWork objektumot
        /// </summary>
        /// <param name="connectionString">A connection string</param>
        public TimeTableUnitOfWork(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// A context létrehozására szolgáló függvény
        /// </summary>
        /// <param name="connectionString">A connection string</param>
        /// <returns>A connectionString segítségével létrehozott TimeTableContext objektum</returns>
        protected override TimeTableContext GetContext(string connectionString)
        {
            return new TimeTableContext(connectionString);
        }

        /// <summary>
        /// Az UserRepository létrehozására/lekérdezésére szolgáló függvény
        /// </summary>
        public IUserRepository UserRepository =>
            _userRepository = _userRepository ?? new UserRepository(Context);

        /// <summary>
        /// Az TimeTableRepository létrehozására/lekérdezésére szolgáló függvény
        /// </summary>
        public ITimeTableRepository TimeTableRepository =>
            _timeTableRepository = _timeTableRepository ?? new TimeTableRepository(Context);

        /// <summary>
        /// Az CourseRepository létrehozására/lekérdezésére szolgáló függvény
        /// </summary>
        public ICourseRepository CourseRepository =>
            _courseRepository = _courseRepository ?? new CourseRepository(Context);
    }
}
