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
    public class BotOpcionesService : IBotOpcionesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BotOpcionesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable GetAll()
        {
            return _unitOfWork.BotOpcionesRepository.GetAll();
        }
        public Task<BotOpciones> GetById(long Id)
        {
            return _unitOfWork.BotOpcionesRepository.GetById(Id);
        }
        public IEnumerable GetMensaje(int id)
        {
            Expression<Func<BotOpciones, bool>> expression = x => x.Id == id;
            List<BotOpcionesDTO> dTOLst = new List<BotOpcionesDTO>();

            var _lst = _unitOfWork.BotOpcionesRepository.Find(expression);

            foreach (var item in _lst)
            {
                BotOpcionesDTO itemDTO = new BotOpcionesDTO();
                itemDTO.Id = item.Id;
                itemDTO.Titulo = item.Titulo;
                itemDTO.Opcion = item.Opcion;
                itemDTO.Mensaje = item.Mensaje;
                itemDTO.IdPadre = item.IdPadre;
                itemDTO.ConApi = item.ConApi;
                itemDTO.UrlApi = item.UrlApi;
                itemDTO.MetodoApi = item.MetodoApi;
                itemDTO.OpcionesApi = item.OpcionesApi;
                itemDTO.OpcionesMsjApi = item.OpcionesMsjApi;
                itemDTO.JsonParametros = item.JsonParametros;
                itemDTO.TipoRetorno = item.TipoRetorno;
                itemDTO.RolId = item.RolId;

                dTOLst.Add(itemDTO);
            }

            return dTOLst;
        }
        public IEnumerable GetOpciones(int idPadre)
        {
            Expression<Func<BotOpciones, bool>> expression = x => x.IdPadre == idPadre;
            List<BotOpcionesDTO> dTOLst = new List<BotOpcionesDTO>();

            var _lst = _unitOfWork.BotOpcionesRepository.Find(expression);

            foreach(var item in _lst)
            {
                BotOpcionesDTO itemDTO = new BotOpcionesDTO();
                itemDTO.Id = item.Id;
                itemDTO.Titulo = item.Titulo;
                itemDTO.Opcion = item.Opcion;
                itemDTO.Mensaje = item.Mensaje;
                itemDTO.IdPadre = item.IdPadre;
                itemDTO.ConApi = item.ConApi;
                itemDTO.UrlApi = item.UrlApi;
                itemDTO.MetodoApi = item.MetodoApi;
                itemDTO.OpcionesApi = item.OpcionesApi;
                itemDTO.OpcionesMsjApi = item.OpcionesMsjApi;
                itemDTO.JsonParametros = item.JsonParametros;
                itemDTO.TipoRetorno = item.TipoRetorno;
                itemDTO.RolId = item.RolId;

                dTOLst.Add(itemDTO);
            }

            return dTOLst;
        }
        public List<string> GetOpcionesById(long id)
        {
            List<string> lst = new List<string>();
            bool buscar = true;
            long _id = id;
            List<BotOpcionesDTO> dTOLst = new List<BotOpcionesDTO>();
            lst.Add("Valor Bot");

            do
            {
                Expression<Func<BotOpciones, bool>> expression = x => x.Id == _id;
                
                var _item = _unitOfWork.BotOpcionesRepository.Find(expression).FirstOrDefault();
                
                if(_item.IdPadre <= 1)
                    buscar = false;
                else
                {
                    _id = _item.IdPadre;

                    if (_item.ConApi)
                    {
                        if (!string.IsNullOrEmpty(_item.OpcionesApi))
                            lst.Add(_item.Id.ToString() + "-[" + _item.OpcionesApi + "]");
                    }
                    if(!string.IsNullOrEmpty(_item.Titulo))
                        lst.Add(_item.Titulo.Split('-')[1]);
                }

            }
            while (buscar);
           
            
            return lst;
        }
        public async Task InsertBotOpcion(BotOpcionesDTO botOpcion)
        {
            BotOpciones newItem = new BotOpciones();    
            //newItem.Id = botOpcion.Id;
            newItem.Titulo = botOpcion.Titulo;
            newItem.Opcion = botOpcion.Opcion;
            newItem.Mensaje=botOpcion.Mensaje;
            newItem.IdPadre = botOpcion.IdPadre;
            newItem.EmpresaId = 1;
            newItem.TipoRetorno = botOpcion.TipoRetorno;
            newItem.RolId = botOpcion.RolId;
            if(botOpcion.ConApi)
            {
                newItem.UrlApi = botOpcion.UrlApi;
                newItem.JsonParametros = botOpcion.JsonParametros;
                newItem.MetodoApi = botOpcion.MetodoApi;
                newItem.OpcionesMsjApi = botOpcion.OpcionesMsjApi;
                newItem.OpcionesApi = botOpcion.OpcionesApi;
            }
            newItem.ConApi = botOpcion.ConApi;

            await _unitOfWork.BotOpcionesRepository.Add(newItem);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateBotOpcion(BotOpcionesDTO botOpcion)
        {
            Expression<Func<BotOpciones, bool>> expression = x => x.Id == botOpcion.Id;
            var _item = _unitOfWork.BotOpcionesRepository.Find(expression).FirstOrDefault();

            _item.Mensaje = botOpcion.Mensaje;
            _item.Titulo = botOpcion.Titulo;
            _item.TipoRetorno = botOpcion.TipoRetorno;
            _item.ActualizadoPor = "User";
            _item.FechaActualizaion = DateTime.Now;
            _item.RolId = botOpcion.RolId;
            if (botOpcion.ConApi)
            {
                _item.UrlApi = botOpcion.UrlApi;
                _item.JsonParametros = botOpcion.JsonParametros;
                _item.MetodoApi = botOpcion.MetodoApi;
                _item.OpcionesMsjApi = botOpcion.OpcionesMsjApi;
                _item.OpcionesApi = botOpcion.OpcionesApi;
            }
            _item.ConApi = botOpcion.ConApi;

            _unitOfWork.BotOpcionesRepository.Update(_item);
            await _unitOfWork.SaveChangesAsync(); 
        }
        public async Task UpdateBotOpcionDisable()
        {
            Expression<Func<BotOpciones, bool>> expression = x => x.Activo == true;
            List<BotOpcionesDTO> dTOLst = new List<BotOpcionesDTO>();

            var item = _unitOfWork.BotOpcionesRepository.Find(expression).FirstOrDefault();

            item.Activo = false;

            _unitOfWork.BotOpcionesRepository.Update(item);            
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateBotOpcionEnable(int Id)
        {
            Expression<Func<BotOpciones, bool>> expression = x => x.Id == Id;
            var _item = _unitOfWork.BotOpcionesRepository.Find(expression).FirstOrDefault();

            _item.Activo = true;

            _unitOfWork.BotOpcionesRepository.Update(_item);
            await _unitOfWork.SaveChangesAsync();
        }
        public long GetOpcionEnable()
        {
            Expression<Func<BotOpciones, bool>> expression = x => x.Activo == true;
            
            var item = _unitOfWork.BotOpcionesRepository.Find(expression).FirstOrDefault();

            if (item == null)
                return 0;
            else
                return item.Id;

        }
    }
}
