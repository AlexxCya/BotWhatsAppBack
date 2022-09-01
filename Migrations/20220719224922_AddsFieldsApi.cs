using Microsoft.EntityFrameworkCore.Migrations;

namespace BotWhatsApp.Migrations
{
    public partial class AddsFieldsApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConApi",
                table: "BotOpciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JsonParametros",
                table: "BotOpciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetodoApi",
                table: "BotOpciones",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpcionesApi",
                table: "BotOpciones",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpcionesMsjApi",
                table: "BotOpciones",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlApi",
                table: "BotOpciones",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConApi",
                table: "BotOpciones");

            migrationBuilder.DropColumn(
                name: "JsonParametros",
                table: "BotOpciones");

            migrationBuilder.DropColumn(
                name: "MetodoApi",
                table: "BotOpciones");

            migrationBuilder.DropColumn(
                name: "OpcionesApi",
                table: "BotOpciones");

            migrationBuilder.DropColumn(
                name: "OpcionesMsjApi",
                table: "BotOpciones");

            migrationBuilder.DropColumn(
                name: "UrlApi",
                table: "BotOpciones");
        }
    }
}
