namespace BotWhatsApp.DTOs
{
    public class BandejaDTO
    {
        public long Id { get; set; }
        public string Destinatario { get; set; }
        public bool Visto { get; set; }
        public string Asesor { get; set; }
        public bool Cerrada { get; set; }
        public int RolId { get; set; }
    }
}
