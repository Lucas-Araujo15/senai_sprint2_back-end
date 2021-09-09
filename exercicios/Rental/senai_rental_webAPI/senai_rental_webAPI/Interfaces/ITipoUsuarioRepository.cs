using senai_rental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuários cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuários</returns>
        List<TipoUsuarioDomain> ListarTodos();

        /// <summary>
        /// Busca um único tipo de usuário em específico
        /// </summary>
        /// <param name="id">ID do tipo de usuário a ser buscado</param>
        /// <returns>Objeto TipoUsuarioDomain que foi buscado</returns>
        TipoUsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta um tipo de usuário específico
        /// </summary>
        /// <param name="IdTipoUsuario">ID do tipo de usuário a ser deletado</param>
        void Deletar(int IdTipoUsuario);

        /// <summary>
        /// Atualiza as informações de um determinado tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto TipoUsuarioDomain com as novas informações</param>
        void Atualizar(TipoUsuarioDomain novoTipoUsuario);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Objeto TipoUsuarioDomain que será cadastrado</param>
        void Inserir(TipoUsuarioDomain tipoUsuario);
    }
}
