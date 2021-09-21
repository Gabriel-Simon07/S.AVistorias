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
           <tr>
               <td>
                   <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" />
               </td>
               <td>
                   <asp:Button ID="btnInserirVistoria" runat="server" Text="Inserir Vistoria" OnClick="btnInserirVistoria_Click" />
               </td>
           </tr>
      </table>          
        <asp:GridView ID="gdListaVistorias" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
			<AlternatingRowStyle BackColor="White" />
			<Columns>
				<asp:BoundField DataField="idVistoria" HeaderText="ID" />
				<asp:BoundField DataField="status" HeaderText="Status" />
				<asp:BoundField DataField="dataAbertura" HeaderText="Data Vistoria" />
				<asp:BoundField DataField="idUsuario" HeaderText="Responsável" />
				<asp:BoundField DataField="descricao" HeaderText="Descrição Vistoria" />
				<asp:BoundField DataField="imagem" HeaderText="Foto" />
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
    </form>
</body>
</html>
