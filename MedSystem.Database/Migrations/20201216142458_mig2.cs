using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedSystem.Database.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PredpisanyLiek_Lieky_LiekId",
                table: "PredpisanyLiek");

            migrationBuilder.DropForeignKey(
                name: "FK_PredpisanyLiek_Vysetrenie_VysetrenieId",
                table: "PredpisanyLiek");

            migrationBuilder.DropForeignKey(
                name: "FK_Vysetrenie_Pacienti_PacientId",
                table: "Vysetrenie");

            migrationBuilder.DropForeignKey(
                name: "FK_Vysetrenie_Personal_ZPersonalId",
                table: "Vysetrenie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vysetrenie",
                table: "Vysetrenie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PredpisanyLiek",
                table: "PredpisanyLiek");

            migrationBuilder.RenameTable(
                name: "Vysetrenie",
                newName: "Vysetrenia");

            migrationBuilder.RenameTable(
                name: "PredpisanyLiek",
                newName: "Predpisy");

            migrationBuilder.RenameIndex(
                name: "IX_Vysetrenie_ZPersonalId",
                table: "Vysetrenia",
                newName: "IX_Vysetrenia_ZPersonalId");

            migrationBuilder.RenameIndex(
                name: "IX_Vysetrenie_PacientId",
                table: "Vysetrenia",
                newName: "IX_Vysetrenia_PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_PredpisanyLiek_VysetrenieId",
                table: "Predpisy",
                newName: "IX_Predpisy_VysetrenieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vysetrenia",
                table: "Vysetrenia",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Predpisy",
                table: "Predpisy",
                columns: new[] { "LiekId", "VysetrenieId" });

            migrationBuilder.CreateTable(
                name: "Poistovne",
                columns: table => new
                {
                    PoistovnaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazov = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    KodPoistovne = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poistovne", x => x.PoistovnaId);
                });

            migrationBuilder.CreateTable(
                name: "Poistenci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatnostOd = table.Column<DateTime>(nullable: false),
                    PlatnostDo = table.Column<DateTime>(nullable: false),
                    PoistovnaId = table.Column<int>(nullable: false),
                    PacientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poistenci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poistenci_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "PacientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poistenci_Poistovne_PoistovnaId",
                        column: x => x.PoistovnaId,
                        principalTable: "Poistovne",
                        principalColumn: "PoistovnaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poistenci_PacientId",
                table: "Poistenci",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Poistenci_PoistovnaId",
                table: "Poistenci",
                column: "PoistovnaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Predpisy_Lieky_LiekId",
                table: "Predpisy",
                column: "LiekId",
                principalTable: "Lieky",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Predpisy_Vysetrenia_VysetrenieId",
                table: "Predpisy",
                column: "VysetrenieId",
                principalTable: "Vysetrenia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vysetrenia_Pacienti_PacientId",
                table: "Vysetrenia",
                column: "PacientId",
                principalTable: "Pacienti",
                principalColumn: "PacientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vysetrenia_Personal_ZPersonalId",
                table: "Vysetrenia",
                column: "ZPersonalId",
                principalTable: "Personal",
                principalColumn: "ZPersonalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predpisy_Lieky_LiekId",
                table: "Predpisy");

            migrationBuilder.DropForeignKey(
                name: "FK_Predpisy_Vysetrenia_VysetrenieId",
                table: "Predpisy");

            migrationBuilder.DropForeignKey(
                name: "FK_Vysetrenia_Pacienti_PacientId",
                table: "Vysetrenia");

            migrationBuilder.DropForeignKey(
                name: "FK_Vysetrenia_Personal_ZPersonalId",
                table: "Vysetrenia");

            migrationBuilder.DropTable(
                name: "Poistenci");

            migrationBuilder.DropTable(
                name: "Poistovne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vysetrenia",
                table: "Vysetrenia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Predpisy",
                table: "Predpisy");

            migrationBuilder.RenameTable(
                name: "Vysetrenia",
                newName: "Vysetrenie");

            migrationBuilder.RenameTable(
                name: "Predpisy",
                newName: "PredpisanyLiek");

            migrationBuilder.RenameIndex(
                name: "IX_Vysetrenia_ZPersonalId",
                table: "Vysetrenie",
                newName: "IX_Vysetrenie_ZPersonalId");

            migrationBuilder.RenameIndex(
                name: "IX_Vysetrenia_PacientId",
                table: "Vysetrenie",
                newName: "IX_Vysetrenie_PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_Predpisy_VysetrenieId",
                table: "PredpisanyLiek",
                newName: "IX_PredpisanyLiek_VysetrenieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vysetrenie",
                table: "Vysetrenie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PredpisanyLiek",
                table: "PredpisanyLiek",
                columns: new[] { "LiekId", "VysetrenieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PredpisanyLiek_Lieky_LiekId",
                table: "PredpisanyLiek",
                column: "LiekId",
                principalTable: "Lieky",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredpisanyLiek_Vysetrenie_VysetrenieId",
                table: "PredpisanyLiek",
                column: "VysetrenieId",
                principalTable: "Vysetrenie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vysetrenie_Pacienti_PacientId",
                table: "Vysetrenie",
                column: "PacientId",
                principalTable: "Pacienti",
                principalColumn: "PacientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vysetrenie_Personal_ZPersonalId",
                table: "Vysetrenie",
                column: "ZPersonalId",
                principalTable: "Personal",
                principalColumn: "ZPersonalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
