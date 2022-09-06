using BotWhatsApp.DTOs;
using BotWhatsApp.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotWhatsApp.Interfaces
{
    public interface IBandejaService
    {
        IEnumerable GetAll(long EmpresaId);
        BandejaDTO GetBandejaPorDestinatario(string Destinatario, long EmpresaId, int RolId);
        BandejaDTO GetBandejaAbiertaPorDestinatario(string Destinatario, long EmpresaId);
        Task InsertBandeja(Bandeja bandeja);
        Task UpdateBandeja(string Destinatario, bool visto, long EmpresaId);
        Task CerrarBandeja(long id);
    }
}
