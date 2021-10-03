<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaLogin.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.TelaLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Width="400px" BackColor="#3399FF" BorderColor="Black" BorderStyle="Solid">
          <img alt="" src="../View/imagemsa.png" style="height: 87px; width: 90px" align="middle" border-style="Solid" border-color="Black"/>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="LabelUsuario" runat="server" Text="Usuário"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLogin" runat="server" HorizontalAlign="Center"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelSenha" runat="server" Text="Senha" HorizontalAlign="Center"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>
            </asp:Panel>
            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" BorderColor="Black" />
    </form>
</body>
</html>
