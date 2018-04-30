///Fájl neve: TimeTableController.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TimeTableDesigner.Shared.Access.Service;
    using TimeTableDesigner.Web.Models;

    /// <summary>
    /// A TimeTableController osztály
    /// </summary>
    [Authorize]
    public class TimeTableController : Controller
    {
        /// <summary>
        /// Az "_userManager" adattag
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// A "_signInManager" adattag
        /// </summary>
        private readonly SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// A "_webDataService" adattag
        /// </summary>
        private readonly IWebDataService _webDataService;

        /// <summary>
        /// A "_timeTableService" adattag
        /// </summary>
        private readonly ITimeTableService _timeTableService;

        /// <summary>
        /// A konstruktor, ami létrehoz egy TimeTableController objektumot
        /// </summary>
        /// <param name="userManager">Az userManager</param>
        /// <param name="signInManager">A signInManager</param>
        /// <param name="webDataService">A webDataService</param>
        /// <param name="timeTableService">A timeTableService</param>
        public TimeTableController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IWebDataService webDataService,
            ITimeTableService timeTableService)
        {
            _webDataService = webDataService;
            _timeTableService = timeTableService;
        }

        /// <summary>
        /// Az index
        /// </summary>
        /// <returns>A Task objektum</returns>
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = User;
            var timeTables = await _timeTableService.ListTimeTablesForUserAsync(_userManager.GetUserId(User));
            return View();
        }
    }
}
