﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelaCadastroVistoria.aspx.cs" Inherits="S.A_Vistorias_ocorrencias.View.CadastroVistoria" %>

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
                <asp:Label ID="LabelIdVistoria" runat="server" Text="ID Vistoria"></asp:Label>
                <asp:TextBox ID="txtIdVistoria" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelData" runat="server" Text="Data"></asp:Label>
                <asp:TextBox ID="txtData" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelStatus" runat="server" Text="Status"></asp:Label>
                <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelIdResponsavel" runat="server" Text="ID Responsavel"></asp:Label>
                <asp:TextBox ID="txtIdResponsavel" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelDescricao" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelEndereco" runat="server" Text="Endereço"></asp:Label>
                <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
			</div>
            <div>
                <asp:Label ID="LabelImagem" runat="server" Text="Imagem"></asp:Label>
                <asp:FileUpload ID="FileUploadImagem" runat="server" />
			</div>
			<div>
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" />
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" />
                <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" />
                <asp:Button ID="btnFechar" runat="server" Text="Fechar" />
			</div>
        </div>
    </form>
</body>
</html>