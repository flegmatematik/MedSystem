using Microsoft.EntityFrameworkCore.Migrations;

namespace MedSystem.Database.Migrations
{
    public partial class PotvrdenieObjednavky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ObjednanePacientom",
                table: "Vysetrenia",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjednanePacientom",
                table: "Vysetrenia");
        }
    }
}
