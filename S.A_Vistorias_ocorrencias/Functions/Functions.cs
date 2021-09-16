using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace S.A_Vistorias_ocorrencias
{
	public class Functions
	{
		public static string ObterConnectionString()
		{
			return "server=localhost;user id=root;sslmode=None;database=s_a_vistoria_e_ocorrencias";
		}

		public static List<Ocorrencia> TodasOcorrencias()
		{
			List<Ocorrencia> lista = new List<Ocorrencia>();

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = "SELECT * FROM ocorrencia";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();

				MySqlDataReader dadoLido = comando.ExecuteReader();

				while (dadoLido.Read())
				{
					lista.Add(new Ocorrencia(dadoLido));
				}
			}
			catch(SqlException se)
			{
				string error = se.ToString();
			}
			finally
			{
				conexao.Close();
			}
			return lista;
		}

		public static void SalvarOcorrencia(Ocorrencia ocorrencia)
		{
			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = "INSERT INTO ocorrencia (id_vistoria, descricao, data_ocorrencia, tipo) VALUES " +
				"(@id_vistoria, @descricao, @data_ocorrencia, @tipo)";

			MySqlCommand comando = new MySqlCommand(query, conexao);
			
			try
			{
				conexao.Open();
				comando.Parameters.AddWithValue("@id_vistoria", ocorrencia.idVistoria);
				comando.Parameters.AddWithValue("@descricao", ocorrencia.descricao);
				comando.Parameters.AddWithValue("@data_ocorrencia", ocorrencia.dataOcorrencia);
				comando.Parameters.AddWithValue("@tipo", ocorrencia.tipo);
				comando.ExecuteNonQuery();
			}
			catch (SqlException se)
			{
				string erro = se.ToString();
			}
			finally
			{
				conexao.Close();
			}
		}

		public static void AtualizarOcorrencia(Ocorrencia ocorrencia)
		{
			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = "UPDATE ocorrencia set id_vistoria = @id_vistoria, descricao = @descricao, data_ocorrencia = @data_ocorrencia, tipo = @tipo";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();
				comando.Parameters.AddWithValue("@id_vistoria", ocorrencia.idVistoria);
				comando.Parameters.AddWithValue("@descricao", ocorrencia.descricao);
				comando.Parameters.AddWithValue("@data_ocorrencia", ocorrencia.dataOcorrencia);
				comando.Parameters.AddWithValue("@tipo", ocorrencia.tipo);
				comando.ExecuteNonQuery();
			}
			catch (SqlException se)
			{
				string erro = se.ToString();
			}
			finally
			{
				conexao.Close();
			}
		}
	}
}