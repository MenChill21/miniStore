using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace miniStore.Data.Migrations
{
    public partial class seedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 8, 0, 6, 45, 3, DateTimeKind.Local).AddTicks(4024),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 6, 23, 28, 10, 580, DateTimeKind.Local).AddTicks(2246));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 6, 23, 28, 10, 580, DateTimeKind.Local).AddTicks(2246),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2024, 8, 8, 0, 6, 45, 3, DateTimeKind.Local).AddTicks(4024));
        }
    }
}
