using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Data.Migrations
{
    public partial class productImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("50154aa5-4637-48c6-9108-2517e8d8227d"),
                column: "ConcurrencyStamp",
                value: "b364002e-c1a0-49d5-8a94-f322a9a75e79");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("dc81385a-f5bc-4494-b888-dec3c000702a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0dc62b15-fa08-43f7-9953-417a0cafb045", "AQAAAAEAACcQAAAAEAm6pvni9EPQ9JH6sg7QvuRNUu5pXMaryCvYohtvOvbP/ELhN+bg8czIkkVmB7ekJQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2020, 4, 26, 16, 19, 36, 55, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("50154aa5-4637-48c6-9108-2517e8d8227d"),
                column: "ConcurrencyStamp",
                value: "f0ac0dd4-5917-4096-8a74-f553d34f567f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("dc81385a-f5bc-4494-b888-dec3c000702a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acc3d659-a380-4f38-933d-1c6fec8a5517", "AQAAAAEAACcQAAAAELz/OIoIjuVGeHx49a46kmj8xSkvoNEuqaqkST3CZbORyO5fkAIiV0dfrnO3awkY7A==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2020, 4, 25, 10, 27, 22, 702, DateTimeKind.Local).AddTicks(2601));
        }
    }
}
