<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="RelatorioDetalhe.aspx.cs" Inherits="Site.Visao.usuarios.RelatorioDetalhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
        <h2><asp:Label ID="LabelTitRelatorio" runat="server">Detalhamento do fechamento financeiro</asp:Label></h2>
            <div class="clr"></div>
            <ol>
                <li>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowcreated="GridView1_RowCreated" onrowdatabound="GridView1_RowDataBound" 
                        DataKeyNames="con_cod,con_taxa,con_valor,con_proposta"
                        GridLines="Vertical" 
                        EnableModelValidation="True"  
                        Font-Size="8pt" 
                        ShowFooter="True" 
                        Width="100%" 
                        BackColor="#FFFFFF" 
                        BorderColor="#4D5152" 
                        BorderStyle="Outset" 
                        BorderWidth="1px" 
                        CellPadding="2">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:TemplateField HeaderText="Banco">
                            <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="con_data_liberacao" HeaderText="Data" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="con_valor" HeaderText="Contrato R$" DataFormatString="{0:n}"/>
                            <asp:BoundField DataField="con_taxa" HeaderText="Com." DataFormatString="{0:N1}%"/>
                            
                            <asp:TemplateField HeaderText="Valor R$">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PL">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="con_tipo" HeaderText="Tipo" />

                            <asp:TemplateField HeaderText="Cliente">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CPF">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="#000000" Font-Bold="True" />
                        <HeaderStyle HorizontalAlign="Left" BackColor="#4D5152" Font-Bold="True" ForeColor="#FFFFFF" />
                        <PagerStyle BackColor="#999999" ForeColor="#000000" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="#000000" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="#FFFFFF" />
                    </asp:GridView>
                </li>
                <li>
                    <input id="Button1" type="button" value="Retornar" class="envia" onclick="window.location='Relatorios.aspx'" style="background-color:#4D5152;color:#FFFFFF;" />
                    <asp:Button ID="Button2" runat="server" Text="Exportar" CssClass="envia" 
                        Style="background-color:#4D5152;color:#FFFFFF;" onclick="Button2_Click" />
                </li>
            </ol>
        </div>
    </div>

</asp:Content>
