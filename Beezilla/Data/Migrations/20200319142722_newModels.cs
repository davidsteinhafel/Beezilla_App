using Microsoft.EntityFrameworkCore.Migrations;

namespace Beezilla.Data.Migrations
{
    public partial class newModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "8fa6009e-9c60-47eb-9503-b6a0a6c75129", "d267104e-558f-4d3e-ad09-ebfa75246047", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d5bb179-f364-475d-81af-d625e1d1c6a0", "b4fdbe8b-6f67-4d64-9b50-810bcf15ac09", "Keeper", "KEEPER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d5bb179-f364-475d-81af-d625e1d1c6a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa6009e-9c60-47eb-9503-b6a0a6c75129");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c1918a2-a049-4ddb-9522-f20fba324df7", "90240172-4724-4558-b966-c39ae4bff042", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd94bcfa-c5ae-47dc-8952-b9408cf53735", "4284b9dc-5ee9-4ee5-881d-f7fd6ed5e8e9", "Keeper", "KEEPER" });
        }
    }
}
