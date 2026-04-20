using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Morent.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelCapacity = table.Column<int>(type: "int", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropoffLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropoffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropoffTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ReviewerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewerTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewerAvatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Capacity", "Description", "FuelCapacity", "FuelType", "ImageUrl", "IsAvailable", "IsFavorite", "Name", "PricePerDay", "Rating", "ReviewCount", "Transmission", "Type" },
                values: new object[,]
                {
                    { 1, 2, null, 90, "Gasoline", "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=600&auto=format&fit=crop", true, false, "Koenigsegg", 99m, 4.7999999999999998, 440, "Manual", "Sport" },
                    { 2, 2, null, 80, "Gasoline", "https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=600&auto=format&fit=crop", true, true, "Nissan GT-R", 80m, 4.9000000000000004, 440, "Manual", "Sport" },
                    { 3, 4, null, 70, "Gasoline", "https://images.unsplash.com/photo-1563720223185-11003d516935?w=600&auto=format&fit=crop", true, false, "Rolls-Royce", 96m, 4.7000000000000002, 440, "Manual", "Sport" },
                    { 4, 6, null, 70, "Gasoline", "https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=600&auto=format&fit=crop", true, false, "All New Rush", 72m, 4.5999999999999996, 300, "Manual", "SUV" },
                    { 5, 6, null, 80, "Gasoline", "https://images.unsplash.com/photo-1533473359331-0135ef1b58bf?w=600&auto=format&fit=crop", true, false, "CR-V", 80m, 4.5, 200, "Manual", "SUV" },
                    { 6, 6, null, 90, "Gasoline", "https://images.unsplash.com/photo-1502877338535-766e1452684a?w=600&auto=format&fit=crop", true, false, "All New Terios", 74m, 4.4000000000000004, 150, "Manual", "SUV" },
                    { 7, 4, null, 80, "Electric", "https://images.unsplash.com/photo-1580273916550-e323be2ae537?w=600&auto=format&fit=crop", true, false, "MG ZX Excite", 76m, 4.2999999999999998, 100, "Manual", "Hatchback" },
                    { 8, 6, null, 80, "Gasoline", "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=600&auto=format&fit=crop", true, false, "New MG ZS", 80m, 4.5, 180, "Manual", "SUV" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CarId", "Comment", "CreatedAt", "Rating", "ReviewerAvatar", "ReviewerName", "ReviewerTitle" },
                values: new object[,]
                {
                    { 1, 2, "We are very happy with the service from the MORENT App. Morent has a low price and also a large variety of cars with good and comfortable facilities.", new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "", "Alex Stanton", "CEO at Bukalapak" },
                    { 2, 2, "We are greatly helped by the services of the MORENT Application. Morent has low prices and also a wide variety of cars with good and comfortable facilities.", new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "", "Skylar Dias", "CEO at Amazon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CarId",
                table: "Reviews",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
