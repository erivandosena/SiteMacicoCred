<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="ListaComissao.aspx.cs" Inherits="Site.Visao.administradores.ListaComissao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="mainbarAdmin">
        <div class="article">
        <h2><span>Manutenção de Relatório de Comissão do Corretor</span></h2>
            <div class="clr"></div>
            <ol>
              <li>
                  <asp:Button ID="Button1" runat="server" Text="Abrir novo Relatório" onclick="Button1_Click" />
                  <br /><br />
              </li>
              <li>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      onrowcreated="GridView1_RowCreated" onrowdeleting="GridView1_RowDeleting" 
                      Width="100%" BackColor="#E6EDE6" BorderColor="White" BorderStyle="Ridge" 
                      BorderWidth="0px" CellPadding="3" CellSpacing="1" GridLines="None" 
                      DataKeyNames="com_cod,com_usuario,com_loja,com_status" AllowPaging="True" EnableModelValidation="True" 
                      onpageindexchanging="GridView1_PageIndexChanging" PageSize="50">
                      <FooterStyle BackColor="#4d5152" ForeColor="Black" />
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <Columns>
                          <asp:HyperLinkField DataNavigateUrlFields="com_cod" DataNavigateUrlFormatString="CadComissao.aspx?pg={0}" DataTextField="com_contrato"  DataTextFormatString="Adicionar/Remover ({0})" HeaderText="Contratos" />
                          <asp:BoundField DataField="com_data_abertura" HeaderText="Abertura" DataFormatString="{0:dd/MM/yyyy}"/>
                          
                          <asp:TemplateField HeaderText="Corretor">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("com_usuario") %>'></asp:Label>
                            </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Loja/Cidade">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("com_loja") %>'></asp:Label>
                            </ItemTemplate>
                         </asp:TemplateField>

                          <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("com_status") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Font-Bold="True" />
                         </asp:TemplateField>

                          <asp:CommandField DeleteText="Deletar" HeaderText="Exclusão" ShowDeleteButton="True" />
                      </Columns>
                      <PagerSettings PageButtonCount="60" />
                      <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Left" />
                      <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle HorizontalAlign="Left" BackColor="#4d5152" Font-Bold="True" ForeColor="#65CDE7" />
                  </asp:GridView>
              </li>
            </ol>
        </div>
      </div>

</asp:Content>
