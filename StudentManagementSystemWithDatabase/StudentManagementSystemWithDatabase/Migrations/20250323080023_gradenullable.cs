using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagementSystemWithDatabase.Migrations
{
    public partial class gradenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-1234-4444-3333-888855556666",
                column: "ConcurrencyStamp",
                value: "6a0445f8-0228-4bb2-b9b7-ad9300b6c823");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b2c4d5e-7777-6766-9999-100011112222",
                column: "ConcurrencyStamp",
                value: "3cd19a14-2569-4a5c-8635-95fda1d5f7e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a6b7c8d-2222-3333-3333-444455556666",
                column: "ConcurrencyStamp",
                value: "6f742519-88a5-4400-aa02-b2b82377fd75");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156053g5-e593-4e67-a793-6f1aa23c1f6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "631c9fc4-70bd-4de5-901a-5685c77a05eb", "AQAAAAEAACcQAAAAEJfEh12M8LSmOsCoyklCL1kwiEW54yrSEdSltFqNybUWrKcVW9jpFx+Nu7t+d0ZRww==", "591b7368-9e17-4ee3-abcc-095ad30da713" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156205d5-c590-4e42-d278-2f1aa21c1f6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40a342b9-b74a-421e-84d5-024b9d7ad26b", "AQAAAAEAACcQAAAAENJbyHEfYROzBIeLq6J8m1ylP/75R9ffj7rLVVCrjom6z1saa/QvSCZHRKAjMsZTiA==", "a1c8fee1-a4bc-41ba-9a9c-d5661be04ff5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156423d5-e893-4e42-a233-6f1aa35c1f6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c00f6e86-b1df-4fdd-99b6-35bb86a361c8", "AQAAAAEAACcQAAAAEO6Rbr6gOtFzUNA9GcuQ9kXbWjftmAEq92nYnd9XDu+5Jy0Hwuk18Nvu7GmWMjLLLw==", "72ed59b9-3e66-4a44-85d0-812a4ba9a103" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "200055d5-c854-4d42-b793-6h1aa21c1f6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55a20318-f8ee-45ee-bcbf-5e87cfff22f3", "AQAAAAEAACcQAAAAEFIrOIIK0hrGSwhddku8IP2Y/z6LP7l62J04Yw6bp21yVFBz8X1nWMJ1hmmnf4tRXw==", "606580dc-5b20-47f6-b11d-154f8fed7015" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "236223d5-e507-4e42-a793-6f1dd64g1f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "718960c6-627a-4ffc-b0b4-5843228ebd3d", "AQAAAAEAACcQAAAAEDLTps8jgFr5hUlvhisbbA+Q9iVkS2RPVtUl3TCTw1f1ppVE3XL8p+luwyS3gah36A==", "080470ad-9489-4309-abba-4d483112fc90" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-1234-4444-3333-888855556666",
                column: "ConcurrencyStamp",
                value: "952638fa-92e5-4196-8ad3-ab31a59bff4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b2c4d5e-7777-6766-9999-100011112222",
                column: "ConcurrencyStamp",
                value: "d0209e9a-1db5-456c-850f-c0abf9b49907");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a6b7c8d-2222-3333-3333-444455556666",
                column: "ConcurrencyStamp",
                value: "b6d3d6ca-15a4-430d-ae60-a6f1f54bdf85");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156053g5-e593-4e67-a793-6f1aa23c1f6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be5ce1cc-c1cb-4425-81b1-fd7eedf33fce", "AQAAAAEAACcQAAAAEJ6hrdX3Ck6X97Mijt6YJyPpxARYsp2RoMx3n3eyq+1MOmTswQ592TFQi7ecDJJRdw==", "368c6a2f-d43a-4623-990d-5e387b6241c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156205d5-c590-4e42-d278-2f1aa21c1f6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd5acd83-9a0f-4c10-9e24-69e28a514594", "AQAAAAEAACcQAAAAEHJgRRRgDUvO4VGnAN2iMmgx0y/vTAmDL3VP5mad2dhppmIp7NKFQGs+vIpAZN7tHw==", "452fb2bc-5628-48cf-9a6c-7a505e8ebe60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "156423d5-e893-4e42-a233-6f1aa35c1f6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9b47c06-b6d6-438b-89f4-056127d95bce", "AQAAAAEAACcQAAAAEEsFnecBvqBiJKf2Sla49WfiWmBI3L8TlhJZo8a7wzpqiaEHpHl7//1z1o60AiuC6Q==", "b57de03f-e14a-4ec4-95c2-cfdd018ac3a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "200055d5-c854-4d42-b793-6h1aa21c1f6b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dc3f7cd-beea-4ff6-9e32-c2e1f5f789c2", "AQAAAAEAACcQAAAAELYPKUnKb9eaDvzM7mSTabdQG5A69IhfIjDmkiJeMhlPdSXcfjS3JZm4PhWpJlh9vg==", "e4cf6e85-461b-45f1-a509-4fc312334d72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "236223d5-e507-4e42-a793-6f1dd64g1f6a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c53472ec-2eb1-4337-9230-4dde3c7578cf", "AQAAAAEAACcQAAAAEORq+yPW5dRlXjZuzu5VfZ/Os+j7tnLcmCIsZ1/khwRhzg2RHGZilVQbhZiVJB3X9g==", "e1c80269-90be-435e-a13e-2faa711904b5" });
        }
    }
}
