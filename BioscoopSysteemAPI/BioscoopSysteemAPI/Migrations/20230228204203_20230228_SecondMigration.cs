using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _20230228_SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_movies",
                table: "movies");

            migrationBuilder.RenameTable(
                name: "movies",
                newName: "Movies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 2, 28, 21, 42, 3, 301, DateTimeKind.Local).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 2, 28, 21, 42, 3, 301, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 2, 28, 21, 42, 3, 301, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 2, 28, 21, 42, 3, 301, DateTimeKind.Local).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 2, 28, 21, 42, 3, 301, DateTimeKind.Local).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 2, 28, 21, 42, 3, 301, DateTimeKind.Local).AddTicks(6079));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 2, 28, 21, 42, 3, 301, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 2, 28, 21, 42, 3, 301, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 2, 28, 21, 42, 3, 301, DateTimeKind.Local).AddTicks(6170));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movies",
                table: "movies",
                column: "MovieId");

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6990));
        }
    }
}
