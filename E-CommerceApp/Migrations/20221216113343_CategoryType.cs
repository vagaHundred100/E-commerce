using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_CommerceApp.Migrations
{
    public partial class CategoryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTypes_CategoryTypes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CategoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTypes_ParentId",
                table: "CategoryTypes",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTypes");

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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "c4233c24-824f-4344-a616-9426816fff4f", new DateTime(2022, 12, 11, 14, 39, 31, 248, DateTimeKind.Local).AddTicks(6915), "AQAAAAEAACcQAAAAEMPu6JzfEn6Pvooe6AZ6njkEmGZg7qrIeNrme0CAlZk04eE1yaFFPXhDi5+Jivibcw==" });
        }
    }
}
