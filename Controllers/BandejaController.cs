using BotWhatsApp.DTOs;
using BotWhatsApp.Interfaces;
using BotWhatsApp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BotWhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandejaController : ControllerBase
    {
        private readonly IBandejaService _bandejaService;
        private readonly IMensajePredetService _mensajePredetService;
        private readonly IConversacionesService _conversacionesService;
        public BandejaController(IBandejaService bandejaService, IMensajePredetService mensajePredetService, IConversacionesService conversacionesService)
        {
            _bandejaService = bandejaService;
            _mensajePredetService = mensajePredetService;
            _conversacionesService = conversacionesService;
        }
        [HttpGet]
        public IActionResult Get(long EmpresaId)
        {
            var result = _bandejaService.GetAll(EmpresaId);
            return Ok(result);
        }
        //[HttpGet]
        //public IActionResult GetByDestinatario(string Destinatario)
        //{
        //    var result =_bandejaService.GetBandejaPorDestinatario(Destinatario);
        //    return Ok(result);
        //}
        [HttpPost]
        public async Task<IActionResult> Post(BandejaDTO bandeja)
        {
            await _bandejaService.CerrarBandeja(bandeja.Id);
            _conversacionesService.GetChat(bandeja.Destinatario);
            var msg = _mensajePredetService.GetByNombre("Fin de Conversacion").Mensaje;
            SendMessage.SendMultimedia(bandeja.Destinatario, msg, string.Empty);
            return Ok();
        }

    }
}
