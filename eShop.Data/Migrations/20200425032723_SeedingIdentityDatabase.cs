using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Data.Migrations
{
    public partial class SeedingIdentityDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Desription", "Name", "NormalizedName" },
                values: new object[] { new Guid("50154aa5-4637-48c6-9108-2517e8d8227d"), "f0ac0dd4-5917-4096-8a74-f553d34f567f", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("dc81385a-f5bc-4494-b888-dec3c000702a"), new Guid("50154aa5-4637-48c6-9108-2517e8d8227d") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("dc81385a-f5bc-4494-b888-dec3c000702a"), 0, "acc3d659-a380-4f38-933d-1c6fec8a5517", new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "vuthuan1997ss@gmail.com", true, "Vu", "Thuan", false, null, "over191997@gmail.com", "admin", "AQAAAAEAACcQAAAAELz/OIoIjuVGeHx49a46kmj8xSkvoNEuqaqkST3CZbORyO5fkAIiV0dfrnO3awkY7A==", null, false, "", false, "admin" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("50154aa5-4637-48c6-9108-2517e8d8227d"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("dc81385a-f5bc-4494-b888-dec3c000702a"), new Guid("50154aa5-4637-48c6-9108-2517e8d8227d") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("dc81385a-f5bc-4494-b888-dec3c000702a"));

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
                value: new DateTime(2020, 4, 25, 10, 18, 13, 542, DateTimeKind.Local).AddTicks(3207));
        }
    }
}
