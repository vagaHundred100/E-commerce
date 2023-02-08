using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_CommerceApp.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "39e18296-e015-4e23-b056-865b08cf00d6", new DateTime(2023, 2, 8, 20, 29, 35, 534, DateTimeKind.Local).AddTicks(6645) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "1d5eedb0-3641-40e9-93b0-f88cea4bdabd", new DateTime(2023, 2, 8, 20, 29, 35, 536, DateTimeKind.Local).AddTicks(5477), "AQAAAAEAACcQAAAAEAidwhefdxqLIrqCdkEvdAv4arOfVj9oemlIIDC9w3QPvUL/Ce+9he0PxUUW+mAgQw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "ba160a38-5571-4d09-b0a5-ea9e5f350128", new DateTime(2023, 1, 27, 19, 21, 56, 531, DateTimeKind.Local).AddTicks(1068) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "c41e55f9-c8d8-4abc-9374-056bcbd8eb77", new DateTime(2023, 1, 27, 19, 21, 56, 532, DateTimeKind.Local).AddTicks(2532), "AQAAAAEAACcQAAAAEGiUxR4BM7Yl3XFmVG7NYo3X55iDk53H9XVxK68aOXiCCavuCM3KROnCyq2ratAeZg==" });
        }
    }
}
