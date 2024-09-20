using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace miniStore.Data.Migrations
{
    public partial class RestructureDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "116500ca-5692-47ef-ab89-d74d28753969");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b9a19f7a-4062-4ec3-9a3f-ba68f84e6b00", "AQAAAAEAACcQAAAAEMS8ylAnVFUKSADcowdlYt/+BdDQya5cSgu8+jNsvWAZLaJiCUIkst7KeEW41mW4zw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 1, 21, 20, 24, 875, DateTimeKind.Local).AddTicks(2578));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8b0ebd5b-77e7-417b-a958-b43350696bb6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7fe6176b-219c-497a-8fdd-d4fd47b80f98", "AQAAAAEAACcQAAAAENQP4KTRDrvNUDa1TKhyXKK5H7zj0L7DOf+aRkELA4RCgCU+4KlufvqI3nHxZtmcqA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 1, 5, 56, 27, 612, DateTimeKind.Local).AddTicks(1752));
        }
    }
}
