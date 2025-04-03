using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TicketBookingApp.Domain.Constants;

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
        public List<int> SeatNumbers { get; set; } = new List<int>();
        
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public BookingStatus BookingStatus { get; set; }

        // Navigation properties
        [JsonIgnore]
        public User ?User { get; set; }
        [JsonIgnore]
        public Event? Event { get; set; }
        [JsonIgnore]
        public Payment? Payment { get; set; }

    }
}
