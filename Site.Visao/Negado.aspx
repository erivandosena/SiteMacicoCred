<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Negado.aspx.cs" Inherits="Site.Visao.Negado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbar">
        <div class="article">
          <h2><span>Acesso Negado</span></h2>
          <div class="clr"></div>
          <p>Você não tem permissão de acesso para esta área do site.</p>
        </div>
        <div class="article">
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Acessar Novamente" onclick="LinkButton1_Click" CausesValidation="False"></asp:LinkButton>
        </div>
    </div>

</asp:Content>
