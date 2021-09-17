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
	public class FunctionVistoria
	{
		public static Vistoria GetVistoriaComOcorrenciaById(Int32 idVistoria)
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

		public static void AtualizarVistoriaById()
		{

		}

		public static void DeletarVistoriaById(string idVistoria)
		{
			Vistoria vistoria = new Vistoria
		}

		public static void CadastrarVistoria()
		{

		}

		public static void GetListVistoria()
		{

		}
	}
}