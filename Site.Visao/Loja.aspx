<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Loja.aspx.cs" Inherits="Site.Visao.Loja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="mainbar">
        <div class="article">
          <h2><asp:Label ID="Label1" runat="server"></asp:Label></h2>
          <asp:Image ID="Image1" runat="server" Visible="False" />
          <br /><br />
          <ul style="list-style-type:none;font-size:8pt;font-weight:bold;">
          <asp:Label ID="Label2" runat="server"></asp:Label>
          </ul>
        </div>
      </div>

</asp:Content>
