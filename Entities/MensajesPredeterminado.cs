using System.ComponentModel.DataAnnotations;

namespace BotWhatsApp.Entities
{
    public class MensajesPredeterminado: BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string NombreMensaje { get; set; }
        [Required]
        [StringLength(1000)]
        public string Mensaje { get; set; }
    }
}
