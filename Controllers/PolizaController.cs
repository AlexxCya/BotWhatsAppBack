using BotWhatsApp.Interfaces.ApiTest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotWhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaService _polizaService;
        public PolizaController(IPolizaService polizaService)
        {
            _polizaService = polizaService;
        }
        [HttpGet]
        public IActionResult Get(string poliza)
        {
            var result = _polizaService.GetByPoliza(poliza);
            return Ok(result);
        }
    }
}
