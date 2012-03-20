<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Informativo.aspx.cs" Inherits="Site.Visao.Informativo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="mainbar">
        <div class="article">
          <h2><asp:Label ID="Label1" runat="server"></asp:Label></h2>
          <p><span class="date"><i><asp:Label ID="Label2" runat="server"></asp:Label></i></span></p>
          <asp:Label ID="Label3" runat="server"></asp:Label>
        </div>
      </div>

</asp:Content>
