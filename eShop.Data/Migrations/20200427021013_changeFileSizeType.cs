using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Data.Migrations
{
    public partial class changeFileSizeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImage",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("50154aa5-4637-48c6-9108-2517e8d8227d"),
                column: "ConcurrencyStamp",
                value: "2ddc67a6-2e06-46cf-8472-526284d3c4e1");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("dc81385a-f5bc-4494-b888-dec3c000702a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "df353503-abf4-410b-b80c-06b236114aa9", "AQAAAAEAACcQAAAAEOt5G4ojNoD9uEzwNBvj0y3L/NjPok5Zck6DMjFgAYy57mpTILjefoCVOCZueOEWYw==" });

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
                value: new DateTime(2020, 4, 27, 9, 10, 12, 93, DateTimeKind.Local).AddTicks(4071));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImage",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

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
        }
    }
}
