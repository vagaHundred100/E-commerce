using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_CommerceApp.Migrations
{
    public partial class NewMigLSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "5f04114e-1bb6-454e-9e2f-a9a3e1da08f4", new DateTime(2022, 12, 11, 14, 39, 31, 240, DateTimeKind.Local).AddTicks(7206) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "c4233c24-824f-4344-a616-9426816fff4f", new DateTime(2022, 12, 11, 14, 39, 31, 248, DateTimeKind.Local).AddTicks(6915), "ADMIN", "AQAAAAEAACcQAAAAEMPu6JzfEn6Pvooe6AZ6njkEmGZg7qrIeNrme0CAlZk04eE1yaFFPXhDi5+Jivibcw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate" },
                values: new object[] { "ed78554b-9dca-4eea-8833-6b5afe183f8d", new DateTime(2022, 11, 27, 17, 51, 55, 793, DateTimeKind.Local).AddTicks(5227) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "6dca9ad9-0d06-414f-96a9-bbda22b6cee1", new DateTime(2022, 11, 27, 17, 51, 55, 797, DateTimeKind.Local).AddTicks(7827), null, "AQAAAAEAACcQAAAAEK28c5pA0DetJYb+fF/MuDau+FQCSYL3H8Zgh4fq7GMLiXdbcAhAllfJcSB/WEEDIA==" });
        }
    }
}
