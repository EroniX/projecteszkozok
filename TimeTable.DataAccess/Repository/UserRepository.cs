using EroniX.Core.DataAccess;
using TimeTableDesigner.DataAccess.DataContext;
using TimeTableDesigner.Shared.Access.Repository;
using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.DataAccess.Repository
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(TimeTableContext context) : base(context)
        {
        }
    }
}
