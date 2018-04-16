using EroniX.Core.Audit;
using EroniX.Core.Services;
using TimeTableDesigner.Shared.Access;
using TimeTableDesigner.Shared.Access.Service;
using TimeTableDesigner.Shared.Access.UnitOfWork;

namespace TimeTableDesigner.Logic.Services
{
    public class TimeTableService : ServiceBaseWithUoWFactory<ITimeTableAppContextProvider, ITimeTableUnitOfWorkFactory,
        ITimeTableUnitOfWork>, ITimeTableService
    {
        public TimeTableService(ITimeTableUnitOfWorkFactory uoWFactory, ITimeTableAppContextProvider appContextProvider, ILogger logger) 
            : base(uoWFactory, appContextProvider, logger)
        {
        }
    }
}
