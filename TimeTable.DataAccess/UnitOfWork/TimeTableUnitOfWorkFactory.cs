using EroniX.Core.DataAccess;
using TimeTableDesigner.Shared.Access.UnitOfWork;

namespace TimeTableDesigner.DataAccess.UnitOfWork
{
    public class TimeTableUnitOfWorkFactory : UnitOfWorkFactory<ITimeTableUnitOfWork, TimeTableUnitOfWork>, ITimeTableUnitOfWorkFactory
    {
        public TimeTableUnitOfWorkFactory(string connectionString) 
            : base(connectionString)
        {
        }
    }
}
