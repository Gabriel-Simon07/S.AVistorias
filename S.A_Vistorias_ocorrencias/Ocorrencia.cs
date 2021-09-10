using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S.A_Vistorias_ocorrencias
{
	public class Ocorrencia
	{
		public Int32 idOcorrencia { get; set; }
		public Int32 idVistoria { get; set; }
		public string descricao { get; set; }
		public DateTime dataOcorrencia { get; set; }
		public Enum tipo { get; set; }
	}
}