using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Morent.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountAndReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedPrice",
                table: "Cars",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiscountedPrice",
                value: 80m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiscountedPrice",
                value: 80m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "DiscountedPrice",
                value: 96m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DiscountedPrice", "PricePerDay" },
                values: new object[] { 72m, 100m });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "DiscountedPrice",
                value: 80m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "DiscountedPrice",
                value: 74m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DiscountedPrice", "PricePerDay" },
                values: new object[] { 76m, 100m });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                column: "DiscountedPrice",
                value: 80m);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Capacity", "Description", "DiscountedPrice", "FuelCapacity", "FuelType", "ImageUrl", "IsAvailable", "IsFavorite", "Name", "PricePerDay", "Rating", "ReviewCount", "Transmission", "Type" },
                values: new object[,]
                {
                    { 9, 4, null, 80m, 70, "Electric", "https://images.unsplash.com/photo-1541899481282-d53bffe3c35d?w=600&auto=format&fit=crop", true, false, "MG ZX Exclusive", 80m, 4.2000000000000002, 90, "Automatic", "Hatchback" },
                    { 10, 4, null, 99m, 60, "Gasoline", "https://images.unsplash.com/photo-1617531653332-bd46c16f4d68?w=600&auto=format&fit=crop", true, false, "BMW M4", 120m, 4.9000000000000004, 520, "Automatic", "Sport" },
                    { 11, 5, null, 95m, 65, "Gasoline", "https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=600&auto=format&fit=crop", true, false, "Mercedes C-Class", 95m, 4.5999999999999996, 380, "Automatic", "Sedan" },
                    { 12, 5, null, 150m, 100, "Electric", "https://images.unsplash.com/photo-1617788138017-80ad40651399?w=600&auto=format&fit=crop", true, false, "Tesla Model S", 180m, 5.0, 600, "Automatic", "Sedan" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Comment",
                value: "We are very happy with the service from the MORENT App. Morent has a low price and also a large variety of cars with good and comfortable facilities. In addition, the service provided by the officers is also very friendly and very polite.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Comment",
                value: "We are greatly helped by the services of the MORENT Application. Morent has low prices and also a wide variety of cars with good and comfortable facilities. In addition, the service provided by the officers is also very friendly and very polite.");

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CarId", "Comment", "CreatedAt", "Rating", "ReviewerAvatar", "ReviewerName", "ReviewerTitle" },
                values: new object[,]
                {
                    { 3, 1, "Amazing car! The Koenigsegg exceeded all my expectations. Smooth ride and incredible acceleration. Highly recommend MORENT for luxury car rentals.", new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "", "John Smith", "CTO at Google" },
                    { 4, 3, "The Rolls-Royce was absolutely stunning. Pure luxury from the moment I sat in it. MORENT made the whole process seamless and easy.", new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "", "Emma Wilson", "CEO at Tesla" },
                    { 5, 4, "Great family SUV! The All New Rush was perfect for our road trip. Spacious, comfortable and fuel efficient. Great value for money.", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "", "Mike Johnson", "Manager at Ford" },
                    { 8, 5, "CR-V was perfect for our family vacation. Reliable, comfortable and great on fuel. MORENT's pricing is very competitive.", new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "", "Lisa Park", "Director at Samsung" },
                    { 6, 10, "The BMW M4 is an absolute beast! Perfect handling and stunning looks. MORENT service was top notch from booking to return.", new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "", "Sarah Lee", "Designer at Apple" },
                    { 7, 12, "Tesla Model S is the future! Silent, fast and incredibly comfortable. MORENT had it ready on time and in perfect condition.", new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "", "David Chen", "Engineer at SpaceX" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "DiscountedPrice",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "PricePerDay",
                value: 72m);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "PricePerDay",
                value: 76m);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Comment",
                value: "We are very happy with the service from the MORENT App. Morent has a low price and also a large variety of cars with good and comfortable facilities.");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Comment",
                value: "We are greatly helped by the services of the MORENT Application. Morent has low prices and also a wide variety of cars with good and comfortable facilities.");
        }
    }
}
