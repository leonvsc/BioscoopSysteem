using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BioscoopSysteemAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Add3DMovie = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AllowedAge = table.Column<byte>(type: "tinyint", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
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

            migrationBuilder.CreateTable(
                name: "MovieRoom",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRoom", x => new { x.MovieId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_MovieRoom_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Add3DMovie", "AllowedAge", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, (byte)16, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2502), "Lorem ipsum dolor sit amet", "/Images/Movies/Movie1.jpeg", "ScaryMovie", 12 },
                    { 2, false, (byte)8, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2543), "Lorem ipsum dolor sit amet", "/Images/Movies/Movie2.jpeg", "AntMan", 9 },
                    { 3, true, (byte)12, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2546), "Lorem ipsum dolor sit amet", "/Images/Movies/Movie3.jpeg", "Plane", 12 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "DateTime", "PaymentMethod", "ReservationId" },
                values: new object[,]
                {
                    { 1, 24, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2619), "Ideal", 1 },
                    { 2, 12, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2624), "CreditCard", 2 },
                    { 3, 12, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2626), "CreditCard", 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "DateTime", "Location", "MovieId", "SeatId", "VisitorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2670), "Amsterdam", 1, 6, 1 },
                    { 2, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2675), "Haarlem", 2, 5, 2 },
                    { 3, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2677), "Zaandam", 3, 4, 3 }
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
                    { 1, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2725), "ScaryMovie", 1, 2, 2, 1, 2 },
                    { 2, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2729), "AntMan", 2, 1, 3, 3, 3 },
                    { 3, new DateTime(2023, 3, 9, 16, 18, 4, 180, DateTimeKind.Local).AddTicks(2732), "Plane", 3, 1, 1, 2, 1 }
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
                table: "MovieRoom",
                columns: new[] { "MovieId", "RoomId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieRoom_RoomId",
                table: "MovieRoom",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieRoom");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
