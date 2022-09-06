using System.Collections.Generic;

namespace BotWhatsApp.DTOs.ChatModel
{
    public class Chat
    {
        public string conversation { get; set; }
        public Contact contact { get; set; }
        public string contactId { get; set; }
        public string id { get; set; }
        public string lastMessage { get; set; }
        public string lastMessageAt { get; set; }
        public List<Message> messages { get; set; }
        public bool muted { get; set; }
        public int unreadCount { get; set; }
        public int rolId { get; set; }
    }
}
