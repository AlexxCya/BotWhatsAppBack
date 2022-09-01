using BotWhatsApp.DTOs;
using BotWhatsApp.Entities;
using System.Threading.Tasks;

namespace BotWhatsApp.Interfaces
{
    public interface IBotService
    {
        Task InsertBot(string Destinatario, long BotOpcionId);
        Task UpdateBot(string Destinatario, long BotOpcionId, long EmpresaId, string valoresApi, string valoresSeleccionados);
        Task<BotDTO> BotActive(string Destinatario, long EmpresaId);
    }
}
