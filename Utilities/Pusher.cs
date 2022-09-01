using BotWhatsApp.DTOs.ChatModel;
using Newtonsoft.Json;
using PusherServer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotWhatsApp.Utilities
{
    public static class Pusher
    {
        public static async Task<string> SendChat(Chat chat)
        {
            var options = new PusherOptions
            {
                Cluster = "us2",
                Encrypted = true
            };

            var pusher = new PusherServer.Pusher(
              "1468004",
              "287874660f17f5c20e70",
              "3dc0f60621971415b046",
              options);

            var json = JsonConvert.SerializeObject(chat);

            //var test = "[ *contact*:{ *name*: *Alex*, *apellido*:*Jonguitud*} ]";

            //var test = "[ 'contact':{ 'name': 'Alex', 'apellido':'Jonguitud'} ]";

            //var test = "[ {'contact':{ 'name': 'Alex', 'apellido':'Jonguitud'}, 'contactId':98 }, {'contact':{ 'name': 'Cynthia', 'apellido':'Jonguitud'}, 'contactId':99 } ]";
            //var test = "[{'contact': {'about': 'Acerca del Asesor','avatar': 'assets/images/avatars/whatsapp.png','id': 'chat-5217822092231 - 20 - False','name': '5217822092231'		},		'contactId': 'Cliente',		'id': 'chat - 5217822092231 - 20 - False',		'lastMessage': 'Uuyh',		'lastMessageAt': '8 / 25 / 2022 4:04:01 PM',		'muted': false,		'unreadCount': 1	},	{		'contact': {'about': 'Acerca del Asesor','avatar': 'assets / images / avatars / whatsapp.png','id': 'chat - 5218184771483 - 16 - False','name': '5218184771483'		},		'contactId': 'Cliente',		'id': 'chat - 5218184771483 - 16 - False',		'lastMessage': 'Hola',		'lastMessageAt': '8 / 4 / 2022 3:17:37 AM',		'muted': false,		'unreadCount': 1	},	{		'contact': {'about': 'Acerca del Asesor','avatar': 'assets / images / avatars / whatsapp.png','id': 'chat - 5218117499423 - 14 - False','name': '5218117499423'		},		'contactId': 'Cliente',		'id': 'chat - 5218117499423 - 14 - False',		'lastMessage': 'Haz Enviado un Archivo',		'lastMessageAt': '7 / 26 / 2022 11:20:21 PM',		'muted': false,		'unreadCount': 0	},	{		'contact': {'about': 'Acerca del Asesor','avatar': 'assets / images / avatars / whatsapp.png','id': 'chat - 5217821458711 - 18 - True','name': '5217821458711'		},		'contactId': 'Cliente',		'id': 'chat - 5217821458711 - 18 - True',		'lastMessage': 'Te ha Enviado un Archivo',		'lastMessageAt': '8 / 24 / 2022 4:24:34 PM',		'muted': false,		'unreadCount': 1	}]";

            var result = await pusher.TriggerAsync(
              "BotChat",
              "getChats",
               new
               {
                   message = json
               });

            return result.ToString();
        }
        //public static async Task<string> SendChat(List<Chat> chats)
        //{
        //    var options = new PusherOptions
        //    {
        //        Cluster = "us2",
        //        Encrypted = true
        //    };

        //    var pusher = new PusherServer.Pusher(
        //      "1468004",
        //      "287874660f17f5c20e70",
        //      "3dc0f60621971415b046",
        //      options);

        //    var json = JsonConvert.SerializeObject(chats);

        //    //var test = "[ *contact*:{ *name*: *Alex*, *apellido*:*Jonguitud*} ]";

        //    //var test = "[ 'contact':{ 'name': 'Alex', 'apellido':'Jonguitud'} ]";

        //    //var test = "[ {'contact':{ 'name': 'Alex', 'apellido':'Jonguitud'}, 'contactId':98 }, {'contact':{ 'name': 'Cynthia', 'apellido':'Jonguitud'}, 'contactId':99 } ]";
        //    //var test = "[{'contact': {'about': 'Acerca del Asesor','avatar': 'assets/images/avatars/whatsapp.png','id': 'chat-5217822092231 - 20 - False','name': '5217822092231'		},		'contactId': 'Cliente',		'id': 'chat - 5217822092231 - 20 - False',		'lastMessage': 'Uuyh',		'lastMessageAt': '8 / 25 / 2022 4:04:01 PM',		'muted': false,		'unreadCount': 1	},	{		'contact': {'about': 'Acerca del Asesor','avatar': 'assets / images / avatars / whatsapp.png','id': 'chat - 5218184771483 - 16 - False','name': '5218184771483'		},		'contactId': 'Cliente',		'id': 'chat - 5218184771483 - 16 - False',		'lastMessage': 'Hola',		'lastMessageAt': '8 / 4 / 2022 3:17:37 AM',		'muted': false,		'unreadCount': 1	},	{		'contact': {'about': 'Acerca del Asesor','avatar': 'assets / images / avatars / whatsapp.png','id': 'chat - 5218117499423 - 14 - False','name': '5218117499423'		},		'contactId': 'Cliente',		'id': 'chat - 5218117499423 - 14 - False',		'lastMessage': 'Haz Enviado un Archivo',		'lastMessageAt': '7 / 26 / 2022 11:20:21 PM',		'muted': false,		'unreadCount': 0	},	{		'contact': {'about': 'Acerca del Asesor','avatar': 'assets / images / avatars / whatsapp.png','id': 'chat - 5217821458711 - 18 - True','name': '5217821458711'		},		'contactId': 'Cliente',		'id': 'chat - 5217821458711 - 18 - True',		'lastMessage': 'Te ha Enviado un Archivo',		'lastMessageAt': '8 / 24 / 2022 4:24:34 PM',		'muted': false,		'unreadCount': 1	}]";

        //    var result = await pusher.TriggerAsync(
        //      "BotChat",
        //      "getChats",
        //       new
        //       {
        //           message = json
        //       });

        //    return result.ToString();   
        //}

        public static async Task<string> GetChat(string destinatario,Message message)
        {
            var options = new PusherOptions
            {
                Cluster = "us2",
                Encrypted = true
            };

            var pusher = new PusherServer.Pusher(
              "1468004",
              "287874660f17f5c20e70",
              "3dc0f60621971415b046",
              options);

            var json = JsonConvert.SerializeObject(message);

            //var test = "[{	'id': '69',	'chatId': 'chat-5217821458711-18-True',	'contactId': 'Cliente',	'createdtAt': '8/24/2022 4:21:56 PM',	'isMine': false,	'value': 'Solicito hablar con un Asesor'},{	'id': '70',	'chatId': 'chat-5217821458711-18-True',	'contactId': 'Asesor',	'createdtAt': '8/24/2022 4:22:48 PM',	'isMine': true,	'value': 'se envio la imagen Alejandro_Jonguitud Del Angel_CV_2022.pdf'},{	'id': '71',	'chatId': 'chat-5217821458711-18-True',	'contactId': 'Asesor',	'createdtAt': '8/24/2022 4:23:08 PM',	'isMine': true,	'value': 'Haz Enviado un Archivo'},{	'id': '72',	'chatId': 'chat-5217821458711-18-True',	'contactId': 'Cliente',	'createdtAt': '8/24/2022 4:23:32 PM',	'isMine': false,	'value': 'Una mamada'},{	'id': '73',	'chatId': 'chat-5217821458711-18-True',	'contactId': 'Cliente',	'createdtAt': '8/24/2022 4:24:34 PM',	'isMine': false,	'value': 'Te ha Enviado un Archivo'}		]";

            //var test = "[{'id':'1','chatId':'chat - 5217822092231 - 20 - False','contactId':'Cliente','createdtAt':'7 / 11 / 2022 11:46:49 PM','isMine':false,'value':'Solicito hablar con un Asesor'},{'id':'2','chatId':'chat - 5217822092231 - 20 - False','contactId':'Asesor','createdtAt':'7 / 11 / 2022 11:47:21 PM','isMine':true,'value':'hola que necesitas'},{'id':'3','chatId':'chat - 5217822092231 - 20 - False','contactId':'Cliente','createdtAt':'7 / 11 / 2022 11:47:36 PM','isMine':false,'value':'Unas dudas'},{'id':'4','chatId':'chat - 5217822092231 - 20 - False','contactId':'Asesor','createdtAt':'7 / 11 / 2022 11:47:51 PM','isMine':true,'value':' < a mat-button href='https://botwhatsappfiles.blob.core.windows.net/images/dfbae0b8-0079-4d0c-ade1-76c4bbde8496.jpg' target= '_blank' > VER ARCHIVO </a> '}]";

            var result = await pusher.TriggerAsync(
              "BotChat",
              "getChat",
               new
               {
                   id = destinatario,
                   message = json
               });

            return result.ToString();
        }
    }
}
