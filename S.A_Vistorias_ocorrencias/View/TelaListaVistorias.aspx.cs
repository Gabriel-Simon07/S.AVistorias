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

		}

		protected void btnInserirVistoria_Click(object sender, EventArgs e)
		{
			Response.Redirect("TelaCadastroVistoria.aspx");
		}
	}
}