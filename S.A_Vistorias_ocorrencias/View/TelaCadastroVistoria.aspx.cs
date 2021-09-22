using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace S.A_Vistorias_ocorrencias.View
{
	public partial class CadastroVistoria : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnInserir_Click(object sender, EventArgs e)
		{
			// DateTime dataAtual = DateTime.Now;
			//INSERIR DATA NO CONSTRUTOR DO CADASTRO
			//inserir imagem no construtor txtImagem
			Vistoria vistoria = new Vistoria();
			CadastrarVistoria(txtIdResponsavel.Text, dplStatus.Text, txtDescricao.Text, txtEndereco.Text);
			Functions.SalvarVistoria(vistoria);
			
		}

		//INSERIR DATA NO CONSTRUTOR DO CADASTRO
		private void CadastrarVistoria(string idResponsavel, string status, string descricao, string endereco)
		{
			//string caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"] + @"\" + imagem.FileName;
			//txtImagem.SaveAs(caminhoArquivo);

			Vistoria vistoria = new Vistoria();
			
			vistoria.idUsuario = idResponsavel;
			vistoria.status = status;
			//INSERIR DATA NO CONSTRUTOR DO CADASTRO
			//vistoria.dataAbertura = data;
			vistoria.descricao = descricao;
			vistoria.endereco = endereco;
			//vistoria.imagem = System.Configuration.ConfigurationManager.AppSettings
			//	["caminhoArquivo"].Replace(@"\", "/") + "/" + imagem.FileName;
			//Functions.SalvarVistoria(vistoria);
		}

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

		//public static void AtualizarVistoria(string idVistoria, string status, DateTime data, Int32 idUsuario, FileUpload imagem, string descricao, string endereco)
		//{
		//	//string caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"] + @"\" + imagem.FileName;
		//	//inputFoto.SaveAs(caminhoArquivo);

		//	Vistoria vistoria = GetVistoriaComOcorrenciaById(Int32.Parse(idVistoria));

		//	vistoria.status = status;
		//	vistoria.dataAbertura = data;
		//	vistoria.idUsuario = idUsuario;
		//	vistoria.descricao = descricao;
		//	vistoria.imagem = System.Configuration.ConfigurationManager.AppSettings
		//		["caminhoArquivo"].Replace(@"\", "/") + "/" + imagem.FileName;
		//	Functions.AtualizarVistoria(vistoria);
		//}

		//public static void DeletarVistoriaById(string idVistoria)
		//{
		//	Vistoria vistoria = GetVistoriaComOcorrenciaById(Int32.Parse(idVistoria));

		//	Functions.TodasVistorias().Remove(vistoria);
		//}

		public static void GetListVistoria()
		{

		}
	}
}