///Fájl neve: HomeController.cs
///Dátum: 2018. 04. 25.

namespace TimeTableDesigner.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TimeTableDesigner.Shared.Access.Service;
    using TimeTableDesigner.Shared.Entity.Web;
    using TimeTableDesigner.Shared.Enum;
    using TimeTableDesigner.Shared.Helper.Utility;
    using TimeTableDesigner.Web.Helpers;
    using TimeTableDesigner.Web.Models.CourseViewModels;

    /// <summary>
    /// A HomeController osztály
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// A "_webDataService" adattag
        /// </summary>
        private readonly IWebDataService _webDataService;

        /// <summary>
        /// A konstruktor, ami létrehoz egy HomeController objektumot
        /// </summary>
        /// <param name="webDataService">A WebDataService</param>
        public HomeController(IWebDataService webDataService)
        {
            _webDataService = webDataService;
        }

        /// <summary>
        /// Az inicializálásért felelős függvény
        /// </summary>
        /// <param name="viewModel">A viewModel</param>
        /// <returns>A Task objektum</returns>
        private async Task Initialize(CourseViewModel viewModel)
        {
            viewModel.Semesters = DropDownListHelper.Convert(
                await _webDataService.ListSemestersAsync(),
                n => n.Id,
                n => n.Name);

            viewModel.Departments = DropDownListHelper.Convert(
                await _webDataService.ListDepartmentsAsync(),
                n => n.Id,
                n => n.Name);

            viewModel.Grades = DropDownListHelper.Convert(
                _webDataService.ListGrades(),
                n => n.ToString(),
                n => n.ToString());

            viewModel.Limits = DropDownListHelper.Convert(
                _webDataService.ListLimits(),
                n => n.ToString(),
                n => EnumUtility.GetDescriptionFromEnumValue(n));

            viewModel.SearchTypes = DropDownListHelper.Convert(
                _webDataService.ListSearchTypes(),
                n => n.ToString(),
                n => EnumUtility.GetDescriptionFromEnumValue(n));
        }

        /// <summary>
        /// Az index függvény
        /// </summary>
        /// <returns>A Task objektum</returns>
        public async Task<IActionResult> Index()
        {
            var viewModel = new CourseViewModel();

            await Initialize(viewModel);

            return View(viewModel);
        }

        /// <summary>
        /// A keresést megvalósító függvény
        /// </summary>
        /// <param name="viewModel">A viewModel</param>
        /// <returns>A Task objektum</returns>
        [HttpGet]
        public async Task<IActionResult> Search(CourseViewModel viewModel)
        {
            IEnumerable<WebCourse> courses;
            switch (viewModel.SearchType)
            {
                case SearchType.Department:
                    courses = await _webDataService.ListWebCoursesByDepartmentAsync(
                        viewModel.Department,
                        viewModel.Semester,
                        viewModel.Grade,
                        viewModel.Limit
                    );
                    break;
                case SearchType.Id:
                    courses = await _webDataService.ListWebCoursesByIdAsync(
                        viewModel.SearchTerm,
                        viewModel.Semester,
                        viewModel.Limit
                    );
                    break;
                case SearchType.Name:
                    courses = await _webDataService.ListWebCoursesByNameAsync(
                        viewModel.SearchTerm,
                        viewModel.Semester,
                        viewModel.Limit
                    );
                    break;
                default:
                    courses = await _webDataService.ListWebCoursesByTeacherAsync(
                        viewModel.SearchTerm,
                        viewModel.Semester,
                        viewModel.Limit
                    );
                    break;
            }

            return PartialView("_CoursesPartialView", courses);
        }
    }
}
