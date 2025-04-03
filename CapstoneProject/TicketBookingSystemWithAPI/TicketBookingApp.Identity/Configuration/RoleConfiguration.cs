using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketBookingApp.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id= "41776008-6086-1abf-b923-2379a6680b9a",
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole
                { 
                    Id = "41886008-6086-1fbf-b924-2879a6680b9c",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}