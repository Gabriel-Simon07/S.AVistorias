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
			string login = string.Empty;

			if (Session["Login"] != null)
			{
				login = Session["Login"].ToString();
			}

			if (login == string.Empty)
			{
				Response.Redirect("TelaLogin.aspx");
			}
			else
			{
				if (!IsPostBack)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "script", "", true);

					string mode = Request.QueryString["mode"];

					btnInserir.Visible = mode == "INS" ? true : false;
					btnAtualizar.Visible = mode == "UPD" ? true : false;
					btnExcluir.Visible = mode == "DEL" ? true : false;

					if (mode != "INS")
					{

						Int32 id = Int32.Parse(Request.QueryString["id"].ToString());

						Vistoria vistoria = Functions.GetVistoriaById(id);

						txtIdVistoria.Text = vistoria.idVistoria.ToString();
						txtData.Text = vistoria.dataAbertura.ToString("yyyy-MM-dd");
						txtStatus.Text = vistoria.status.ToString();
						txtIdResponsavel.Text = vistoria.idUsuario;
						txtDescricao.Text = vistoria.descricao;
						txtEndereco.Text = vistoria.endereco;

						if (mode != "UPD")
						{
							txtIdVistoria.Enabled = false;
							txtData.Enabled = false;
							txtStatus.Enabled = false;
							txtDescricao.Enabled = false;
							txtIdResponsavel.Enabled = false;
							txtEndereco.Enabled = false;
						}
					}
				}
			}
		
		}

		protected void btnInserir_Click(object sender, EventArgs e)
		{ 
			Vistoria vistoria = CriarVistoria();
			Functions.SalvarVistoria(vistoria);
			Response.Redirect("TelaListaVistorias.aspx");
		}

		//INSERIR DATA NO CONSTRUTOR DO CADASTRO
		private Vistoria CriarVistoria()
		{
			Vistoria vistoria = new Vistoria();

			string caminhoArquivo = string.Empty;

			if (txtImagem.HasFile) {
				caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"] + @"\" + txtImagem.FileName;
				txtImagem.SaveAs(caminhoArquivo);
			}

			vistoria.idUsuario = txtIdResponsavel.Text;
			vistoria.status = txtStatus.Text;
			vistoria.dataAbertura = DateTime.Parse(txtData.Text);
			vistoria.descricao = txtDescricao.Text;
			vistoria.endereco = txtEndereco.Text;
			vistoria.imagem = System.Configuration.ConfigurationManager.AppSettings
				["caminhoArquivo"].Replace(@"\", "/") + "/" + txtImagem.FileName;

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

		

		protected void btnAtualizar_Click(object sender, EventArgs e)
		{
			Vistoria vistoria = CriarVistoria();
			Functions.AtualizarVistoria(vistoria);
			Response.Redirect("TelaListaVistorias.aspx");
		}
	}
}