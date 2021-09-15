using senai.inlock.webAPI.efcore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.efcore.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo"></param>
        void Cadastrar(Jogo jogo);

        /// <summary>
        /// Deleta um jogo específico
        /// </summary>
        /// <param name="id">ID do jogo a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza as informações de um jogo específico
        /// </summary>
        /// <param name="novoJogo">Objeto Jogo com as novas informações</param>
        void Atualizar(Jogo novoJogo);

        /// <summary>
        /// Lista todos os jogos cadastrados
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<Jogo> ListarTodos();

        /// <summary>
        /// Lista um jogo específico
        /// </summary>
        /// <param name="id">ID do jogo a ser procurado</param>
        /// <returns>Objeto Jogo que foi encontrado</returns>
        Jogo ListarPorId(int id);
    }
}
