using BotWhatsApp.DTOs;
using BotWhatsApp.DTOs.ChatModel;
using BotWhatsApp.Entities;
using BotWhatsApp.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotWhatsApp.Utilities;

namespace BotWhatsApp.Services
{
    public class ConversacionesService : IConversacionesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBandejaService _bandejaService;
        public ConversacionesService(IUnitOfWork unitOfWork, IBandejaService bandejaService)
        {
            _unitOfWork = unitOfWork;
            _bandejaService = bandejaService;
        }
        public IEnumerable GetConversacionesByDestinatario(string Destinatario)
        {
            return _unitOfWork.ConversacionesRepository.GetAll().Where(x => x.Destinatario == Destinatario);
        }

        public async Task InsertConversaciones(ConversacionesDTO conversacionesDTO, string uri)
        {
            int maxOrder = 0;
            var lst = _unitOfWork.ConversacionesRepository.GetAll();
            //var maxOrder = _unitOfWork.ConversacionesRepository.GetAll().Where(x => x.Destinatario == conversacionesDTO.Destinatario).Max(x => x.Orden);
            if (lst.Count() > 0)
            {
                var conversaciones = lst.Where(x => x.Destinatario == conversacionesDTO.Destinatario);
                if (conversaciones.Count() > 0)
                    maxOrder = conversaciones.Max(x => x.Orden);
            }
            Conversaciones newItem = new Conversaciones();

            newItem.Destinatario = conversacionesDTO.Destinatario;
            newItem.Orden = maxOrder + 1;
            newItem.Mensaje = conversacionesDTO.Mensaje;
            newItem.Tipo = conversacionesDTO.Tipo;
            newItem.BandejaId = conversacionesDTO.BandejaId;
            if (!string.IsNullOrEmpty(uri))
                newItem.MediaUrl = uri;

            await _unitOfWork.ConversacionesRepository.Add(newItem);
            await _unitOfWork.SaveChangesAsync();

            if (conversacionesDTO.Tipo == "Asesor")
                await _bandejaService.UpdateBandeja(conversacionesDTO.Destinatario, true, 1);

            //    GetChat("");
            //}
            //else
            //{



            GetChat(conversacionesDTO.Destinatario, conversacionesDTO.RolId);


        }
        public Chat GetChat(string Destinatario, int RolId)
        {

            Chat chat = new Chat();
            List<Message> messages = new List<Message>();
            var _bandeja = _bandejaService.GetBandejaPorDestinatario(Destinatario, 1, RolId);

            if (_bandeja != null)
            {
                var lstMsgs = _unitOfWork.ConversacionesRepository.GetAll().Where(x => x.Destinatario == Destinatario);


                chat.conversation = Destinatario;
                chat.id = "chat-" + lstMsgs.FirstOrDefault().Destinatario + "-" + _bandeja.Id.ToString();
                chat.contactId = "Cliente";

                Contact contact = new Contact
                {
                    about = "Acerca del Asesor",
                    avatar = "assets/images/avatars/whatsapp.png",
                    id = "chat-" + lstMsgs.FirstOrDefault().Destinatario + "-" + _bandeja.Id.ToString(),
                    name = lstMsgs.FirstOrDefault().Destinatario
                };

                chat.contact = contact;

                if (_bandeja.Cerrada)
                    chat.muted = true;
                else
                    chat.muted = false;

                foreach (var msg in lstMsgs)
                {
                    var message = "";

                    if (msg.MediaUrl != null)
                        message = "<a mat-button href='" + msg.MediaUrl + "' target='_blank' >VER ARCHIVO </a>";
                    else
                        message = message = msg.Mensaje;

                    if (msg.Tipo == "Asesor")
                    {
                        //var _href = " <a mat-button href='https://botwhatsappfiles.blob.core.windows.net/images/2c1e16c2-bfc1-4e12-9233-0c7531ee9f81.jpg' target='_blank'> <mat-icon svgIcon='heroicons_outline:plus-circle'></mat-icon> </a> ";
                        //var _href = " <a mat-button href='https://botwhatsappfiles.blob.core.windows.net/images/2c1e16c2-bfc1-4e12-9233-0c7531ee9f81.jpg' target='_blank'> ARCHIVO</a> ";

                        messages.Add(new Message
                        {
                            createdtAt = msg.FechaCreacion.ToString(),
                            contactId = "Asesor",
                            chatId = "chat-" + msg.Destinatario + "-" + _bandeja.Id.ToString(),
                            id = msg.Id.ToString(),
                            value = message,
                            isMine = true

                        }
                                );
                    }
                    else
                    {
                        messages.Add(new Message
                        {
                            createdtAt = msg.FechaCreacion.ToString(),
                            contactId = "Cliente",
                            chatId = "chat-" + msg.Destinatario + "-" + _bandeja.Id.ToString(),
                            id = msg.Id.ToString(),
                            value = message,
                            isMine = false

                        }
                            );
                    }
                }

                chat.lastMessage = lstMsgs.LastOrDefault().Mensaje;
                chat.lastMessageAt = lstMsgs.LastOrDefault().FechaCreacion.ToString();
                chat.rolId = RolId;
                if (_bandeja.Visto)
                    chat.unreadCount = 0;
                else
                    chat.unreadCount = 1;


                var r = Pusher.GetChat(Destinatario, messages.LastOrDefault());

                var r2 = Pusher.SendChat(chat);
            }
            return chat;

        }
        public List<Chat> GetChats(string Destinatario, int RolId)
        {
            var lstDestinatarios = _unitOfWork.ConversacionesRepository.GetAll().GroupBy(x => x.Destinatario).ToList().Select(x => new { Destinatario = x.Key });

            List<Chat> chats = new List<Chat>();

            foreach (var item in lstDestinatarios)
            {
                
                //List<Message> messages = new List<Message>();
                var _bandeja = _bandejaService.GetBandejaPorDestinatario(item.Destinatario, 1, RolId);
                if (_bandeja != null)
                {
                    Chat chat = new Chat();
                    var lstMsgs = _unitOfWork.ConversacionesRepository.GetAll().Where(x => x.Destinatario == item.Destinatario && x.BandejaId == _bandeja.Id);

                    chat.conversation = item.Destinatario;
                    chat.id = "chat-" + lstMsgs.FirstOrDefault().Destinatario + "-" + _bandeja.Id.ToString();
                    chat.contactId = "Cliente";

                    Contact contact = new Contact
                    {
                        about = "Acerca del Asesor",
                        avatar = "assets/images/avatars/whatsapp.png",
                        id = "chat-" + lstMsgs.FirstOrDefault().Destinatario + "-" + _bandeja.Id.ToString(),
                        name = lstMsgs.FirstOrDefault().Destinatario
                    };

                    chat.contact = contact;

                    if (_bandeja.Cerrada)
                        chat.muted = true;
                    else
                        chat.muted = false;

                    //foreach (var msg in lstMsgs)
                    //{
                    //    var message = "";

                    //    if (msg.MediaUrl != null)
                    //        message = "<a mat-button href='" + msg.MediaUrl + "' target='_blank' >VER ARCHIVO </a>";
                    //    else
                    //        message = message = msg.Mensaje;

                    //    if (msg.Tipo == "Asesor")
                    //    {
                    //        //var _href = " <a mat-button href='https://botwhatsappfiles.blob.core.windows.net/images/2c1e16c2-bfc1-4e12-9233-0c7531ee9f81.jpg' target='_blank'> <mat-icon svgIcon='heroicons_outline:plus-circle'></mat-icon> </a> ";
                    //        //var _href = " <a mat-button href='https://botwhatsappfiles.blob.core.windows.net/images/2c1e16c2-bfc1-4e12-9233-0c7531ee9f81.jpg' target='_blank'> ARCHIVO</a> ";

                    //        messages.Add(new Message
                    //        {
                    //            createdtAt = msg.FechaCreacion.ToString(),
                    //            contactId = "Asesor",
                    //            chatId = "chat-" + msg.Destinatario + "-" + _bandeja.Id.ToString(),
                    //            id = msg.Id.ToString(),
                    //            value = message,
                    //            isMine = true

                    //        }
                    //                );
                    //    }
                    //    else
                    //    {
                    //        messages.Add(new Message
                    //        {
                    //            createdtAt = msg.FechaCreacion.ToString(),
                    //            contactId = "Cliente",
                    //            chatId = "chat-" + msg.Destinatario + "-" + _bandeja.Id.ToString(),
                    //            id = msg.Id.ToString(),
                    //            value = message,
                    //            isMine = false

                    //        }
                    //            );
                    //    }
                    //}
                    //chat.messages = messages;
                    chat.lastMessage = lstMsgs.LastOrDefault().Mensaje;
                    chat.lastMessageAt = lstMsgs.LastOrDefault().FechaCreacion.ToString();
                    chat.rolId = RolId;
                    if (_bandeja.Visto)
                        chat.unreadCount = 0;
                    else
                        chat.unreadCount = 1;

                    chats.Add(chat);
                }
               


                //if (Destinatario == item.Destinatario)
                //{
                //    var r = Pusher.GetChat(Destinatario, messages.LastOrDefault());
                //}

            }
         //   var r2 = Pusher.SendChat(chats);

            return chats;

        }
        public Chat GetChatByDestinatario(string Destinatario, int RolId)
        {
            Chat chat = new Chat();
            List<Message> messages = new List<Message>();
            var _bandeja = _bandejaService.GetBandejaPorDestinatario(Destinatario, 1, RolId);

            if (_bandeja != null)
            {
                var lstMsgs = _unitOfWork.ConversacionesRepository.GetAll().Where(x => x.Destinatario == Destinatario && x.BandejaId == _bandeja.Id);

                chat.conversation = Destinatario;
                chat.id = "chat-" + lstMsgs.FirstOrDefault().Destinatario + "-" + _bandeja.Id.ToString();
                chat.contactId = "Cliente";

                Contact contact = new Contact
                {
                    about = "Acerca del Asesor",
                    avatar = "assets/images/avatars/whatsapp.png",
                    id = "chat-" + lstMsgs.FirstOrDefault().Destinatario + "-" + _bandeja.Id.ToString(),
                    name = lstMsgs.FirstOrDefault().Destinatario
                };

                chat.contact = contact;

                if (_bandeja.Cerrada)
                    chat.muted = true;
                else
                    chat.muted = false;

                foreach (var msg in lstMsgs)
                {
                    var message = "";

                    if (msg.MediaUrl != null)
                        message = "<a mat-button href='" + msg.MediaUrl + "' target='_blank' >VER ARCHIVO </a>";
                    else
                        message = message = msg.Mensaje;

                    if (msg.Tipo == "Asesor")
                    {
                        //var _href = " <a mat-button href='https://botwhatsappfiles.blob.core.windows.net/images/2c1e16c2-bfc1-4e12-9233-0c7531ee9f81.jpg' target='_blank'> <mat-icon svgIcon='heroicons_outline:plus-circle'></mat-icon> </a> ";
                        //var _href = " <a mat-button href='https://botwhatsappfiles.blob.core.windows.net/images/2c1e16c2-bfc1-4e12-9233-0c7531ee9f81.jpg' target='_blank'> ARCHIVO</a> ";

                        messages.Add(new Message
                        {
                            createdtAt = msg.FechaCreacion.ToString(),
                            contactId = "Asesor",
                            chatId = "chat-" + msg.Destinatario + "-" + _bandeja.Id.ToString(),
                            id = msg.Id.ToString(),
                            value = message,
                            isMine = true

                        }
                                );
                    }
                    else
                    {
                        messages.Add(new Message
                        {
                            createdtAt = msg.FechaCreacion.ToString(),
                            contactId = "Cliente",
                            chatId = "chat-" + msg.Destinatario + "-" + _bandeja.Id.ToString(),
                            id = msg.Id.ToString(),
                            value = message,
                            isMine = false

                        }
                            );
                    }
                }
                chat.messages = messages;
                chat.lastMessage = lstMsgs.LastOrDefault().Mensaje;
                chat.lastMessageAt = lstMsgs.LastOrDefault().FechaCreacion.ToString();
                chat.rolId = RolId;

            }
            return chat;

        }
    }
}
