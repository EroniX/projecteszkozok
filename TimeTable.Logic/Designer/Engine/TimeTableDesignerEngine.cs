using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTableDesigner.Logic.Designer.Preferences;
using TimeTableDesigner.Shared.Access.Service;
using TimeTableDesigner.Shared.Entity.Database;
using TimeTableDesigner.Shared.Entity.Web;

namespace TimeTableDesigner.Logic.Designer.Engine
{
    public class TimeTableDesignerEngine
    {
        private readonly IDictionary<string, IEnumerable<WebCourse>> _webCourseDictionary;

        public TimeTableDesignerEngine(IDictionary<string, IEnumerable<WebCourse>> webCourseDictionary)
        {
            _webCourseDictionary = webCourseDictionary;
        }

        private IList<IDictionary<string, IEnumerable<WebCourse>>> Analyze()
        {
            
        }

        public TimeTable Design(ITimeTablePreference preference)
        {
            return null;
        }

        public static async Task<TimeTableDesignerEngine> CreateAsync(IWebDataService webDataService, IEnumerable<string> webCourseIds)
        {
            var webCourseDictionary = new Dictionary<string, IEnumerable<WebCourse>>();

            foreach (var webCourseId in webCourseIds)
            {
                var webCourses = await webDataService.ListWebCoursesByIdAsync(webCourseId, ""/*@TODO: Create method for current semester*/);
                webCourseDictionary.Add(webCourseId, webCourses);
            }

            return new TimeTableDesignerEngine(webCourseDictionary);
        }
    }
}
