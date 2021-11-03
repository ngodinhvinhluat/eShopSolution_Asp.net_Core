using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 0, 17, 49, 361, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeafault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("45284839-e929-4807-8c84-cb1cf81cdcdf"),
                column: "ConcurrencyStamp",
                value: "b4c4892a-3f40-466a-948b-71ea5730a3b3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("2659d4c4-6bb0-48ea-9711-39b671deb886"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7dc8c4e3-c00d-4ad3-b293-c81ad228295b", "AQAAAAEAACcQAAAAEAdTS53ftWKYg+nX5rhB9sKJdAqbD5zm67DvB2z7hJvYqRMM0Qmgm9uI9V9bB5fcsg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 28, 16, 49, 1, 186, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 0, 17, 49, 361, DateTimeKind.Local).AddTicks(1079),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("45284839-e929-4807-8c84-cb1cf81cdcdf"),
                column: "ConcurrencyStamp",
                value: "608ee34d-cc1e-4b1b-8f4b-fa2ff3f97a7d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("2659d4c4-6bb0-48ea-9711-39b671deb886"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "abb49dbc-5e0b-4305-a6d3-965a2cf9a72a", "AQAAAAEAACcQAAAAECO+JJ/tdS9yY1SKxxDtgLa1+2EJPEWmK8/9DxgMQH/DSR2AGTAyBfaUnfXga+i2Ng==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 27, 0, 17, 49, 400, DateTimeKind.Local).AddTicks(2766));
        }
    }
}
