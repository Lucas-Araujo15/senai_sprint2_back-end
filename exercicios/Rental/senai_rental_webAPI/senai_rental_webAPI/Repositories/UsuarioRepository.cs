using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = @"Data source=DESKTOP-SV3M4A7\SQLEXPRESS; initial catalog=rental; user id = sa; pwd=Senai@132";
        public void Atualizar(UsuarioDomain novoUsuario)
        {
            if (novoUsuario.IdTipoUsuario != 0 || novoUsuario.nomeUsuario != null || novoUsuario.email != null || novoUsuario.senha != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdate = "UPDATE usuario SET IdTipoUsuario = @IdTipoUsuario, nomeUsuario = @nomeUsuario, email = @email, senha = @senha WHERE IdUsuario = @IdVeiculo";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@IdTipoUsuario", novoUsuario.IdTipoUsuario);
                        cmd.Parameters.AddWithValue("@nomeUsuario", novoUsuario.nomeUsuario);
                        cmd.Parameters.AddWithValue("@email", novoUsuario.email);
                        cmd.Parameters.AddWithValue("@senha", novoUsuario.senha);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectById = "SELECT IdUsuario,  usuario.IdTipoUsuario, nomeUsuario, email, nomeTipoUsuario FROM usuario INNER JOIN tipoUsuario ON tipoUsuario.IdTipoUsuario = usuario.IdTipoUsuario WHERE IdUsuario = @IdUsuario";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", id);
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[1]),
                            nomeTipoUsuario = rdr[4].ToString()
                        };

                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            IdTipoUsuario = Convert.ToInt32(rdr[1]),
                            nomeUsuario = rdr[2].ToString(),
                            email = rdr[3].ToString(),
                            tipoUsuario = tipoUsuario
                        };
                        return usuario;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int IdUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM usuario WHERE IdUsuario = @IdUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO usuario (IdTipoUsuario, nomeUsuario, email, senha) VALUES (@IdTipoUsuario, @nomeUsuario, @email, @senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@IdTipoUsuario", usuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@nomeUsuario", usuario.nomeUsuario);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@senha", usuario.senha);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListarTodos()
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectById = "SELECT IdUsuario,  usuario.IdTipoUsuario, nomeUsuario, email, nomeTipoUsuario FROM usuario INNER JOIN tipoUsuario ON tipoUsuario.IdTipoUsuario = usuario.IdTipoUsuario";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();
                    List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[1]),
                            nomeTipoUsuario = rdr[4].ToString()
                        };

                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            IdTipoUsuario = Convert.ToInt32(rdr[1]),
                            nomeUsuario = rdr[2].ToString(),
                            email = rdr[3].ToString(),
                            tipoUsuario = tipoUsuario
                        };

                        listaUsuarios.Add(usuario);
                    }
                    return listaUsuarios;
                }
            }
        }
    }
}
