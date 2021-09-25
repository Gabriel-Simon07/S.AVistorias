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
				Int32 id_vistoria = Int32.Parse(Request.QueryString["id_vistoria"]);
				List<Ocorrencia> ocorrencias = Functions.TodasOcorrencias(id_vistoria);
				gvListaOcorrencias.DataSource = ocorrencias;
				gvListaOcorrencias.DataBind();
			}
		}

		protected void btnInserir_Click(object sender, EventArgs e)
		{
			Response.Redirect("TelaCadastroOcorrencia.aspx?acao=INS");

		}
	}
}