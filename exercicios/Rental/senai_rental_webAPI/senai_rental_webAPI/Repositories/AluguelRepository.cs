using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = @"Data source=DESKTOP-PJVB3DK\SQLEXPRESS; initial catalog=rental; integrated security=true";
        public void Atualizar(AluguelDomain novoAluguel)
        {
            throw new NotImplementedException();
        }

        public AluguelDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idAluguel)
        {
            throw new NotImplementedException();
        }

        public void Inserir(AluguelDomain aluguel)
        {
            
        }

        public List<AluguelDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
