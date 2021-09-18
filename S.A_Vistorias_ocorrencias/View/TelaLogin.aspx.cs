using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace S.A_Vistorias_ocorrencias
{
	public partial class TelaLogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				txtUsuario.Text = string.Empty;
				txtSenha.Text = string.Empty;
			}

			if (HttpContext.Current.Session["Logado"] == null)
			{
				Session["Login"] = string.Empty;
				Session["Logado"] = false;
			}
		}

		protected void btnConfirmar_Click(object sender, EventArgs e)
		{
			bool temError = false;
			string mensagemErro = string.Empty;

			string usuario = txtUsuario.Text = string.Empty;
			string senha = txtSenha.Text = string.Empty;

			if (!temError)
			{
				if(usuario == string.Empty)
				{
					temError = true;
					mensagemErro = "Informe um usuário válido ("+ usuario +")";
				}
			}

			if (!temError)
			{
				if(senha == string.Empty)
				{
					temError = true;
					mensagemErro = "Informe uma senha válida";
				}
			}

			if (!temError)
			{
				if (Functions.ValidaUsuario(usuario, senha))
				{
					Session["NomeLogin"] = usuario;
					Session["Logado"] = true;
				}
				else
				{
					temError = true;
					mensagemErro = "Usuário ou senha incorreto!("+ usuario +")("+ senha +")";

				}
			}

			if (temError)
				Response.Write("<script>alert('Erro: " + mensagemErro + " " + usuario + "')<script>");
		}
	}
}