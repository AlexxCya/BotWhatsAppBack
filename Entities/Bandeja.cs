using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotWhatsApp.Entities
{
    public class Bandeja: BaseEntity
    {
        
        [StringLength(20)]
        public string Destinatario { get; set; }
        public bool Visto { get; set; }
        [StringLength(60)]
        public string Asesor { get; set; }
        public long EmpresaId { get; set; }
        public bool Cerrada { get; set; }
        public List<Conversaciones> Conversaciones { get; set; }

    }
}
