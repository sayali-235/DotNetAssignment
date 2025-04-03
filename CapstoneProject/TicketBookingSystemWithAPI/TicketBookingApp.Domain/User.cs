using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
 

namespace TicketBookingApp.Domain
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        //[Required]
        public string? ApplicationUserId { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser applicationUser { get; set; }

        //public ICollection<Booking> ?Booking { get; set; }
    }
}
