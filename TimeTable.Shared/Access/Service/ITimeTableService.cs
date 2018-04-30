///Fájl neve: ITimeTableService.cs
///Dátum: 2018. 04. 24.

namespace TimeTableDesigner.Shared.Access.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TimeTableDesigner.Shared.Entity.Database;

    /// <summary>
    /// Az ITimeTableService interfész
    /// </summary>
    public interface ITimeTableService
    {
        /// <summary>
        /// Egy adott felhasználóhoz tartozó órarend megjelenítése
        /// </summary>
        /// <param name="userId">A felhasználó azonosítója</param>
        /// <returns>A megfelelő TimeTable objektumokat tartalmazó lista</returns>
        Task<IEnumerable<TimeTable>> ListTimeTablesForUserAsync(string userId);
    }
}
