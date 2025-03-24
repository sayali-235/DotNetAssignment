using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystemWithDatabase.Models;

namespace StudentManagementSystemWithDatabase.Configuration
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
           var hasher= new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    //156223d5-c854-4e42-a793-6f1aa21c1f6b
                    Id = "200055d5-c854-4d42-b793-6h1aa21c1f6b",
                    UserName = "Admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Admin@123")
                }
                );
            builder.HasData(
                new ApplicationUser
                {
                    Id = "156205d5-c590-4e42-d278-2f1aa21c1f6b",
                    UserName = "Admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    Email = "admin1@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Admin1@123")
                }
                );
            builder.HasData(
                new ApplicationUser
                {
                    Id = "156053g5-e593-4e67-a793-6f1aa23c1f6b",
                    UserName = "Admin2@gmail.com",
                    NormalizedEmail = "ADMIN2@GMAIL.COM",
                    Email = "admin2@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Admin2@123")
                }
                );
            builder.HasData(
               new ApplicationUser
               {
                   Id = "156423d5-e893-4e42-a233-6f1aa35c1f6b",
                   UserName = "Teacher@gmail.com",
                   NormalizedEmail = "TEACHER@GMAIL.COM",
                   Email = "teacher@gmail.com",
                   PasswordHash = hasher.HashPassword(null, "Teacher@123")
               }
               );
            builder.HasData(
                new ApplicationUser
                {
                    Id = "236223d5-e507-4e42-a793-6f1dd64g1f6a",
                    UserName = "Sayali@gmail.com",
                    NormalizedEmail = "SAYALI@GMAIL.COM",
                    Email = "sayali@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Sayali@123")
                }
                );
        }
    }
}
