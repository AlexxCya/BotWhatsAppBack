using BotWhatsApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
//using Newtonsoft.Json.Converters;
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json.
using System.Dynamic;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Converters;

namespace BotWhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestasController : ControllerBase
    {
        private readonly IRespuestasServices _respuestasServices;
        public RespuestasController(IRespuestasServices respuestasServices)
        {
            _respuestasServices = respuestasServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string preguntaOpcion, string destinatario, string empresaWhatsApp)
        {
            //List<ExpandoObject>

            var x = JsonSerializer.Deserialize<List<ExpandoObject>>(@"[{""name"":""Alex"", ""apellido"":""Jonguitud""},{""name"":""Cynthia"", ""apellido"":""Sanchez""}]");
            foreach (var item in x)
            {
                IDictionary<string, object> propertyValues = item;

                foreach (var property in propertyValues.Keys)
                {
                    var rult = String.Format("{0} : {1}", property, propertyValues[property]);
                }
            }
            //var x = jsonS JsonConverter.DeserializeObject<List<ExpandoObject>>("", new ExpandoObjectConverter());
            //SendMultimedia();
            var result = await _respuestasServices.RespuestasBot(preguntaOpcion, destinatario, empresaWhatsApp, string.Empty);
            return Ok(result);
        }
        private void SendMultimedia()
        {
            TwilioClient.Init("AC03a47af37178d8017645a8cf9ccb9d07", "c361f34bb75523d8b1d2306dd6f0efbe");

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("whatsapp:+5217822092231"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");// ESTE SERA FIJO
            //var unicodeString = char.ConvertFromUtf32(0x1F4DE);
            messageOptions.Body = " Ya esta lo de enviar Imagenes desde el Bot" ;
            var image = new[]{
                //new Uri("https://botwhatsappfiles.blob.core.windows.net/images/aa9a02ef-1878-428a-8a3b-844b215af58a.jpeg")
                new Uri("https://botwhatsappfiles.blob.core.windows.net/images/dfbae0b8-0079-4d0c-ade1-76c4bbde8496.jpeg")
                //new Uri("C:\\Users\\alexb\\Downloads\\test.jpg")
            }.ToList();
            messageOptions.MediaUrl = image;

            var message = MessageResource.Create(messageOptions);

        }
        //private void Send()
        //{
        //    TwilioClient.Init("AC03a47af37178d8017645a8cf9ccb9d07", "c361f34bb75523d8b1d2306dd6f0efbe");

        //    var message = MessageResource.Create(
        //        body: "Hola este es un msj automatico....",
        //        from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
        //        to: new Twilio.Types.PhoneNumber("whatsapp:+5217822092231"));

        //   var res =  message.Sid;
        //}
    }
}
