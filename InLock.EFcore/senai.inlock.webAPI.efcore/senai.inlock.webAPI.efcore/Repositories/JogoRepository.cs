using senai.inlock.webAPI.efcore.Contexts;
using senai.inlock.webAPI.efcore.Domains;
using senai.inlock.webAPI.efcore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.efcore.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        BlogContext ctx = new BlogContext();

        public void Atualizar(Jogo novoJogo)
        {
            ctx.Jogos.Update(novoJogo);
            ctx.SaveChanges();
        }

        public void Cadastrar(Jogo jogo)
        {
            ctx.Jogos.Add(jogo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogo jogoBuscado = ListarPorId(id);

            if (jogoBuscado != null)
            {
                ctx.Jogos.Remove(jogoBuscado);
                ctx.SaveChanges();
            }
        }

        public Jogo ListarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(x => x.IdJogo == id);
        }

        public List<Jogo> ListarTodos()
        {
            return ctx.Jogos.ToList();
        }
    }
}
