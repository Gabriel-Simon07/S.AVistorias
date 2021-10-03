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
		public static Vistoria GetVistoriaById(Int32 idVistoria)
		{
			Vistoria vistoria = new Vistoria();

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = $"SELECT  * FROM vistoria WHERE id_vistoria = '{idVistoria}' LIMIT 1";

			MySqlCommand comando = new MySqlCommand(query, conexao);
			try
			{
				conexao.Open();

				MySqlDataReader dadoLido = comando.ExecuteReader();

				while (dadoLido.Read())
				{
					vistoria = new Vistoria(dadoLido);
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
			return vistoria;
		}

		public static Usuario GetUsuarioById(Int32 idUsuario)
		{
			Usuario usuario = new Usuario();

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = $"SELECT  * FROM usuario WHERE id_usuario = '{idUsuario}' LIMIT 1";

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
				string erro = se.ToString();
			}
			finally
			{
				conexao.Close();
			}
			return usuario;
		}

		public static string ObterConnectionString()
		{
			return "server=localhost;userid=root;sslmode=None;database=s_a_vistoria_e_ocorrencias";
		}

		public static bool ValidaUsuario(string login, string senha)
		{
			Usuario usuario = ObterUsuarioPorLogin(login);
			return usuario.login == login && usuario.senha == senha;	
		}

		public static Usuario ObterUsuarioPorLogin(string login)
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

		public static List<Vistoria> TodasVistorias()
		{
			List<Vistoria> lista = new List<Vistoria>();

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = "SELECT id_vistoria, id_usuario, status_vistoria, data_abertura, endereco, imagem_local, descricao_vistoria FROM vistoria";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();

				MySqlDataReader dadoLido = comando.ExecuteReader();

				while (dadoLido.Read())
				{
					lista.Add(new Vistoria(dadoLido));
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
			return lista;
		}

		public static void DeletarVistoriaById(Int32 idVistoria)
		{
			Vistoria vistoria = Functions.GetVistoriaById(idVistoria);

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());
			string query = "Delete From VISTORIA where id_vistoria = @id_vistoria";
			MySqlCommand comando = new MySqlCommand(query, conexao);
			try
			{
				conexao.Open();
				comando.Parameters.AddWithValue("@id_vistoria", idVistoria);
				comando.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				string errorMessage = ex.ToString();
			}
			finally
			{
				conexao.Close();
			}
		}
		public static List<Ocorrencia> TodasOcorrencias(Int32 id_vistoria)
		{
			List<Ocorrencia> lista = new List<Ocorrencia>();

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = "SELECT * FROM ocorrencia WHERE id_vistoria = @id_vistoria";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();
				comando.Parameters.AddWithValue("@id_vistoria", id_vistoria);

				MySqlDataReader dadoLido = comando.ExecuteReader();

				while (dadoLido.Read())
				{
					lista.Add(new Ocorrencia(dadoLido));
				}
			}
			catch (SqlException se)
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

		public static void SalvarVistoria(Vistoria vistoria)
		{
			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = "INSERT INTO vistoria (id_usuario, status_vistoria, endereco, " +
				" descricao_vistoria, imagem_local, data_abertura) VALUES (@id_usuario, @status_vistoria, @endereco, @descricao_vistoria, @imagem_local, @data_abertura)";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();

				comando.Parameters.AddWithValue("@id_usuario", vistoria.idUsuario);
				comando.Parameters.AddWithValue("@status_vistoria", vistoria.status);
				comando.Parameters.AddWithValue("@data_abertura", vistoria.dataAbertura);
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

			string query = $"UPDATE ocorrencia set descricao = @descricao, data_ocorrencia = @data_ocorrencia, tipo = @tipo WHERE id_ocorrencia = @id_ocorrencia";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();
				comando.Parameters.AddWithValue("@id_ocorrencia", ocorrencia.idOcorrencia);
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

		public static void AtualizarVistoria(Vistoria vistoria)
		{
			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = $"UPDATE vistoria set id_usuario = @id_usuario, status_vistoria = @status_vistoria, data_abertura = @data_abertura, endereco = @endereco, " +
				"imagem_local = @imagem_local, descricao_vistoria = @descricao_vistoria WHERE id_vistoria = @id_vistoria";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();
				comando.Parameters.AddWithValue("@id_vistoria", vistoria.idVistoria);
				comando.Parameters.AddWithValue("@id_usuario", vistoria.idUsuario);
				comando.Parameters.AddWithValue("@status_vistoria", vistoria.status);
				comando.Parameters.AddWithValue("@data_abertura", vistoria.dataAbertura);
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

		public static Ocorrencia getOcorrenciaByIdVistoria(Int32 idVistoria)
		{
			Ocorrencia ocorrencia = new Ocorrencia();

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = $"SELECT  * FROM ocorrencia WHERE id_vistoria = '{idVistoria}' LIMIT 1";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();

				MySqlDataReader dadoLido = comando.ExecuteReader();

				while (dadoLido.Read())
				{
					ocorrencia = (new Ocorrencia(dadoLido));
				}

			}
			catch (SqlException se)
			{
				string messageError = se.ToString();
			}
			finally
			{
				conexao.Close();
			}
			return ocorrencia;
		}

		public static void deletarOcorrenciaById(Int32 idOcorrencia)
		{
			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = "Delete From OCORRENCIA where id_ocorrencia = @id_ocorrencia";
			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();
				comando.Parameters.AddWithValue("@id_ocorrencia", idOcorrencia);
				comando.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				string errorMessage = ex.ToString();
			}
			finally
			{
				conexao.Close();
			}
		}

		public static List<Ocorrencia> getOcorrenciaByParametros(List<string>parametros)
		{
			List<Ocorrencia> listaOcorrencia = new List<Ocorrencia>();	

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = "SELECT * FROM ocorrencia";
			string where = string.Empty;
			int i = 0;

			foreach (string parametro in parametros)
			{
				if(parametro != string.Empty)
				{
					switch (i)
					{
						case 0:
							where += "id_ocorrencia = @id_ocorrencia";
							break;
						case 1:
							where += where != string.Empty ? " AND " : "";
							where += "id_vistoria = @id_vistoria";
							break;
						case 2:
							where += where != string.Empty ? " AND " : "";
							where += " data_ocorrencia >= @dataInicial"; //?
							break;
						case 3:
							where += where != string.Empty ? " AND " : "";
							where += " data_ocorrencia <= @dataFinal";//?
							break;
						case 4:
							where += where != string.Empty ? " AND " : "";
							where += " descricao = @descricao";
							break;
						case 5:
							where += where != string.Empty ? " AND " : "";
							where += " tipo = @tipo";
							break;
					}
				}
				i++;
			}
			if (where != string.Empty)
				where = " WHERE " + where;

			query += where;

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();
				comando.Parameters.AddWithValue("@id_ocorrencia", parametros[0]);
				comando.Parameters.AddWithValue("@tipo", parametros[1]);
				comando.Parameters.AddWithValue("@id_vistoria", parametros[2]);
				comando.Parameters.AddWithValue("@descricao", parametros[4]);
				MySqlDataReader dadoLido = comando.ExecuteReader();

				while (dadoLido.Read())
				{
					listaOcorrencia.Add(new Ocorrencia(dadoLido));
				}

			}
			catch (SqlException ex)
			{
				string error = ex.ToString();
			}
			finally
			{
				conexao.Close();
			}
			return listaOcorrencia;
		}
	}

}