using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemWithDatabase.Constants;
using StudentManagementSystemWithDatabase.Models;
using StudentManagementSystemWithDatabase.Services;

namespace StudentManagementSystemWithDatabase.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {

        readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        [AllowAnonymous]
        public async  Task<IActionResult> GetAllCourses()
        {
            return View( await _courseService.GetAllCourses());
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> AddCourse()
        {
            return View(); 
        }


        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            ModelState.Remove("Enrollments");
            if (ModelState.IsValid)
            {
                int result = await _courseService.AddCourse(course);
                if (result > 0)
                {
                    TempData["message"] = "Course Added Successfully";
                    return RedirectToAction("GetAllCourses");
                }
                else
                {
                    TempData["Msg"] = "Course Addition Failed";
                    return View(course);
                }
            }
            else
            {
                return View(course);
            }
            
        }
        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher}")]
        public async Task<IActionResult> GetCourseById(int id)
        { 
            var result=await _courseService.GetCourseById(id);
            return View(result);
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> UpdateCourse(int id)
        {
            var result = await _courseService.GetCourseById(id);
            return View(result);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> UpdateCourse(Course course)
        {
            int updatedItem = await _courseService.UpdateCourse(course);
            if (updatedItem > 0)
            {
                TempData["Updatemsg"] = "Data Updated";
                return RedirectToAction("GetAllCourses");

            }
            else
            {
                TempData["Updatemsg"] = "Course Not Found";
                return View(course);
            }
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult>DeleteCourse(int id)
        {
            await _courseService.DeleteCourse(id);
            return RedirectToAction("GetAllCourses");
        }

    }
}
