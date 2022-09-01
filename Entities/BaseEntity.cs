using System;

namespace BotWhatsApp.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public string CreadoPor { get; set; } = "System";
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string ActualizadoPor { get; set; }
        public DateTime? FechaActualizaion { get; set; }
    }
}
