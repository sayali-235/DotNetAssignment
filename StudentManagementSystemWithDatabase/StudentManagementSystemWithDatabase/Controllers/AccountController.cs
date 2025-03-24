using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemWithDatabase.Constants;
using StudentManagementSystemWithDatabase.Context;
using StudentManagementSystemWithDatabase.Models;
using StudentManagementSystemWithDatabase.ViewModel;

namespace StudentManagementSystemWithDatabase.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly StudentManegementDbContext _studentManegementDbContext;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,StudentManegementDbContext studentManegementDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _studentManegementDbContext = studentManegementDbContext;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var createdUser = new ApplicationUser { UserName = user.Email, Email = user.Email };
               
                var result = await _userManager.CreateAsync(createdUser, user.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(createdUser, Role.Student);
                    var student = new Student
                    {

                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        DateOfBirth = user.DateOfBirth,
                        UserId = createdUser.Id
                    };
                    _studentManegementDbContext.Students.Add(student);
                    await _studentManegementDbContext.SaveChangesAsync();
                    
                    return  RedirectToAction("Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return  View(user);
        }
        [HttpGet]
       public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email.ToUpper());

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Login Attempt");
                    return View(loginModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, false);


                if (result.Succeeded)
                {
                    if (await _userManager.IsInRoleAsync(user, Role.Admin) || await _userManager.IsInRoleAsync(user, Role.Teacher))
                    {
                        return RedirectToAction("GetAllStudents", "Student");
                    }
                    else if (await _userManager.IsInRoleAsync(user, Role.Student))
                    {
                        return RedirectToAction("GetAllCourses", "Course");
                    }
                }
                ModelState.AddModelError("", "Login failed");

            }
            return View(loginModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
