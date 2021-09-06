using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRestaurantManagement.Migrations
{
    public partial class paymentidUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentID",
                table: "CustomerOrders",
                type: "text",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "OrderCreationDate", "PaymentID" },
                values: new object[] { new DateTime(2021, 9, 6, 17, 49, 36, 724, DateTimeKind.Local).AddTicks(5031), null });

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "OrderCreationDate", "PaymentID" },
                values: new object[] { new DateTime(2021, 9, 6, 17, 49, 36, 725, DateTimeKind.Local).AddTicks(7146), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PaymentID",
                table: "CustomerOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "OrderCreationDate", "PaymentID" },
                values: new object[] { new DateTime(2021, 9, 6, 17, 39, 58, 103, DateTimeKind.Local).AddTicks(3713), 0L });

            migrationBuilder.UpdateData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "OrderCreationDate", "PaymentID" },
                values: new object[] { new DateTime(2021, 9, 6, 17, 39, 58, 104, DateTimeKind.Local).AddTicks(5994), 0L });
        }
    }
}
