using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingApp.Domain
{
    public class Booking
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int SeatNumber { get; set; } 
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public string Status { get; set; } = "Pending"; // Possible values: "Pending", "Confirmed", "Cancelled"

        // Navigation properties
        public User User { get; set; }
        public Event Event { get; set; }
        public Payment Payment { get; set; }

    }
}
