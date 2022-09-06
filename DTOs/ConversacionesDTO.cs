using Microsoft.AspNetCore.Http;

namespace BotWhatsApp.DTOs
{
    public class ConversacionesDTO
    {
        public string Destinatario { get; set; }
        public string Tipo { get; set; }
        public string Mensaje { get; set; }
        public long BandejaId { get; set; }
        public int RolId { get; set; }
        public IFormFile Imagen { get; set; }
    }
}
