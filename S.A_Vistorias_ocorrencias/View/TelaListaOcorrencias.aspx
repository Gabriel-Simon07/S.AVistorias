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
                    <asp:DropDownList ID="dptTipo" runat="server" Height="19px" Width="125px">
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
        <div>
        <asp:Button ID="btnPesquisarOcorrencia"  Text="Pesquisar" BorderColor="Black" runat="server" />
        <asp:Button ID="btnInserir" runat="server" Text="Inserir Ocorrências" BorderColor="Black" OnClick="btnInserir_Click" />
	</div>
	<div>
         <asp:GridView ID="gdListaOcorrencias" runat="server" OnRowCommand="gdListaOcorrencias_RowCommand" CellPadding="4" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                 <asp:Button ID="btnVisualizar" runat="server"
                                    CommandName="Visualizar"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Visualizar" />
                                <asp:Button ID="btnAlterar" runat="server"
                                    CommandName="Alterar"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Alterar" />
                                <asp:Button ID="btnExcluir" runat="server"
                                  CommandName="Excluir"
                                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                  Text="Excluir" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    	<asp:BoundField HeaderText="ID Ocorrência" DataField="idOcorrencia" />
						<asp:BoundField DataField="idVistoria" HeaderText="ID Vistoria" />
						<asp:BoundField DataField="descricao" HeaderText="Descrição" />
						<asp:BoundField DataField="dataOcorrencia" HeaderText="Data Ocorrência" />
						<asp:BoundField DataField="descricao" HeaderText="Descrição" />
						<asp:BoundField DataField="tipo" HeaderText="Tipo" />
                    </Columns>
			    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
			    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
			    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
			    <RowStyle BackColor="White" ForeColor="#003399" />
			    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
			    <SortedAscendingCellStyle BackColor="#EDF6F6" />
			    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
			    <SortedDescendingCellStyle BackColor="#D6DFDF" />
			    <SortedDescendingHeaderStyle BackColor="#002876" />
		    </asp:GridView>
	</div>
    </form>
	
</body>
</html>
