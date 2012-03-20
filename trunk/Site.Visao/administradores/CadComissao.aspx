<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CadComissao.aspx.cs" Inherits="Site.Visao.administradores.CadComissao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../scripts/JSMascaras.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
    <div class="mainbar">
        <div class="formulario" style="margin-left: -60px;">
            <fieldset>
            <legend>AGENTE</legend> 
                <asp:Label ID="Label1" runat="server" AssociatedControlID="DropDownListNomeOper" Text="Nome: "></asp:Label>
                <asp:DropDownList ID="DropDownListNomeOper" runat="server" Width="515px" Style="float:left;"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListNomeOper" ErrorMessage="*"></asp:RequiredFieldValidator>

                <asp:Panel ID="Panel1" runat="server">
                <br />
                
                <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxDtAber" Text="Abertura: "></asp:Label>
                <asp:TextBox ID="TextBoxDtAber" runat="server" Width="120px" MaxLength="10" Enabled="False"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" AssociatedControlID="TextBoxDtFech" Text="Fechamento: "></asp:Label>
                <asp:TextBox ID="TextBoxDtFech" runat="server" Width="120px" MaxLength="10" Enabled="False"></asp:TextBox>
                </asp:Panel>
            </fieldset>
             
            <asp:Panel ID="Panel2" runat="server">
                <fieldset>
                <legend>CLIENTE</legend> 
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="DropDownListPro" Text="Proposta: "></asp:Label>
                    <asp:DropDownList ID="DropDownListPro" runat="server" Width="515px" Style="float:left;" AutoPostBack="True" onselectedindexchanged="DropDownListPro_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListPro" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                    <br />

                    <asp:Label ID="Label5" runat="server" AssociatedControlID="TextBoxNome" Text="Nome: "></asp:Label>
                    <asp:TextBox ID="TextBoxNome" runat="server" Width="295px" MaxLength="80" ReadOnly="True"></asp:TextBox>

                    <asp:Label ID="Label6" runat="server" AssociatedControlID="TextBoxCpf" Text="CPF: "></asp:Label>
                    <asp:TextBox ID="TextBoxCpf" runat="server" Width="90px" MaxLength="14" onkeyup="formataCPF(this,event);" ReadOnly="True"></asp:TextBox>
                </fieldset>

                <fieldset>
                <legend>CONTRATO</legend> 
                    <asp:Label ID="Label7" runat="server" AssociatedControlID="TextBoxContrato" Text="Contrato Nº: "></asp:Label>
                    <asp:TextBox ID="TextBoxContrato" runat="server" Width="65px" MaxLength="30"></asp:TextBox>

                    <asp:Label ID="Label10" runat="server" AssociatedControlID="TextBoxData" Text="Data: "></asp:Label>
                    <asp:TextBox ID="TextBoxData" runat="server" Width="65px" MaxLength="10" onkeyup="formataData(this,event);"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxData" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                    <asp:Label ID="Label8" runat="server" AssociatedControlID="DropDownListBanco" Text="Banco: "></asp:Label>
                    <asp:DropDownList ID="DropDownListBanco" runat="server" DataSourceID="ObjectDataSourceBanco" DataTextField="ban_nome" DataValueField="ban_cod" Style="float:left;width:132px;">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSourceBanco" runat="server" SelectMethod="RecuperaBancos" TypeName="Site.Modelo.Banco"></asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListBanco" ErrorMessage="*"></asp:RequiredFieldValidator>
                    
                    <br />

                    <asp:Label ID="Label11" runat="server" AssociatedControlID="TextBoxValor" Text="Valor R$: "></asp:Label>
                    <asp:TextBox ID="TextBoxValor" runat="server" Width="90px" MaxLength="25" onkeyup="formataValor(this,event);"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxValor" ErrorMessage="*"></asp:RequiredFieldValidator>

                    <asp:Label ID="Label9" runat="server" AssociatedControlID="DropDownListPlano" Text="Plano: "></asp:Label>
                    <asp:DropDownList ID="DropDownListPlano" runat="server" Width="105px" Style="float:left;">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="36">36</asp:ListItem>
                        <asp:ListItem Value="48">48</asp:ListItem>
                        <asp:ListItem Value="59">59</asp:ListItem>
                        <asp:ListItem Value="60">60</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownListPlano" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                    <asp:Label ID="Label16" runat="server" AssociatedControlID="TextBoxValorPrestacao" Text="Parcela R$: "></asp:Label>
                    <asp:TextBox ID="TextBoxValorPrestacao" runat="server" Width="65px" MaxLength="25" onkeyup="formataValor(this,event);"></asp:TextBox>
                
                    <br />

                    <asp:Label ID="Label12" runat="server" AssociatedControlID="DropDownListTipo" Text="Tipo: "></asp:Label>
                    <asp:DropDownList ID="DropDownListTipo" runat="server" Style="float:left;">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>NOVO</asp:ListItem>
                        <asp:ListItem>REFIN</asp:ListItem>
                        <asp:ListItem>RECOMPRA</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownListTipo" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                    <asp:Label ID="Label13" runat="server" AssociatedControlID="DropDownListComissao" Text="Percentual %: "></asp:Label>
                    <asp:DropDownList ID="DropDownListComissao" runat="server" Width="65px" Style="float:left;" AutoPostBack="True" onselectedindexchanged="DropDownListComissao_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>0,5</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownListComissao" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                    <asp:Label ID="Label14" runat="server" AssociatedControlID="TextBoxPag" Text="Comissão R$: "></asp:Label>
                    <asp:TextBox ID="TextBoxPag" runat="server" Width="95px" MaxLength="25" onkeyup="formataValor(this,event);"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxPag" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                    </fieldset>
            </asp:Panel>
            
            <br />

            <asp:Button ID="ButtonConfirma" runat="server" Text="Confirmar" onclick="ButtonConfirma_Click" Style="margin-left:120px;"/>
            <asp:Button ID="ButtonEncerrar" runat="server" Text="Encerrar" CausesValidation="False" onclick="ButtonEncerrar_Click" />
            <asp:Button ID="ButtonReabrir" runat="server" Text="Reabrir" CausesValidation="False" onclick="ButtonReabrir_Click" />
            <asp:Button ID="ButtonImprimir" runat="server" Text="Recibo" CausesValidation="False" Enabled="False" onclick="ButtonImprimir_Click" />
            <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False" onclick="ButtonCancelar_Click" />
       </div>
    </div>
       <div class="article">
            <asp:Panel ID="Panel3" runat="server" Style="margin-top: -30px;">
            <div class="formulario">
                <fieldset style="margin-left: 55px;"><legend>COMISSÕES</legend></fieldset>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onrowcreated="GridView1_RowCreated" onrowdeleting="GridView1_RowDeleting" BackColor="#E6EDE6" BorderColor="White" BorderStyle="Ridge" BorderWidth="0px" CellPadding="3" CellSpacing="1" GridLines="None" EnableModelValidation="True" DataKeyNames="con_cod,con_taxa,con_valor" onrowdatabound="GridView1_RowDataBound" ShowFooter="True" Width="100%" Style="margin-top: -20px;">
                    <FooterStyle BackColor="#4d5152" ForeColor="White" Font-Bold="True" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black"/>
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="con_comissao,con_cod" DataNavigateUrlFormatString="CadComissao.aspx?pg={0}&con={1}" DataTextField="con_numero"  DataTextFormatString="Visualizar ({0})" HeaderText="Contrato" />
                        <asp:BoundField DataField="con_tipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="con_data_liberacao" HeaderText="Data" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="con_valor" HeaderText="Valor" DataFormatString="{0:C}"/>
                        <asp:BoundField DataField="con_taxa" HeaderText="Perc" DataFormatString="{0:N1}%"/>
                        <asp:TemplateField HeaderText="Comissão R$">
                            <ItemTemplate>
                                <asp:Label ID="Label15" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField DeleteText="Remover" HeaderText="Exclusão" ShowDeleteButton="True" ButtonType="Button" />
                    </Columns>
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle HorizontalAlign="Left" BackColor="#4d5152" Font-Bold="True" ForeColor="#65CDE7" />
            </asp:GridView>
            </asp:Panel>    
       </div> 
   </div>

</asp:Content>
