using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedSystem.Database.Migrations
{
    public partial class OckovanieAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypOckovania",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazov = table.Column<string>(nullable: true),
                    Vyrobca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypOckovania", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ockovanie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOckovanie = table.Column<int>(nullable: false),
                    TypOckovaniaId = table.Column<int>(nullable: true),
                    IdPacient = table.Column<int>(nullable: false),
                    PacientId = table.Column<int>(nullable: true),
                    DatumOckovania = table.Column<DateTime>(nullable: false),
                    PopisReakcie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ockovanie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ockovanie_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "PacientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ockovanie_TypOckovania_TypOckovaniaId",
                        column: x => x.TypOckovaniaId,
                        principalTable: "TypOckovania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ockovanie_PacientId",
                table: "Ockovanie",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ockovanie_TypOckovaniaId",
                table: "Ockovanie",
                column: "TypOckovaniaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ockovanie");

            migrationBuilder.DropTable(
                name: "TypOckovania");
        }
    }
}
