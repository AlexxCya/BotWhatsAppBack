using System.ComponentModel.DataAnnotations;

namespace BotWhatsApp.Entities
{
    public class Bots:BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Destinatario { get; set; }
        public long BotOpcionesId { get; set; }
        public string ValoresApi { get; set; }
        public string ValoresSeleccionados { get; set; }
    }
}
