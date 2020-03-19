using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beezilla.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d5bb179-f364-475d-81af-d625e1d1c6a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa6009e-9c60-47eb-9503-b6a0a6c75129");

            migrationBuilder.CreateTable(
                name: "Keepers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    HiveCount = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keepers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keepers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Queens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seen = table.Column<bool>(nullable: false),
                    Marked = table.Column<bool>(nullable: false),
                    QueenStart = table.Column<DateTime>(nullable: false),
                    QueenEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperament = table.Column<string>(nullable: true),
                    Brood = table.Column<int>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    Supers = table.Column<int>(nullable: false),
                    Species = table.Column<string>(nullable: true),
                    Mites = table.Column<string>(nullable: true),
                    HiveType = table.Column<string>(nullable: true),
                    Propolis = table.Column<string>(nullable: true),
                    HiveImageUrl = table.Column<string>(nullable: true),
                    QueenCells = table.Column<int>(nullable: false),
                    KeeperModel = table.Column<int>(nullable: true),
                    HiveStrength = table.Column<string>(nullable: true),
                    SwarmPotential = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hives_Keepers_KeeperModel",
                        column: x => x.KeeperModel,
                        principalTable: "Keepers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5ebcca2-ff02-4f0c-ad28-6e31a6eea020", "993a6894-b2b9-4d2d-bd5f-8a542fbd1f5d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eff88620-7486-47ce-a7f2-94eb253012a3", "33ccf9a1-d6bc-4490-8904-88d1bd1aeae0", "Keeper", "KEEPER" });

            migrationBuilder.CreateIndex(
                name: "IX_Hives_KeeperModel",
                table: "Hives",
                column: "KeeperModel");

            migrationBuilder.CreateIndex(
                name: "IX_Keepers_IdentityUserId",
                table: "Keepers",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hives");

            migrationBuilder.DropTable(
                name: "Queens");

            migrationBuilder.DropTable(
                name: "Keepers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5ebcca2-ff02-4f0c-ad28-6e31a6eea020");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff88620-7486-47ce-a7f2-94eb253012a3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8fa6009e-9c60-47eb-9503-b6a0a6c75129", "d267104e-558f-4d3e-ad09-ebfa75246047", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d5bb179-f364-475d-81af-d625e1d1c6a0", "b4fdbe8b-6f67-4d64-9b50-810bcf15ac09", "Keeper", "KEEPER" });
        }
    }
}
