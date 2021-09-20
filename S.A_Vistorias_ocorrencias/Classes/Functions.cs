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

		public static bool ValidaUsuario(string login, string senha)
		{
			Usuario usuario = ObterUsuarioPorId(login);
			return usuario.login == login && usuario.senha == senha;	
		}

		public static Usuario ObterUsuarioPorId(string login)
		{
			Usuario usuario = new Usuario();

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = $"SELECT * FROM usuario WHERE login = '{login}'LIMIT 1";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();

				MySqlDataReader dadoLido = comando.ExecuteReader();
				while (dadoLido.Read())
				{
					usuario = (new Usuario(dadoLido));
				}
			}
			catch (SqlException se)
			{
				string erro = se.ToString();
			}
			finally
			{
				conexao.Close();
			}
			return usuario;
		}

		//public static List<Vistoria> TodasVistorias()
		//{
		//	List<Vistoria> lista = new List<Vistoria>();

		//	MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

		//	string query = "SELECT * FROM vistoria";

		//	MySqlCommand comando = new MySqlCommand(query, conexao);

		//	try
		//	{
		//		conexao.Open();

		//		MySqlDataReader dadoLido = comando.ExecuteReader();

		//		while (dadoLido.Read())
		//		{
		//			lista.Add(new Vistoria(dadoLido));
		//		}
		//	}
		//	catch (SqlException se)
		//	{
		//		string erro = se.ToString();
		//	}
		//	finally
		//	{
		//		conexao.Close();
		//	}
		//	return lista;
		//}

		//public static List<Ocorrencia> TodasOcorrencias()
		//{
		//	List<Ocorrencia> lista = new List<Ocorrencia>();

		//	MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

		//	string query = "SELECT * FROM ocorrencia";

		//	MySqlCommand comando = new MySqlCommand(query, conexao);

		//	try
		//	{
		//		conexao.Open();

		//		MySqlDataReader dadoLido = comando.ExecuteReader();

		//		while (dadoLido.Read())
		//		{
		//			lista.Add(new Ocorrencia(dadoLido));
		//		}
		//	}
		//	catch(SqlException se)
		//	{
		//		string error = se.ToString();
		//	}
		//	finally
		//	{
		//		conexao.Close();
		//	}
		//	return lista;
		//}

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

		public static void SalvarVistoria(Vistoria vistoria)
		{
			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			//INSERIR O CAMPO DE DATA NO BANCO, TIREI DO SCRIPT
			string query = "INSERT INTO vistoria (id_usuario, status_vistoria, endereco, " +
				"imagem_local, descricao_vistoria) VALUES (@id_usuario, @status_vistoria, @endereco, @imagem_local, @descricao_vistoria)";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();

				comando.Parameters.AddWithValue("@id_usuario", vistoria.idUsuario);
				comando.Parameters.AddWithValue("@status_vistoria", vistoria.status);
				//comando.Parameters.AddWithValue("@data_abertura", vistoria.dataAbertura);
				comando.Parameters.AddWithValue("@endereco", vistoria.endereco);
				comando.Parameters.AddWithValue("@imagem_local", vistoria.imagem);
				comando.Parameters.AddWithValue("@descricao_vistoria", vistoria.descricao);
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

			//string query = $"UPDATE ocorrencia set id_vistoria = @id_vistoria, descricao = @descricao, data_ocorrencia = @data_ocorrencia, tipo = @tipo WHERE id_ocorrencia '{}'";

			//MySqlCommand comando = new MySqlCommand(query, conexao);

			//try
			//{
			//	conexao.Open();
			//	comando.Parameters.AddWithValue("@id_vistoria", ocorrencia.idVistoria);
			//	comando.Parameters.AddWithValue("@descricao", ocorrencia.descricao);
			//	comando.Parameters.AddWithValue("@data_ocorrencia", ocorrencia.dataOcorrencia);
			//	comando.Parameters.AddWithValue("@tipo", ocorrencia.tipo);
			//	comando.ExecuteNonQuery();
			//}
			//catch (SqlException se)
			//{
			//	string erro = se.ToString();
			//}
			//finally
			//{
			//	conexao.Close();
			//}
		}

		public static void AtualizarVistoria(Vistoria vistoria)
		{
			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			//string query = $"UPDATE vistoria set id_usuario = @id_usuario, status_vistoria = @status_vistoria, data_abertura = @data_abertura, endereco = @endereco, " +
			//	"imagem_local = @imagem_local, descricao_vistoria = @descricao_vistoria WHERE id_vistoria = '{}'"

			//MySqlCommand comando = new MySqlCommand(query, conexao);

			//try
			//{
			//	conexao.Open();
			//	comando.Parameters.AddWithValue("@id_usuario", vistoria.idUsuario);
			//	comando.Parameters.AddWithValue("@status_vistoria", vistoria.status);
			//	comando.Parameters.AddWithValue("@data_abertura", vistoria.dataAbertura);
			//	comando.Parameters.AddWithValue("@endereco", vistoria.endereco);
			//	comando.Parameters.AddWithValue("@imagem_local", vistoria.imagem);
			//	comando.Parameters.AddWithValue("@descricao_vistoria", vistoria.descricao);
			//	comando.ExecuteNonQuery();
			//}
			//catch (SqlException se)
			//{
			//	string erro = se.ToString();
			//}
			//finally
			//{
			//	conexao.Close();
			//}
		}
		}
}