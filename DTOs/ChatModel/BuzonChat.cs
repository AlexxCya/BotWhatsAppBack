namespace BotWhatsApp.DTOs.ChatModel
{
    public class BuzonChat
    {
        public string id { get; set; }
        public string contactId { get; set; }
        public int unreadCount { get; set; }
        public bool muted { get; set; }
        public string lastMessage { get; set; }
        public string lastMessageAt { get; set; }
    }
}
