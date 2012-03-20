<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="Site.Visao.usuarios.ListaClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../scripts/JSMascaras.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
          <h2><span>Manutenção de Clientes</span></h2>
          <div class="clr"></div>
          <asp:Label ID="Label4" runat="server" AssociatedControlID="TextBoxCpf" Text="Busca por CPF: "></asp:Label>
          <asp:TextBox ID="TextBoxCpf" runat="server" Width="100px" MaxLength="14" onkeyup="formataCPF(this,event);"></asp:TextBox>
          <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxNome" Text="ou Nome: "></asp:Label>
          <asp:TextBox ID="TextBoxNome" runat="server" Width="280px" MaxLength="80" onkeyup="formataTexto(this,event);"></asp:TextBox>
            &nbsp;
            <asp:Button ID="ButtonBusca" runat="server" Text="Localizar" 
               OnClientClick="this.disabled = true; this.value = 'Pesquisando...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" onclick="ButtonBusca_Click" />
            <asp:Button ID="ButtonLista" runat="server" Text="Todos" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" onclick="ButtonLista_Click" />
            <asp:Button ID="ButtonNovo" runat="server" Text="Novo" CausesValidation="False" onclick="ButtonNovo_Click" />
        </div>
        <div class="article">
            <ol>
              <li>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      onrowcreated="GridView1_RowCreated" onrowdeleting="GridView1_RowDeleting" 
                      Width="100%" BackColor="#E6EDE6" BorderColor="White" BorderStyle="Ridge" 
                      BorderWidth="0px" CellPadding="3" CellSpacing="1" GridLines="None" 
                      DataKeyNames="cli_cod" AllowPaging="True" EnableModelValidation="True" 
                      onpageindexchanging="GridView1_PageIndexChanging" PageSize="50">
                      <FooterStyle BackColor="#4d5152" ForeColor="Black" />
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <Columns>
                          <asp:HyperLinkField DataNavigateUrlFields="cli_cod" DataNavigateUrlFormatString="CadCliente.aspx?pg={0}" DataTextField="cli_cod" DataTextFormatString="Visualizar" HeaderText="Manutenção" />
                          <asp:BoundField DataField="cli_nome" HeaderText="Nome" />
                          <asp:BoundField DataField="cli_mae" HeaderText="Mãe" />
                          <asp:CommandField DeleteText="Deletar" HeaderText="Exclusão" 
                              ShowDeleteButton="True" />
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
