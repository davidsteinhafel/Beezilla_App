using Microsoft.EntityFrameworkCore.Migrations;

namespace Beezilla.Data.Migrations
{
    public partial class Keeper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d2f3f84-f114-4c3b-8618-528327ca2972");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c1918a2-a049-4ddb-9522-f20fba324df7", "90240172-4724-4558-b966-c39ae4bff042", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd94bcfa-c5ae-47dc-8952-b9408cf53735", "4284b9dc-5ee9-4ee5-881d-f7fd6ed5e8e9", "Keeper", "KEEPER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c1918a2-a049-4ddb-9522-f20fba324df7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd94bcfa-c5ae-47dc-8952-b9408cf53735");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d2f3f84-f114-4c3b-8618-528327ca2972", "4b6febfb-8e19-4b91-a529-ccbff79e1a41", "Admin", "ADMIN" });
        }
    }
}
