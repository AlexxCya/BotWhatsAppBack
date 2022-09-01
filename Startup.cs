using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BotWhatsApp.Data;
using BotWhatsApp.Interfaces;
using BotWhatsApp.Interfaces.ApiTest;
using BotWhatsApp.Repositories;
using BotWhatsApp.Services;
using BotWhatsApp.Services.ApiTest;
using BotWhatsApp.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
namespace BotWhatsApp
{
    public class Startup
    {
        readonly string MiCors = "MiCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MiCors,
            //        builder =>
            //        {
            //            builder.WithHeaders("*");
            //            builder.WithOrigins("*");
            //            builder.WithMethods("*");
            //        });
            //});

            services.AddCors(options =>
            
                options.AddPolicy(MiCors,
                    policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    ));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BotWhatsApp", Version = "v1" });
            });
            //services.AddDbContext<BotWhatsAppContext>(options =>
            //     options.UseInMemoryDatabase(databaseName: "InMemoryDB")
            //    );
            services.AddDbContext<BotWhatsAppContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("Connection"))
             );
            services.AddTransient<IRespuestasServices, RespuestasService>();
            services.AddTransient<IConversacionesService, ConversacionesService>();
            services.AddTransient<IBandejaService, BandejaService>();
            services.AddTransient<IBotOpcionesService, BotOpcionesService>();
            services.AddTransient<IBotService, BotService>();
            services.AddTransient<IEmpresaService, EmpresaService>();
            services.AddTransient<IFileAzureStorage, FileAzureStorage>();
            services.AddTransient<IMensajePredetService, MensajePredetService>();
            services.AddTransient<IModeloService, ModeloService>();
            services.AddTransient<IPolizaService, PolizaService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(MiCors);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BotWhatsApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
