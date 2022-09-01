using BotWhatsApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BotWhatsApp.Data
{
    public class BotWhatsAppContext:DbContext
    {
        public BotWhatsAppContext()
        {

        }
        public BotWhatsAppContext(DbContextOptions<BotWhatsAppContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Bots> Bots{ get; set; }
        //public virtual DbSet<Respuestas> Respuestas { get; set; }
        public virtual DbSet<Conversaciones> Conversaciones { get; set; }
        public virtual DbSet<Bandeja> Bandeja { get; set; }
        public virtual DbSet<BotOpciones> BotOpciones { get; set; }
        public virtual DbSet<MensajesPredeterminado> MensajesPredeterminado { get; set; }
        public virtual DbSet<Poliza> Polizas { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
