using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBookingApp.Domain;
using TicketBookingApp.Domain.Constants;

namespace TicketBookingApp.Infrastructure.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(b => b.SeatNumbers)
                 .HasConversion(
                     v => string.Join(",", v),
                     v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                 );

            builder.HasData(
                new Booking
                {
                    BookingId = 1,
                    UserId = 1,
                    EventId = 1,
                    SeatNumbers = new List<int> { 10, 11, 12 },
                    BookingDate = DateTime.UtcNow,
                    BookingStatus = BookingStatus.Confirmed
                });
        }
    }
}
