using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void Atualizar(ClienteDomain novoCliente)
        {
            throw new NotImplementedException();
        }

        public ClienteDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idCliente)
        {
            throw new NotImplementedException();
        }

        public void Inserir(ClienteDomain cliente)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
