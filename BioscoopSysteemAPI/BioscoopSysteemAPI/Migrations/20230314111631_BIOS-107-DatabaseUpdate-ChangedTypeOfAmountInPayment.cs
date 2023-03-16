using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class BIOS107DatabaseUpdateChangedTypeOfAmountInPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Payments",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
                columns: new[] { "Amount", "PaidAt" },
                values: new object[] { 24.0, new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(692) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                columns: new[] { "Amount", "PaidAt" },
                values: new object[] { 12.0, new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                columns: new[] { "Amount", "PaidAt" },
                values: new object[] { 12.0, new DateTime(2023, 3, 14, 12, 16, 31, 206, DateTimeKind.Local).AddTicks(702) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                columns: new[] { "Amount", "PaidAt" },
                values: new object[] { 24, new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3669) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                columns: new[] { "Amount", "PaidAt" },
                values: new object[] { 12, new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3674) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                columns: new[] { "Amount", "PaidAt" },
                values: new object[] { 12, new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3760));
        }
    }
}
