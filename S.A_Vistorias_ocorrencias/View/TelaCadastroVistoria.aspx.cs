using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace S.A_Vistorias_ocorrencias.View
{
	public partial class CadastroVistoria : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnInserir_Click(object sender, EventArgs e)
		{
			// DateTime dataAtual = DateTime.Now;
			//INSERIR DATA NO CONSTRUTOR DO CADASTRO
			Vistoria vistoria = new Vistoria();
			CadastrarVistoria(txtIdResponsavel.Text, txtStatus.Text, txtImagem, txtDescricao.Text, txtEndereco.Text);
			Functions.SalvarVistoria(vistoria);
			
		}

		//INSERIR DATA NO CONSTRUTOR DO CADASTRO
		private void CadastrarVistoria(string idResponsavel, string status, FileUpload imagem, string descricao, string endereco)
		{
			string caminhoArquivo = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoArquivo"] + @"\" + imagem.FileName;
			txtImagem.SaveAs(caminhoArquivo);

			Vistoria vistoria = new Vistoria();
			
			vistoria.idUsuario = idResponsavel;
			//INSERIR DATA NO CONSTRUTOR DO CADASTRO
			//vistoria.dataAbertura = data;
			vistoria.descricao = descricao;
			vistoria.endereco = endereco;
			vistoria.idUsuario = idResponsavel;
			vistoria.status = status;
			vistoria.imagem = System.Configuration.ConfigurationManager.AppSettings
				["caminhoArquivo"].Replace(@"\", "/") + "/" + imagem.FileName;
			Functions.SalvarVistoria(vistoria);
		}
	}
}