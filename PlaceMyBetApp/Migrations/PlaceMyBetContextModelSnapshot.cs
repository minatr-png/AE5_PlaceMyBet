﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaceMyBetApp.Models;

namespace PlaceMyBetApp.Migrations
{
    [DbContext(typeof(PlaceMyBetContext))]
    partial class PlaceMyBetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AE2.Models.Apuesta", b =>
                {
                    b.Property<int>("ApuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Cuota")
                        .HasColumnType("float");

                    b.Property<float>("Dinero")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("MercadoId")
                        .HasColumnType("int");

                    b.Property<string>("OverUnder")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("ApuestaId");

                    b.HasIndex("MercadoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Apuestas");

                    b.HasData(
                        new
                        {
                            ApuestaId = 1,
                            Cuota = 24f,
                            Dinero = 50f,
                            Fecha = new DateTime(2020, 11, 12, 22, 41, 6, 31, DateTimeKind.Local).AddTicks(119),
                            OverUnder = "over",
                            Tipo = 2,
                            UsuarioId = "juanjo@gmail.com"
                        });
                });

            modelBuilder.Entity("AE2.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomLocal")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NomVisitante")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");

                    b.HasData(
                        new
                        {
                            EventoId = 1,
                            Fecha = new DateTime(2020, 11, 12, 22, 41, 6, 34, DateTimeKind.Local).AddTicks(109),
                            NomLocal = "Valencia",
                            NomVisitante = "Real Madrid"
                        });
                });

            modelBuilder.Entity("AE2.Models.Mercado", b =>
                {
                    b.Property<int>("MercadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("CuotaOver")
                        .HasColumnType("float");

                    b.Property<float>("CuotaUnder")
                        .HasColumnType("float");

                    b.Property<float>("DineoroOver")
                        .HasColumnType("float");

                    b.Property<float>("DineroUnder")
                        .HasColumnType("float");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("MercadoId");

                    b.HasIndex("EventoId");

                    b.ToTable("Mercados");

                    b.HasData(
                        new
                        {
                            MercadoId = 1,
                            CuotaOver = 14f,
                            CuotaUnder = 10f,
                            DineoroOver = 20f,
                            DineroUnder = 32f,
                            EventoId = 1,
                            Tipo = 2
                        });
                });

            modelBuilder.Entity("AE2.Models.Usuario", b =>
                {
                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Apellidos")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CuentaUsu")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = "juanjo@gmail.com",
                            Apellidos = "Navarro Molero",
                            CuentaUsu = 1,
                            Edad = 32,
                            Nombre = "Juanjo"
                        });
                });

            modelBuilder.Entity("PlaceMyBetApp.Models.Cuenta", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Banco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("CuentaId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cuentas");

                    b.HasData(
                        new
                        {
                            CuentaId = 1,
                            Banco = "Sabadell",
                            Saldo = 1000m,
                            UsuarioId = "juanjo@gmail.com"
                        });
                });

            modelBuilder.Entity("AE2.Models.Apuesta", b =>
                {
                    b.HasOne("AE2.Models.Mercado", "Mercado")
                        .WithMany("Apuestas")
                        .HasForeignKey("MercadoId");

                    b.HasOne("AE2.Models.Usuario", "Usuario")
                        .WithMany("Apuestas")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("AE2.Models.Mercado", b =>
                {
                    b.HasOne("AE2.Models.Evento", "Evento")
                        .WithMany("Mercado")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaceMyBetApp.Models.Cuenta", b =>
                {
                    b.HasOne("AE2.Models.Usuario", "Usuario")
                        .WithOne("Cuenta")
                        .HasForeignKey("PlaceMyBetApp.Models.Cuenta", "UsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
