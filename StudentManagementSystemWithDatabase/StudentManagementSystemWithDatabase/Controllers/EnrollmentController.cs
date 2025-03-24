using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystemWithDatabase.Constants;
using StudentManagementSystemWithDatabase.Context;
using StudentManagementSystemWithDatabase.Exception;
using StudentManagementSystemWithDatabase.Models;
using StudentManagementSystemWithDatabase.Services;

namespace StudentManagementSystemWithDatabase.Controllers
{
    [Authorize]
    public class EnrollmentController : Controller
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly IEnrollmentService _enrollmentService;
        readonly ICourseService _courseService;
        readonly IStudentService _studentService;
        readonly StudentManegementDbContext _studentManegementDbContext;
        public EnrollmentController(UserManager<ApplicationUser> userManager, IEnrollmentService enrollmentService, IStudentService studentService, ICourseService courseService, StudentManegementDbContext studentManegementDbContext)
        {
            _userManager = userManager;
            _enrollmentService = enrollmentService;
            _courseService = courseService;
            _studentService = studentService;
            _studentManegementDbContext = studentManegementDbContext;
        }
        

        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher},{Role.Student}")]
        [HttpGet]
        public async Task<IActionResult> EnrollStudent()
        {
            try
            {
                var userId =  _userManager.GetUserId(User);
                var student= await _studentManegementDbContext.Students
                .FirstOrDefaultAsync(s => s.UserId == userId);
                

                if (student == null)
                {
                    TempData["Error"] = "Student not found.";
                    return RedirectToAction("ErrorPage");
                }
                var courses = await _courseService.GetAllCourses();
                if (courses == null || !courses.Any())
                {
                    TempData["Error"] = "No courses available for enrollment.";
                }

                // Using full name for students
                ViewBag.StudentName = student.FirstName + " " + student.LastName;
                ViewBag.StudentId = student.Id;

                ViewBag.Courses = (await _courseService.GetAllCourses())
                                  .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.CourseName })
                                  .ToList();

                return View();
            }
            catch ( EnrollmentNotFound ex)
            {
                TempData["Error"] = "An error occurred while fetching students or courses.";
                return RedirectToAction("ErrorPage"); 
            }
        }
       
        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher},{Role.Student}")]

        [HttpPost]
        public async Task<IActionResult> EnrollStudent(int studentId, int courseId)
        {
            await _enrollmentService.EnrollStudent(studentId, courseId);
            return RedirectToAction("GetEnrollmentsByStudentId", new {  studentId });
        }

        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher},{Role.Student}")]
        [HttpGet("GetEnrollmentsByStudentId/{studentId}")]
        public async Task<IActionResult> GetEnrollmentsByStudentId(int studentId)
        {
            try
            {
                // Fetch the student details
                var student = await _studentManegementDbContext.Students
                    .FirstOrDefaultAsync(s => s.Id == studentId);

                if (student == null)
                {
                    TempData["Error"] = "Student not found.";
                    return RedirectToAction("ErrorPage");
                }

                // Fetch the enrollments
                var enrollments = await _enrollmentService.GetEnrollmentsByStudentId(studentId);

                if (!enrollments.Any())
                {
                    TempData["Error"] = $"No enrollments found for {student.FirstName} {student.LastName}.";
                    return RedirectToAction("ErrorPage");
                }

                // Pass student details to the View
                ViewBag.StudentName = $"{student.FirstName} {student.LastName}";
                ViewBag.StudentId = studentId;

                return View(enrollments);
            }
            catch (EnrollmentNotFound ex)
            {
                TempData["Error"] = "An error occurred while fetching enrollments.";
                return RedirectToAction("ErrorPage");
            }
        }

        [Authorize(Roles = $"{Role.Admin}, {Role.Teacher},{Role.Student}")]
        [HttpGet]
        public async Task<IActionResult> EnrolledStudents()
        {
            var enrollments = await _studentManegementDbContext.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();

            return View(enrollments);
        }


        [HttpGet] 
        public async Task<IActionResult> WithdrawStudent()
        { 
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> WithdrawStudent(int studentId, int courseId)
        {
            var enrollment = await _studentManegementDbContext.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrollment == null)
            {
                return NotFound("Enrollment not found.");
            }

            _studentManegementDbContext.Enrollments.Remove(enrollment);
            await _studentManegementDbContext.SaveChangesAsync();

            return RedirectToAction("GetEnrollmentsByStudentId", new {  studentId });
        }

    }
}
