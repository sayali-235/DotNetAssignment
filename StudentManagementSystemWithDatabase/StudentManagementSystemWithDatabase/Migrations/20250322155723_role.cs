using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystemWithDatabase.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a2b3c4d-2222-3333-3333-444455556666", "156053d5-e593-4e42-a793-6f1aa21c1f6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a2b3c4d-2222-3333-3333-444455556666", "156205d5-c854-4e42-d278-2f1aa21c1f6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a2b3c4d-1111-4444-3333-888855556666", "156223d5-e893-4e42-b233-6f1aa05c1f6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a2b3c4d-2222-3333-3333-444455556666", "200055d5-c854-4e42-a793-6f1aa21c1f6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2b3c4d5e-7777-6666-9999-100011112222", "206223d5-e593-4e42-a793-6f1dd64g1f6b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-1111-4444-3333-888855556666");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-2222-3333-3333-444455556666");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b3c4d5e-7777-6666-9999-100011112222");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156053d5-e593-4e42-a793-6f1aa21c1f6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156205d5-c854-4e42-d278-2f1aa21c1f6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156223d5-e893-4e42-b233-6f1aa05c1f6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "200055d5-c854-4e42-a793-6f1aa21c1f6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "206223d5-e593-4e42-a793-6f1dd64g1f6b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a2b3c4d-1234-4444-3333-888855556666", "952638fa-92e5-4196-8ad3-ab31a59bff4b", "Teacher", "TEACHER" },
                    { "1b2c4d5e-7777-6766-9999-100011112222", "d0209e9a-1db5-456c-850f-c0abf9b49907", "Student", "STUDENT" },
                    { "5a6b7c8d-2222-3333-3333-444455556666", "b6d3d6ca-15a4-430d-ae60-a6f1f54bdf85", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "156053g5-e593-4e67-a793-6f1aa23c1f6b", 0, "be5ce1cc-c1cb-4425-81b1-fd7eedf33fce", "admin2@gmail.com", false, false, null, "ADMIN2@GMAIL.COM", null, "AQAAAAEAACcQAAAAEJ6hrdX3Ck6X97Mijt6YJyPpxARYsp2RoMx3n3eyq+1MOmTswQ592TFQi7ecDJJRdw==", null, false, "368c6a2f-d43a-4623-990d-5e387b6241c1", false, "Admin2@gmail.com" },
                    { "156205d5-c590-4e42-d278-2f1aa21c1f6b", 0, "cd5acd83-9a0f-4c10-9e24-69e28a514594", "admin1@gmail.com", false, false, null, "ADMIN1@GMAIL.COM", null, "AQAAAAEAACcQAAAAEHJgRRRgDUvO4VGnAN2iMmgx0y/vTAmDL3VP5mad2dhppmIp7NKFQGs+vIpAZN7tHw==", null, false, "452fb2bc-5628-48cf-9a6c-7a505e8ebe60", false, "Admin1@gmail.com" },
                    { "156423d5-e893-4e42-a233-6f1aa35c1f6b", 0, "e9b47c06-b6d6-438b-89f4-056127d95bce", "teacher@gmail.com", false, false, null, "TEACHER@GMAIL.COM", null, "AQAAAAEAACcQAAAAEEsFnecBvqBiJKf2Sla49WfiWmBI3L8TlhJZo8a7wzpqiaEHpHl7//1z1o60AiuC6Q==", null, false, "b57de03f-e14a-4ec4-95c2-cfdd018ac3a9", false, "Teacher@gmail.com" },
                    { "200055d5-c854-4d42-b793-6h1aa21c1f6b", 0, "1dc3f7cd-beea-4ff6-9e32-c2e1f5f789c2", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", null, "AQAAAAEAACcQAAAAELYPKUnKb9eaDvzM7mSTabdQG5A69IhfIjDmkiJeMhlPdSXcfjS3JZm4PhWpJlh9vg==", null, false, "e4cf6e85-461b-45f1-a509-4fc312334d72", false, "Admin@gmail.com" },
                    { "236223d5-e507-4e42-a793-6f1dd64g1f6a", 0, "c53472ec-2eb1-4337-9230-4dde3c7578cf", "sayali@gmail.com", false, false, null, "SAYALI@GMAIL.COM", null, "AQAAAAEAACcQAAAAEORq+yPW5dRlXjZuzu5VfZ/Os+j7tnLcmCIsZ1/khwRhzg2RHGZilVQbhZiVJB3X9g==", null, false, "e1c80269-90be-435e-a13e-2faa711904b5", false, "Sayali@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5a6b7c8d-2222-3333-3333-444455556666", "156053g5-e593-4e67-a793-6f1aa23c1f6b" },
                    { "5a6b7c8d-2222-3333-3333-444455556666", "156205d5-c590-4e42-d278-2f1aa21c1f6b" },
                    { "1a2b3c4d-1234-4444-3333-888855556666", "156423d5-e893-4e42-a233-6f1aa35c1f6b" },
                    { "5a6b7c8d-2222-3333-3333-444455556666", "200055d5-c854-4d42-b793-6h1aa21c1f6b" },
                    { "1b2c4d5e-7777-6766-9999-100011112222", "236223d5-e507-4e42-a793-6f1dd64g1f6a" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a6b7c8d-2222-3333-3333-444455556666", "156053g5-e593-4e67-a793-6f1aa23c1f6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a6b7c8d-2222-3333-3333-444455556666", "156205d5-c590-4e42-d278-2f1aa21c1f6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a2b3c4d-1234-4444-3333-888855556666", "156423d5-e893-4e42-a233-6f1aa35c1f6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a6b7c8d-2222-3333-3333-444455556666", "200055d5-c854-4d42-b793-6h1aa21c1f6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1b2c4d5e-7777-6766-9999-100011112222", "236223d5-e507-4e42-a793-6f1dd64g1f6a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-1234-4444-3333-888855556666");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b2c4d5e-7777-6766-9999-100011112222");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a6b7c8d-2222-3333-3333-444455556666");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156053g5-e593-4e67-a793-6f1aa23c1f6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156205d5-c590-4e42-d278-2f1aa21c1f6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156423d5-e893-4e42-a233-6f1aa35c1f6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "200055d5-c854-4d42-b793-6h1aa21c1f6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "236223d5-e507-4e42-a793-6f1dd64g1f6a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a2b3c4d-1111-4444-3333-888855556666", "9051e3cc-1772-4996-b071-42e68e534e21", "Teacher", "" },
                    { "1a2b3c4d-2222-3333-3333-444455556666", "142593f8-dcb2-4b76-bfb8-377e02bbbf72", "Admin", "ADMIN" },
                    { "2b3c4d5e-7777-6666-9999-100011112222", "2172094b-f4e5-40a2-9047-2ffb92d6a585", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "156053d5-e593-4e42-a793-6f1aa21c1f6b", 0, "fa9a86ec-87bb-4b6c-b127-10efefa3ad73", "admin2@gmail.com", false, false, null, "ADMIN2@GMAIL.COM", null, "AQAAAAEAACcQAAAAEAfh0pi6jhqTaV8JVgUwZCK1c5bX/k2B207bZa2QKHKN5hQlPEJVH8K01a5lDEB8Qw==", null, false, "a669f5bf-3912-475b-a4bf-81eaaca27de9", false, "Admin2@gmail.com" },
                    { "156205d5-c854-4e42-d278-2f1aa21c1f6b", 0, "d8c00e07-6313-4cae-b9c2-9924c0238ec8", "admin1@gmail.com", false, false, null, "ADMIN1@GMAIL.COM", null, "AQAAAAEAACcQAAAAEPJzzwF/gYqrrBQ2a+Sv4psx9XAQMicBYl064cSRZZsSOGjtJch3qA7RIBO1hXjAeg==", null, false, "922b0440-cf4a-402d-bc36-e437acb9893d", false, "Admin1@gmail.com" },
                    { "156223d5-e893-4e42-b233-6f1aa05c1f6b", 0, "8bdd6134-3826-4199-ae13-4eb22f520667", "teacher@gmail.com", false, false, null, "TEACHER@GMAIL.COM", null, "AQAAAAEAACcQAAAAEALL/9VY89x8rt+pDVumQCLAYv/gSlp2k+6VC7Tpe6ksJ6EY4OInZGtAeWfE+wxuJg==", null, false, "e68dc328-b7e2-4124-94fb-25de91a58b39", false, "Teacher@gmail.com" },
                    { "200055d5-c854-4e42-a793-6f1aa21c1f6b", 0, "1bd6fe48-b3b9-41bd-95c2-27d2cef0a7a3", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", null, "AQAAAAEAACcQAAAAEGOtfEYxzMxutyaKizN/GsunfLkzAOrmGU8j3ERdREoXe9uJtrLYW7mKoxkTRiLAkg==", null, false, "aabd27a0-90f5-4383-98fd-805feca49cec", false, "Admin@gmail.com" },
                    { "206223d5-e593-4e42-a793-6f1dd64g1f6b", 0, "231c487f-b4a0-4265-a63a-ddbdc3e7d5fb", "sayali@gmail.com", false, false, null, "SAYALI@GMAIL.COM", null, "AQAAAAEAACcQAAAAECEyN85ZXVL3UOyAE4Z03+lhXyEGrIKiqBPurp6Mw2W+wB2a/NDjbGva/7KHeqGrVQ==", null, false, "ed6dd143-c516-4e31-bdbc-7f541ce03d96", false, "Sayali@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1a2b3c4d-2222-3333-3333-444455556666", "156053d5-e593-4e42-a793-6f1aa21c1f6b" },
                    { "1a2b3c4d-2222-3333-3333-444455556666", "156205d5-c854-4e42-d278-2f1aa21c1f6b" },
                    { "1a2b3c4d-1111-4444-3333-888855556666", "156223d5-e893-4e42-b233-6f1aa05c1f6b" },
                    { "1a2b3c4d-2222-3333-3333-444455556666", "200055d5-c854-4e42-a793-6f1aa21c1f6b" },
                    { "2b3c4d5e-7777-6666-9999-100011112222", "206223d5-e593-4e42-a793-6f1dd64g1f6b" }
                });
        }
    }
}
