<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="Site.Visao.usuarios.Relatorios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
        <h2><span>Fechamentos financeiros disponíveis</span></h2>
        <div class="clr"></div>
            <ol>
                <li>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowcreated="GridView1_RowCreated" onpageindexchanging="GridView1_PageIndexChanging" 
                        DataKeyNames="com_cod,com_loja,com_data_abertura,com_data_fechamento" 
                        Width="100%" 
                        GridLines="Vertical" 
                        AllowPaging="True" 
                        EnableModelValidation="True" 
                        PageSize="50"
                        BackColor="#FFFFFF" 
                        BorderColor="#4D5152" 
                        BorderStyle="Outset" 
                        BorderWidth="1px" 
                        CellPadding="2">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nº">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="com_data_fechamento" HeaderText="Data/Hora" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"/>
                          
                            <asp:TemplateField HeaderText="Valor Total">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Loja">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Relatório">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDetalhe" runat="server" onclick="lbDetalhe_Click">Detalhar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings PageButtonCount="60" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="#000000" />
                        <HeaderStyle HorizontalAlign="Left" BackColor="#4D5152" Font-Bold="True" ForeColor="#FFFFFF" />
                        <PagerStyle BackColor="#999999" ForeColor="#000000" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="#000000" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="#FFFFFF" />
                    </asp:GridView>
                </li>
            </ol>
        </div>
    </div>

</asp:Content>
