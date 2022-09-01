using BotWhatsApp.DTOs;
using BotWhatsApp.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotWhatsApp.Interfaces
{
    public interface IBotOpcionesService
    {
        IEnumerable GetAll();
        Task<BotOpciones> GetById(long Id);
        IEnumerable GetMensaje(int id);
        IEnumerable GetOpciones(int idPadre);
        List<string> GetOpcionesById(long id);
        Task InsertBotOpcion(BotOpcionesDTO botOpcion);
        Task UpdateBotOpcion(BotOpcionesDTO botOpcion);
        Task UpdateBotOpcionDisable();
        Task UpdateBotOpcionEnable(int Id);
        long GetOpcionEnable();
    }
}
