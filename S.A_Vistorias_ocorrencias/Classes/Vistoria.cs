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
		public string idUsuario { get; set; }
		public string status { get; set; }
		public DateTime dataAbertura { get; set; }
		public string imagem { get; set; }
		public string descricao { get; set; }
		public string endereco { get; set; }

		public Vistoria() { }

		public Vistoria(Int32 idVistoria, string idUsuario, string status, string descricao, string endereco, string imagem, DateTime data)
		{
			this.idVistoria = idVistoria;
			this.idUsuario = idUsuario;	
			this.status = status;
			this.descricao = descricao;
			this.endereco = endereco;
			this.imagem = imagem;
			this.dataAbertura = data;
		}

		public Vistoria(MySqlDataReader dadoLido)
		{
			this.idVistoria = !dadoLido.IsDBNull(0) ? dadoLido.GetInt32(0) : 0;
			this.idUsuario = !dadoLido.IsDBNull(1) ? dadoLido.GetString(1) : "";
			this.status = !dadoLido.IsDBNull(2) ? dadoLido.GetString(2) : "";
			this.dataAbertura = !dadoLido.IsDBNull(3) ? dadoLido.GetDateTime(3) : DateTime.MinValue;
			this.endereco = !dadoLido.IsDBNull(4) ? dadoLido.GetString(4) : "";
			this.imagem = !dadoLido.IsDBNull(5) ? dadoLido.GetString(5) : "";
			this.descricao = !dadoLido.IsDBNull(6) ? dadoLido.GetString(6) : "";
		}
	}
}