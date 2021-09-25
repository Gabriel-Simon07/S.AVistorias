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
				if (!IsPostBack)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "script", "", true);

					string mode = Request.QueryString["mode"];

					btnInserir.Visible = mode == "INS" ? true : false;
					btnAtualizar.Visible = mode == "UPD" ? true : false;
					btnExcluir.Visible = mode == "DEL" ? true : false;

					if (mode != "INS")
					{

						Int32 id = Int32.Parse(Request.QueryString["id"].ToString());
						//CORRIGIR, OBTER LISTA DE OCORRENCIAS DA VISTORIA
						//Vistoria vistoria = Functions.getOcorrenciaByIdVistoria();

						//txtIdVistoria.Text = vistoria.idVistoria.ToString();
						//txtData.Text = vistoria.dataAbertura.ToString("yyyy-MM-dd");
						//txtIdOcorrencia.Text = vistoria.idVistoria.ToString();
						//dplTipo.SelectedValue = vistoria.status;
						//txtDescricao.Text = vistoria.descricao;

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

		

		public static void atualizarOcorrencia(string idOcorrencia, string descricao, Enum tipo)
		{
			Ocorrencia ocorrencia = Functions.getOcorrenciaByIdVistoria(Int32.Parse(idOcorrencia));
			ocorrencia.descricao = descricao;
			ocorrencia.tipo = tipo;

			Functions.AtualizarOcorrencia(ocorrencia);
		}

		public static void deletarOcorrenciaById(string idOcorrencia)
		{
			Ocorrencia ocorrencia = Functions.getOcorrenciaByIdVistoria(Int32.Parse(idOcorrencia));

			//Functions.TodasOcorrencias().Remove(ocorrencia);	
		}

		public static void getListOcorrencias()
		{

		}

		public static void CadastrarOcorrencia(Int32 idVistoria, string descricao, DateTime data, Enum tipo)
		{
			Ocorrencia ocorrencia = new Ocorrencia();

			ocorrencia.idVistoria = idVistoria;
			ocorrencia.descricao = descricao;
			ocorrencia.dataOcorrencia = data;
			ocorrencia.tipo = tipo;

			Functions.SalvarOcorrencia(ocorrencia);
		}

		protected void btnAtualizar_Click(object sender, EventArgs e)
		{

		}
	}
}