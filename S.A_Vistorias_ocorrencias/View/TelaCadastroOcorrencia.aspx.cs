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
	public partial class TelaCadastroOcorrencia : System.Web.UI.Page
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
				txtIdVistoria.Text = Request.QueryString["id_vistoria"];
				txtIdOcorrencia.Text = Request.QueryString["id_ocorrencia"];

				if (!IsPostBack)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "script", "", true);

					string mode = Request.QueryString["mode"];

					btnInserir.Visible = mode == "INS" ? true : false;
					btnAtualizar.Visible = mode == "UPD" ? true : false;
					btnExcluir.Visible = mode == "DEL" ? true : false;

					if (mode != "INS")
					{

						Int32 idOcorrencia = Int32.Parse(Request.QueryString["id_vistoria"].ToString());

						Ocorrencia ocorrencia = Functions.getOcorrenciaByIdVistoria(idOcorrencia);

						txtIdVistoria.Text = ocorrencia.idVistoria.ToString();
						txtIdOcorrencia.Text = ocorrencia.idOcorrencia.ToString();
						txtData.Text = ocorrencia.dataOcorrencia.ToString("yyyy-MM-dd");
						dplTipo.SelectedValue = ocorrencia.tipo.ToString();
						txtDescricao.Text = ocorrencia.descricao;

						if (mode != "UPD")
						{
							txtIdVistoria.Enabled = false;
							txtData.Enabled = false;
							txtIdOcorrencia.Enabled = false;
							txtDescricao.Enabled = false;
							dplTipo.Enabled = false;
						}
					}
				}
			}
		}

		public static void getListOcorrencias()
		{

		}

		protected void btnAtualizar_Click(object sender, EventArgs e)
		{
			Int32 vistoriaId = Int32.Parse(Request.QueryString["id_vistoria"]);
			Int32 ocorrenciaId = Int32.Parse(Request.QueryString["id_ocorrencia"]);

			Ocorrencia ocorrencia = new Ocorrencia
			{
				idVistoria = vistoriaId,
				idOcorrencia = ocorrenciaId,
				dataOcorrencia = DateTime.Parse(txtData.Text),
				tipo = (Enumeradores.Tipo)Enum.Parse(typeof(Enumeradores.Tipo), dplTipo.SelectedValue),
				descricao = txtDescricao.Text
			};
			Functions.AtualizarOcorrencia(ocorrencia);
			Response.Redirect($"TelaListaOcorrencias.aspx?id_vistoria={vistoriaId}");
		}

		protected void btnInserir_Click(object sender, EventArgs e)
		{
			Int32 vistoriaId = Int32.Parse(Request.QueryString["id_vistoria"]);

			Ocorrencia ocorrencia = new Ocorrencia
			{
				idVistoria = vistoriaId,
				dataOcorrencia = DateTime.Parse(txtData.Text),
				tipo = (Enumeradores.Tipo) Enum.Parse(typeof(Enumeradores.Tipo), dplTipo.SelectedValue),
				descricao = txtDescricao.Text
			};

			Functions.SalvarOcorrencia(ocorrencia);
			Response.Redirect($"TelaListaOcorrencias.aspx?id_vistoria={vistoriaId}");
		}

		protected void btnExcluir_Click(object sender, EventArgs e)
		{
			Int32 vistoriaId = Int32.Parse(Request.QueryString["id_vistoria"]);
			Int32 ocorrenciaId = Int32.Parse(Request.QueryString["id_ocorrencia"]);

			Functions.deletarOcorrenciaById(ocorrenciaId);
			Response.Redirect($"TelaListaOcorrencias.aspx?id_vistoria={vistoriaId}");
		}

		protected void btnFechar_Click(object sender, EventArgs e)
		{
			Int32 vistoriaId = Int32.Parse(Request.QueryString["id_vistoria"]);
			Response.Redirect($"TelaListaOcorrencias.aspx?id_vistoria={vistoriaId}");
		}
	}
}