//Fájl neve: TimeTableService.cs
//Dátum: 2018. 04. 23.

namespace TimeTableDesigner.Logic.Services
{
    using EroniX.Core.Audit;
    using EroniX.Core.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TimeTableDesigner.Shared.Access;
    using TimeTableDesigner.Shared.Access.Service;
    using TimeTableDesigner.Shared.Access.UnitOfWork;
    using TimeTableDesigner.Shared.Entity.Database;

    /// <summary>
    /// TimeTableService osztály
    /// </summary>
    public class TimeTableService : ServiceBaseWithUoWFactory<ITimeTableAppContextProvider, ITimeTableUnitOfWorkFactory,
        ITimeTableUnitOfWork>, ITimeTableService
    {
        /// <summary>
        /// A konstruktor, ami létrehoz egy TimeTableService objektumot
        /// </summary>
        /// <param name="uoWFactory">Az ITimeTableUnitOfWorkFactory</param>
        /// <param name="appContextProvider">Az ITimeTableAppContextProvider</param>
        /// <param name="logger">Az ILogger</param>
        public TimeTableService(ITimeTableUnitOfWorkFactory uoWFactory, ITimeTableAppContextProvider appContextProvider, ILogger logger) 
            : base(uoWFactory, appContextProvider, logger)
        {
        }

        /// <summary>
        /// Egy adott felhasználóhoz tartozó órarend megjelenítése
        /// </summary>
        /// <param name="userId">A felhasználó azonosítója</param>
        /// <returns>A megfelelő TimeTable objektumokat tartalmazó lista</returns>
        public async Task<IEnumerable<TimeTable>> ListTimeTablesForUserAsync(string userId)
        {
            using (var uow = UoWFactory.Create())
            {
                return await uow.TimeTableRepository.ListAsync(n => n.UserId == userId);
            }
        }
    }
}

