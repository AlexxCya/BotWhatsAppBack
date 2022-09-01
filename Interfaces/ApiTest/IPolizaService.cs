using BotWhatsApp.DTOs;
using System.Threading.Tasks;

namespace BotWhatsApp.Interfaces.ApiTest
{
    public interface IPolizaService
    {
        PolizaDTO GetByPoliza(string poliza);
    }
}
