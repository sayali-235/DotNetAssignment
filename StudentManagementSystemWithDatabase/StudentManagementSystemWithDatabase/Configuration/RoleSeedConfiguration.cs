using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentManagementSystemWithDatabase.Configuration
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "5a6b7c8d-2222-3333-3333-444455556666",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
             new IdentityRole
             {
                 Id = "1a2b3c4d-1234-4444-3333-888855556666",
                 Name = "Teacher",
                 NormalizedName = "TEACHER"
             },
            new IdentityRole
            {
                Id = "1b2c4d5e-7777-6766-9999-100011112222",
                Name = "Student",
                NormalizedName = "STUDENT"
            } );
        }
    }
}
