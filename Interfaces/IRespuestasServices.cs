using BotWhatsApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotWhatsApp.Interfaces
{
    public interface IRespuestasServices
    {
        //string RespuestasPorPregunta(string preguntaOpcion, string numero);
        //Task<string> RespuestasBot2(string preguntaOpcion, string numero, string empresaWhatsApp, string mediaUri);
        Task<string> RespuestasBot(string preguntaOpcion, string numero, string empresaWhatsApp, string mediaUri);
    }
}
