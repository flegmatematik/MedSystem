using Microsoft.EntityFrameworkCore.Migrations;

namespace MedSystem.Database.Migrations
{
    public partial class UpdateVys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PotvrdeneDoktorom",
                table: "Vysetrenia",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TypVysetreniaId",
                table: "Vysetrenia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypVysetrenia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazov = table.Column<string>(nullable: true),
                    Skratka = table.Column<string>(nullable: true),
                    Popis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypVysetrenia", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vysetrenia_TypVysetreniaId",
                table: "Vysetrenia",
                column: "TypVysetreniaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vysetrenia_TypVysetrenia_TypVysetreniaId",
                table: "Vysetrenia",
                column: "TypVysetreniaId",
                principalTable: "TypVysetrenia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vysetrenia_TypVysetrenia_TypVysetreniaId",
                table: "Vysetrenia");

            migrationBuilder.DropTable(
                name: "TypVysetrenia");

            migrationBuilder.DropIndex(
                name: "IX_Vysetrenia_TypVysetreniaId",
                table: "Vysetrenia");

            migrationBuilder.DropColumn(
                name: "PotvrdeneDoktorom",
                table: "Vysetrenia");

            migrationBuilder.DropColumn(
                name: "TypVysetreniaId",
                table: "Vysetrenia");
        }
    }
}
