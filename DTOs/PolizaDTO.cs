using System;

namespace BotWhatsApp.DTOs
{
    public class PolizaDTO
    {
        public string Nombre { get; set; }
        public string Vehiculo { get; set; }
        public string Cobertura { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public decimal Costo { get; set; }
    }
}
