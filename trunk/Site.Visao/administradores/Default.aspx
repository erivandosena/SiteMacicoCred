<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site.Visao.administradores.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin" style="background-color:#fff;">
        <div class="article">
        <div style="float:left;padding:10px 10px 10px 80px;width:300px"><img alt="" src="../Arquivos/image/logomarca.jpg" border="0" align="left" /></div>
        <div style="float:left;padding:10px 10px 0px 50px;width:300px;vertical-align:top;">
        
        <ul>
        <li><h2 style="font-size:12pt;">Páginas</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelPaginas" runat="server"></asp:Label></h3>

        <li><h2 style="font-size:12pt;">Lojas</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelLojas" runat="server"></asp:Label></h3>

        <li><h2 style="font-size:12pt;">Usuários</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelUsuarios" runat="server"></asp:Label></h3>

        <li><h2 style="font-size:12pt;">Clientes</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelClientes" runat="server"></asp:Label></h3>

        <li><h2 style="font-size:12pt;">Bancos</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelBancos" runat="server"></asp:Label></h3>

        <li><h2 style="font-size:12pt;">Corretores</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelCorretores" runat="server"></asp:Label></h3>

        <li><h2 style="font-size:12pt;">Propostas Novas</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelPropostasNovas" runat="server"></asp:Label></h3>

        <li><h2 style="font-size:12pt;">Propostas Negadas</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelPropNegadas" runat="server"></asp:Label></h3>

        <li><h2 style="font-size:12pt;">Propostas Aprovadas</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelPropAprovadas" runat="server"></asp:Label></h3>

        <li><h2 style="font-size:12pt;">Propostas Faturadas</h2></li>
          <h3 style="font-size:16pt;margin:-20px -20px -20px 0;">
          <asp:Label ID="LabelPropFaturadas" runat="server"></asp:Label></h3>
        </ul>

        </div>
        </div>
      </div>

</asp:Content>
