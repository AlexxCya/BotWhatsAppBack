using BotWhatsApp.DTOs;
using BotWhatsApp.Interfaces;
using BotWhatsApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace BotWhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversacionesController : ControllerBase
    {
        private readonly IConversacionesService _conversacionesService;
        private readonly IFileAzureStorage _fileAzureStorage;

        public ConversacionesController(IConversacionesService conversacionesService, IFileAzureStorage fileAzureStorage)
        {
            _conversacionesService = conversacionesService;
            _fileAzureStorage = fileAzureStorage;   
        }
        [HttpGet]
        public IActionResult Get(string Destinatario)
        {
            var result = _conversacionesService.GetConversacionesByDestinatario(Destinatario);
            return Ok(result);
        }
        //[HttpPost]
        //public async Task<IActionResult> Conversacion(ConversacionesDTO conversacionesDTO)
        //{
        //    // ESTE METODO SOLO LO CONSUMIRA EL ASESOR
        //    await _conversacionesService.InsertConversaciones(conversacionesDTO);
        //    Send(conversacionesDTO.Destinatario, conversacionesDTO.Mensaje);
        //    return Ok(conversacionesDTO);

        //}
        [HttpGet("chat")]
        public IActionResult GetChats()
        {
            var result = _conversacionesService.GetChats("");
            return Ok(result);
        }
        [HttpGet("chatById")]
        public IActionResult GetChatById(string id)
        { 
            var destinatario = id.Split('-')[1];
            var result = _conversacionesService.GetChatByDestinatario(destinatario);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Conversacion([FromForm] ConversacionesDTO conversacionesDTO)
        {
            string uri = string.Empty;
            if (conversacionesDTO.Imagen != null)
            {
               uri = await _fileAzureStorage.Save("images", conversacionesDTO.Imagen);
            }
            // ESTE METODO SOLO LO CONSUMIRA EL ASESOR
            await _conversacionesService.InsertConversaciones(conversacionesDTO, uri);
            SendMessage.SendMultimedia(conversacionesDTO.Destinatario, conversacionesDTO.Mensaje, uri);
            return Ok(conversacionesDTO);

        }
        //private void Send(string numero, string mensaje)
        //{
        //    TwilioClient.Init("AC03a47af37178d8017645a8cf9ccb9d07", "c361f34bb75523d8b1d2306dd6f0efbe");

        //    var message = MessageResource.Create(
        //        body: mensaje,
        //        from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
        //        to: new Twilio.Types.PhoneNumber("whatsapp:+" + numero));

        //    var res = message.Sid;
        //}
        //private void SendMultimedia(string destinatario, string mensaje, string uri)
        //{
        //    TwilioClient.Init("AC03a47af37178d8017645a8cf9ccb9d07", "c361f34bb75523d8b1d2306dd6f0efbe");

        //    var messageOptions = new CreateMessageOptions(
        //        new PhoneNumber("whatsapp:+" + destinatario));
        //    messageOptions.From = new PhoneNumber("whatsapp:+14155238886");// ESTE SERA FIJO
        //    messageOptions.Body = mensaje;
        //    if (!string.IsNullOrEmpty(uri))
        //    {
        //        var image = new[]{
        //        new Uri(uri) }.ToList();
        //        messageOptions.MediaUrl = image;
        //    }
        //    var message = MessageResource.Create(messageOptions);

        //}
    }
}
