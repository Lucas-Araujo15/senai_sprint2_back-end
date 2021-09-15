using Microsoft.EntityFrameworkCore;
using senai.inlock.webAPI.CF.Contexts;
using senai.inlock.webAPI.CF.Domains;
using senai.inlock.webAPI.CF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.CF.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(Estudios novoEstudio)
        {
            ctx.Estudios.Update(novoEstudio);
            ctx.SaveChanges();
        }

        public void Cadastrar(Estudios estudio)
        {
            ctx.Estudios.Add(estudio);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudios estudioBuscado = ListarPorId(id);

            if (estudioBuscado != null)
            {
                ctx.Estudios.Remove(estudioBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Estudios> ListarComJogos()
        {
            return ctx.Estudios.Include(x => x.listaJogos).ToList();
        }

        public Estudios ListarPorId(int id)
        {
            return ctx.Estudios.FirstOrDefault(x => x.idEstudio == id);
        }

        public List<Estudios> ListarTodos()
        {
            return (ctx.Estudios.ToList());
        }
    }
}
