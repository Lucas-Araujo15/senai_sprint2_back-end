using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository


    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parêmetros
        /// Data source: Nome do servidor
        /// Initial catalogo: Nome do banco de dados
        /// user id, pwd,: Autenticação com login e senha
        /// integrated securiry: Autenticação com o WIndows
        /// </summary>

        //private string stringConexao = "Data source =; initial catalogo =; user id=sa; pwd=Senai@132";

        private string stringConexao = @"Data source=DESKTOP-SV3M4A7\SQLEXPRESS; initial catalog=catalogo_m; user id = sa; pwd=Senai@132";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            if (genero.idGenero != 0 && genero.nomeGenero != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdate = "UPDATE genero SET nomeGenero = @nomeGenero WHERE idGenero = @idGenero";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@idGenero", genero.idGenero);
                        cmd.Parameters.AddWithValue("@nomeGenero", genero.nomeGenero);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain genero)
        {
            if (genero.nomeGenero != null && idGenero != 0)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdate = "UPDATE genero SET nomeGenero = @nomeGenero WHERE idGenero = @idGenero";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@idGenero", idGenero);
                        cmd.Parameters.AddWithValue("@nomeGenero", genero.nomeGenero);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {            

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idGenero, nomeGenero FROM genero WHERE idGenero = @idGenero;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            nomeGenero = rdr[1].ToString()
                        };
                        return genero;
                    }
                    return null;
                }              
            }
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsertInto = "INSERT INTO genero (nomeGenero) VALUES (@nomeGenero)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsertInto, con))
                {
                    cmd.Parameters.AddWithValue("@nomeGenero", novoGenero.nomeGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM genero WHERE idGenero = @id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idGenero, nomeGenero FROM genero;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            nomeGenero = rdr[1].ToString()
                        };

                        listaGenero.Add(genero);

                    }
                }
                return listaGenero;
            }
        }
    }
}
    

