using Microsoft.EntityFrameworkCore.Migrations;

namespace BotWhatsApp.Migrations
{
    public partial class Bandeja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cerrada",
                table: "Bandeja");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cerrada",
                table: "Bandeja",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
