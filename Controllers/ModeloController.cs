using BotWhatsApp.DTOs.ApiTest;
using BotWhatsApp.Interfaces.ApiTest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BotWhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;
        public ModeloController(IModeloService modeloService)
        {
            _modeloService= modeloService;
        }
        [HttpPost]
        public IActionResult Post(ParamDTO param)
        {
            var result = _modeloService.GetModelosPorAnio(param);
            return Ok(result);
        }
        [HttpPost("cotizar")]
        public IActionResult Cotizar(CotizacionDTO param)
        {
            var result = _modeloService.GetCotizacion(param);
            return Ok(result);
        }
    }
}
