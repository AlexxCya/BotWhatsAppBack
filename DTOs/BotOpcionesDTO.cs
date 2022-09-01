namespace BotWhatsApp.DTOs
{
    public class BotOpcionesDTO
    {
        public long Id { get; set; }
        public string Mensaje { get; set; }
        public int IdPadre { get; set; }
        public bool Opcion { get; set; }
        public string Titulo { get; set; }
        public bool ConApi { get; set; } = false;
        public string UrlApi { get; set; }
        public string MetodoApi { get; set; }
        public string JsonParametros { get; set; }
        public string OpcionesMsjApi { get; set; }
        public string OpcionesApi { get; set; }
        public string TipoRetorno { get; set; }
    }
}
