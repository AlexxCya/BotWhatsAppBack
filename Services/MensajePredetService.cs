using BotWhatsApp.DTOs;
using BotWhatsApp.Entities;
using BotWhatsApp.Interfaces;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BotWhatsApp.Services
{
    public class MensajePredetService : IMensajePredetService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MensajePredetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable GetAll()
        {
            return _unitOfWork.MensajesPredeterminadoRepository.GetAll();
        }

        public MensajePredtDTO GetById(long Id)
        {
           var item = _unitOfWork.MensajesPredeterminadoRepository.GetById(Id);

            MensajePredtDTO mensaje = new MensajePredtDTO();
            mensaje.Mensaje = item.Result.Mensaje;
            mensaje.NombreMensaje = item.Result.NombreMensaje;

            return mensaje;
        }
        public MensajePredtDTO GetByNombre(string nombreMensaje)
        {
            Expression<Func<MensajesPredeterminado, bool>> expression = x => x.NombreMensaje == nombreMensaje;
            var item = _unitOfWork.MensajesPredeterminadoRepository.Find(expression).FirstOrDefault();


            MensajePredtDTO mensaje = new MensajePredtDTO();
            mensaje.Mensaje = item.Mensaje;
            mensaje.NombreMensaje = item.NombreMensaje;

            return mensaje;
        }


        //public Task Insert(MensajePredtDTO mensajePredt)
        //{
        //    MensajesPredeterminado newItem = new MensajesPredeterminado();
        //    //newItem.Id = botOpcion.Id;
        //    newItem.Titulo = botOpcion.Titulo;
        //    newItem.Opcion = botOpcion.Opcion;
        //    newItem.Mensaje = botOpcion.Mensaje;
        //    newItem.IdPadre = botOpcion.IdPadre;
        //    newItem.EmpresaId = 1;

        //    await _unitOfWork.BotOpcionesRepository.Add(newItem);
        //    await _unitOfWork.SaveChangesAsync();
        //}

        public async Task Update(MensajePredtDTO mensajePredt)
        {
            Expression<Func<MensajesPredeterminado, bool>> expression = x => x.Id == mensajePredt.Id;
            var _item = _unitOfWork.MensajesPredeterminadoRepository.Find(expression).FirstOrDefault();

            _item.Mensaje = mensajePredt.Mensaje;
            _item.ActualizadoPor = "User";
            _item.FechaActualizaion = DateTime.Now;

            _unitOfWork.MensajesPredeterminadoRepository.Update(_item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
