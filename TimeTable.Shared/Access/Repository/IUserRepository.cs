///Fájl neve: IUserRepository.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Access.Repository
{
    using EroniX.Core.DataAccess;
    using TimeTableDesigner.Shared.Entity.Database;

    /// <summary>
    /// Az IUserRepository interfész
    /// </summary>
    public interface IUserRepository : IEntityRepository<User>
    {
    }
}
