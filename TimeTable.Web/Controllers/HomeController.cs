using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTableDesigner.Shared.Access.Service;
using TimeTableDesigner.Shared.Entity.Web;
using TimeTableDesigner.Shared.Enum;
using TimeTableDesigner.Shared.Helper.Utility;
using TimeTableDesigner.Web.Helpers;
using TimeTableDesigner.Web.Models.CourseViewModels;

namespace TimeTableDesigner.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebDataService _webDataService;

        public HomeController(IWebDataService webDataService)
        {
            _webDataService = webDataService;
        }

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

        public async Task<IActionResult> Index()
        {
            var viewModel = new CourseViewModel();

            await Initialize(viewModel);

            return View(viewModel);
        }

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
                case SearchType.Teacher:
                    courses = await _webDataService.ListWebCoursesByTeacherAsync(
                        viewModel.SearchTerm,
                        viewModel.Semester,
                        viewModel.Limit
                    );
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            return PartialView("_CoursesPartialView", courses);
        }
    }
}
