using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace S.A_Vistorias_ocorrencias
{
	public class Vistoria
	{
		public Int32 idVistoria { get; set; }
		public string status { get; set; }
		public DateTime dataAbertura { get; set; }
		public string idUsuario { get; set; }
		public string imagem { get; set; }
		public string descricao { get; set; }
		public string endereco { get; set; }

		public Vistoria() { }
		//inserir imagem no construtor string imagem
		public Vistoria(string idUsuario, string status, string descricao, string endereco)
		{
			//INSERIR DATA NO CONSTRUTOR
			this.idUsuario = idUsuario;
			this.status = status;
			//this.dataAbertura = data;
			//this.imagem = imagem;
			this.descricao = descricao;
			this.endereco = endereco;
		}

		public Vistoria(MySqlDataReader dadoLido)
		{
			this.idUsuario = !dadoLido.IsDBNull(3) ? dadoLido.GetString(3) : "";
			this.status = !dadoLido.IsDBNull(1) ? dadoLido.GetString(1) : "";
			this.dataAbertura = !dadoLido.IsDBNull(2) ? dadoLido.GetDateTime(2) : DateTime.MinValue;
			this.imagem = !dadoLido.IsDBNull(4) ? dadoLido.GetString(4) : "";
			this.descricao = !dadoLido.IsDBNull(5) ? dadoLido.GetString(5) : "";
			this.endereco = !dadoLido.IsDBNull(6) ? dadoLido.GetString(6) : "";
			this.idVistoria = !dadoLido.IsDBNull(0) ? dadoLido.GetInt32(0) : 0;
		}

		
	}
}