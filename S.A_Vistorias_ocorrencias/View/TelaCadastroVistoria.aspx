<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaCadastroVistoria.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.View.CadastroVistoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img alt="" src="../View/imagemsa.png" style="height: 80px; width: 82px" />
			<table ID="tblCadastro" runat="server">
				<tr>
					<td>
                        <asp:Label ID="LabelIdVistoria" runat="server" Text="ID Vistoria"></asp:Label>
					</td>
                    <td>
                        <asp:TextBox ID="txtIdVistoria" ReadOnly="True" runat="server"></asp:TextBox>
                    </td>
				</tr>
                <tr>
					<td>
                        <asp:Label ID="LabelData" runat="server" Text="Data"></asp:Label>
					</td>
                    <td>
                        <asp:TextBox ID="txtData" TextMode="Date" runat="server"></asp:TextBox>
                    </td>
				</tr>                
                <tr>
                    <td>
                        <asp:Label ID="LabelStatus" runat="server" Text="Status"></asp:Label>
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlStatus" runat="server">
							 <asp:ListItem Value="Aberto">Aberto</asp:ListItem>
                            <asp:ListItem Value="Aberto">Fechado</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelIdResponsavel" runat="server" Text="ID Responsavel"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIdResponsavel" runat="server"></asp:TextBox>
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
                        <asp:Label ID="LabelEndereco" runat="server" Text="Endereço"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelImagem" runat="server" Text="Imagem"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="txtImagem" runat="server" />
                    </td>
                </tr>
			</table>
			
			<div>
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" OnClick="btnInserir_Click" BorderColor="Black" />
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" BorderColor="Black" OnClick="btnExcluir_Click" />
                <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" BorderColor="Black" OnClick="btnAtualizar_Click" />
                <asp:Button ID="btnFechar" runat="server" Text="Fechar" BorderColor="Black" OnClick="btnFechar_Click" />
			</div>
        </div>
    </form>
</body>
</html>
