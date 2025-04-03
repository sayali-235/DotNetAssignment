using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketBookingApp.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    //admin
                    RoleId= "41776008-6086-1abf-b923-2379a6680b9a",
                    
                    UserId = "41076062-6086-1fbf-b923-2879a6680b9a"

                },
                 new IdentityUserRole<string>
                 {
                     //user
                     RoleId = "41886008-6086-1fbf-b924-2879a6680b9c",
                     
                     UserId = "41776062-5023-1fcf-b923-2879a6680b9a"


                 });
        }
    }
}