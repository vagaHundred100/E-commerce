using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_CommerceApp.Migrations
{
    public partial class samirMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "59a9645b-38ef-4483-92b6-6ef8a747e83d", new DateTime(2023, 1, 11, 21, 8, 56, 937, DateTimeKind.Local).AddTicks(348) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "a8612dc1-614c-42f8-9dc8-3232d927ed62", new DateTime(2023, 1, 11, 21, 8, 56, 938, DateTimeKind.Local).AddTicks(6360), "AQAAAAEAACcQAAAAEDxnaZJ0TXbrEWbPS/uoUk0a+5YYCUcx3A/g6PLgOcfSxrCslji8DP5R8w4Kt4y9QA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "92067c38-11ba-42cf-a2c9-b362f1c894a4", new DateTime(2022, 12, 16, 15, 33, 42, 293, DateTimeKind.Local).AddTicks(1729) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "44d438d2-6907-450c-91aa-0ae7de9df3ca", new DateTime(2022, 12, 16, 15, 33, 42, 294, DateTimeKind.Local).AddTicks(5208), "AQAAAAEAACcQAAAAEAfdbcg1bDb0xJr3RaIgRNMkmDRLk9b36Ap/CV4d8ded7978pbMW+4SawN6JytaNYg==" });
        }
    }
}
