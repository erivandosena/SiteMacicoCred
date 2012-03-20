<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Site.Visao.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbar">
        <div class="article">
          <h2><span>Acesso Restrito</span></h2>
          <div class="clr"></div>
          <p>Informe seu nome de usuário e senha para autenticação no sistema.</p>
        </div>
        <div class="article">
        <asp:Login ID="Login2" runat="server" FailureText="Usuário ou senha inválida. Tente novamente!" onauthenticate="Login1_Authenticate" CssClass="Login">
            <LayoutTemplate>
            <ol>
              <li>
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:</asp:Label>
                <asp:TextBox ID="UserName" runat="server" class="text" Style="height: 16px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Usuário obrigatório." ToolTip="Usuário obrigatório." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
              </li>
              <li>
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>
                <asp:TextBox ID="Password" runat="server" TextMode="Password" class="text" Style="height: 16px;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Senha obrigatória." ToolTip="Senha obrigatória." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
              </li>
              <li>
                <asp:Label ID="Remember" runat="server" AssociatedControlID="RememberMe" Visible="False">Lembre-me<asp:CheckBox ID="RememberMe" runat="server" CssClass="checkbox" Text=""/></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" Style="padding-top: 2px;" onclick="LinkButton1_Click">Esqueci a senha</asp:LinkButton>
                <div style="color:#f00;text-align:center;"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
              </li>
              <li>
                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="Login1" class="envia" />
                <div class="clr"></div>
              </li>
            </ol>
            </LayoutTemplate>
        </asp:Login>
        </div>
    </div>

</asp:Content>
