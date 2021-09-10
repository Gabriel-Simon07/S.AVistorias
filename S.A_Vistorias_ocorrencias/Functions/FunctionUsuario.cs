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
		public static Usuario getNameById(string nome)
		{
            {
                Usuario usuario = new Usuario();

                MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

                string query = $"SELECT usuario.nome FROM usuario WHERE nome = '{nome}' LIMIT 1";

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
                catch(SqlException se)
                {
                    string messageError = se.ToString();
                }

                finally
                {
                    conexao.Close();
                }

                return usuario;
            }
        }

        public static Usuario ObterUsuarioLogin(string login)
		{
            Usuario usuario = new Usuario();

            MySqlConnection conexao  = new MySqlConnection(Functions.ObterConnectionString());

            string query = $"SELECT * FROM usuario WHERE login = '{login}' LIMIT 1";

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
			catch (SqlException se)
			{
                string messageError = se.ToString();
			}
			finally
			{
                conexao.Clone();
			}
            return usuario;
		}

        public static bool validaLogin(string login, string senha)
		{
            Usuario usuario = ObterUsuarioLogin(login);
            return usuario.login == login && usuario.senha == senha;
		}
	}
}