using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace S.A_Vistorias_ocorrencias.Functions
{
	public class FunctionUsuario
	{
		public static Usuario getNameById(Int32 id)
		{
            {
                Usuario usuario = new Usuario();

                MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

                string query = $"SELECT * FROM usuario WHERE id_usuario = '{id}' LIMIT 1";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                try
                {
                    conexao.Open();

                    MySqlDataReader dadoLido = comando.ExecuteReader();

                    while (dadoLido.Read())
                    {
                        usuario = new Usuario(dadoLido);
                    }
                }
                catch
                {
                    /*error*/
                }

                finally
                {
                    conexao.Close();
                }

                return usuario;

            }
        }
	}
}