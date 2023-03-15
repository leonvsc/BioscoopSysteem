using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class BIOS107DatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Payments",
                newName: "PaidAt");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Arrangementen",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsStudent",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Reservations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MollieId",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "MollieId", "PaidAt", "PaymentStatus" },
                values: new object[] { "tr_9x5yAUbWZ2", new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7680), "paid" });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                columns: new[] { "MollieId", "PaidAt", "PaymentStatus" },
                values: new object[] { "tr_9x5yAUbWZ2", new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7684), "paid" });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                columns: new[] { "MollieId", "PaidAt", "PaymentStatus" },
                values: new object[] { "tr_9x5yAUbWZ2", new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7686), "paid" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "Age", "Arrangementen", "DateTime", "IsStudent", "PaymentId", "TotalPrice" },
                values: new object[] { "12 tm 65", "popcorn", new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7702), false, 0, 12.0 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "Age", "Arrangementen", "DateTime", "IsStudent", "PaymentId", "TotalPrice" },
                values: new object[] { "65+", "", new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7709), false, 0, 12.0 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "Age", "Arrangementen", "DateTime", "IsStudent", "PaymentId", "TotalPrice" },
                values: new object[] { "12 tm 65", "popcorn", new DateTime(2023, 3, 12, 12, 48, 45, 44, DateTimeKind.Local).AddTicks(7712), true, 0, 9.0 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Arrangementen",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsStudent",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MollieId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "PaidAt",
                table: "Payments",
                newName: "DateTime");

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
                value: new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                columns: new[] { "DateTime", "ReservationId" },
                values: new object[] { new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2619), 1 });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                columns: new[] { "DateTime", "ReservationId" },
                values: new object[] { new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2624), 2 });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                columns: new[] { "DateTime", "ReservationId" },
                values: new object[] { new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2626), 3 });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2729));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2732));
        }
    }
}
