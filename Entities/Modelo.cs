using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotWhatsApp.Entities
{
    public class Modelo:BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string NombreModelo { get; set; }
        public int Anio { get; set; }
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Costo { get; set; }
        public long MarcaId { get; set; }
    }
}
