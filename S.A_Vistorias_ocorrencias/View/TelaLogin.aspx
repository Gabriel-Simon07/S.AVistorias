<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaLogin.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.TelaLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<img alt="vistoriaOCorrencia" src="Downloads\imagem\marreco" />
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelUsuario" runat="server" Text="Usuário"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelSenha" runat="server" Text="Senha"></asp:Label>
            <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>    
        </div>
    </form>
    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" />
</body>
</html>
