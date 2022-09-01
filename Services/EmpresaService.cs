using BotWhatsApp.Entities;
using BotWhatsApp.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BotWhatsApp.Services
{
    public class EmpresaService: IEmpresaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmpresaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public long GetEmpresaByWhatsApp(string NumeroWhatsapp)
        {
            Expression<Func<Empresa, bool>> expression = x => x.NumeroWhatsapp == NumeroWhatsapp;
            //List<BotOpcionesDTO> dTOLst = new List<BotOpcionesDTO>();

            return _unitOfWork.EmpresaRepository.Find(expression).FirstOrDefault().Id;

        }
    }
}

