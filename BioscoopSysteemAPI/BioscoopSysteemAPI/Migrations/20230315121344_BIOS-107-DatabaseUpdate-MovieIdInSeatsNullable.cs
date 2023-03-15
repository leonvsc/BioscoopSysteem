using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class BIOS107DatabaseUpdateMovieIdInSeatsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Seats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaidAt",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                column: "PaidAt",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                column: "PaidAt",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 15, 13, 13, 44, 747, DateTimeKind.Local).AddTicks(4511));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaidAt",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                column: "PaidAt",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                column: "PaidAt",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(1235));
        }
    }
}
