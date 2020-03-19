using Microsoft.EntityFrameworkCore.Migrations;

namespace Beezilla.Data.Migrations
{
    public partial class Addition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72ae0055-0bd9-4791-bf5b-96654a1104d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86183c49-db01-4955-ae56-226cc5d913f1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54273c62-ca0c-461c-be0e-1a30e79ab065", "d9706ee5-dbc5-4157-bb2f-d4183cf64ce3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c17eeb60-0d33-49de-8030-ef94b88824d4", "84b2a715-e3b3-49a1-9589-58ee51c5380f", "Keeper", "KEEPER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54273c62-ca0c-461c-be0e-1a30e79ab065");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c17eeb60-0d33-49de-8030-ef94b88824d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86183c49-db01-4955-ae56-226cc5d913f1", "7677d8c4-bcba-44c9-8c03-157fd8a237fc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72ae0055-0bd9-4791-bf5b-96654a1104d1", "caabd911-e45c-4d2d-bf75-6d65379ace28", "Keeper", "KEEPER" });
        }
    }
}
