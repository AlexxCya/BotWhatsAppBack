using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotWhatsApp.Entities
{
    public class Empresa: BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string RazonSocial { get; set; }
        [Required]
        [StringLength(100)]
        public string Representante { get; set; }
        [StringLength(120)]
        public string Direccion { get; set; }
        [StringLength(20)]
        public string Telefono { get; set; }
        [StringLength(20)]
        public string NumeroWhatsapp { get; set; }
        public List<BotOpciones> BotOpciones { get; set; }
        public List<Bandeja> Bandejas { get; set; }

    }
}
