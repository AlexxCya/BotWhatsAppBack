using BotWhatsApp.Data;
using BotWhatsApp.DTOs;
using BotWhatsApp.Entities;
using BotWhatsApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BotWhatsApp.Services
{
    public class BotService: IBotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBotOpcionesService _botOpcionesService;
        public BotService(IUnitOfWork unitOfWork, IBotOpcionesService botOpcionesService)
        {
            _unitOfWork = unitOfWork;
            _botOpcionesService = botOpcionesService;   
        }
        public async Task InsertBot(string Destinatario, long BotOpcionId)
        {
            Bots newItem = new Bots();
            //newItem.Id = botOpcion.Id;
            newItem.Destinatario = Destinatario;
            newItem.BotOpcionesId = BotOpcionId;


            await _unitOfWork.BotsRepository.Add(newItem);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateBot(string Destinatario, long BotOpcionId, long EmpresaId, string valoresApi, string valoresSeleccionados)
        {
           
            Expression<Func<Bots, bool>> expression = x => x.Destinatario == Destinatario;
            var _lst = _unitOfWork.BotsRepository.Find(expression);


            if (_lst.Count() == 1)
            {
                var bot = _lst.First();
                bot.BotOpcionesId = BotOpcionId;
                bot.ValoresApi = valoresApi;
                bot.ValoresSeleccionados = valoresSeleccionados;
                bot.ActualizadoPor = "User";
                bot.FechaActualizaion = DateTime.Now;

                _unitOfWork.BotsRepository.Update(bot);
            }
            else
            {
                foreach(var bot in _lst)
                {
                    var botOpc = await _botOpcionesService.GetById(bot.Id);

                    if(botOpc.EmpresaId == EmpresaId)
                    {
                        bot.BotOpcionesId = BotOpcionId;
                        bot.ActualizadoPor = "User";
                        bot.FechaActualizaion = DateTime.Now;

                        _unitOfWork.BotsRepository.Update(bot);
                    }

                }
            }


           
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<BotDTO> BotActive(string Destinatario, long EmpresaId)
        {

            Expression<Func<Bots, bool>> expression = x => x.Destinatario == Destinatario;
            var _lst = _unitOfWork.BotsRepository.Find(expression);
            Bots bots = new Bots();
            string retorno = string.Empty;
            int rolId = 1;

            if (_lst.Count() == 1)
            {
                bots = _lst.First();

                var botOpc = await _botOpcionesService.GetById(bots.BotOpcionesId);
                retorno = botOpc.TipoRetorno;
                rolId = botOpc.RolId;
                
            }
            else
            {
                foreach (var bot in _lst)
                {
                    var botOpc = await _botOpcionesService.GetById(bot.Id);
                   
                    if (botOpc.EmpresaId == EmpresaId)
                    {
                        bots = bot;
                        retorno = botOpc.TipoRetorno;
                        rolId = botOpc.RolId;
                    }

                }
            }


            if(bots.Id == 0)
                return null;
            else
            {
                BotDTO botDTO = new BotDTO();   
                botDTO.Id = bots.Id;
                botDTO.ValoresSeleccionados = bots.ValoresSeleccionados;
                botDTO.ValoresApi = bots.ValoresApi;
                botDTO.BotOpcionesId = bots.BotOpcionesId;
                botDTO.TipoRetorno = retorno;
                botDTO.RolId = rolId;

                return botDTO;

            }
         
        }
    }
}
