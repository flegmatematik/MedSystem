using Microsoft.EntityFrameworkCore.Migrations;

namespace MedSystem.Database.Migrations
{
    public partial class ByteLengths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "Accounts",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "Accounts",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "Accounts",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "Accounts",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldMaxLength: 20);
        }
    }
}
