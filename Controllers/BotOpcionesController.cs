using BotWhatsApp.DTOs;
using BotWhatsApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BotWhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotOpcionesController : ControllerBase
    {
        private readonly IBotOpcionesService _botOpcionesService;
        public BotOpcionesController(IBotOpcionesService botOpcionesService)
        {
            _botOpcionesService = botOpcionesService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _botOpcionesService.GetAll();
            return Ok(result);
        }
        [HttpGet("mensaje")]
        public IActionResult GetMensaje(int id)
        {
            var result = _botOpcionesService.GetMensaje(id);
            return Ok(result);
        }
        [HttpGet("opciones")]
        public IActionResult GetOpciones(int idPadre)
        {
            var result = _botOpcionesService.GetOpciones(idPadre);
            return Ok(result);
        }
        [HttpGet("opcionesById")]
        public IActionResult GetOpcionesById(long id)
        {
            var result = _botOpcionesService.GetOpcionesById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(BotOpcionesDTO botOpcion)
        {
            await _botOpcionesService.InsertBotOpcion(botOpcion);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(BotOpcionesDTO botOpcion)
        {
            await _botOpcionesService.UpdateBotOpcion(botOpcion);
            return Ok();
        }
    }
}
