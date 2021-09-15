using senai.inlock.webAPI.CF.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.CF.Interfaces
{
    interface IJogosRepositorycs
    {
        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo"></param>
        void Cadastrar(Jogos jogo);

        /// <summary>
        /// Deleta um jogo específico
        /// </summary>
        /// <param name="id">ID do jogo a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza as informações de um jogo específico
        /// </summary>
        /// <param name="novoJogo">Objeto Jogos com as novas informações</param>
        void Atualizar(Jogos novoJogo);

        /// <summary>
        /// Lista todos os jogos cadastrados
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<Jogos> ListarTodos();

        /// <summary>
        /// Lista um jogo específico
        /// </summary>
        /// <param name="id">ID do jogo a ser procurado</param>
        /// <returns>Objeto Jogos que foi encontrado</returns>
        Jogos ListarPorId(int id);
    }
}
