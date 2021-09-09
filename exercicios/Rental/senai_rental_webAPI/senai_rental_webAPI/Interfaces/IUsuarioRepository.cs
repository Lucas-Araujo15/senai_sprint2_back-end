using senai_rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        List<UsuarioDomain> ListarTodos();

        /// <summary>
        /// Busca um único usuário em específico
        /// </summary>
        /// <param name="id">ID do usuário a ser buscado</param>
        /// <returns>Objeto UsuarioDomain que foi buscado</returns>
        UsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta um usuário específico
        /// </summary>
        /// <param name="IdUsuario">ID do usuário a ser deletado</param>
        void Deletar(int IdUsuario);

        /// <summary>
        /// Atualiza as informações de um determinado usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto UsuarioDomain com as novas informações</param>
        void Atualizar(UsuarioDomain novoUsuario);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto UsuarioDomain que será cadastrado</param>
        void Inserir(UsuarioDomain usuario);
    }
}
