<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaLogin.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.TelaLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<img src="Downloads\imagem\marreco" />
    <form id="form1" runat="server">
		<div id="login">
          <img alt="" src="../View/LogoGole_drinks.jpeg" style="height: 87px; width: 90px" align="middle" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="LabelUsuario" runat="server" Text="Usuário"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelSenha" runat="server" Text="Senha"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>    
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
       </div>
    </form>
    
</body>
</html>
