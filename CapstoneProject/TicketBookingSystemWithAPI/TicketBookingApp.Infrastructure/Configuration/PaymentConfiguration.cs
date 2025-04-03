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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData(
               new Payment
               {
                   PaymentId = 1,
                   BookingId = 1,  
                   Amount = 2000.00m,
                   PaymentMethod = PaymentMethod.PayPal,
                   PaymentStatus = PaymentStatus.Success,
                   PaymentDate = DateTime.UtcNow
               });
        }
    }
}
