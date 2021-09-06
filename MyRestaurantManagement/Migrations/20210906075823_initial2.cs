using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestaurantManagement.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "OrderCreationDate",
                value: new DateTime(2021, 9, 6, 13, 28, 22, 548, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 2L,
                column: "OrderCreationDate",
                value: new DateTime(2021, 9, 6, 13, 28, 22, 549, DateTimeKind.Local).AddTicks(6594));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 1L,
                column: "OrderCreationDate",
                value: new DateTime(2021, 9, 6, 13, 25, 47, 599, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 2L,
                column: "OrderCreationDate",
                value: new DateTime(2021, 9, 6, 13, 25, 47, 601, DateTimeKind.Local).AddTicks(923));
        }
    }
}
