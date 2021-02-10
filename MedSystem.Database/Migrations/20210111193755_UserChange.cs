using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedSystem.Database.Migrations
{
    public partial class UserChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heslo",
                table: "Uzivatelia");

            migrationBuilder.DropColumn(
                name: "UzivatelskeMeno",
                table: "Uzivatelia");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Uzivatelia",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefonneCislo",
                table: "Uzivatelia",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<byte[]>(nullable: false),
                    Salt = table.Column<byte[]>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    UzivatelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Uzivatelia_UzivatelId",
                        column: x => x.UzivatelId,
                        principalTable: "Uzivatelia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UzivatelId",
                table: "Accounts",
                column: "UzivatelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Uzivatelia");

            migrationBuilder.DropColumn(
                name: "TelefonneCislo",
                table: "Uzivatelia");

            migrationBuilder.AddColumn<string>(
                name: "Heslo",
                table: "Uzivatelia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UzivatelskeMeno",
                table: "Uzivatelia",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
