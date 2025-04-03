using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBookingApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class guidid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41076062-6086-1fbf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "584111d9-07f5-48e3-91e3-fc361fabce27", "AQAAAAIAAYagAAAAECfK0sqxKZtBDIKnzleKtIt9KnqkzdmyWhQkOMcuARZ4sUqgvGx4wT/1GXIIJ84+RA==", "da0d19ce-0eb2-41c2-b1f1-af237d0b2320" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-5023-1fcf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d89c00f5-181a-43b2-82b7-ba3596652ba4", "AQAAAAIAAYagAAAAEJofA/nLvt/2JLImzGJhhNRSK+TdcZReOlQt6b3bQte2FIOk70GXsMkNZ1806Iiemg==", "6a3952c7-6f59-4515-b07e-a4c2ae9384df" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41076062-6086-1fbf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acebcbd0-701b-45c0-aec3-24fca02bfbd9", "AQAAAAIAAYagAAAAEFO3MAAxFmoAqqqBwFaYmectDaEUMJuVNMdA10uHxC0C1/d9NBgO3L9HUm1UE88nQA==", "9645baa9-2c33-47a6-9829-c0e08ab2a9ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-5023-1fcf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbac44a2-ad71-4bf5-b496-99d8201b896b", "AQAAAAIAAYagAAAAEHA67MwZvER+qwNiSMXcLNkZctsVlmytdFTVCyJcaeI27tCojf+9liNshQV58UivMA==", "0c55877c-32b9-4313-8518-2e67c84315c9" });
        }
    }
}
