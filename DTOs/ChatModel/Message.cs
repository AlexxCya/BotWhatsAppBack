namespace BotWhatsApp.DTOs.ChatModel
{
    public class Message
    {
        public string id { get; set; }
        public string chatId { get; set; }
        public string contactId { get; set; }
        public string createdtAt { get; set; }
        public bool isMine { get; set; }
        public string value { get; set; }
    }
}
