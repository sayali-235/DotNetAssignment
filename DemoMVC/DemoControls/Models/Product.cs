using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoControls.Models
{
    public class Product
    {
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        public Category Category { get; set; }
        public bool IsInStock { get; set; }
        public string Gender { get; set; }
    }
    public enum Category
    {
        Electronics=1,
        Groceries
    }
}
