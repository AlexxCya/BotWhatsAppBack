using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotWhatsApp.DTOs;
using BotWhatsApp.DTOs.ChatModel;

namespace BotWhatsApp.Interfaces
{
    public interface IConversacionesService
    {
        IEnumerable GetConversacionesByDestinatario(string Destinatario);
        Task InsertConversaciones(ConversacionesDTO conersacionesDTO, string uri);
        Chat GetChat(string Destinatario, int RolId);
        List<Chat> GetChats(string Destinatario, int RolId);
        Chat GetChatByDestinatario(string Destinatario, int RolId);
    }
}
