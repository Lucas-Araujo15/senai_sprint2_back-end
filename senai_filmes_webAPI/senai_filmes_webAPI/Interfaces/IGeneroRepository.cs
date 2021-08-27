using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using senai_filmes_webAPI.Domains;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GêneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        // Estrutura de métodos da interface
        // TipoRetorno NomeMetodo (TipoParametro NomeParametro);
        // void Listar();

        /// <summary>
        /// Retorna todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero pelo ID
        /// </summary>
        /// <param name="idGenero">ID do gênero que será buscado</param>
        /// <returns>Um objeto do tipo GeneroDomain que foi buscado</returns>
        GeneroDomain BuscarPorId(int idGenero);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto GeneroDomain com as informações que serão cadastradas</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero passando o ID pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto GeneroDomain com novas informações</param>
        void AtualizarIdCorpo (GeneroDomain genero);

        /// <summary>
        /// Atualiza um gênero passando o ID pela URL da requisição
        /// </summary>
        /// <param name="idGenero">ID do gênero que será atualizado</param>
        /// <param name="genero">Objeto GeneroDomain com as novas informações</param>
        void AtualizarIdUrl(int idGenero, GeneroDomain genero);

        /// <summary>
        /// Deleta um gênero específico
        /// </summary>
        /// <param name="idGenero">ID do gênero que será deletado</param>
        void Deletar(int idGenero);
    }
}
