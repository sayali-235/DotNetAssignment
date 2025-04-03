using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBookingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyuserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "BookingDate",
                value: new DateTime(2025, 4, 2, 6, 20, 5, 816, DateTimeKind.Utc).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 4, 2, 6, 20, 5, 816, DateTimeKind.Utc).AddTicks(5280));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "BookingDate",
                value: new DateTime(2025, 4, 2, 6, 6, 11, 181, DateTimeKind.Utc).AddTicks(365));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaymentDate",
                value: new DateTime(2025, 4, 2, 6, 6, 11, 181, DateTimeKind.Utc).AddTicks(640));
        }
    }
}
