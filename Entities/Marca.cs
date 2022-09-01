using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotWhatsApp.Entities
{
    public class Marca:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string NombreMarca  {get; set;}
        public List<Modelo> Modelos { get; set; }
    }
}
