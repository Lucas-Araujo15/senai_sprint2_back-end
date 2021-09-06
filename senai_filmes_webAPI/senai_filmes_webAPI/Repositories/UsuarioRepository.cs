using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = @"Data source=DESKTOP-SV3M4A7\SQLEXPRESS; initial catalog=catalogo_m; user id = sa; pwd=Senai@132";
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            if (email != null && senha != null)
            {
                using(SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryAutenticacao = "SELECT idUsuario, email, senha, permissao FROM usuario WHERE email = @email AND senha = @senha";

                    con.Open();

                    SqlDataReader rdr;

                    using(SqlCommand cmd = new SqlCommand(queryAutenticacao, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            UsuarioDomain usuario = new UsuarioDomain()
                            {
                                idUsuario = Convert.ToInt32(rdr[0]),
                                email = rdr[1].ToString(),
                                senha = rdr[2].ToString(),
                                permissao = rdr[3].ToString()
                            };
                            return usuario;
                        }
                    }
                }                
            }
            return null;
        }
    }
}
