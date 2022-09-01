using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotWhatsApp.Entities
{
    public class Poliza: BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string NumPoliza { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string Vehiculo { get; set; }
        [StringLength(50)]
        public string Cobertura { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }
        [StringLength(500)]
        public string PdfUrl { get; set; }
    }
}
