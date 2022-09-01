using BotWhatsApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BotWhatsApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new BotWhatsAppContext(serviceProvider.GetRequiredService<DbContextOptions<BotWhatsAppContext>>()))
            {
                //bool countriesAny = _context.Country.AnyAsync();
                //if ()
                //{

                //}
                //_context.PreguntasOpciones.AddRange(
                //    new PreguntasOpciones { Id = 1, PreguntaOpcion = "Hola"  },
                //    new PreguntasOpciones { Id = 2, PreguntaOpcion = "Opcion 1" },
                //    new PreguntasOpciones { Id = 3, PreguntaOpcion = "Opcion 2" },
                //    new PreguntasOpciones { Id = 4, PreguntaOpcion = "Opcion 3" },
                //    new PreguntasOpciones { Id = 5, PreguntaOpcion = "Opcion 4" }
                //    );

                //_context.Respuestas.AddRange(
                //    new Respuestas { Id = 1, Respuesta = "Bienvenido a la asistencia virtual de ITECH DEV.  \n Digite el Numero de la Opción que requiera:  \n 1.- Ver Clientes  \n 2.- Quienes Somos \n 3.- Hablar con un Asesor", IdPreguntaOpcion = 1 },
                //    new Respuestas { Id = 2, Respuesta = "SORIANA", IdPreguntaOpcion = 2 },
                //    new Respuestas { Id = 3, Respuesta = "CEMEX", IdPreguntaOpcion = 2 },
                //    new Respuestas { Id = 4, Respuesta = "Somos el apoyo empresarial que nuestros clientes necesitan para dar el salto tecnológico tan necesario hoy en día. Lo logramos con pasión, porque nos gusta lo que hacemos, somos pro activos y mantenemos una constante comunicación contigo. Sabemos la responsabilidad que adquirimos y mediante un trabajo en equipo efectivo alcanzamos todas las expectativas. \n"
                //            + "Cada proyecto es para nosotros una misión en la cual el objetivo principal es entregarte un producto que mejore drásticamente algún ámbito de tu negocio y no desistimos hasta lograrlo.", IdPreguntaOpcion = 3 },
                //    new Respuestas { Id = 5, Respuesta = "En Breve un Asesor se pondra en contacto con usted", IdPreguntaOpcion = 4 });

                //_context.Conversaciones.AddRange(
                //    new Conversaciones { Id=1, Destinatario = "5217822092231", Tipo="Cliente", Mensaje="Necesito Hablar con un Asesor", Orden=1 },
                //    new Conversaciones { Id = 2, Destinatario = "5217822092231", Tipo = "Asesor", Mensaje = "Hola en que te puedo apoyar?", Orden = 2 },
                //    new Conversaciones { Id = 3, Destinatario = "5217822092231", Tipo = "Cliente", Mensaje = "Quiero saber el horario de atención", Orden = 3 },
                //    new Conversaciones { Id = 4, Destinatario = "5217822094415", Tipo = "Cliente", Mensaje = "Necesito Hablar con un Asesor", Orden = 1 },
                //    new Conversaciones { Id = 5, Destinatario = "5217822094415", Tipo = "Asesor", Mensaje = "Hola en que te puedo apoyar?", Orden = 2 }
                //    );
                //_context.Bandeja.AddRange(
                //    new Bandeja { Id = 1,Destinatario = "5217822092231", Asesor="Yo", Visto=false},
                //    new Bandeja { Id = 2, Destinatario = "5217822094415", Asesor = "Yo", Visto = true }
                //    );
                _context.BotOpciones.AddRange(
                    new BotOpciones { Id = 1, Activo=true, IdPadre=0, Mensaje= "Bienvenido a la asistencia virtual de ITECH DEV.  \n Responda con el Numero de la Opción que requiera:", Opcion=false, Titulo="Bienvenida" },
                    new BotOpciones { Id = 2, Activo = false, IdPadre = 1, Mensaje = "Las siguientes empresas han dado su opinion acerca de nosotros  \n Responda con el Numero de la Opción que requiera:", Opcion = true, Titulo = "1.- Nuestros Clientes" },
                    new BotOpciones { Id = 3, Activo = false, IdPadre = 2, Mensaje = "Itech Dev es una empresa altamente confiable", Opcion = true, Titulo = "1.- Soriana" }
                    );

                _context.SaveChanges();
            }
        }
    }
}
