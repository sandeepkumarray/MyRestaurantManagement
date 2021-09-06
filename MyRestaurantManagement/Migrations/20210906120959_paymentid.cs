using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestaurantManagement.Migrations
{
    public partial class paymentid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PaymentID",
                table: "CustomerOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "OrderCreationDate",
                value: new DateTime(2021, 9, 6, 17, 39, 58, 103, DateTimeKind.Local).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 2L,
                column: "OrderCreationDate",
                value: new DateTime(2021, 9, 6, 17, 39, 58, 104, DateTimeKind.Local).AddTicks(5994));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "CustomerOrders");

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "OrderCreationDate",
                value: new DateTime(2021, 9, 6, 14, 22, 36, 988, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 2L,
                column: "OrderCreationDate",
                value: new DateTime(2021, 9, 6, 14, 22, 36, 990, DateTimeKind.Local).AddTicks(241));
        }
    }
}
