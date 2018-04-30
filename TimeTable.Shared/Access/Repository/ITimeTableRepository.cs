///Fájl neve: ITimeTableRepository.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Access.Repository
{
    using EroniX.Core.DataAccess;
    using TimeTableDesigner.Shared.Entity.Database;

    /// <summary>
    /// Az ITimeTableRepository intefész
    /// </summary>
    public interface ITimeTableRepository : IEntityRepository<TimeTable>
    {
    }
}
