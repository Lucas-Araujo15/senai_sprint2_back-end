using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeDomain
    /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Retorna todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme pelo ID
        /// </summary>
        /// <param name="idFilme">ID do filme que será buscado</param>
        /// <returns>Objeto FilmeDomain que foi buscado</returns>
        FilmeDomain BuscarPorId(int idFilme);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto FilmeDomain com as informações que serão cadastradas</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um filme passando o ID pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto FilmeDomain com novas informações</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme passando o ID pela URL da requisição
        /// </summary>
        /// <param name="idFIlme">ID do filme a ser atualizado</param>
        /// <param name="filme">Objeto FilmeDomain com as novas informações</param>
        void AtualizarIdUrl(int idFIlme, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme específico
        /// </summary>
        /// <param name="idFilme">ID do filme que será deletado</param>
        void Deletar(int idFilme);
    }
}
