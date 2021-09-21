<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaListaOcorrencias.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.View.TelaListaOcorrencias" %>

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
                    <asp:Label ID="LabelTipo" runat="server" Text="Tipo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
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
                    <asp:Label ID="LabelDescricao" runat="server" Text="Descrição"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
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
                    <asp:Label ID="LabelDataFinal" runat="server" Text="Data Final"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDataFinal" runat="server"></asp:TextBox>
                </td>
            </tr>
         </table>
    </form>
	<div>
        <asp:Button ID="btnPesquisarOcorrencia" runat="server" Text="Pesquisar" />
        <asp:Button ID="btnInserir" runat="server" Text="Inserir Ocorrências" />
	</div>
	<div>
        <asp:GridView ID="gvListaOcorrencias" runat="server" AutoGenerateColumns="False">
			<Columns>
				<asp:BoundField DataField="idOcorrencia" HeaderText="ID" />
				<asp:BoundField DataField="tipo" HeaderText="Tipo" />
				<asp:BoundField DataField="dataOcorrencia" HeaderText="Data Ocorrência" />
				<asp:BoundField HeaderText="Foto" />
			</Columns>
		</asp:GridView>
	</div>
</body>
</html>
