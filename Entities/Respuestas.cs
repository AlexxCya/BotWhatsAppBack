namespace BotWhatsApp.Entities
{
    public partial class Respuestas : BaseEntity
    {
        public string Respuesta { get; set; }
        public int Prioridad { get; set; }
        public long IdPreguntaOpcion { get; set; }
    }
}
