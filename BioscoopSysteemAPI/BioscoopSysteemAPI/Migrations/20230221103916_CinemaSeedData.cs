using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class CinemaSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AllowedAge = table.Column<byte>(type: "tinyint", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InUse = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfSeatsAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    SeatRow = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "DateTime", "PaymentMethod", "ReservationId" },
                values: new object[,]
                {
                    { 1, 24, new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6830), "Ideal", 1 },
                    { 2, 12, new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6880), "CreditCard", 2 },
                    { 3, 12, new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6890), "CreditCard", 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "DateTime", "Location", "MovieId", "SeatId", "VisitorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6900), "Amsterdam", 1, 6, 1 },
                    { 2, new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6910), "Haarlem", 2, 5, 2 },
                    { 3, new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6920), "Zaandam", 3, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "InUse", "NumberOfSeatsAvailable" },
                values: new object[,]
                {
                    { 1, false, 150 },
                    { 2, false, 250 },
                    { 3, false, 75 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "MovieId", "SeatNumber", "SeatRow" },
                values: new object[,]
                {
                    { 1, 1, 8, 3 },
                    { 2, 2, 14, 2 },
                    { 3, 3, 16, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "DateTime", "MovieName", "PaymentId", "Quantity", "RoomId", "SeatId", "VisitorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6970), "ScaryMovie", 1, 2, 2, 1, 2 },
                    { 2, new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6980), "AntMan", 2, 1, 3, 3, 3 },
                    { 3, new DateTime(2023, 2, 21, 11, 39, 16, 601, DateTimeKind.Local).AddTicks(6990), "Plane", 3, 1, 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "VisitorId", "Age", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, (byte)25, "Piet", "Avans" },
                    { 2, (byte)28, "Jan", "School" },
                    { 3, (byte)19, "Hans", "Koning" }
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "AllowedAge", "Description", "ImageUrl", "Name", "Price", "RoomId" },
                values: new object[,]
                {
                    { 1, (byte)16, "Lorem ipsum dolor sit amet", "/Images/Movies/Movie1.jpeg", "ScaryMovie", 12, 5 },
                    { 2, (byte)8, "Lorem ipsum dolor sit amet", "/Images/Movies/Movie2.jpeg", "AntMan", 9, 4 },
                    { 3, (byte)12, "Lorem ipsum dolor sit amet", "/Images/Movies/Movie3.jpeg", "Plane", 12, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Visitors");
        }
    }
}
