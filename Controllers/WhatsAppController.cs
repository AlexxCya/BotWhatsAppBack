using BotWhatsApp.Interfaces;
using BotWhatsApp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace BotWhatsApp.Controllers
{
    [Route("api/whatsapp")]
    public class WhatsAppController : TwilioController
    {
        private readonly IRespuestasServices _respuestasServices;
        private readonly IFileAzureStorage _fileAzureStorage;
        public WhatsAppController(IRespuestasServices respuestasServices, IFileAzureStorage fileAzureStorage)
        {
            _respuestasServices = respuestasServices;
            _fileAzureStorage = fileAzureStorage;
        }
        //[HttpPost("message")]
        //public async Task<TwiMLResult> MessageAsync(SmsRequest input)
        //{

        //    var response = new MessagingResponse();
        //    string textUser = input.Body;
        //    var destinatario = input.From.Split('+')[1];
        //    var empresaWhatsApp = input.To.Split('+')[1];
        //    string textBot = await _respuestasServices.RespuestasBot(textUser, destinatario, empresaWhatsApp);

        //    if (textBot.ToLower() != "asesor")
        //    {
        //        response.Message(textBot);
        //        return TwiML(response);
        //    }
        //    return null;
        //}
        [HttpPost("message")]
        public async Task<TwiMLResult> MessageAsync(SmsRequest input)
        {
            var _numMedia = int.Parse(Request.Form["NumMedia"][0]);
            string uri = string.Empty;
            if (_numMedia > 0)
            {
                var extension = Request.Form["MediaContentType0"][0].Split('/')[1];
                var webClient = new WebClient();
                byte[] imageBytes = webClient.DownloadData(Request.Form["MediaUrl0"][0]);

                var stream = new MemoryStream(imageBytes);

                IFormFile file = new FormFile(stream, 0, stream.Length, "newImage", "newImage." + extension);

                uri = await _fileAzureStorage.Save("images", file);
            }


            var response = new MessagingResponse();
            string textUser = input.Body == null ? "Te ha Enviado un Archivo" : input.Body;
            var destinatario = input.From.Split('+')[1];
            var empresaWhatsApp = input.To.Split('+')[1];
            string textBot = await _respuestasServices.RespuestasBot(textUser, destinatario, empresaWhatsApp, uri);

            if (textBot.ToLower() != "asesor")
            {
                if (textBot.Contains("[FILE]"))
                {
                    SendMessage.SendMultimedia(destinatario, "", textBot.Split('#')[1]);
                }
                else
                {
                    response.Message(textBot);
                    return TwiML(response);
                }
            }
            return null;
        }
    }
}
