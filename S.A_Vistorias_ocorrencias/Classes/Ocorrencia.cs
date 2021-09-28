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
	public class Ocorrencia
	{

		public Int32 idOcorrencia { get; set; }
		public Int32 idVistoria { get; set; }
		public string descricao { get; set; }
		public DateTime dataOcorrencia { get; set; }
		public Enum tipo { get; set; }

		public Ocorrencia() { }

		public Ocorrencia(Int32 idVistoria, Int32 idOcorrencia, string descricao, DateTime data, Enum tipo)
		{
			this.idVistoria = idVistoria;
			this.idOcorrencia = idOcorrencia;
			this.descricao = descricao;
			this.dataOcorrencia = data;
			this.tipo = tipo;
		}

		public Ocorrencia(MySqlDataReader dadoLido) {
			this.idOcorrencia = !dadoLido.IsDBNull(0) ? dadoLido.GetInt32(0) : 0;
			this.idVistoria = !dadoLido.IsDBNull(2) ? dadoLido.GetInt32(2) : 0;
			this.descricao = !dadoLido.IsDBNull(4) ? dadoLido.GetString(4) : "";
			this.dataOcorrencia = !dadoLido.IsDBNull(3) ? dadoLido.GetDateTime(3) : DateTime.MinValue;
			string tipoStr = !dadoLido.IsDBNull(1) ? dadoLido.GetString(1) : "AMBIENTE";
			this.tipo = Enumeradores.Parse(typeof(Enumeradores.Tipo), tipoStr);

		}
	}
}