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
		public bool status { get; set; }
		public DateTime dataAbertura { get; set; }
		public Int32 idUsuario { get; set; }
		public string imagem { get; set; }
		public string descricao { get; set; }
		public string endereco { get; set; }

		public Vistoria() { }

		public Vistoria(Int32 idVistoria, bool status, DateTime data, string imagem, string descricao, string endereco)
		{
			this.idVistoria = idVistoria;
			this.status = status;
			this.dataAbertura = data;
			this.imagem = imagem;
			this.descricao = descricao;
			this.endereco = endereco;
		}

		public Vistoria(MySqlDataReader dadoLido)
		{
			this.idVistoria = !dadoLido.IsDBNull(0) ? dadoLido.GetInt32(0) : 0;
			this.status = !dadoLido.IsDBNull(1) ? dadoLido.GetBoolean(1) : true;
			this.dataAbertura = !dadoLido.IsDBNull(2) ? dadoLido.GetDateTime(2) : DateTime.MinValue;
			this.idUsuario = !dadoLido.IsDBNull(3) ? dadoLido.GetInt32(3) : 0;
			this.imagem = !dadoLido.IsDBNull(4) ? dadoLido.GetString(4) : "";
			this.descricao = !dadoLido.IsDBNull(5) ? dadoLido.GetString(5) : "";
			this.endereco = !dadoLido.IsDBNull(6) ? dadoLido.GetString(6) : "";
		}

		
	}
}