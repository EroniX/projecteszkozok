///Fájl neve: TimeTableRepository.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.DataAccess.Repository
{
    using EroniX.Core.DataAccess;
    using TimeTableDesigner.DataAccess.DataContext;
    using TimeTableDesigner.Shared.Access.Repository;
    using TimeTableDesigner.Shared.Entity.Database;

    /// <summary>
    /// Az órarendért felelős repositry
    /// </summary>
    public class TimeTableRepository : EntityRepository<TimeTable>, ITimeTableRepository
    {
        /// <summary>
        /// A konstruktor, ami létrehoz egy TimeTableRepository objektumot
        /// </summary>
        /// <param name="context">A TimeTableContext</param>
        public TimeTableRepository(TimeTableContext context) : base(context)
        {
        }
    }
}
