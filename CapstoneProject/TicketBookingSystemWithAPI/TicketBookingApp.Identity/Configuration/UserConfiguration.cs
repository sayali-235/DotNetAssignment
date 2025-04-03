using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBookingApp.Identity.Model;

namespace TicketBookingApp.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "41076062-6086-1fbf-b923-2879a6680b9a",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    FirstName = "Admin",
                    LastName = "system",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                },
                new ApplicationUser
                {
                    Id = "41776062-5023-1fcf-b923-2879a6680b9a",
                    Email = "sayali@gmail.com",
                    NormalizedEmail = "SAYALI@GMAIL.COM",
                    FirstName = "sayali",
                    LastName = "divekar",
                    UserName = "sayali@gmail.com",
                    NormalizedUserName = "SAYALI@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Sayali@123")
                }
                );
        }
    }
}