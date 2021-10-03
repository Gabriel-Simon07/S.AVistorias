<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaListaVistorias.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.View.ListaVistorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server">
        <img alt="" src="../View/imagemsa.png" style="height: 87px; width: 90px" align="middle" border-style="Solid" border-color="Black"/>
        <asp:ImageButton ID="ImageButtonLogout" runat="server" ImageAlign="Right" ImageUrl="../View/logout.jpg" Width="40" Height="40" OnClick="ButtonLogouta_Click" />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" GroupingText="Filtros">
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
                   <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" BorderColor="Black" OnClick="btnPesquisar_Click" />
               </td>
               <td>
                   <asp:Button ID="btnInserirVistoria" runat="server" Text="Inserir Vistoria" OnClick="btnInserirVistoria_Click" BorderColor="Black" />
               </td>
           </tr>
      </table>          
            </asp:Panel>
        <asp:Panel ID="PanelListaVistorias" runat="server" GroupingText="Lista de Vistorias">
            <asp:GridView ID="gdListaVistorias" runat="server" OnRowCommand="gdListaVistorias_RowCommand" CellPadding="4" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
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
                                <asp:Button ID="btn" runat="server"
                                    CommandName="Ocorrencia"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Ocorrência" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    	<asp:BoundField DataField="idVistoria" HeaderText="ID Vistoria" />
                    	<asp:BoundField DataField="idUsuario" HeaderText="ID Usuario" />
						<asp:BoundField DataField="status" HeaderText="Status" />
						<asp:BoundField DataField="dataAbertura" HeaderText="Data" />
						<asp:ImageField DataImageUrlField="imagem" HeaderText="Foto">
						</asp:ImageField>
						<asp:BoundField DataField="descricao" HeaderText="Descrição" />
						<asp:BoundField DataField="endereco" HeaderText="Endereço" />
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
          </asp:Panel>
    </form>
</body>
</html>
