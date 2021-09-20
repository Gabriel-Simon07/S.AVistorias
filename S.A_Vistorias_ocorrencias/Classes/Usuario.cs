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
	public class Usuario
	{
		public Usuario() {}

		public Usuario(MySqlDataReader dadoLido)
		{
			this.idUsuario = !dadoLido.IsDBNull(0) ? dadoLido.GetInt32(0) : 0;
			this.nome = !dadoLido.IsDBNull(1) ? dadoLido.GetString(1) : "";
			this.login = !dadoLido.IsDBNull(2) ? dadoLido.GetString(2) : "";
			this.senha = !dadoLido.IsDBNull(3) ? dadoLido.GetString(3) : "";
			this.perfil = !dadoLido.IsDBNull(4) ? dadoLido.GetString(4) : "";
		}

		public Usuario(string nome, string login, string senha, string perfil)
		{
			this.nome = nome;
			this.login = login;
			this.senha = senha;
			this.perfil = perfil;
		}

		public Int32 idUsuario { get; set; }
		public string nome { get; set; }
		public string login { get; set; }
		public string senha { get; set; }
		public string perfil { get; set; }
	}
}