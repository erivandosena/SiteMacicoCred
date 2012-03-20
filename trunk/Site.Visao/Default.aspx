<%@ Page Title="Untitled Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site.Visao.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbar">
        <div class="article">
          <div class="clr"></div>
          <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
          <div class="clr"></div>
        </div>
        <div class="article">
          <h2><asp:Label ID="Label2" runat="server" Visible="False"></asp:Label></h2>
          <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
        </div>
      </div>

</asp:Content>
