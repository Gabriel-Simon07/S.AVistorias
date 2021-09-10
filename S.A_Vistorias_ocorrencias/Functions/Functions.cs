using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S.A_Vistorias_ocorrencias.Functions
{
	public class Functions
	{
		public static string ObterConnectionString()
		{
			return "server=localhost;user id=root;sslmode=None;database=s_a_vistoria_e_ocorrencias";
		}
	}
}