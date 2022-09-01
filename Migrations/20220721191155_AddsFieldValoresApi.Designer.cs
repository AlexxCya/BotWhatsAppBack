﻿// <auto-generated />
using System;
using BotWhatsApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BotWhatsApp.Migrations
{
    [DbContext(typeof(BotWhatsAppContext))]
    [Migration("20220721191155_AddsFieldValoresApi")]
    partial class AddsFieldValoresApi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BotWhatsApp.Entities.Bandeja", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualizadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Asesor")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("Cerrada")
                        .HasColumnType("bit");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destinatario")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("FechaActualizaion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Visto")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Bandeja");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.BotOpciones", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("ActualizadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ConApi")
                        .HasColumnType("bit");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("FechaActualizaion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPadre")
                        .HasColumnType("int");

                    b.Property<string>("JsonParametros")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mensaje")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("MetodoApi")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Opcion")
                        .HasColumnType("bit");

                    b.Property<string>("OpcionesApi")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("OpcionesMsjApi")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UrlApi")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("BotOpciones");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Bots", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualizadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("BotOpcionesId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destinatario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("FechaActualizaion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ValoresApi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BotOpcionesId");

                    b.ToTable("Bots");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Conversaciones", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualizadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("BandejaId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destinatario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("FechaActualizaion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("MediaUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("BandejaId");

                    b.ToTable("Conversaciones");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Empresa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualizadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime?>("FechaActualizaion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumeroWhatsapp")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Representante")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Marca", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualizadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaActualizaion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreMarca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.MensajesPredeterminado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualizadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaActualizaion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("NombreMensaje")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MensajesPredeterminado");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Modelo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualizadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaActualizaion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<long>("MarcaId")
                        .HasColumnType("bigint");

                    b.Property<string>("NombreModelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Poliza", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualizadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cobertura")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreadoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaActualizaion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumPoliza")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Vehiculo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Polizas");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Bandeja", b =>
                {
                    b.HasOne("BotWhatsApp.Entities.Empresa", null)
                        .WithMany("Bandejas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BotWhatsApp.Entities.BotOpciones", b =>
                {
                    b.HasOne("BotWhatsApp.Entities.Empresa", null)
                        .WithMany("BotOpciones")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Bots", b =>
                {
                    b.HasOne("BotWhatsApp.Entities.BotOpciones", null)
                        .WithMany("Bots")
                        .HasForeignKey("BotOpcionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Conversaciones", b =>
                {
                    b.HasOne("BotWhatsApp.Entities.Bandeja", null)
                        .WithMany("Conversaciones")
                        .HasForeignKey("BandejaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Modelo", b =>
                {
                    b.HasOne("BotWhatsApp.Entities.Marca", null)
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Bandeja", b =>
                {
                    b.Navigation("Conversaciones");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.BotOpciones", b =>
                {
                    b.Navigation("Bots");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Empresa", b =>
                {
                    b.Navigation("Bandejas");

                    b.Navigation("BotOpciones");
                });

            modelBuilder.Entity("BotWhatsApp.Entities.Marca", b =>
                {
                    b.Navigation("Modelos");
                });
#pragma warning restore 612, 618
        }
    }
}
