using Microsoft.EntityFrameworkCore.Migrations;

namespace MedSystem.Database.Migrations
{
    public partial class RemoveLieky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predpisy");

            migrationBuilder.DropTable(
                name: "Lieky");

            migrationBuilder.DropIndex(
                name: "IX_Uzivatelia_OsobaId",
                table: "Uzivatelia");

            migrationBuilder.CreateIndex(
                name: "IX_Uzivatelia_OsobaId",
                table: "Uzivatelia",
                column: "OsobaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Uzivatelia_OsobaId",
                table: "Uzivatelia");

            migrationBuilder.CreateTable(
                name: "Lieky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vyrobca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lieky", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Predpisy",
                columns: table => new
                {
                    LiekId = table.Column<int>(type: "int", nullable: false),
                    VysetrenieId = table.Column<int>(type: "int", nullable: false),
                    Davkovanie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mnozstvo = table.Column<int>(type: "int", nullable: false),
                    Popis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predpisy", x => new { x.LiekId, x.VysetrenieId });
                    table.ForeignKey(
                        name: "FK_Predpisy_Lieky_LiekId",
                        column: x => x.LiekId,
                        principalTable: "Lieky",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Predpisy_Vysetrenia_VysetrenieId",
                        column: x => x.VysetrenieId,
                        principalTable: "Vysetrenia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uzivatelia_OsobaId",
                table: "Uzivatelia",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Predpisy_VysetrenieId",
                table: "Predpisy",
                column: "VysetrenieId");
        }
    }
}
