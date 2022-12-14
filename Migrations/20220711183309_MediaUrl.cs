using Microsoft.EntityFrameworkCore.Migrations;

namespace BotWhatsApp.Migrations
{
    public partial class MediaUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "Conversaciones",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "Conversaciones");
        }
    }
}
