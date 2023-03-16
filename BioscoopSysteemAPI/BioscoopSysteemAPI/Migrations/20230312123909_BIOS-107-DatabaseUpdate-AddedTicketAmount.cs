using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class BIOS107DatabaseUpdateAddedTicketAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketAmount",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaidAt",
                value: new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                column: "PaidAt",
                value: new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                column: "PaidAt",
                value: new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "DateTime", "TicketAmount" },
                values: new object[] { new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2375), 1 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "DateTime", "TicketAmount" },
                values: new object[] { new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2382), 1 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "DateTime", "TicketAmount" },
                values: new object[] { new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2385), 1 });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2444));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketAmount",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaidAt",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                column: "PaidAt",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                column: "PaidAt",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7764));
        }
    }
}
