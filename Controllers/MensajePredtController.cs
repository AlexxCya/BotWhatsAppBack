using BotWhatsApp.DTOs;
using BotWhatsApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BotWhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajePredtController : ControllerBase
    {
        private readonly IMensajePredetService _mensajePredetService;
        public MensajePredtController(IMensajePredetService mensajePredetService)
        {
            _mensajePredetService = mensajePredetService;
        }
        public IActionResult Get()
        {
            var result = _mensajePredetService.GetAll();
            return Ok(result);
        }
        [HttpGet("mensaje")]
        public IActionResult GeById(long id)
        {
            var result = _mensajePredetService.GetById(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(MensajePredtDTO mensaje)
        {
            await _mensajePredetService.Update(mensaje);
            return Ok();
        }
    }
}
