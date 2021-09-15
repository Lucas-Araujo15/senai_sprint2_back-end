﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using senai.inlock.webAPI.CF.Contexts;

namespace senai.inlock.webAPI.CF.Migrations
{
    [DbContext(typeof(InLockContext))]
    [Migration("20210915134710_criacao-banco")]
    partial class criacaobanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("senai.inlock.webAPI.CF.Domains.Estudios", b =>
                {
                    b.Property<int>("idEstudio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nomeEstudio")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("idEstudio");

                    b.ToTable("Estudios");

                    b.HasData(
                        new
                        {
                            idEstudio = 1,
                            nomeEstudio = "Blizzard"
                        },
                        new
                        {
                            idEstudio = 2,
                            nomeEstudio = "Rockstar Studios"
                        },
                        new
                        {
                            idEstudio = 3,
                            nomeEstudio = "Square Enix"
                        });
                });

            modelBuilder.Entity("senai.inlock.webAPI.CF.Domains.Jogos", b =>
                {
                    b.Property<int>("idJogo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dataLancamento")
                        .HasColumnType("DATE");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("idEstudio")
                        .HasColumnType("int");

                    b.Property<string>("nomeJogo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("valor")
                        .HasColumnType("DECIMAL (10,2)");

                    b.HasKey("idJogo");

                    b.HasIndex("idEstudio");

                    b.ToTable("Jogos");

                    b.HasData(
                        new
                        {
                            idJogo = 1,
                            dataLancamento = new DateTime(2012, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            descricao = "É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã",
                            idEstudio = 1,
                            nomeJogo = "Diablo 3",
                            valor = 99m
                        },
                        new
                        {
                            idJogo = 2,
                            dataLancamento = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            descricao = "Jogo eletrônico de ação-aventura western",
                            idEstudio = 2,
                            nomeJogo = "Red Dead Redemption II",
                            valor = 120m
                        });
                });

            modelBuilder.Entity("senai.inlock.webAPI.CF.Domains.TiposUsuario", b =>
                {
                    b.Property<int>("idTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("idTipoUsuario");

                    b.ToTable("TiposUsuario");

                    b.HasData(
                        new
                        {
                            idTipoUsuario = 1,
                            titulo = "Administrador"
                        },
                        new
                        {
                            idTipoUsuario = 2,
                            titulo = "Cliente"
                        });
                });

            modelBuilder.Entity("senai.inlock.webAPI.CF.Domains.Usuarios", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("idTipoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("idUsuario");

                    b.HasIndex("idTipoUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            idUsuario = 1,
                            email = "admin@admin.com",
                            idTipoUsuario = 1,
                            senha = "admin"
                        },
                        new
                        {
                            idUsuario = 2,
                            email = "cliente@cliente.com",
                            idTipoUsuario = 2,
                            senha = "cliente"
                        });
                });

            modelBuilder.Entity("senai.inlock.webAPI.CF.Domains.Jogos", b =>
                {
                    b.HasOne("senai.inlock.webAPI.CF.Domains.Estudios", "estudio")
                        .WithMany("listaJogos")
                        .HasForeignKey("idEstudio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estudio");
                });

            modelBuilder.Entity("senai.inlock.webAPI.CF.Domains.Usuarios", b =>
                {
                    b.HasOne("senai.inlock.webAPI.CF.Domains.TiposUsuario", "tipoUsuario")
                        .WithMany()
                        .HasForeignKey("idTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tipoUsuario");
                });

            modelBuilder.Entity("senai.inlock.webAPI.CF.Domains.Estudios", b =>
                {
                    b.Navigation("listaJogos");
                });
#pragma warning restore 612, 618
        }
    }
}
