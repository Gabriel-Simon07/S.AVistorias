<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaListaOcorrencias.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.View.TelaListaOcorrencias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <img alt="" src="../View/LogoGole_drinks.jpeg" style="height: 80px; width: 82px" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="LabelTipo" runat="server" Text="Tipo"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" Width="125px">
					</asp:DropDownList>
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
                    <asp:TextBox ID="txtIdVistoria" ReadOnly="true" runat="server"></asp:TextBox>
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
        <asp:Button ID="btnPesquisarOcorrencia" runat="server" Text="Pesquisar" BorderColor="Black" />
        <asp:Button ID="btnInserir" runat="server" Text="Inserir Ocorrências" BorderColor="Black" />
	</div>
	<div>
        <asp:GridView ID="gvListaOcorrencias" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
			<AlternatingRowStyle BackColor="White" />
			<Columns>
				<asp:BoundField DataField="idOcorrencia" HeaderText="ID" />
				<asp:BoundField DataField="tipo" HeaderText="Tipo" />
				<asp:BoundField DataField="dataOcorrencia" HeaderText="Data Ocorrência" />
				<asp:BoundField HeaderText="Foto" />
			</Columns>
			<EditRowStyle BackColor="#7C6F57" />
			<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
			<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
			<RowStyle BackColor="#E3EAEB" />
			<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
			<SortedAscendingCellStyle BackColor="#F8FAFA" />
			<SortedAscendingHeaderStyle BackColor="#246B61" />
			<SortedDescendingCellStyle BackColor="#D4DFE1" />
			<SortedDescendingHeaderStyle BackColor="#15524A" />
		</asp:GridView>
	</div>
</body>
</html>
