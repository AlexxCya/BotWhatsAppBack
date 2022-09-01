using BotWhatsApp.Data;
using BotWhatsApp.Entities;
using BotWhatsApp.Interfaces;
using System.Threading.Tasks;

namespace BotWhatsApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BotWhatsAppContext _context;
        private readonly IRepository<PreguntasOpciones> _pregutasOpcRepository;
        private readonly IRepository<Respuestas> _respuestasRepository;
        private readonly IRepository<Conversaciones> _conversacionesRepository;
        private readonly IRepository<Bandeja> _bandejaRepository;
        private readonly IRepository<BotOpciones> _botOpcionesRepository;
        private readonly IRepository<Bots> _botsRepository;
        private readonly IRepository<Empresa> _empresaRepository;
        private readonly IRepository<MensajesPredeterminado> _mensajesPredeterminadoRepository;
        private readonly IRepository<Poliza> _polizaRepository;
        private readonly IRepository<Marca> _marcaRepository;
        private readonly IRepository<Modelo> _modeloRepository;


        public UnitOfWork(BotWhatsAppContext context)
        {
            _context = context;
        }
        public IRepository<PreguntasOpciones> PreguntasOpcionesRepository => _pregutasOpcRepository ?? new BaseRepository<PreguntasOpciones>(_context);

        public IRepository<Respuestas> RespuestasRepository => _respuestasRepository ?? new BaseRepository<Respuestas>(_context);
        public IRepository<Conversaciones> ConversacionesRepository => _conversacionesRepository ?? new BaseRepository<Conversaciones>(_context);
        public IRepository<Bandeja> BandejaRepository => _bandejaRepository ?? new BaseRepository<Bandeja>(_context);
        public IRepository<BotOpciones> BotOpcionesRepository => _botOpcionesRepository ?? new BaseRepository<BotOpciones>(_context);
        public IRepository<Bots> BotsRepository => _botsRepository ?? new BaseRepository<Bots>(_context);
        public IRepository<Empresa> EmpresaRepository => _empresaRepository ?? new BaseRepository<Empresa>(_context);
        public IRepository<MensajesPredeterminado> MensajesPredeterminadoRepository => _mensajesPredeterminadoRepository ?? new BaseRepository<MensajesPredeterminado>(_context);
        public IRepository<Poliza> PolizaRepository => _polizaRepository ?? new BaseRepository<Poliza>(_context);
        public IRepository<Marca> MarcaRepository => _marcaRepository ?? new BaseRepository<Marca>(_context);
        public IRepository<Modelo> ModeloRepository => _modeloRepository ?? new BaseRepository<Modelo>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
