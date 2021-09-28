using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace S.A_Vistorias_ocorrencias.View
{
	public partial class TelaListaOcorrencias : System.Web.UI.Page
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
			if (!IsPostBack)
			{
				dptTipo.Items.Add("Ambiental");
				dptTipo.Items.Add("Patrimonial");

				Int32 id_vistoria = Int32.Parse(Request.QueryString["id_vistoria"]);
				txtIdVistoria.Text = id_vistoria.ToString();
				List<Ocorrencia> ocorrencias = Functions.TodasOcorrencias(id_vistoria);
				gdListaOcorrencias.DataSource = ocorrencias;
				gdListaOcorrencias.DataBind();
			}
		}

		protected void btnInserir_Click(object sender, EventArgs e)
		{
			string mode = "INS";
			Int32 vistoriaId = Int32.Parse(txtIdVistoria.Text);
			Response.Redirect($"TelaCadastroOcorrencia.aspx?mode={mode}&id_vistoria={vistoriaId}");
		}
		protected void gdListaOcorrencias_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int rowIndex = Convert.ToInt32(e.CommandArgument);

			GridViewRow row = gdListaOcorrencias.Rows[rowIndex];

			Int32 ocorrenciaId = Int32.Parse(row.Cells[1].Text);
			Int32 vistoriaId = Int32.Parse(row.Cells[2].Text);

			string mode;

			switch (e.CommandName)
			{
				case "Alterar":
					mode = "UPD";
					Response.Redirect($"TelaCadastroOcorrencia.aspx?mode={mode}&id_ocorrencia={ocorrenciaId}&id_vistoria={vistoriaId}");
					break;

				case "Excluir":
					mode = "DEL";
					Response.Redirect($"TelaCadastroOcorrencia.aspx?mode={mode}&id_ocorrencia={ocorrenciaId}&id_vistoria={vistoriaId}");
					break;

				default:
					mode = "DSP";
					Response.Redirect($"TelaCadastroOcorrencia.aspx?mode={mode}&id_ocorrencia={ocorrenciaId}&id_vistoria={vistoriaId}");
					break;
			}
		}
	}
}