using Microsoft.EntityFrameworkCore.Migrations;

namespace BotWhatsApp.Migrations
{
    public partial class MensajesPredt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomnbreMensaje",
                table: "MensajesPredeterminado",
                newName: "NombreMensaje");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreMensaje",
                table: "MensajesPredeterminado",
                newName: "NomnbreMensaje");
        }
    }
}
