using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Morent.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCarTypesStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsFavorite",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsFavorite",
                value: true);
        }
    }
}
