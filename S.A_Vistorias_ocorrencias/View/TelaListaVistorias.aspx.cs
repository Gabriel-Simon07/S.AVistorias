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

			//acima verifica se esta logado 

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

		protected void GridViewUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
		{

			int indiceLinha = Convert.ToInt32(e.CommandName);

			GridViewRow linha = gdListaVistorias.Rows[indiceLinha];

			Int32 id_vistoria = int.Parse(linha.Cells[1].Text);

			if (e.CommandName == "Visualizar")
			{
				Response.Redirect($"TelaCadastroVistoria.aspx?mode=visualizar&id_vistoria={id_vistoria}");
			}

			if(e.CommandName == "Ocorrencia")
			{
				Response.Redirect($"TelaListaOcorrencias.aspx?mode=ocorrencia&id_vistoria={id_vistoria}");
			}

			if(e.CommandName == "Alterar")
			{
				Response.Redirect($"TelaCadastroVistoria.aspx?mode=alterar&id_vistoria={id_vistoria}");
			}
		}
	}
}