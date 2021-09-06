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
        private string stringConexao = @"Data source=DESKTOP-SV3M4A7\SQLEXPRESS; initial catalog=catalogo_m; user id = sa; pwd=Senai@132";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            if (filme.idFilme != 0 && filme.idGenero != 0 && filme.tituloFilme != null)
            {
                using(SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdate = "UPDATE filme SET idGenero = @idGenero, tituloFilme = @tituloFilme WHERE idFilme = @idFilme";

                    con.Open();

                    using(SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@idGenero", filme.idGenero);
                        cmd.Parameters.AddWithValue("@idFilme", filme.idFilme);
                        cmd.Parameters.AddWithValue("@tituloFilme", filme.tituloFilme);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtualizarIdUrl(int idFilme, FilmeDomain filme)
        {
            if (filme.idGenero != 0 && filme.tituloFilme != null && idFilme != 0)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdate = "UPDATE filme SET idGenero = @idGenero, tituloFilme = @tituloFilme WHERE idFilme = @idFilme";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@idGenero", filme.idGenero);
                        cmd.Parameters.AddWithValue("@idFilme", idFilme);
                        cmd.Parameters.AddWithValue("@tituloFilme", filme.tituloFilme);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public FilmeDomain BuscarPorId(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idFilme, filme.idGenero, tituloFilme, nomeGenero FROM filme INNER JOIN genero ON genero.idGenero = filme.idGenero WHERE idFilme = @idFilme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    cmd.Parameters.AddWithValue("@idFilme", idFilme);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain();
                        genero.nomeGenero = rdr[3].ToString();

                        FilmeDomain filme = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            idGenero = Convert.ToInt32(rdr[1]),
                            tituloFilme = rdr[2].ToString(),
                            genero = genero
                        };
                        return filme;
                    }
                    return null;
                }                
            }
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
