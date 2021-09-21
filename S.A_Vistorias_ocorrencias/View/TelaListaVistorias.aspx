<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaListaVistorias.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.View.ListaVistorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <table>
        <tr>
            <td>
                <asp:Label ID="LabelStatus" runat="server" Text="Status"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelIdVistoria" runat="server" Text="ID Vistoria"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIdVistoria" runat="server"></asp:TextBox>
            </td>
        </tr>  
        <tr>
            <td>
                <asp:Label ID="LabelDataInicial" runat="server" Text="Data Inicial"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDataInicial" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelEndereco" runat="server" Text="Endereco"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelIdUsuario" runat="server" Text="Id Usuário responsável"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIdUsuario" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelDataFinal" runat="server" Text="Data Final"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDataFinal" runat="server"></asp:TextBox>
            </td>
        </tr>
      </table>          
        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" />
        <asp:GridView ID="gdListaVistorias" runat="server"></asp:GridView>
    </form>
</body>
</html>
