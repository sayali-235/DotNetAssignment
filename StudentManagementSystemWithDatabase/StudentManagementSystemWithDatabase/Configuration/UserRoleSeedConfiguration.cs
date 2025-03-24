using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentManagementSystemWithDatabase.Configuration
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "5a6b7c8d-2222-3333-3333-444455556666",//admin role
                    UserId= "200055d5-c854-4d42-b793-6h1aa21c1f6b"
                }  );
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "5a6b7c8d-2222-3333-3333-444455556666",//admin1 role
                    UserId = "156205d5-c590-4e42-d278-2f1aa21c1f6b"
                });
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "5a6b7c8d-2222-3333-3333-444455556666",//admin2 role
                    UserId = "156053g5-e593-4e67-a793-6f1aa23c1f6b"
                });
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1a2b3c4d-1234-4444-3333-888855556666",//Teacher role
                    UserId = "156423d5-e893-4e42-a233-6f1aa35c1f6b"
                });
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1b2c4d5e-7777-6766-9999-100011112222",//student role
                    UserId = "236223d5-e507-4e42-a793-6f1dd64g1f6a"
                });


        }
    }
}
