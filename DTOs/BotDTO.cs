namespace BotWhatsApp.DTOs
{
    public class BotDTO
    {
        public long Id { get; set; }
        public long BotOpcionesId { get; set; }
        public string ValoresApi { get; set; }
        public string ValoresSeleccionados { get; set; }
        public string TipoRetorno { get; set; }
        public int RolId { get; set; }

    }
}
