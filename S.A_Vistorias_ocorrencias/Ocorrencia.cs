using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S.A_Vistorias_ocorrencias
{
	public class Ocorrencia
	{
		public Int32 IdOcorrencia { get; set; }
		public Int32 IdVistoria { get; set; }
		public string Descricao { get; set; }
		public DateTime DataOcorrencia { get; set; }
		public Enum Tipo { get; set; }
	}
}