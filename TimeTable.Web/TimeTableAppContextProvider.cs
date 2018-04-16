using System;
using Microsoft.AspNetCore.Http;
using TimeTableDesigner.Shared.Access;

namespace TimeTableDesigner.Web
{
    public class TimeTableAppContextProvider : ITimeTableAppContextProvider
    {
        public string UserName { get; set; }

        public string RequestCorrelationToken { get; set; }
    }
}
