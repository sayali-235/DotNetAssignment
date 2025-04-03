using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingApp.Domain.Constants;

namespace TicketBookingApp.Domain
{
    public class Event
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Venue {  get; set; } = string.Empty;
        [Required]
        public int AvailableSeats { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public EventType EventType {  get; set; }

        public ICollection<Booking>? Booking { get; set; }
    }
}
