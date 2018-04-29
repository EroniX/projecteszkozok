using EroniX.Core.DataAccess;
using TimeTableDesigner.Shared.Access.Repository;

namespace TimeTableDesigner.Shared.Access.UnitOfWork
{
    public interface ITimeTableUnitOfWork : IUnitOfWork
    {
        ITimeTableRepository TimeTableRepository { get; }

        ICourseRepository CourseRepository { get; }
    }
}
