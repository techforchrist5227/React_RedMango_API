using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedMango_API.Migrations
{
    public partial class InitialSeedMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/spring roll.jpg", "Spring Roll", 7.9900000000000002, "" },
                    { 2, "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/idli.jpg", "Idli", 8.9900000000000002, "" },
                    { 3, "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/pani puri.jpg", "Panu Puri", 8.9900000000000002, "Best Seller" },
                    { 4, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/hakka noodles.jpg", "Hakka Noodles", 10.99, "" },
                    { 5, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/malai kofta.jpg", "Malai Kofta", 12.99, "Top Rated" },
                    { 6, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/paneer pizza.jpg", "Paneer Pizza", 11.99, "" },
                    { 7, "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/paneer tikka.jpg", "Paneer Tikka", 13.99, "Chef's Special" },
                    { 8, "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/carrot love.jpg", "Carrot Love", 4.9900000000000002, "" },
                    { 9, "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/rasmalai.jpg", "Rasmalai", 4.9900000000000002, "Chef's Special" },
                    { 10, "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/sweet rolls.jpg", "Sweet Rolls", 3.9900000000000002, "Top Rated" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "MenuItems");
        }
    }
}
