using Microsoft.EntityFrameworkCore;
using TicketBookingApp.Domain;
using TicketBookingApp.Domain.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketBookingApp.Infrastructure.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(
                new Event
                { 
                    EventId=1,
                    Name = "Tech Conference 2025",
                    Description = "A conference on emerging technologies and software development trends.",
                    Date = new DateTime(2025, 06, 15, 10, 30, 00),
                    Venue = "Grand Auditorium, Mumbai",
                    AvailableSeats = 200,
                    Price = 1499.99m,
                    EventType = EventType.Conference
                });
        }
    }
}