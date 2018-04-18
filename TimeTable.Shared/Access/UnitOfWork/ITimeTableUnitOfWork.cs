using System.Runtime.Remoting.Contexts;
using EroniX.Core.DataAccess;
using TimeTableDesigner.Shared.Access.Repository;

namespace TimeTableDesigner.Shared.Access.UnitOfWork
{
    public interface ITimeTableUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        ITimeTableRepository TimeTableRepository { get; }

        ICourseRepository CourseRepository { get; }
    }
}
