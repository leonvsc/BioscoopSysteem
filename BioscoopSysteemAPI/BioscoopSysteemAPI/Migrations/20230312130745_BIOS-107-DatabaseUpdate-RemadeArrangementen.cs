using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class BIOS107DatabaseUpdateRemadeArrangementen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arrangementen",
                table: "Reservations");

            migrationBuilder.AddColumn<bool>(
                name: "WantsKinderfeestje",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WantsPopcorn",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WantsVIP",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "DateTime", "WantsKinderfeestje", "WantsPopcorn", "WantsVIP" },
                values: new object[] { new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(528), false, false, false });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "DateTime", "WantsKinderfeestje", "WantsPopcorn", "WantsVIP" },
                values: new object[] { new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(535), false, false, false });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "DateTime", "WantsKinderfeestje", "WantsPopcorn", "WantsVIP" },
                values: new object[] { new DateTime(2023, 3, 12, 14, 7, 45, 321, DateTimeKind.Local).AddTicks(538), false, false, false });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WantsKinderfeestje",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "WantsPopcorn",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "WantsVIP",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Arrangementen",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "Arrangementen", "DateTime" },
                values: new object[] { "popcorn", new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2375) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "Arrangementen", "DateTime" },
                values: new object[] { "", new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2382) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "Arrangementen", "DateTime" },
                values: new object[] { "popcorn", new DateTime(2023, 3, 12, 13, 39, 9, 363, DateTimeKind.Local).AddTicks(2385) });

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
    }
}
