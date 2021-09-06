using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestaurantManagement.Migrations
{
    public partial class rateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "CustomerOrders",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "OrderCreationDate", "Rate" },
                values: new object[] { new DateTime(2021, 9, 6, 14, 22, 36, 988, DateTimeKind.Local).AddTicks(2209), 2000m });

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "OrderCreationDate", "Rate" },
                values: new object[] { new DateTime(2021, 9, 6, 14, 22, 36, 990, DateTimeKind.Local).AddTicks(241), 600m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "CustomerOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "OrderCreationDate", "Rate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 28, 22, 548, DateTimeKind.Local).AddTicks(516), 2000 });

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "OrderCreationDate", "Rate" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 28, 22, 549, DateTimeKind.Local).AddTicks(6594), 600 });
        }
    }
}
