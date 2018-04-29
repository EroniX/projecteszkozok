using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeTableDesigner.Shared.Access.Service;
using TimeTableDesigner.Web.Models;

namespace TimeTableDesigner.Web.Controllers
{
    [Authorize]
    public class TimeTableController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebDataService _webDataService;
        private readonly ITimeTableService _timeTableService;

        public TimeTableController(
            UserManager<ApplicationUser> userManager, 
            IWebDataService webDataService, 
            ITimeTableService timeTableService)
        {
            _userManager = userManager;
            _webDataService = webDataService;
            _timeTableService = timeTableService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var timeTables = await _timeTableService.ListTimeTablesForUserAsync(_userManager.GetUserId(User));
            return View();
        }
    }
}
