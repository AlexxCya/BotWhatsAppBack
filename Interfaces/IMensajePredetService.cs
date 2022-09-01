using BotWhatsApp.DTOs;
using System.Collections;
using System.Threading.Tasks;

namespace BotWhatsApp.Interfaces
{
    public interface IMensajePredetService
    {
        IEnumerable GetAll();
        MensajePredtDTO GetById(long Id);
        MensajePredtDTO GetByNombre(string nombreMensaje);
        //Task Insert(MensajePredtDTO mensajePredt);
        Task Update(MensajePredtDTO mensajePredt);
    }
}
