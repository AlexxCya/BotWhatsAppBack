using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BotWhatsApp.Entities
{
    public class BotOpciones : BaseEntity
    {
        [StringLength(2000)]
        public string Mensaje { get; set; }
        public int IdPadre { get; set; }
        public bool Opcion { get; set; }
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }
        public bool Activo { get; set; } = false;
        public bool ConApi { get; set; } = false;
        [StringLength(1000)]
        public string UrlApi { get; set; }
        [StringLength(10)]
        public string MetodoApi { get; set; }
        public string JsonParametros { get; set; }
        [StringLength(1000)]
        public string OpcionesMsjApi { get; set; }
        [StringLength(1000)]
        public string OpcionesApi { get; set; }
        public long EmpresaId { get; set; }
        [StringLength(30)]
        public string TipoRetorno { get; set; }
        public int RolId { get; set; }
        public List<Bots> Bots { get; set; }
    }
}
