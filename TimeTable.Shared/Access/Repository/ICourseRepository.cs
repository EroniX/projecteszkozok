///Fájl neve: ICourseRepository.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Access.Repository
{
    using EroniX.Core.DataAccess;
    using TimeTableDesigner.Shared.Entity.Database;

    /// <summary>
    /// Az ICourseRepository interfész
    /// </summary>
    public interface ICourseRepository : IEntityRepository<Course>
    {
    }
}
