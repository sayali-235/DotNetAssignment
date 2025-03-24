using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemWithDatabase.Constants;
using StudentManagementSystemWithDatabase.Models;
using StudentManagementSystemWithDatabase.Services;

namespace StudentManagementSystemWithDatabase.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        
        readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles =Role.Admin)]
        public async Task<IActionResult> AddStudent()
        {
           
            return View();
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> AddStudent(Student student)
        {
            ModelState.Remove("Enrollments");
            if (ModelState.IsValid)
            {
                int result=await _studentService.AddStudent(student);
                if(result >0)
                {
                    TempData["message"] = "Student Added Successfully";
                    return RedirectToAction("GetAllStudents");
                }
                else
                {
                    TempData["Msg"] = "Student Addition Failed";
                    return View(student);
                }
            }
            else
            {
                return View(student);
            }
            
        }
        
        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher},{Role.Student}")]
        public async Task<IActionResult> GetAllStudents()
        {
            return View(await _studentService.GetAllStudents());
        }
        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher}")]
        public async Task<IActionResult> UpdateStudent(int id)
        {
            var result= await _studentService.GetStudentById(id);
            return View(result);

        }
        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher}")]
        [HttpPost]
        public async Task<IActionResult>UpdateStudent(Student student)
        {
            int updatedItem=await _studentService.UpdateStudent(student);
            if(updatedItem > 0)
            {
                TempData["Updatemsg"] = "Data Updated";
                return RedirectToAction("GetAllStudents");

            }
            else {
                TempData["Updatemsg"] = "Course Not Found";
                return View(student);
            }
        }
        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher},{Role.Student}")]
        public async Task<IActionResult>GetStudentById(int id)
        {
            return View(await _studentService.GetStudentById(id));
        }
        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher}")]
        public async Task<IActionResult>DeleteStudent(int id)
        {
             await _studentService.DeleteStudent(id);
            return RedirectToAction("GetAllStudents");

        }
    }
}
