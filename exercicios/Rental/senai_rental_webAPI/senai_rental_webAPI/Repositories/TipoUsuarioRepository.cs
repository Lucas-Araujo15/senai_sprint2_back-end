using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = @"Data source=DESKTOP-SV3M4A7\SQLEXPRESS; initial catalog=rental; user id = sa; pwd=Senai@132";
        public void Atualizar(TipoUsuarioDomain novoTipoUsuario)
        {
            if (novoTipoUsuario.nomeTipoUsuario != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdate = "UPDATE tipoUsuario SET nomeTipoUsuario = @nomeTipoUsuario WHERE IdTipoUsuario = @IdTipoUsuario";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@IdTipoUsuario", novoTipoUsuario.IdTipoUsuario);
                        cmd.Parameters.AddWithValue("@nomeTipoUsuario", novoTipoUsuario.nomeTipoUsuario);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectById = "SELECT IdTipoUsuario, nomeTipoUsuario FROM tipoUsuario WHERE IdTipoUsuario = @IdTipoUsuario";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", id);
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            nomeTipoUsuario = rdr[1].ToString()
                        };
                        return tipoUsuario;
                    }
                    return null;
                }
            }
        }

        public void Deletar(int IdTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM tipoUsuario WHERE IdTipoUsuario = @IdTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", IdTipoUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inserir(TipoUsuarioDomain tipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO tipoUsuario (nomeTipoUsuario) VALUES (@nomeTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@nomeTipoUsuario", tipoUsuario.nomeTipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuarioDomain> ListarTodos()
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectById = "SELECT IdTipoUsuario, nomeTipoUsuario FROM tipoUsuario";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();
                    List<TipoUsuarioDomain> listaTiposUsuarios = new List<TipoUsuarioDomain>();

                    while (rdr.Read())
                    {                        
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {                            
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            nomeTipoUsuario = rdr[1].ToString()
                        };

                        listaTiposUsuarios.Add(tipoUsuario);
                    }
                    return listaTiposUsuarios;
                }
            }
        }
    }
}
