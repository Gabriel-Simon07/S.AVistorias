<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaListaOcorrencias.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.View.TelaListaOcorrencias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<div>
                <asp:Label ID="LabelTipo" runat="server" Text="Tipo"></asp:Label>
                <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelDataInicial" runat="server" Text="Data Inicial"></asp:Label>
                <asp:TextBox ID="txtDataInicial" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelDescricao" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelIdVistoria" runat="server" Text="ID Vistoria"></asp:Label>
                <asp:TextBox ID="txtIdVistoria" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelDataFinal" runat="server" Text="Data Final"></asp:Label>
                <asp:TextBox ID="txtDataFinal" runat="server"></asp:TextBox>
			</div>
        </div>
    </form>
    <asp:Button ID="btnPesquisarOcorrencia" runat="server" Text="Pesquisar" />
	<div>
        <asp:Button ID="btnInserir" runat="server" Text="Inserir Ocorrências" />
	</div>
	<div>
        <asp:GridView ID="gvListaOcorrencias" runat="server"></asp:GridView>
	</div>
</body>
</html>
