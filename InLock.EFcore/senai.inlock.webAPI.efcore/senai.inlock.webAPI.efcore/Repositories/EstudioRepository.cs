using Microsoft.EntityFrameworkCore;
using senai.inlock.webAPI.efcore.Contexts;
using senai.inlock.webAPI.efcore.Domains;
using senai.inlock.webAPI.efcore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai.inlock.webAPI.efcore.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        BlogContext ctx = new BlogContext();
        public void Atualizar(Estudio novoEstudio)
        {
            ctx.Estudios.Update(novoEstudio);
            ctx.SaveChanges();
        }

        public void Cadastrar(Estudio estudio)
        {
            ctx.Estudios.Add(estudio);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudio estudioBuscado = ListarPorId(id);

            if (estudioBuscado != null)
            {
                ctx.Estudios.Remove(estudioBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(x => x.Jogos).ToList();
        }

        public Estudio ListarPorId(int id)
        {
            return ctx.Estudios.FirstOrDefault(x => x.IdEstudio == id);
        }

        public List<Estudio> ListarTodos()
        {
            return (ctx.Estudios.ToList());
        }
    }
}
