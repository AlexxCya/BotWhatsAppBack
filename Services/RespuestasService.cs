using BotWhatsApp.DTOs;
using BotWhatsApp.DTOs.ApiTest;
using BotWhatsApp.Entities;
using BotWhatsApp.Interfaces;
using BotWhatsApp.Utilities.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BotWhatsApp.Services
{
    public class RespuestasService : IRespuestasServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConversacionesService _conversacionesService;
        private readonly IBandejaService _bandejaService;
        private readonly IBotOpcionesService _botOpcionesService;
        private readonly IBotService _botService;
        private readonly IEmpresaService _empresaService;
        private readonly IMensajePredetService _mensajePredetService;
        public RespuestasService(IUnitOfWork unitOfWork, IConversacionesService conversacionesService, IBandejaService bandejaService, IBotOpcionesService botOpcionesService,
                                    IBotService botService, IEmpresaService empresaService, IMensajePredetService MensajePredetService)
        {
            _unitOfWork = unitOfWork;
            _conversacionesService = conversacionesService;
            _bandejaService = bandejaService;
            _botOpcionesService = botOpcionesService;
            _botService = botService;
            _empresaService = empresaService;
            _mensajePredetService = MensajePredetService;
        }
        //public string RespuestasPorPregunta(string preguntaOpcion, string destinatario)
        //{
        //    string msg = "Asesor",pregunta = string.Empty;
        //    var _bandeja = _bandejaService.GetBandejaPorDestinatario(destinatario);

        //    if (_bandeja != null || preguntaOpcion.Equals("3"))
        //    {
        //        pregunta = preguntaOpcion;
        //        if (_bandeja == null)
        //        {
        //            Bandeja newBandeja = new Bandeja();

        //            newBandeja.Destinatario = destinatario;
        //            newBandeja.Visto = false;
        //            newBandeja.Asesor = "Yo";

        //            _bandejaService.InsertBandeja(newBandeja);

        //            pregunta = "Solicito hablar con un Asesor";
        //        }else
        //            _bandejaService.UpdateBandeja(destinatario, false);    

        //        ConversacionesDTO newItem = new ConversacionesDTO();

        //        newItem.Destinatario = destinatario;
        //        newItem.Mensaje = pregunta;
        //        newItem.Tipo = "Cliente";

        //        _conversacionesService.InsertConversaciones(newItem);

        //        return msg;
        //    }
        //    else
        //    {
        //        //string _opc = "Opcion 3.- Hablar con un Asesor";

        //        var _preguntasOpciones = _unitOfWork.PreguntasOpcionesRepository.GetAll();
        //        var _idPreguntaOpcion = _preguntasOpciones.Where(x => x.PreguntaOpcion.ToLower().Contains(preguntaOpcion.ToLower())).FirstOrDefault() == null
        //            ? 0 : _preguntasOpciones.Where(x => x.PreguntaOpcion.ToLower().Contains(preguntaOpcion.ToLower())).FirstOrDefault().Id;

        //        if (_idPreguntaOpcion > 0)
        //        {
        //            var _respuestas = _unitOfWork.RespuestasRepository.GetAll().Where(x => x.IdPreguntaOpcion == _idPreguntaOpcion);
        //            msg = _respuestas.FirstOrDefault().Respuesta;
        //        }
        //        else
        //            msg = "OPCION NO VALIDA, VUELVA A INTENTAR";

        //        return msg;
        //    }

        //}
        //public async Task<string> RespuestasBot2(string preguntaOpcion, string destinatario, string empresaWhatsApp, string mediaUri)
        //{
        //    string msg = "Asesor", pregunta = string.Empty;
        //    long empresaId = 0;
        //    empresaId = _empresaService.GetEmpresaByWhatsApp(empresaWhatsApp);

        //    var _bandeja = _bandejaService.GetBandejaPorDestinatario(destinatario, empresaId);


        //    if (_bandeja != null || preguntaOpcion.ToLower().Equals("asesor"))
        //    {
        //        pregunta = preguntaOpcion;
        //        if (_bandeja == null)
        //        {
        //            Bandeja newBandeja = new Bandeja();

        //            newBandeja.Destinatario = destinatario;
        //            newBandeja.Visto = false;
        //            newBandeja.Asesor = "Yo";
        //            newBandeja.EmpresaId = empresaId;

        //            await _bandejaService.InsertBandeja(newBandeja);

        //            pregunta = "Solicito hablar con un Asesor";

        //            msg = _mensajePredetService.GetByNombre("Inicio de Conversacion").Mensaje;

        //            //await _botOpcionesService.UpdateBotOpcionDisable();
        //        }
        //        else
        //            await _bandejaService.UpdateBandeja(destinatario, false, empresaId);

        //        ConversacionesDTO newItem = new ConversacionesDTO();

        //        newItem.Destinatario = destinatario;
        //        newItem.Mensaje = pregunta;
        //        newItem.Tipo = "Cliente";
        //        if (_bandeja != null)
        //            newItem.BandejaId = _bandeja.Id;
        //        else
        //            newItem.BandejaId = _bandejaService.GetBandejaPorDestinatario(destinatario, empresaId).Id;

        //        if (string.IsNullOrEmpty(mediaUri))
        //            await _conversacionesService.InsertConversaciones(newItem, string.Empty);
        //        else
        //            await _conversacionesService.InsertConversaciones(newItem, mediaUri);

        //        return msg;
        //    }
        //    else
        //    {
        //        var _idActivo = await _botService.BotActive(destinatario, empresaId);

        //        if (preguntaOpcion.ToLower().Equals("menu") || preguntaOpcion.ToLower().Equals("hola") || _idActivo == null)
        //        {
        //            //await _botOpcionesService.UpdateBotOpcionDisable();
        //            //await _botOpcionesService.UpdateBotOpcionEnable(1);

        //            msg = await ConstruirRespuesta(1, destinatario, empresaId);

        //            return msg;

        //        }
        //        else
        //        {
        //            //var opcionActiva = _botOpcionesService.GetOpcionEnable();
        //            if (preguntaOpcion.ToLower().Equals("atras"))
        //            {
        //                //msg = await ConstruirRespuesta(int.Parse(opcionActiva.ToString()));
        //                msg = await ConstruirRespuesta(int.Parse(_idActivo.BotOpcionesId.ToString()), destinatario, empresaId);
        //            }
        //            else
        //            {
        //                //var message = _botOpcionesService.GetMensaje(int.Parse(opcionActiva.ToString()));
        //                var lstOpcionesActivas = _botOpcionesService.GetOpciones(int.Parse(_idActivo.BotOpcionesId.ToString())).Cast<BotOpcionesDTO>();
        //                var opcionSeleccionada = lstOpcionesActivas.Where(x => x.Titulo.ToLower().Contains(preguntaOpcion.ToLower()));
        //                var _id = opcionSeleccionada.Count() == 0 ? 0 : int.Parse(opcionSeleccionada.FirstOrDefault().Id.ToString());

        //                if (_id > 0)
        //                {
        //                    msg = await ConstruirRespuesta(_id, destinatario, empresaId);

        //                }
        //                else
        //                {
        //                    var unicodeString = char.ConvertFromUtf32(0x274C);
        //                    var unicodeAsesor = char.ConvertFromUtf32(0x1F935);
        //                    var unicodeMenu = char.ConvertFromUtf32(0x1F4C3);
        //                    var unicodeAtras = char.ConvertFromUtf32(0x21A9);
        //                    msg = "OPCION INVALIDA!!! " + unicodeString + unicodeString + " \n \n  Para regresar a la opcion Anterior responde: \n" + unicodeAtras + " Atras \n Para regresar al Inicio responde: \n" + unicodeMenu + " MENU \n Para hablar con un asesor responde: \n" + unicodeAsesor + " ASESOR";
        //                }

        //            }
        //            return msg;
        //        }
        //    }

        //}
        public async Task<string> RespuestasBot(string preguntaOpcion, string destinatario, string empresaWhatsApp, string mediaUri)
        {
            //var res = await ConsumirApiTest("effect_entries/language/url,effect_entries/language/name");
            string msg = "Asesor", pregunta = string.Empty;
            bool error = false;
            long empresaId = 0;
            empresaId = _empresaService.GetEmpresaByWhatsApp(empresaWhatsApp);

            var _bandeja = _bandejaService.GetBandejaAbiertaPorDestinatario(destinatario, empresaId);


            if (_bandeja != null || preguntaOpcion.ToLower().Equals("asesor"))
            {
                pregunta = preguntaOpcion;
                if (_bandeja == null)
                {
                    Bandeja newBandeja = new Bandeja();

                    newBandeja.Destinatario = destinatario;
                    newBandeja.Visto = false;
                    newBandeja.Asesor = "Yo";
                    newBandeja.EmpresaId = empresaId;

                    await _bandejaService.InsertBandeja(newBandeja);

                    pregunta = "Solicito hablar con un Asesor";

                    msg = _mensajePredetService.GetByNombre("Inicio de Conversacion").Mensaje;

                    //await _botOpcionesService.UpdateBotOpcionDisable();
                }
                else
                    await _bandejaService.UpdateBandeja(destinatario, false, empresaId);

                ConversacionesDTO newItem = new ConversacionesDTO();

                newItem.Destinatario = destinatario;
                newItem.Mensaje = pregunta;
                newItem.Tipo = "Cliente";
                if (_bandeja != null)
                    newItem.BandejaId = _bandeja.Id;
                else
                    newItem.BandejaId = _bandejaService.GetBandejaAbiertaPorDestinatario(destinatario, empresaId).Id;

                if (string.IsNullOrEmpty(mediaUri))
                    await _conversacionesService.InsertConversaciones(newItem, string.Empty);
                else
                    await _conversacionesService.InsertConversaciones(newItem, mediaUri);

                //_conversacionesService.GetChats(destinatario);

                return msg;
            }
            else
            {
                var _idActivo = await _botService.BotActive(destinatario, empresaId);
                var retorno = _idActivo.TipoRetorno;
                if (preguntaOpcion.ToLower().Equals("menu") || preguntaOpcion.ToLower().Equals("hola") || _idActivo == null)
                {
                    //await _botOpcionesService.UpdateBotOpcionDisable();
                    //await _botOpcionesService.UpdateBotOpcionEnable(1);

                    msg = await ConstruirRespuesta(1, destinatario, empresaId, null, null, preguntaOpcion, retorno);

                    return msg;

                }
                else
                {
                    //ESTA OPCION POR EL MOMENTO NO ESTA ACTIVA
                    if (preguntaOpcion.ToLower().Equals("atras"))
                    {
                        //msg = await ConstruirRespuesta(int.Parse(opcionActiva.ToString()));
                        msg = await ConstruirRespuesta(int.Parse(_idActivo.BotOpcionesId.ToString()), destinatario, empresaId, null, null, preguntaOpcion, retorno);
                        
                    }
                    else
                    {
                    if (!string.IsNullOrEmpty(_idActivo.ValoresApi))
                    {
                        var opciones = _botOpcionesService.GetOpciones(int.Parse(_idActivo.BotOpcionesId.ToString())) != null ?
                                                _botOpcionesService.GetOpciones(int.Parse(_idActivo.BotOpcionesId.ToString())).Cast<BotOpcionesDTO>()
                                                : null;

                        var opcionSeleccionada = opciones != null ? opciones.FirstOrDefault() : null;


                        if (opcionSeleccionada != null)
                        {
                            var lstOpcionesActivas = System.Text.Json.JsonSerializer.Deserialize<List<ValoresApi>>(_idActivo.ValoresApi);

                            var _valor = lstOpcionesActivas.Where(x => x.Valor.ToLower().Contains(preguntaOpcion.ToLower())).Count() > 0 ?
                                            lstOpcionesActivas.Where(x => x.Valor.ToLower().Contains(preguntaOpcion.ToLower())).FirstOrDefault().Valor
                                            : string.Empty;

                            if (!string.IsNullOrEmpty(_valor))
                            {
                                string json = string.Empty;
                                List<ValoresSeleccionados> lstValoresSeleccionados = new List<ValoresSeleccionados>();

                                if (!string.IsNullOrEmpty(_idActivo.ValoresSeleccionados))
                                    lstValoresSeleccionados = System.Text.Json.JsonSerializer.Deserialize<List<ValoresSeleccionados>>(_idActivo.ValoresSeleccionados);

                                ValoresSeleccionados valor = new ValoresSeleccionados();
                                valor.BotOpcionId = _idActivo.BotOpcionesId;
                                valor.Valor = _valor.Split('-')[1].TrimStart();

                                lstValoresSeleccionados.Add(valor);
                                json = JsonConvert.SerializeObject(lstValoresSeleccionados);

                                var _id = int.Parse(opcionSeleccionada.Id.ToString());

                                if (opcionSeleccionada.ConApi)
                                    msg = await ConstruirRespuesta(_id, destinatario, empresaId, opcionSeleccionada, json, preguntaOpcion, retorno);
                                else
                                    msg = await ConstruirRespuesta(_id, destinatario, empresaId, null, json, preguntaOpcion, retorno);
                            }
                            else
                                error = true;
                        }
                    }
                    else
                    {
                        var lstOpcionesActivas = _botOpcionesService.GetOpciones(int.Parse(_idActivo.BotOpcionesId.ToString())).Cast<BotOpcionesDTO>();
                        var opcionSeleccionada = lstOpcionesActivas.Where(x => x.Titulo.ToLower().Contains(preguntaOpcion.ToLower()));
                        var _id = opcionSeleccionada.Count() == 0 ? 0 : int.Parse(opcionSeleccionada.FirstOrDefault().Id.ToString());

                        if (_id > 0)
                        {
                                var _opcionSeleccionada = opcionSeleccionada.Cast<BotOpcionesDTO>().FirstOrDefault();
                            if (_opcionSeleccionada.ConApi && !string.IsNullOrEmpty(_opcionSeleccionada.OpcionesApi))
                                msg = await ConstruirRespuesta(_id, destinatario, empresaId, opcionSeleccionada.Cast<BotOpcionesDTO>().FirstOrDefault(), _idActivo.ValoresSeleccionados, preguntaOpcion, _opcionSeleccionada.TipoRetorno);
                            else
                                msg = await ConstruirRespuesta(_id, destinatario, empresaId, null, null, preguntaOpcion, _opcionSeleccionada.TipoRetorno);

                        }
                        else
                        {
                            var opcionActiva = _botOpcionesService.GetMensaje(int.Parse(_idActivo.BotOpcionesId.ToString())).Cast<BotOpcionesDTO>().FirstOrDefault();

                            _id = int.Parse(opcionActiva.Id.ToString());

                            //if(_idActivo.TipoRetorno == "PDF")
                            //{

                            //}

                            if (opcionActiva.ConApi)
                                msg = await ConstruirRespuesta(_id, destinatario, empresaId, opcionActiva, _idActivo.ValoresSeleccionados, preguntaOpcion, opcionActiva.TipoRetorno);
                            else
                                msg = await ConstruirRespuesta(_id, destinatario, empresaId, null, null, preguntaOpcion, opcionActiva.TipoRetorno);

                            //error = true;
                        }
                    }
                    if (error || string.IsNullOrEmpty(msg))
                    {
                        var unicodeString = char.ConvertFromUtf32(0x274C);
                        var unicodeAsesor = char.ConvertFromUtf32(0x1F935);
                        var unicodeMenu = char.ConvertFromUtf32(0x1F4C3);
                        var unicodeAtras = char.ConvertFromUtf32(0x21A9);
                        msg = "OPCION INVALIDA!!! " + unicodeString + unicodeString + " \n \n  Vuelva a Intentarlo con Otra Opcion: \n  \n Para regresar al Inicio responde: \n" + unicodeMenu + " MENU \n Para hablar con un asesor responde: \n" + unicodeAsesor + " ASESOR";

                    }
                        
                    }
                    return msg;
                }
            }

        }
        private async Task<string> ConstruirRespuesta(int id, string destinatario, long empresaId, BotOpcionesDTO opcionSeleccionada, 
                                                        string valoresSeleccionados, string opcion, string tipoRetorno)
        {
            var message = _botOpcionesService.GetMensaje(id).Cast<BotOpcionesDTO>().FirstOrDefault().Mensaje;
            string msg = string.Empty;

            var unicodeManita = char.ConvertFromUtf32(0x1F449);
            var unicodeChat = char.ConvertFromUtf32(0x1F4AC);
            var unicodeAsesor = char.ConvertFromUtf32(0x1F935);
            var unicodeMenu = char.ConvertFromUtf32(0x1F4C3);
            try
            {
                if (opcionSeleccionada == null)
                {
                    var lstOpciones = _botOpcionesService.GetOpciones(id).Cast<BotOpcionesDTO>();


                    msg = message + " \n ";

                    if (lstOpciones.Count() > 0)
                    {
                        foreach (var item in lstOpciones)
                        {
                            msg += unicodeManita + item.Titulo + " \n ";
                        }
                        //await _botOpcionesService.UpdateBotOpcionDisable();
                        //await _botOpcionesService.UpdateBotOpcionEnable(id);

                        if (id == 1)
                        {
                            msg += " \n " + unicodeChat + "Si requiere una atencion de persona a persona por favor Responda ASESOR" + unicodeAsesor;
                        }
                    }
                    else
                        msg += "Para regresar al Inicio responde: \n" + unicodeMenu + " MENU \n Para hablar con un asesor responde: \n" + unicodeAsesor + " ASESOR";

                    var _exists = await _botService.BotActive(destinatario, empresaId);

                    if (_exists == null)
                        await _botService.InsertBot(destinatario, long.Parse(id.ToString()));
                    else
                        await _botService.UpdateBot(destinatario, long.Parse(id.ToString()), empresaId, string.Empty, string.Empty);
                }
                else
                {
                    var lstParametros = System.Text.Json.JsonSerializer.Deserialize<List<Parametros>>(opcionSeleccionada.JsonParametros);
                    string paramsInput = "{", paramsUrl = string.Empty;
                    foreach (var item in lstParametros)
                    {
                        if (item.tipo == "json")
                        {
                            var value = string.Empty;
                            if (item.valor.Contains("-["))
                            {
                                var lstValoresSeleccionados = System.Text.Json.JsonSerializer.Deserialize<List<ValoresSeleccionados>>(valoresSeleccionados);
                                var _id = long.Parse(item.valor.Split('-')[0]);

                                value = lstValoresSeleccionados.Where(x => x.BotOpcionId == _id).FirstOrDefault().Valor;
                            }
                            else
                                value = item.valor.Trim();

                            if (paramsInput != "{")
                                paramsInput += ", \"" + item.nombre.Trim() + "\" :\"" + value + "\"";
                            else
                                paramsInput += " \"" + item.nombre.Trim() + "\" :\"" + value + "\"";
                        }
                        if (item.tipo == "url")
                        {
                            if (string.IsNullOrEmpty(paramsUrl))
                                paramsUrl = "?" + item.nombre.Trim() + "=" + (item.valor == "Valor Bot" ? opcion : item.valor.Trim());
                            else
                                paramsUrl += "&" + item.nombre.Trim() + "=" + (item.valor == "Valor Bot" ? opcion : item.valor.Trim());
                        }
                    }
                    paramsInput += "}";

                    var resultApi = await ConsumirApi(opcionSeleccionada.MetodoApi, paramsInput, opcionSeleccionada.UrlApi + paramsUrl);
                    var msgApi = ConstruirMensajeApi(resultApi.ToString(), opcionSeleccionada.OpcionesMsjApi, tipoRetorno);
                    List<ValoresApi> lstValoresApi = new List<ValoresApi>();
                    var opcApi = ConstruirOpcionesApi(resultApi.ToString(), opcionSeleccionada.OpcionesApi, ref lstValoresApi);


                    msg = (msgApi != string.Empty ? msgApi : opcionSeleccionada.Mensaje) + "\n" + opcApi;

                    if(string.IsNullOrEmpty(opcApi))
                        msg += "Para regresar al Inicio responde: \n" + unicodeMenu + " MENU \n Para hablar con un asesor responde: \n" + unicodeAsesor + " ASESOR";

                    string valoresSel = string.Empty;
                    if (!string.IsNullOrEmpty(valoresSeleccionados))
                        valoresSel = valoresSeleccionados;

                    if (lstValoresApi.Count == 0)
                        await _botService.UpdateBot(destinatario, long.Parse(id.ToString()), empresaId, string.Empty, valoresSel);
                    else
                    {
                        var json = JsonConvert.SerializeObject(lstValoresApi);
                        await _botService.UpdateBot(destinatario, long.Parse(id.ToString()), empresaId, json, valoresSel);
                    }


                }
            }
            catch (Exception ex)
            {
                msg = string.Empty;
            }

            return msg;
        }
        private async Task<string> ConsumirApi(string metodo, string paramsInput, string url)
        {
            var result = string.Empty;
            //ParamDTO dTO = new ParamDTO();
            //dTO.Anio = 2020;

            ////var json = JsonConvert.SerializeObject(dTO);

            using var client = new HttpClient();
            if (metodo.ToLower().Equals("post"))
            {
                var data = new StringContent(paramsInput, Encoding.UTF8, "application/json");


                var response = await client.PostAsync(url, data);

                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                result = await client.GetStringAsync(url);
            }
            
            return result;
        }
        private async Task<string> ConsumirApiTest(string OutputOpc)
        {
            var result = string.Empty;
            var api = string.Empty;
            //var json = JsonConvert.SerializeObject(dTO);

            using var client = new HttpClient();
            //if (metodo.ToLower().Equals("post"))
            //{
            //    var data = new StringContent(paramsInput, Encoding.UTF8, "application/json");


            //    var response = await client.PostAsync(url, data);

            //    result = await response.Content.ReadAsStringAsync();
            //}
            //else
            //{
                api = await client.GetStringAsync("https://pokeapi.co/api/v2/ability/7");
            //}
            var x = System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(api);
            IDictionary<string, object> propertyValues = x;


            List<string> lstOutput = new List<string>();

            if (OutputOpc.Contains(','))
            {
                foreach (var item in OutputOpc.Split(','))
                {
                    lstOutput.Add(item);

                }

            }
            else
                lstOutput.Add(OutputOpc);

            List<ValoresOutput> valores = new List<ValoresOutput>();

            foreach (var prop in propertyValues.Keys)
            {
                if (propertyValues[prop].ToString().Substring(0, 1) == "[")
                    ListJson(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                else
                {
                    if (propertyValues[prop].ToString().Substring(0, 1) == "{")
                        Json(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                    else
                    {
                        if (lstOutput.Where(x => x == prop).Count() > 0)
                        {
                            ValoresOutput valor = new ValoresOutput();
                            valor.Campo = prop.ToString();
                            valor.Valor = propertyValues[prop].ToString();

                            valores.Add(valor);
                        }
                    }
                }

                //var rult = String.Format("{0} : {1}", prop, propertyValues[prop]);
            }

            List<string> lstCampos = new List<string>();
            int itemC = 1;
            bool start= true;
            var unicodeManita = char.ConvertFromUtf32(0x1F449);
            foreach (var valor in valores)
            {
                if(lstCampos.Where(x => x == valor.Campo).Count() == 0)
                {
                    if (start)
                    {
                        result += itemC.ToString() + ".- " + unicodeManita + " "+ valor.Valor;
                        start = false;
                    }
                    else
                        result += " " + valor.Valor;
                    
                    lstCampos.Add(valor.Campo);
                }
                else
                {
                    start = true;
                    lstCampos.Clear();  
                    itemC++;
                    result += "\n";
                }
            }

            //foreach (var property in dictionary.Keys)
            //{
            //    if(dictionary[property].ToString().Substring(0, 1) == "[")
            //    {
            //        var x2 = System.Text.Json.JsonSerializer.Deserialize<List<ExpandoObject>>(dictionary[property].ToString());

            //        foreach (var item in x2)
            //        {
            //            IDictionary<string, object> propertyValues = item;

            //            foreach (var property2 in propertyValues.Keys)
            //            {

            //                var rult2 = String.Format("{0} : {1}", property2, propertyValues[property2]);
            //            }
            //        }
            //    }
            //    var rult = String.Format("{0} : {1}", property, dictionary[property]);
            //}

            //foreach (var item in x)
            //{
            //    IDictionary<string, object> propertyValues = item;

            //    foreach (var property in propertyValues.Keys)
            //    {

            //        var rult = String.Format("{0} : {1}", property, propertyValues[property]);
            //    }
            //}

            return result;
        }
        private string ConstruirMensajeApi(string resultApi, string OutputOpc, string tipoTRetorno)
        {
            var result = string.Empty;

            List<string> lstOutput = new List<string>();

            if (OutputOpc.Contains(','))
            {
                foreach (var item in OutputOpc.Split(','))
                {
                    lstOutput.Add(item);

                }

            }
            else
                lstOutput.Add(OutputOpc);

            List<ValoresOutput> valores = new List<ValoresOutput>();


            if (resultApi.ToString().Substring(0, 1) == "{")
            {
                var x = System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(resultApi);
                IDictionary<string, object> propertyValues = x;

                foreach (var prop in propertyValues.Keys)
                {
                    if (propertyValues[prop] != null && propertyValues[prop].ToString().Substring(0, 1) == "[")
                        ListJson(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                    else
                    {
                        if (propertyValues[prop] != null && propertyValues[prop].ToString().Substring(0, 1) == "{")
                            Json(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                        else
                        {
                            if (lstOutput.Where(x => x == prop).Count() > 0)
                            {
                                ValoresOutput valor = new ValoresOutput();
                                valor.Campo = prop.ToString();
                                valor.Valor = propertyValues[prop].ToString();

                                valores.Add(valor);
                            }
                        }
                    }

                    //var rult = String.Format("{0} : {1}", prop, propertyValues[prop]);
                }
            }
            else
            {
                var x = System.Text.Json.JsonSerializer.Deserialize<List<ExpandoObject>>(resultApi);
                foreach (var item in x)
                {
                    IDictionary<string, object> propertyValues = item;

                    foreach (var prop in propertyValues.Keys)
                    {
                        if (propertyValues[prop] != null && propertyValues[prop].ToString().Substring(0, 1) == "[")
                            ListJson(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                        else
                        {
                            if (propertyValues[prop] != null && propertyValues[prop].ToString().Substring(0, 1) == "{")
                                Json(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                            else
                            {
                                if (lstOutput.Where(x => x == prop).Count() > 0)
                                {
                                    ValoresOutput valor = new ValoresOutput();
                                    valor.Campo = prop.ToString();
                                    valor.Valor = propertyValues[prop].ToString();

                                    valores.Add(valor);
                                }
                            }
                        }
                    }
                }
            }

            if (tipoTRetorno.Equals("TEXTO"))
            {
                foreach (var valor in valores)
                {
                    result += valor.Valor + " ";
                }
            }
            if (tipoTRetorno.Equals("PDF"))
            {

                var valueUrl = valores.Where(x => x.Valor.ToLower().Contains("http")).FirstOrDefault().Valor;
                result = "[FILE]#" + valueUrl ;
                
            }


            return result;
        }
        private string ConstruirOpcionesApi(string resultApi,string OutputOpc, ref List<ValoresApi> valoresApi)
        {
            var result = string.Empty;

            List<string> lstOutput = new List<string>();

            if (OutputOpc.Contains(','))
            {
                foreach (var item in OutputOpc.Split(','))
                {
                    lstOutput.Add(item);

                }

            }
            else
                lstOutput.Add(OutputOpc);

            List<ValoresOutput> valores = new List<ValoresOutput>();


            if (resultApi.ToString().Substring(0, 1) == "{")
            {
                var x = System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(resultApi);
                IDictionary<string, object> propertyValues = x;

                foreach (var prop in propertyValues.Keys)
                {
                    if (propertyValues[prop] != null && propertyValues[prop].ToString().Substring(0, 1) == "[")
                        ListJson(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                    else
                    {
                        if (propertyValues[prop] != null && propertyValues[prop].ToString().Substring(0, 1) == "{")
                            Json(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                        else
                        {
                            if (lstOutput.Where(x => x == prop).Count() > 0)
                            {
                                ValoresOutput valor = new ValoresOutput();
                                valor.Campo = prop.ToString();
                                valor.Valor = propertyValues[prop].ToString();

                                valores.Add(valor);
                            }
                        }
                    }

                    //var rult = String.Format("{0} : {1}", prop, propertyValues[prop]);
                }
            }
            else
            {
                var x = System.Text.Json.JsonSerializer.Deserialize<List<ExpandoObject>>(resultApi);
                foreach (var item in x)
                {
                    IDictionary<string, object> propertyValues = item;

                    foreach (var prop in propertyValues.Keys)
                    {
                        if (propertyValues[prop] != null && propertyValues[prop].ToString().Substring(0, 1) == "[")
                            ListJson(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                        else
                        {
                            if (propertyValues[prop] != null && propertyValues[prop].ToString().Substring(0, 1) == "{")
                                Json(propertyValues[prop].ToString(), prop, lstOutput, ref valores);
                            else
                            {
                                if (lstOutput.Where(x => x == prop).Count() > 0)
                                {
                                    ValoresOutput valor = new ValoresOutput();
                                    valor.Campo = prop.ToString();
                                    valor.Valor = propertyValues[prop].ToString();

                                    valores.Add(valor);
                                }
                            }
                        }
                    }
                }
            }
            List<string> lstCampos = new List<string>();
            int itemC = 1;
            bool start = true;
            var unicodeManita = char.ConvertFromUtf32(0x1F449);
            foreach (var valor in valores)
            {
                if (lstOutput.Count() > 1)
                {
                    if (lstCampos.Where(x => x == valor.Campo).Count() == 0)
                    {
                        if (start)
                        {
                            result += itemC.ToString() + ".- " + unicodeManita + " " + valor.Valor;
                            start = false;
                        }
                        else
                            result += " " + valor.Valor;

                        lstCampos.Add(valor.Campo);
                    }
                    else
                    {
                        start = true;
                        lstCampos.Clear();
                        itemC++;
                        result += "\n";
                    }
                }else
                {
                    ValoresApi newValor = new ValoresApi();
                    newValor.Valor = itemC.ToString() + ".- " + valor.Valor;
                    result += itemC.ToString() + ".- " + unicodeManita + " " + valor.Valor + "\n";
                    valoresApi.Add(newValor);
                    itemC++;
                }
            }

            
            return result;
        }
        private void ListJson(string property, string nodo, List<string> outputLst, ref List<ValoresOutput> valores)
        {
            var x2 = System.Text.Json.JsonSerializer.Deserialize<List<ExpandoObject>>(property);

            foreach (var item in x2)
            {
                IDictionary<string, object> propertyValues = item;

                foreach (var prop in propertyValues.Keys)
                {
                    if (propertyValues[prop].ToString().Substring(0, 1) == "[")
                         ListJson(propertyValues[prop].ToString(), nodo + "/" + prop, outputLst, ref valores);
                    else
                    {
                        if (propertyValues[prop].ToString().Substring(0, 1) == "{")
                             Json(propertyValues[prop].ToString(), nodo + "/" + prop, outputLst, ref valores);
                        else
                        {
                            var _nodo = nodo + "/" + prop;
                            if (outputLst.Where(x => x == _nodo).Count() > 0)
                            {
                                ValoresOutput valor = new ValoresOutput();
                                valor.Campo = _nodo;
                                valor.Valor = propertyValues[prop].ToString();

                                valores.Add(valor);
                            }
                        }
                    }
                }
            }

        }
        private void Json(string property, string nodo, List<string> outputLst, ref List<ValoresOutput> valores)
        {
            var item = System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(property);

            
            IDictionary<string, object> propertyValues = item;

            foreach (var prop in propertyValues.Keys)
            {
                if (propertyValues[prop].ToString().Substring(0, 1) == "[")
                     ListJson(propertyValues[prop].ToString(), nodo + "/" + prop, outputLst, ref valores);
                else
                {
                    if (propertyValues[prop].ToString().Substring(0, 1) == "{")
                         Json(propertyValues[prop].ToString(), nodo + "/" + prop, outputLst, ref valores);
                    else
                    {
                        var _nodo = nodo + "/" + prop;
                        if (outputLst.Where(x => x == _nodo).Count() > 0)
                        {
                            ValoresOutput valor = new ValoresOutput();
                            valor.Campo = _nodo;
                            valor.Valor = propertyValues[prop].ToString();

                            valores.Add(valor);
                        }
                    }
                }
                //var rult = String.Format("{0} : {1}", prop, propertyValues[prop]);
            }


            //return textoArmado;
        }
    }
}
