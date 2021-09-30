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

						Int32 id = Int32.Parse(Request.QueryString["id_vistoria"].ToString());

						Vistoria vistoria = Functions.GetVistoriaById(id);

						txtIdVistoria.Text = vistoria.idVistoria.ToString();
						txtData.Text = vistoria.dataAbertura.ToString("yyyy-MM-dd");
						ddlStatus.SelectedValue = vistoria.status;
						txtIdResponsavel.Text = vistoria.idUsuario;
						txtDescricao.Text = vistoria.descricao;
						txtEndereco.Text = vistoria.endereco;

						if (mode != "UPD")
						{
							txtIdVistoria.Enabled = false;
							txtData.Enabled = false;
							ddlStatus.Enabled = false;
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
			string caminhoArquivo = string.Empty;

			if (txtImagem.HasFile)
			{
				caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"] + @"\" + txtImagem.FileName;
				txtImagem.SaveAs(caminhoArquivo);
			}
			Vistoria vistoria = new Vistoria
			{
				dataAbertura = DateTime.Parse(txtData.Text),
				idUsuario = txtIdResponsavel.Text,
				status = ddlStatus.SelectedValue,
				descricao = txtDescricao.Text,
				endereco = txtEndereco.Text,
				imagem = caminhoArquivo
			};

			Functions.SalvarVistoria(vistoria);
			Response.Redirect("TelaListaVistorias.aspx");
		}

		private Vistoria CriarVistoria()
		{
			Vistoria vistoria = new Vistoria();

			string caminhoArquivo = string.Empty;

			if (txtImagem.HasFile) {
				caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"] + @"\" + txtImagem.FileName;
				txtImagem.SaveAs(caminhoArquivo);
			}

			vistoria.idUsuario = txtIdResponsavel.Text;
			vistoria.status = ddlStatus.Text;
			vistoria.dataAbertura = DateTime.Parse(txtData.Text);
			vistoria.descricao = txtDescricao.Text;
			vistoria.endereco = txtEndereco.Text;
			vistoria.imagem = System.Configuration.ConfigurationManager.AppSettings
				["caminhoArquivo"].Replace(@"\", "/") + "/" + txtImagem.FileName;

			return vistoria;
		}

		public static void AtualizarVistoria(string idVistoria, string status, DateTime data, string idUsuario, FileUpload imagem, string descricao, string endereco)
		{
			

			Vistoria vistoria = Functions.GetVistoriaById(Int32.Parse(idVistoria));

			vistoria.status = status;
			vistoria.dataAbertura = data;
			vistoria.idUsuario = idUsuario;
			vistoria.descricao = descricao;
			vistoria.endereco = endereco;
			vistoria.imagem = System.Configuration.ConfigurationManager.AppSettings
				["caminhoArquivo"].Replace(@"\", "/") + "/" + imagem.FileName;
			Functions.AtualizarVistoria(vistoria);
		}

		protected void btnAtualizar_Click(object sender, EventArgs e)
		{

			string caminhoArquivo = string.Empty;
			if (txtImagem.HasFile)
			{
				caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"] + @"\" + txtImagem.FileName;
				txtImagem.SaveAs(caminhoArquivo);
				string arquivoUrl = System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"].Replace(@"\", "/") + "/" + txtImagem.FileName;
			}

			Vistoria vistoria = new Vistoria
			{
				idVistoria = Int32.Parse(txtIdVistoria.Text),
				idUsuario = txtIdResponsavel.Text,
				status = ddlStatus.SelectedValue,
				descricao = txtDescricao.Text,
				endereco = txtEndereco.Text,
				imagem = caminhoArquivo,
				dataAbertura = DateTime.Parse(txtData.Text)		
			};

			Functions.AtualizarVistoria(vistoria);
			Response.Redirect("TelaListaVistorias.aspx");
		}













		protected void btnFechar_Click(object sender, EventArgs e)
		{
			Response.Redirect("TelaListaVistorias.aspx");
		}

		protected void btnExcluir_Click(object sender, EventArgs e)
		{
			Int32 id = Int32.Parse(txtIdVistoria.Text);
			Functions.DeletarVistoriaById(id);
			Response.Redirect("TelaListaVistorias.aspx");
		}
	}
}