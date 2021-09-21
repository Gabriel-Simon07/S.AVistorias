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
				txtUsuario.Text = string.Empty;
				txtSenha.Text = string.Empty;
			}

			if (HttpContext.Current.Session["Logado"] == null)
			{
				Session["Login"] = string.Empty;
				Session["Logado"] = false;
			}
		}

		protected void logar(string usuario, string senha)
		{
			Usuario usuarioLogar = ObterUsuarioLogin(usuario);
			usuarioLogar.login = usuario;
			usuarioLogar.senha = senha;


			if (usuarioLogar.senha == "12345" && usuarioLogar.login =="Analista")
			{
				Response.Redirect("TelaCadastroVistoria.aspx");
			}
			else if (usuarioLogar.senha == "12345" && usuarioLogar.login == "Operador")
			{
				Response.Redirect("TelaListaVistorias.aspx");
			}
		}

		protected void btnConfirmar_Click(object sender, EventArgs e)
		{
			string mensagemErro = "passei por aqui";
			string usuario = txtUsuario.Text;
			logar(txtUsuario.Text, txtSenha.Text);
			Response.Write("<script>console.log('Erro: " + mensagemErro + " " + usuario + "')<script>");




			bool temError = false;
			// string mensagemErro = string.Empty;

			//string usuario = txtUsuario.Text = string.Empty;
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