<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="ListaPaginas.aspx.cs" Inherits="Site.Visao.administradores.ListaPaginas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
        <h2><span>Manutenção de Páginas</span></h2>
        <div class="clr"></div>
            <ol>
              <li>
                  <asp:Button ID="Button1" runat="server" Text="Nova Página" onclick="Button1_Click" />
                  <br /><br />
              </li>
              <li>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowcreated="GridView1_RowCreated" 
                      onrowdeleting="GridView1_RowDeleting" Width="100%" BackColor="#e6ede6" BorderColor="White" BorderStyle="Ridge" BorderWidth="0px" CellPadding="3" 
                      CellSpacing="1" GridLines="None">
                      <FooterStyle BackColor="#4d5152" ForeColor="Black" />
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <Columns>
                          <asp:HyperLinkField DataNavigateUrlFields="pag_cod" DataNavigateUrlFormatString="CadPagina.aspx?pg={0}" DataTextField="pag_cod" DataTextFormatString="Alterar" HeaderText="Edição" />
                          <asp:BoundField DataField="pag_nome" HeaderText="Nome" />
                          <asp:BoundField DataField="pag_descricao" HeaderText="Descrição" />
                          <asp:BoundField DataField="pag_posicao" HeaderText="Menu" />
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
