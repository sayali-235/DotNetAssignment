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
            builder.HasData(
                new Booking
                {
                    BookingId = 1,
                    UserId = 1,  
                    EventId = 1,  
                    SeatNumber = 10,
                    BookingDate = DateTime.UtcNow,  
                    BookingStatus = BookingStatus.Confirmed
                });
        }
    }
}
