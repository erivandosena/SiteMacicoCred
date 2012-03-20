<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CadBanco.aspx.cs" Inherits="Site.Visao.administradores.CadBanco" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="mainbarAdmin">
        <div class="article">
        <h2><span>Cadastro de Banco</span></h2>
            <div class="clr"></div>
            <ol>
              <li>
                  <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxNome" Text="Nome"></asp:Label>
                  <asp:TextBox ID="TextBoxNome" runat="server" Width="300px" MaxLength="30"></asp:TextBox>
                  &nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
              </li>
              <li>
                  <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxSite" Text="Site"></asp:Label>
                  <asp:TextBox ID="TextBoxSite" runat="server" MaxLength="255" Width="300px"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxSite" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
              </li>
              <li>
                  <asp:Label ID="Label3" runat="server" AssociatedControlID="TextBoxImagem" Text="URL da Logomarca"></asp:Label>
                  <asp:TextBox ID="TextBoxImagem" runat="server" MaxLength="255" Width="600"></asp:TextBox>
              </li>
              <li>
                  <p>&nbsp;</p> 
                  <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" 
                      onclick="ButtonSalvar_Click" />
                  <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" 
                      CausesValidation="False" onclick="ButtonCancelar_Click" />  
              </li>
            </ol>
        </div>
      </div>

</asp:Content>
