using Microsoft.EntityFrameworkCore.Migrations;

namespace MedSystem.Database.Migrations
{
    public partial class BackCompat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pacienti_OsobaId",
                table: "Pacienti");

            migrationBuilder.CreateIndex(
                name: "IX_Pacienti_OsobaId",
                table: "Pacienti",
                column: "OsobaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pacienti_OsobaId",
                table: "Pacienti");

            migrationBuilder.CreateIndex(
                name: "IX_Pacienti_OsobaId",
                table: "Pacienti",
                column: "OsobaId");
        }
    }
}
