using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystemWithDatabase.Models
{
    public class Student
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        private string _name;
        [NotMapped]
        public string Name { 
            get
            {
                return FirstName + " " + LastName;
            }
               
            set
            {
                _name = value;
            }
        }

        [Required,EmailAddress]

        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string UserId {  get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public ICollection<Enrollment>Enrollments { get; set; }
    }
}
