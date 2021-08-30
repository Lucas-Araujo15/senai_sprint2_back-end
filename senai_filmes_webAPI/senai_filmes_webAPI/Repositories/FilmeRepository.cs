using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = @"Data source=DESKTOP-PJVB3DK\SQLEXPRESS; initial catalog=catalogo_m; integrated security=true";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idFIlme, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int idFilme)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsertInto = "INSERT INTO filme(idGenero, tituloFilme) VALUES (@idGenero, @tituloFilme)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsertInto, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", novoFilme.idGenero);
                    cmd.Parameters.AddWithValue("@tituloFilme", novoFilme.tituloFilme);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM filme WHERE idFilme = @idFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idFilme", idFilme);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idFilme, filme.idGenero, tituloFilme, nomeGenero FROM filme INNER JOIN genero ON genero.idGenero = filme.idGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        GeneroRepository GeneroFilme = new GeneroRepository();
                        List<GeneroDomain> listaDeGeneros = GeneroFilme.ListarTodos();

                        FilmeDomain filme = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            idGenero = Convert.ToInt32(rdr[1]),
                            tituloFilme = rdr[2].ToString(),
                            genero = listaDeGeneros.Find(x => x.idGenero == Convert.ToInt32(rdr[1]))                            
                        };
                        listaFilme.Add(filme);
                    }
                }
                return listaFilme;
            }
        }
    }
}
