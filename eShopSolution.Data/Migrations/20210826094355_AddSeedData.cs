using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 26, 16, 43, 54, 643, DateTimeKind.Local).AddTicks(9131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 26, 16, 16, 24, 467, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "IsShowOnHome", "ParentID", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi-VN", true, "Tiếng Việt" },
                    { "en-US", false, "English" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "DateCreated", "OriginalPrice", "Price" },
                values: new object[] { 1, new DateTime(2021, 8, 26, 16, 43, 54, 666, DateTimeKind.Local).AddTicks(4619), 15000m, 100000m });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryID", "LanguageID", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, 1, "vi-VN", "Tai nghe", "tai-nghe", "Tai nghe hiện đại jack kết nối 3.5", "Tai nghe hiện đại" },
                    { 3, 2, "vi-VN", "Tai nghe bluetooth", "tai-nghe-bluetooth", "Tai nghe không dây kết nối thông qua Bluetooth", "Tai nghe không dây hiện đại kết nối Blutooth" },
                    { 2, 1, "en-US", "Headphone", "headphone", " Modern headphones with jack connect 3.5", "Modern headphone" },
                    { 4, 2, "en-US", "Bluetooth headphone", "bluetooth-headphone", "Wireless headphones connected via Bluetooth", "Modern wireless Bluetooth headset" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategory",
                columns: new[] { "CategoryID", "ProductID" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "Id", "Description", "Detail", "LanguageID", "Name", "ProductID", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Tai Nghe Bluetooth TWS VIVAN Liberty T200 - Cảm Ứng - Playtime Đến 22H ", "Mua Tai Nghe Bluetooth TWS VIVAN Liberty T200 - Cảm Ứng - Playtime Đến 22H - Chống Nước IPX4 giá tốt. Mua hàng qua mạng uy tín, tiện lợi.", "vi-VN", "Tai nghe bluetooth Vivan", 1, "tai-nghe-bluetooth-vivan", "Tai nghe Bluetooth Vivan hiện đại sạc 2h dùng 6.5h", "Tai nghe Bluetooth Vivan hiện đại" },
                    { 2, "VIVAN Liberty T200 Bluetooth Headset - Touch - Playtime Up to 22H ", "VIVAN Liberty T200 Bluetooth Headset - Touch - Playtime Up to 22H - IPX4 Waterproof at good price. Buy online reputable, convenient.", "en-US", "Vivan bluetooth headset", 1, "vivan-bluetooth-headset", "Modern Vivan Bluetooth headset charges for 2 hours and uses 6.5 hours", "Modern Vivan Bluetooth headset" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: "en-US");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "ID",
                keyValue: "vi-VN");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 26, 16, 16, 24, 467, DateTimeKind.Local).AddTicks(5446),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 26, 16, 43, 54, 643, DateTimeKind.Local).AddTicks(9131));
        }
    }
}
