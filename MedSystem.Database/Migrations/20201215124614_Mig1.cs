using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedSystem.Database.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lieky",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazov = table.Column<string>(nullable: true),
                    Vyrobca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lieky", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Osoby",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeleMeno = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoby", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacienti",
                columns: table => new
                {
                    PacientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsobaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacienti", x => x.PacientId);
                    table.ForeignKey(
                        name: "FK_Pacienti_Osoby_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osoby",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    ZPersonalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pozicia = table.Column<string>(nullable: true),
                    Ambulancia = table.Column<string>(nullable: true),
                    OsobaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.ZPersonalId);
                    table.ForeignKey(
                        name: "FK_Personal_Osoby_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osoby",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Uzivatelia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzivatelskeMeno = table.Column<string>(nullable: true),
                    Heslo = table.Column<string>(nullable: true),
                    TypPristupu = table.Column<int>(nullable: false),
                    OsobaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzivatelia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uzivatelia_Osoby_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osoby",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vysetrenie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zaznam = table.Column<string>(nullable: true),
                    ObjednanyTermin = table.Column<DateTime>(nullable: false),
                    RealnyTermin = table.Column<DateTime>(nullable: false),
                    Ambulancia = table.Column<string>(nullable: true),
                    PacientId = table.Column<int>(nullable: false),
                    ZPersonalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vysetrenie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vysetrenie_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "PacientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vysetrenie_Personal_ZPersonalId",
                        column: x => x.ZPersonalId,
                        principalTable: "Personal",
                        principalColumn: "ZPersonalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PredpisanyLiek",
                columns: table => new
                {
                    VysetrenieId = table.Column<int>(nullable: false),
                    LiekId = table.Column<int>(nullable: false),
                    Popis = table.Column<string>(nullable: true),
                    Mnozstvo = table.Column<int>(nullable: false),
                    Davkovanie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredpisanyLiek", x => new { x.LiekId, x.VysetrenieId });
                    table.ForeignKey(
                        name: "FK_PredpisanyLiek_Lieky_LiekId",
                        column: x => x.LiekId,
                        principalTable: "Lieky",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredpisanyLiek_Vysetrenie_VysetrenieId",
                        column: x => x.VysetrenieId,
                        principalTable: "Vysetrenie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacienti_OsobaId",
                table: "Pacienti",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_OsobaId",
                table: "Personal",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_PredpisanyLiek_VysetrenieId",
                table: "PredpisanyLiek",
                column: "VysetrenieId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzivatelia_OsobaId",
                table: "Uzivatelia",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vysetrenie_PacientId",
                table: "Vysetrenie",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vysetrenie_ZPersonalId",
                table: "Vysetrenie",
                column: "ZPersonalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredpisanyLiek");

            migrationBuilder.DropTable(
                name: "Uzivatelia");

            migrationBuilder.DropTable(
                name: "Lieky");

            migrationBuilder.DropTable(
                name: "Vysetrenie");

            migrationBuilder.DropTable(
                name: "Pacienti");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Osoby");
        }
    }
}
