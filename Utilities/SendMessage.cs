using System;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace BotWhatsApp.Utilities
{
    public static class SendMessage
    {
        public static void SendMultimedia(string destinatario, string mensaje, string uri)
        {
            TwilioClient.Init("AC03a47af37178d8017645a8cf9ccb9d07", "c361f34bb75523d8b1d2306dd6f0efbe"); //test

            //TwilioClient.Init("AC2884ed3d73b7b474ec2567b55f69dffb", "e5879676508b7ba5c9b2cb5d0a1023c3");

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("whatsapp:+" + destinatario));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");// ESTE SERA FIJO test
            //messageOptions.From = new PhoneNumber("whatsapp:+5218141701660");// ESTE SERA FIJO
            messageOptions.Body = mensaje;
            if (!string.IsNullOrEmpty(uri))
            {
                var image = new[]{
                new Uri(uri) }.ToList();
                messageOptions.MediaUrl = image;
            }
            var message = MessageResource.Create(messageOptions);

        }
    }
}
