using senai.inlock.webAPI.efcore.Domains;
using System.Collections.Generic;

namespace senai.inlock.webAPI.efcore.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="estudio">Objeto Estudio que será cadastrado</param>
        void Cadastrar(Estudio estudio);

        /// <summary>
        /// Deleta um estúdio em específico
        /// </summary>
        /// <param name="id">ID do estúdio a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza as informações de um estúdio já existente
        /// </summary>
        /// <param name="novoEstudio">Objeto Estudio com as novas informações</param>
        void Atualizar(Estudio novoEstudio);

        /// <summary>
        /// Lista todos os estúdios cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de estúdios</returns>
        List<Estudio> ListarTodos();

        /// <summary>
        /// Lista um estúdio em específico
        /// </summary>
        /// <param name="id">ID do estúdio que será listado</param>
        /// <returns>Objeto Estudio que foi encontrado</returns>
        Estudio ListarPorId(int id);

        /// <summary>
        /// Lista todos os estúdios e inclui a lista de jogos daquele determinado estúdio
        /// </summary>
        /// <returns>Lista de estúdios</returns>
        List<Estudio> ListarComJogos();
    }
}
