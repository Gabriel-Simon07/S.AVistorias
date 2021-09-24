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
		}
	}
}