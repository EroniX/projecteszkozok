///Fájl neve: UserRepository.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.DataAccess.Repository
{
    using EroniX.Core.DataAccess;
    using TimeTableDesigner.DataAccess.DataContext;
    using TimeTableDesigner.Shared.Access.Repository;
    using TimeTableDesigner.Shared.Entity.Database;

    /// <summary>
    /// A felhasználókért felelős repositry
    /// </summary>
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        /// <summary>
        /// A konstruktor, ami létrehoz egy UserRepository objektumot
        /// </summary>
        /// <param name="context">A TimeTableContext</param>
        public UserRepository(TimeTableContext context) : base(context)
        {
        }
    }
}
