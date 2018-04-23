using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTableDesigner.Shared.Entity.Database;
using TimeTableDesigner.Shared.Entity.Web;

namespace TimeTableDesigner.Logic.Designer.Preferences
{
    public interface ITimeTablePreference
    {
        int CalculatePoints(TimeTable timeTable);
    }
}
