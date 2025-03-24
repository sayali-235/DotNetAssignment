using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystemWithDatabase.Models
{
    public class ApplicationUser:IdentityUser
    {
         public Student Student { get; set; }
    }
}
