using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class BIOS107DatabaseUpdateSwitchedReservationAndPaymentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5454));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5457));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                columns: new[] { "PaidAt", "ReservationId" },
                values: new object[] { new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5483), 1 });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                columns: new[] { "PaidAt", "ReservationId" },
                values: new object[] { new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5488), 2 });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                columns: new[] { "PaidAt", "ReservationId" },
                values: new object[] { new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5490), 3 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5577));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaidAt",
                value: new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                column: "PaidAt",
                value: new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                column: "PaidAt",
                value: new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "DateTime", "PaymentId" },
                values: new object[] { new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(528), 0 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "DateTime", "PaymentId" },
                values: new object[] { new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(535), 0 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "DateTime", "PaymentId" },
                values: new object[] { new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(538), 0 });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(591));
        }
    }
}
