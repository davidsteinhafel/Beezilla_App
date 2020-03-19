using Microsoft.EntityFrameworkCore.Migrations;

namespace Beezilla.Data.Migrations
{
    public partial class latLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5ebcca2-ff02-4f0c-ad28-6e31a6eea020");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff88620-7486-47ce-a7f2-94eb253012a3");

            migrationBuilder.AddColumn<int>(
                name: "HiveLat",
                table: "Hives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HiveLon",
                table: "Hives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86183c49-db01-4955-ae56-226cc5d913f1", "7677d8c4-bcba-44c9-8c03-157fd8a237fc", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72ae0055-0bd9-4791-bf5b-96654a1104d1", "caabd911-e45c-4d2d-bf75-6d65379ace28", "Keeper", "KEEPER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72ae0055-0bd9-4791-bf5b-96654a1104d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86183c49-db01-4955-ae56-226cc5d913f1");

            migrationBuilder.DropColumn(
                name: "HiveLat",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "HiveLon",
                table: "Hives");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5ebcca2-ff02-4f0c-ad28-6e31a6eea020", "993a6894-b2b9-4d2d-bd5f-8a542fbd1f5d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eff88620-7486-47ce-a7f2-94eb253012a3", "33ccf9a1-d6bc-4490-8904-88d1bd1aeae0", "Keeper", "KEEPER" });
        }
    }
}
