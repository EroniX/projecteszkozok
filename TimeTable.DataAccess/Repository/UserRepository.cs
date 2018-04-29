using EroniX.Core.DataAccess;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.DataAccess.Repository
{
    public class UserRepository : EntityWithStringIdRepository<User>, IUserRepository
    {
        public UserRepository(TimeTableContext context) : base(context)
        {
        }
    }
}
