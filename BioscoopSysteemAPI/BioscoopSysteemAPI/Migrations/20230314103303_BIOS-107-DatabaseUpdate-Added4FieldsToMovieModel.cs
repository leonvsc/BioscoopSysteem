using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class BIOS107DatabaseUpdateAdded4FieldsToMovieModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specials",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Subtitles",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                columns: new[] { "Date", "Genre", "Language", "Specials", "Subtitles" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3605), "Horror", "English", "Ladies Night", true });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                columns: new[] { "Date", "Genre", "Language", "Specials", "Subtitles" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3641), "Horror", "English", "Ladies Night", true });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "Date", "Genre", "Language", "Specials", "Subtitles" },
                values: new object[] { new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3645), "Horror", "English", "Ladies Night", true });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1,
                column: "PaidAt",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                column: "PaidAt",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                column: "PaidAt",
                value: new DateTime(2023, 3, 14, 11, 33, 3, 131, DateTimeKind.Local).AddTicks(3676));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Specials",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Subtitles",
                table: "Movies");

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
                column: "PaidAt",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2,
                column: "PaidAt",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3,
                column: "PaidAt",
                value: new DateTime(2023, 3, 13, 11, 14, 43, 713, DateTimeKind.Local).AddTicks(5490));

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
    }
}
