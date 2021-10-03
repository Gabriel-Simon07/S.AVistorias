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
		public Enumeradores.Tipo tipo { get; set; }

		public Ocorrencia() { }

		public Ocorrencia(Int32 idVistoria, Int32 idOcorrencia, string descricao, DateTime data, string tipo)
		{
			this.idVistoria = idVistoria;
			this.idOcorrencia = idOcorrencia;
			this.descricao = descricao;
			this.dataOcorrencia = data;
			this.tipo = (Enumeradores.Tipo)Enum.Parse(typeof(Enumeradores.Tipo), tipo);
		}

		public Ocorrencia(MySqlDataReader dadoLido) {
			this.idOcorrencia = !dadoLido.IsDBNull(0) ? dadoLido.GetInt32(0) : 0;
			this.tipo = !dadoLido.IsDBNull(1) ? (Enumeradores.Tipo)Enum.Parse(typeof(Enumeradores.Tipo), dadoLido.GetString(1)) : Enumeradores.Tipo.AMBIENTE;
			this.idVistoria = !dadoLido.IsDBNull(2) ? dadoLido.GetInt32(2) : 0;
			this.dataOcorrencia = !dadoLido.IsDBNull(3) ? dadoLido.GetDateTime(3) : DateTime.MinValue;
			this.descricao = !dadoLido.IsDBNull(4) ? dadoLido.GetString(4) : "";

		}
	}
}