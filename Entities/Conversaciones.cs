using System.ComponentModel.DataAnnotations;

namespace BotWhatsApp.Entities
{
    public class Conversaciones: BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Destinatario { get; set; }
        [Required]
        [StringLength(10)]
        public string Tipo { get; set; }
        [Required]
        public string Mensaje { get; set; }
        public int Orden { get; set; }
        public long BandejaId { get; set; }

        [StringLength(500)]
        public string MediaUrl { get; set; }
    }
}
