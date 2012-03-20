﻿<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="Site.Visao.administradores.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
        <h2><span>Manutenção de Usuários</span></h2>
        <div class="clr"></div>
            <ol>
              <li>
                  <asp:Button ID="Button1" runat="server" Text="Novo Usuário" onclick="Button1_Click" />
                  <br /><br />
              </li>
              <li>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowcreated="GridView1_RowCreated" 
                      onrowdeleting="GridView1_RowDeleting" Width="100%" BackColor="#e6ede6" BorderColor="White" BorderStyle="Ridge" BorderWidth="0px" CellPadding="3" 
                      CellSpacing="1" GridLines="None">
                      <FooterStyle BackColor="#4d5152" ForeColor="Black" />
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <Columns>
                          <asp:HyperLinkField DataNavigateUrlFields="usu_cod" DataNavigateUrlFormatString="CadUsuario.aspx?pg={0}" DataTextField="usu_cod" DataTextFormatString="Alterar" HeaderText="Edição" />
                          <asp:BoundField DataField="usu_nome" HeaderText="Nome" />
                          <asp:BoundField DataField="usu_email" HeaderText="E-mail" />
                          <asp:BoundField DataField="usu_funcao" HeaderText="Perfil" />
                          <asp:CommandField DeleteText="Excluir" HeaderText="Baixa" ShowDeleteButton="True" />
                      </Columns>
                      <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                      <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle HorizontalAlign="Left" BackColor="#4d5152" Font-Bold="True" ForeColor="#65CDE7" />
                  </asp:GridView>
              </li>
            </ol>
        </div>
      </div>

</asp:Content>
