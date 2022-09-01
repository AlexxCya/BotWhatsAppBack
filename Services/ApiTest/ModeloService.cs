using BotWhatsApp.DTOs.ApiTest;
using BotWhatsApp.Entities;
using BotWhatsApp.Interfaces;
using BotWhatsApp.Interfaces.ApiTest;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace BotWhatsApp.Services.ApiTest
{
    public class ModeloService: IModeloService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModeloService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable GetModelosPorAnio(ParamDTO param)
        {
            Expression<Func<Modelo, bool>> expression = x => x.Anio == param.Anio;

            return _unitOfWork.ModeloRepository.Find(expression);
        }
        public CotizacionResponse GetCotizacion(CotizacionDTO param)
        {
            Expression<Func<Modelo, bool>> expression = x => x.Anio == param.Anio && x.NombreModelo == param.Modelo;

            CotizacionResponse response = new CotizacionResponse();
            response.Mensaje = "Esta es la Cotizacion de un " + param.Modelo + " " + param.Anio.ToString() + " con un precio de $";
            response.Costo = _unitOfWork.ModeloRepository.Find(expression).FirstOrDefault().Costo;

            return response;
        }
    }
}
