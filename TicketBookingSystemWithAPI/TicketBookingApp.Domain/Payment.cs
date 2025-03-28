using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingApp.Domain
{
    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        [Required]
        public int BookingId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; } = string.Empty; // e.g., CreditCard, PayPal, UPI
        [Required]
        public string Status { get; set; } = "Pending"; // Possible values: "Pending", "Success", "Failed"
        [Required]
        public DateTime PaymentDate { get; set; }

        public Booking Booking { get; set; }
    }
}
