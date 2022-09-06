using BotWhatsApp.DTOs;
using BotWhatsApp.Entities;
using BotWhatsApp.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BotWhatsApp.Services
{
    public class BandejaService : IBandejaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BandejaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable GetAll(long EmpresaId)
        {
            Expression<Func<Bandeja, bool>> expression = x => x.EmpresaId == EmpresaId && x.Cerrada == false;

            return _unitOfWork.BandejaRepository.Find(expression);
        }

        public BandejaDTO GetBandejaPorDestinatario(string Destinatario, long EmpresaId, int RolId)
        {
            Expression<Func<Bandeja, bool>> expression = x => x.Destinatario == Destinatario && x.EmpresaId == EmpresaId && x.RolId == RolId;
            BandejaDTO dTO = new BandejaDTO();

            var _item = _unitOfWork.BandejaRepository.Find(expression).LastOrDefault();

            if (_item != null)
            {
                dTO.Id = _item.Id;
                dTO.Destinatario = _item.Destinatario;
                dTO.Asesor = _item.Asesor;
                dTO.Visto = _item.Visto;
                dTO.Cerrada = _item.Cerrada;

                return dTO;
            }
            else
                return null;
            
        }
        public BandejaDTO GetBandejaAbiertaPorDestinatario(string Destinatario, long EmpresaId)
        {
            Expression<Func<Bandeja, bool>> expression = x => x.Destinatario == Destinatario && x.EmpresaId == EmpresaId && x.Cerrada == false;
            BandejaDTO dTO = new BandejaDTO();

            var _item = _unitOfWork.BandejaRepository.Find(expression).LastOrDefault();

            if (_item != null)
            {
                dTO.Id = _item.Id;
                dTO.Destinatario = _item.Destinatario;
                dTO.Asesor = _item.Asesor;
                dTO.Visto = _item.Visto;
                dTO.Cerrada = _item.Cerrada;

                return dTO;
            }
            else
                return null;

        }

        public async Task InsertBandeja(Bandeja bandeja)
        {
            await _unitOfWork.BandejaRepository.Add(bandeja);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateBandeja(string Destinatario, bool visto, long EmpresaId)
        {
            Expression<Func<Bandeja, bool>> expression = x => x.Destinatario == Destinatario && x.EmpresaId == EmpresaId;
            var _item = _unitOfWork.BandejaRepository.Find(expression).LastOrDefault();

            //Bandeja item = new Bandeja();
            _item.Visto = visto;
            //item.Id = _item.Id;
            //item.Destinatario = Destinatario;
            //item.Asesor = _item.Asesor;

            _unitOfWork.BandejaRepository.Update(_item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task CerrarBandeja(long id)
        {
            Expression<Func<Bandeja, bool>> expression = x => x.Id == id;
            var _item = _unitOfWork.BandejaRepository.Find(expression).FirstOrDefault();

            _item.Cerrada = true;

            _unitOfWork.BandejaRepository.Update(_item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
