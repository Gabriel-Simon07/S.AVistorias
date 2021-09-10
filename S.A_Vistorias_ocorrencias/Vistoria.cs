using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S.A_Vistorias_ocorrencias
{
	public class Vistoria
	{
		public Int32 IdVistoria { get; set; }
		public bool Status { get; set; }
		public DateTime DataAbertura { get; set; }
		public Int32 IdUsuario { get; set; }
		public string Imagem { get; set; }
		public string Descricao { get; set; }
		public string Endereco { get; set; }
	}
}