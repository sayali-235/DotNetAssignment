using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBookingApp.Domain;

namespace TicketBookingApp.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    UserName = "Sayali",
                    Email="sayali@gmail.com",
                    PhoneNumber="1234567890",
                   // ApplicationUserId = "41776062-6086-1fcf-b923-2879a6680b9a"
                });
        }
    }
}
