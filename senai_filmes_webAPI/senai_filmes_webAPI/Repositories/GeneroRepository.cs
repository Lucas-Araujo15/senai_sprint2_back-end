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

        private string stringConexao = @"Data source=DESKTOP-PJVB3DK\SQLEXPRESS; initial catalog=catalogo_m; integrated security=true";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "INSERT INTO genero (nomeGenero) VALUES ('" + novoGenero.nomeGenero + "')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idGenero)
        {
            throw new NotImplementedException();
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
    

