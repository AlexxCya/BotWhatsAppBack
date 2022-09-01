using BotWhatsApp.DTOs;
using BotWhatsApp.Entities;
using BotWhatsApp.Interfaces;
using BotWhatsApp.Interfaces.ApiTest;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BotWhatsApp.Services.ApiTest
{
    public class PolizaService : IPolizaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PolizaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PolizaDTO GetByPoliza(string poliza)
        {
            Expression<Func<Poliza, bool>> expression = x => x.NumPoliza == poliza;
            var item = _unitOfWork.PolizaRepository.Find(expression).FirstOrDefault();

            PolizaDTO _poliza = new PolizaDTO();
            _poliza.Fin = item.Fin;
            _poliza.Vehiculo = item.Vehiculo;   
            _poliza.Nombre = item.Nombre;   
            _poliza.Inicio = item.Inicio;
            _poliza.Cobertura = item.Cobertura;
            _poliza.Costo = item.Costo;

            return _poliza;

        }
    }
}
