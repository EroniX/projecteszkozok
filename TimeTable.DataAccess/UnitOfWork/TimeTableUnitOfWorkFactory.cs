///Fájl neve: TimeTableUnitOfWorkFactory.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.DataAccess.UnitOfWork
{
    using EroniX.Core.DataAccess;
    using TimeTableDesigner.Shared.Access.UnitOfWork;

    /// <summary>
    /// A TimeTableUnitOfWorkFactory osztály
    /// </summary>
    public class TimeTableUnitOfWorkFactory : UnitOfWorkFactory<ITimeTableUnitOfWork, TimeTableUnitOfWork>, ITimeTableUnitOfWorkFactory
    {
        /// <summary>
        /// A konstruktor, ami létrehoz egy TimeTableUnitOfWorkFactory objektumot
        /// </summary>
        /// <param name="connectionString">A connection string</param>
        public TimeTableUnitOfWorkFactory(string connectionString) 
            : base(connectionString)
        {
        }
    }
}
