using BotWhatsApp.Entities;
using System;
using System.Threading.Tasks;

namespace BotWhatsApp.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<PreguntasOpciones> PreguntasOpcionesRepository { get; }
        IRepository<Respuestas> RespuestasRepository { get; }
        IRepository<Conversaciones> ConversacionesRepository { get; }
        IRepository<Bandeja> BandejaRepository { get; }
        IRepository<BotOpciones> BotOpcionesRepository { get; }
        IRepository<Bots> BotsRepository { get; }
        IRepository<Empresa> EmpresaRepository { get; }
        IRepository<MensajesPredeterminado> MensajesPredeterminadoRepository { get; }
        IRepository<Poliza> PolizaRepository { get; }
        IRepository<Marca> MarcaRepository { get; }
        IRepository<Modelo> ModeloRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
