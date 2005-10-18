<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CadLink.aspx.cs" Inherits="Site.Visao.administradores.CadLink" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
        <h2><span>Cadastro do Link</span></h2>
            <div class="clr"></div>
            <ol>
              <li>
                  <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxNome" Text="Nome"></asp:Label>
                  <asp:TextBox ID="TextBoxNome" runat="server" Width="300px" MaxLength="30"></asp:TextBox>
                  &nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
              </li>
              <li>
                  <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxUrl" Text="URL"></asp:Label>
                  <asp:TextBox ID="TextBoxUrl" runat="server" MaxLength="255" Width="600"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxUrl" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
              </li>
              <li>
                  <asp:Label ID="Label3" runat="server" AssociatedControlID="DropDownListTipo" Text="Tipo"></asp:Label>
                  <asp:DropDownList ID="DropDownListTipo" runat="server">
                      <asp:ListItem Selected="True" Value=""></asp:ListItem>
                      <asp:ListItem Value="INSS">INSS</asp:ListItem>
                      <asp:ListItem Value="Bancos">Bancos</asp:ListItem>
                      <asp:ListItem Value="Fatores & Tabelas">Fatores & Tabelas</asp:ListItem>
                      <asp:ListItem Value="Úteis">Úteis</asp:ListItem>
                  </asp:DropDownList>
                  &nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListTipo" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
              </li>
              <li>
                  <p>&nbsp;</p> 
                  <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" onclick="ButtonSalvar_Click" />
                  <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False" onclick="ButtonCancelar_Click"  />  
              </li>
            </ol>
        </div>
      </div>

</asp:Content>
