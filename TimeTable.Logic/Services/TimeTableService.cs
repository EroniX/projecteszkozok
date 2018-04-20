using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EroniX.Core.Audit;
using EroniX.Core.Services;
using TimeTableDesigner.Shared.Access;
using TimeTableDesigner.Shared.Access.Service;
using TimeTableDesigner.Shared.Access.UnitOfWork;
using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.Logic.Services
{
    public class TimeTableService : ServiceBaseWithUoWFactory<ITimeTableAppContextProvider, ITimeTableUnitOfWorkFactory,
        ITimeTableUnitOfWork>, ITimeTableService
    {
        public TimeTableService(ITimeTableUnitOfWorkFactory uoWFactory, ITimeTableAppContextProvider appContextProvider, ILogger logger) 
            : base(uoWFactory, appContextProvider, logger)
        {
        }

        public async Task<IEnumerable<TimeTable>> ListTimeTablesForUserAsync(string userId)
        {
            using (var uow = UoWFactory.Create())
            {
                return await uow.TimeTableRepository.ListAsync(n => n.UserId == userId);
            }
        }
    }
}
