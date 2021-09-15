using senai.inlock.webAPI.CF.Contexts;
using senai.inlock.webAPI.CF.Domains;
using senai.inlock.webAPI.CF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.CF.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(Jogos novoJogo)
        {
            ctx.Jogos.Update(novoJogo);
            ctx.SaveChanges();
        }

        public void Cadastrar(Jogos jogo)
        {
            ctx.Jogos.Add(jogo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogos jogoBuscado = ListarPorId(id);

            if (jogoBuscado != null)
            {
                ctx.Jogos.Remove(jogoBuscado);
                ctx.SaveChanges();
            }
        }

        public Jogos ListarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(x => x.idJogo == id);
        }

        public List<Jogos> ListarTodos()
        {
            return ctx.Jogos.ToList();
        }
    }
}
