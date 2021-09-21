<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaCadastroOcorrencia.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.View.TelaCadastroOcorrencia" %>

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
                    <asp:Label ID="LabelIdVistoria" runat="server" Text="ID Vistoria"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIdVistoria" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelIdOcorrencia" runat="server" Text="ID Ocorrência"></asp:Label>                
                </td>
                <td>
                    <asp:TextBox ID="txtIdOcorrencia" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelData" runat="server" Text="Data"></asp:Label>                
                </td>
                <td>
                    <asp:TextBox ID="txtData" runat="server"></asp:TextBox>
                </td>
            </tr>
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
                    <asp:Label ID="LabelDescricao" runat="server" Text="Descrição"></asp:Label>                
                </td>
                <td>
                    <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
                </td>
            </tr>
         </table>		        
		<asp:Button ID="btnInserir" runat="server" Text="Inserir" />
        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" />
        <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" />
        <asp:Button ID="btnFechar" runat="server" Text="Fechar" />
    </form>
	<div>
	</div>
</body>
</html>
