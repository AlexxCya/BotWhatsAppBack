using BotWhatsApp.DTOs.ApiTest;
using System.Collections;

namespace BotWhatsApp.Interfaces.ApiTest
{
    public interface IModeloService
    {
        IEnumerable GetModelosPorAnio(ParamDTO param);
        CotizacionResponse GetCotizacion(CotizacionDTO param);
    }
}
