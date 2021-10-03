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

namespace S.A_Vistorias_ocorrencias
{
	public partial class TelaLogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				txtLogin.Text = string.Empty;
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
			string login = txtLogin.Text;
			string senha = txtSenha.Text;

			bool temError = false;

			string mensagemErro = string.Empty;
			if (!temError)
			{
				if(login == string.Empty)
				{
					temError = true;
					mensagemErro = "Informe um usuário válido ("+ login +")";
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
				if (Functions.ValidaUsuario(login, senha))
				{
					Session["Login"] = login;
					Session["Logado"] = true;
					Response.Redirect("TelaListaVistorias.aspx");
				}
				else
				{
					temError = true;
					mensagemErro = "Usuário ou senha incorreto!("+ login +")("+ senha +")";

				}
			}

			if (temError)
				Response.Write("<script>alert('Erro: " + mensagemErro + " " + login + "')<script>");
		}

		public static Usuario getNameById(string nome)
		{
			{
				Usuario usuario = new Usuario();

				MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

				string query = $"SELECT usuario.nome FROM usuario WHERE nome = '{nome}' LIMIT 1";

				MySqlCommand comando = new MySqlCommand(query, conexao);

				try
				{
					conexao.Open();

					MySqlDataReader dadoLido = comando.ExecuteReader();

					while (dadoLido.Read())
					{
						usuario = new Usuario(dadoLido);
					}
				}
				catch (SqlException se)
				{
					string messageError = se.ToString();
				}

				finally
				{
					conexao.Close();
				}

				return usuario;
			}
		}

		public static Usuario ObterUsuarioLogin(string login)
		{
			Usuario usuario = new Usuario();

			MySqlConnection conexao = new MySqlConnection(Functions.ObterConnectionString());

			string query = $"SELECT * FROM usuario WHERE login = '{login}' LIMIT 1";

			MySqlCommand comando = new MySqlCommand(query, conexao);

			try
			{
				conexao.Open();

				MySqlDataReader dadoLido = comando.ExecuteReader();
				while (dadoLido.Read())
				{
					usuario = new Usuario(dadoLido);
				}
			}
			catch (SqlException se)
			{
				string messageError = se.ToString();
			}
			finally
			{
				conexao.Clone();
			}
			return usuario;
		}

		public static bool validaLogin(string login, string senha)
		{
			Usuario usuario = ObterUsuarioLogin(login);
			return usuario.login == login && usuario.senha == senha;
		}
	}
}