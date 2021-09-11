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
	public class FunctionOcorrencia
	{

		public static Ocorrencia getOcorrenciaByIdVistoria(Int32 idVistoria)
		{
			Ocorrencia ocorrencia = new Ocorrencia();

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = $"SELECT  * ocorrencia FROM ocorrencia WHERE id_vistoria = '{idVistoria}' LIMIT 1";

			MySqlCommand command = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();


			}
			catch (SqlException se)
			{
				string messageError = se.ToString();
			}
			finally
			{
				conexao.Close();
			}
		}
	}
}