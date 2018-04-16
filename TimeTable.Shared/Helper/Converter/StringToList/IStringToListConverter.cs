using System.Collections.Generic;
using TimeTableDesigner.Shared.Entity.Web;

namespace TimeTableDesigner.Shared.Helper.Converter.StringToList
{
    public interface IStringToListConverter
    {
        IEnumerable<T> Convert<T>(string source)
            where T : class, IWebEntity, new();
    }
}
