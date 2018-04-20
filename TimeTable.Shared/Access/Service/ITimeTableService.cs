using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTableDesigner.Shared.Entity.Database;

namespace TimeTableDesigner.Shared.Access.Service
{
    public interface ITimeTableService
    {
        Task<IEnumerable<TimeTable>> ListTimeTablesForUserAsync(string userId);
    }
}
