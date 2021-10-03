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
	public partial class ListaVistorias : System.Web.UI.Page
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
				gdListaVistorias.DataSource = Functions.TodasVistorias();
				gdListaVistorias.DataBind();
			}

		}

		protected void btnInserirVistoria_Click(object sender, EventArgs e)
		{
			Response.Redirect("TelaCadastroVistoria.aspx?mode=INS");
		}

		protected void gdListaVistorias_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int rowIndex = Convert.ToInt32(e.CommandArgument);
		
			GridViewRow row = gdListaVistorias.Rows[rowIndex];
			
			Int32 vistoriaId = Int32.Parse(row.Cells[1].Text);

			string mode;

			switch (e.CommandName)
			{
				case "Alterar":

					mode = "UPD";
					Response.Redirect($"TelaCadastroVistoria.aspx?mode={mode}&id_vistoria={vistoriaId}");
					break;

				case "Excluir":

					mode = "DEL";
					Response.Redirect($"TelaCadastroVistoria.aspx?mode={mode}&id_vistoria={vistoriaId}");
					break;

				default:

					mode = "DSP";
					Response.Redirect($"TelaCadastroVistoria.aspx?mode={mode}&id_vistoria={vistoriaId}");
					break;

				case "Ocorrencia":

					Response.Redirect($"TelaListaOcorrencias.aspx?id_vistoria={vistoriaId}");
					
					break;

			}
		}

		protected void btnPesquisar_Click(object sender, EventArgs e)
		{
			
		}

		protected void ButtonLogouta_Click(object sender, ImageClickEventArgs e)
		{
			Session["Login"] = string.Empty;
			Response.Redirect("TelaLogin.aspx");
		}
	}
}