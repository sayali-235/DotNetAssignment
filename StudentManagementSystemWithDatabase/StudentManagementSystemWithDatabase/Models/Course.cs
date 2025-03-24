using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystemWithDatabase.Models
{
    public class Course
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
