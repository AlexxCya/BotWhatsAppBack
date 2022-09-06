using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace BotWhatsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : TwilioController
    {
        [HttpPost("message")]
        public ActionResult Message(string From, string Body)
        {
            var twiml = new MessagingResponse();
            twiml.Message($"Hello {From}. You said {Body}");
            return Ok();
        }
    }
}
