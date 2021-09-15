using Microsoft.EntityFrameworkCore;
using senai.inlock.webAPI.CF.Domains;
using System;

namespace senai.inlock.webAPI.CF.Contexts
{
    public class InLockContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public DbSet<Estudios> Estudios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Jogos> Jogos { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Server=NOTE0113B2\\SQLEXPRESS; Database=InLock_Games; user id=sa; pwd=Senai@132");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposUsuario>().HasData(

                new TiposUsuario
                {
                    idTipoUsuario = 1,
                    titulo = "Administrador"
                },

                new TiposUsuario
                {
                    idTipoUsuario = 2,
                    titulo = "Cliente"
                }
                );

            modelBuilder.Entity<Usuarios>().HasData(

                new Usuarios
                {
                    idUsuario = 1,
                    email = "admin@admin.com",
                    senha = "admin",
                    idTipoUsuario = 1
                },

                new Usuarios
                {
                    idUsuario = 2,
                    email = "cliente@cliente.com",
                    senha = "cliente",
                    idTipoUsuario = 2
                }
                );

            modelBuilder.Entity<Estudios>().HasData(

                new Estudios { idEstudio = 1, nomeEstudio = "Blizzard"},
                new Estudios { idEstudio = 2, nomeEstudio = "Rockstar Studios"},
                new Estudios { idEstudio = 3, nomeEstudio = "Square Enix"}

                );

            modelBuilder.Entity<Jogos>().HasData(

                new Jogos
                {
                    idJogo = 1,
                    nomeJogo = "Diablo 3",
                    descricao = "É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã",
                    dataLancamento = Convert.ToDateTime("15/05/2012"),
                    idEstudio = 1,
                    valor = Convert.ToDecimal(99),
                },

                new Jogos
                {
                    idJogo = 2,
                    nomeJogo = "Red Dead Redemption II",
                    descricao = "Jogo eletrônico de ação-aventura western",
                    dataLancamento = Convert.ToDateTime("26/10/2018"),
                    idEstudio = 2,
                    valor = Convert.ToDecimal(120),
                }
                );
            base.OnModelCreating(modelBuilder);

            //Add-Migration criacao-banco
            //Update-Database


            //Remove-Migration
        }
    }
}
