<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CadUsuario.aspx.cs" Inherits="Site.Visao.administradores.CadUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../scripts/JSMascaras.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbar">
        <div class="article">
        <h2><span>Cadastro do Usuário</span></h2>
        <div class="clr"></div>
            <ol>
                <li>
                    <asp:Label ID="LabelCodigo" runat="server" Visible="False" Text="Código"></asp:Label>
                </li>
                <li>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxNome" Text="Nome de usuário"></asp:Label>
                    <asp:TextBox ID="TextBoxNome" runat="server" Width="150px" MaxLength="32"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
                </li>
                <li>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxEmail" Text="E-mail"></asp:Label>
                    <asp:TextBox ID="TextBoxEmail" runat="server" MaxLength="50" Width="400px"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="E-mail inválido." ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </li>
                <li>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="TextBoxSenha" Text="Senha"></asp:Label>
                    <asp:TextBox ID="TextBoxSenha" runat="server" MaxLength="32" Width="150px" TextMode="Password"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="DropDownListLocal" Text="Loja"></asp:Label>
                    <asp:DropDownList ID="DropDownListLocal" runat="server" DataSourceID="ObjectDataSource1" DataTextField="loj_nome" DataValueField="loj_cod">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="RecuperaLojas" TypeName="Site.Modelo.Loja"></asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListLocal" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
                </li>
                <li>
                    <asp:Label ID="Label5" runat="server" AssociatedControlID="CheckBoxListFuncao" Text="Perfil"></asp:Label>
                    <asp:CheckBoxList ID="CheckBoxListFuncao" runat="server" RepeatColumns="3" 
                        RepeatDirection="Horizontal" CellSpacing="1" TextAlign="Left" Width="250px" 
                        onselectedindexchanged="CheckBoxListFuncao_SelectedIndexChanged" 
                        oninit="CheckBoxListFuncao_Init" AutoPostBack="True" Style="margin-top: -25px;">
                    </asp:CheckBoxList>
                </li>

                <asp:Panel ID="Panel1" runat="server" Visible="False">
                
                <li>
                    <asp:Label ID="Label6" runat="server" AssociatedControlID="TextBoxNomeComp" Text="Nome completo"></asp:Label>
                    <asp:TextBox ID="TextBoxNomeComp" runat="server" Width="400px" MaxLength="80"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label7" runat="server" AssociatedControlID="TextBoxCpf" Text="CPF"></asp:Label>
                    <asp:TextBox ID="TextBoxCpf" runat="server" Width="150px" MaxLength="14" onkeyup="formataCPF(this,event);"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label8" runat="server" AssociatedControlID="TextBoxRg" Text="RG"></asp:Label>
                    <asp:TextBox ID="TextBoxRg" runat="server" Width="150px" MaxLength="25"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label9" runat="server" AssociatedControlID="TextBoxDatNasc" Text="Data Nascimento"></asp:Label>
                    <asp:TextBox ID="TextBoxDatNasc" runat="server" Width="100px" MaxLength="10" onkeyup="formataData(this,event);"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label10" runat="server" AssociatedControlID="TextBoxEndereco" Text="Endereço residencial"></asp:Label>
                    <asp:TextBox ID="TextBoxEndereco" runat="server" Width="400px" MaxLength="100"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label11" runat="server" AssociatedControlID="TextBoxEndereco" Text="Endereço comercial"></asp:Label>
                    <asp:TextBox ID="TextBoxEnderecoCom" runat="server" Width="400px" MaxLength="100"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label12" runat="server" AssociatedControlID="TextBoxCep" Text="CEP"></asp:Label>
                    <asp:TextBox ID="TextBoxCep" runat="server" Width="100px" MaxLength="9" onkeyup="formataCEP(this,event);"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label13" runat="server" AssociatedControlID="TextBoxBairro" Text="Bairro"></asp:Label>
                    <asp:TextBox ID="TextBoxBairro" runat="server" Width="150px" MaxLength="50"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label14" runat="server" AssociatedControlID="TextBoxCidade" Text="Cidade"></asp:Label>
                    <asp:TextBox ID="TextBoxCidade" runat="server" Width="150px" MaxLength="30"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label15" runat="server" AssociatedControlID="DropDownListUf" Text="Estado"></asp:Label>
                    <asp:DropDownList ID="DropDownListUf" runat="server">
                        <asp:ListItem></asp:ListItem>
			            <asp:ListItem Value="AC">Acre</asp:ListItem>
			            <asp:ListItem Value="AL">Alagoas</asp:ListItem>
			            <asp:ListItem Value="AP">Amapá</asp:ListItem>
			            <asp:ListItem Value="AM">Amazonas</asp:ListItem>
			            <asp:ListItem Value="BA">Bahia</asp:ListItem>
			            <asp:ListItem Value="CE">Ceará</asp:ListItem>
			            <asp:ListItem Value="DF">Distrito Federal</asp:ListItem>
			            <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
			            <asp:ListItem Value="GO">Goiás</asp:ListItem>
			            <asp:ListItem Value="MA">Maranhão</asp:ListItem>
			            <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
			            <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
			            <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
			            <asp:ListItem Value="PA">Pará</asp:ListItem>
			            <asp:ListItem Value="PB">Paraiba</asp:ListItem>
			            <asp:ListItem Value="PR">Paraná</asp:ListItem>
			            <asp:ListItem Value="PE">Pernambuco</asp:ListItem>
			            <asp:ListItem Value="PI">Piauí</asp:ListItem>
			            <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
			            <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
			            <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
			            <asp:ListItem Value="RO">Rondônia</asp:ListItem>
			            <asp:ListItem Value="RR">Roraima</asp:ListItem>
			            <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
			            <asp:ListItem Value="SP">São Paulo</asp:ListItem>
			            <asp:ListItem Value="SE">Sergipe</asp:ListItem>
			            <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                    </asp:DropDownList>
                </li>
                <li>
                    <asp:Label ID="Label16" runat="server" AssociatedControlID="TextBoxTel" Text="Telefone Próprio"></asp:Label>
                    <asp:TextBox ID="TextBoxTel" runat="server" Width="100px" MaxLength="14" onkeyup="formataTelefone(this,event);"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label17" runat="server" AssociatedControlID="TextBoxTel2" Text="Telefone Recado"></asp:Label>
                    <asp:TextBox ID="TextBoxTel2" runat="server" Width="100px" MaxLength="14" onkeyup="formataTelefone(this,event);"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label18" runat="server" Text="Banco" AssociatedControlID="DropDownListBanco"></asp:Label>
                    <asp:DropDownList ID="DropDownListBanco" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Banco ABC Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Alfa S.A.</asp:ListItem>
                        <asp:ListItem>Banco Alvorada S.A.</asp:ListItem>
                        <asp:ListItem>Banco Banerj S.A.</asp:ListItem>
                        <asp:ListItem>Banco Bankpar S.A.</asp:ListItem>
                        <asp:ListItem>Banco Barclays S.A.</asp:ListItem>
                        <asp:ListItem>Banco BBM S.A.</asp:ListItem>
                        <asp:ListItem>Banco Beg S.A.</asp:ListItem>
                        <asp:ListItem>Banco BGN S.A.</asp:ListItem>
                        <asp:ListItem>Banco BM&F de Serviços de Liquidação e Custódia S.A.</asp:ListItem>
                        <asp:ListItem>Banco BMG S.A.</asp:ListItem>
                        <asp:ListItem>Banco BNP Paribas Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Boavista Interatlântico S.A.</asp:ListItem>
                        <asp:ListItem>Banco Bonsucesso S.A.</asp:ListItem>
                        <asp:ListItem>Banco Bracce S.A.</asp:ListItem>
                        <asp:ListItem>Banco Bradesco BBI S.A.</asp:ListItem>
                        <asp:ListItem>Banco Bradesco Cartões S.A.</asp:ListItem>
                        <asp:ListItem>Banco Bradesco Financiamentos S.A.</asp:ListItem>
                        <asp:ListItem>Banco Bradesco S.A.</asp:ListItem>
                        <asp:ListItem>Banco Brascan S.A.</asp:ListItem>
                        <asp:ListItem>Banco BTG Pactual S.A.</asp:ListItem>
                        <asp:ListItem>Banco BVA S.A.</asp:ListItem>
                        <asp:ListItem>Banco Cacique S.A.</asp:ListItem>
                        <asp:ListItem>Banco Caixa Geral - Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Cargill S.A.</asp:ListItem>
                        <asp:ListItem>Banco Citibank S.A.</asp:ListItem>
                        <asp:ListItem>Banco Citicard S.A.</asp:ListItem>
                        <asp:ListItem>Banco CNH Capital S.A.</asp:ListItem>
                        <asp:ListItem>Banco Comercial e de Investimento Sudameris S.A.</asp:ListItem>
                        <asp:ListItem>Banco Cooperativo do Brasil S.A. - BANCOOB</asp:ListItem>
                        <asp:ListItem>Banco Cooperativo Sicredi S.A.</asp:ListItem>
                        <asp:ListItem>Banco Credit Agricole Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Credit Suisse (Brasil) S.A.</asp:ListItem>
                        <asp:ListItem>Banco Cruzeiro do Sul S.A.</asp:ListItem>
                        <asp:ListItem>Banco CSF S.A.</asp:ListItem>
                        <asp:ListItem>Banco da Amazônia S.A.</asp:ListItem>
                        <asp:ListItem>Banco da China Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Daycoval S.A.</asp:ListItem>
                        <asp:ListItem>Banco de Lage Landen Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco de Pernambuco S.A. - BANDEPE</asp:ListItem>
                        <asp:ListItem>Banco de Tokyo-Mitsubishi UFJ Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Dibens S.A.</asp:ListItem>
                        <asp:ListItem>Banco do Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco do Estado de Sergipe S.A.</asp:ListItem>
                        <asp:ListItem>Banco do Estado do Pará S.A.</asp:ListItem>
                        <asp:ListItem>Banco do Estado do Rio Grande do Sul S.A.</asp:ListItem>
                        <asp:ListItem>Banco do Nordeste do Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Fator S.A.</asp:ListItem>
                        <asp:ListItem>Banco Fiat S.A.</asp:ListItem>
                        <asp:ListItem>Banco Fibra S.A.</asp:ListItem>
                        <asp:ListItem>Banco Ficsa S.A.</asp:ListItem>
                        <asp:ListItem>Banco Fidis S.A.</asp:ListItem>
                        <asp:ListItem>Banco Finasa BMC S.A.</asp:ListItem>
                        <asp:ListItem>Banco Ford S.A.</asp:ListItem>
                        <asp:ListItem>Banco GE Capital S.A.</asp:ListItem>
                        <asp:ListItem>Banco GMAC S.A.</asp:ListItem>
                        <asp:ListItem>Banco Guanabara S.A.</asp:ListItem>
                        <asp:ListItem>Banco Honda S.A.</asp:ListItem>
                        <asp:ListItem>Banco Ibi S.A. Banco Múltiplo</asp:ListItem>
                        <asp:ListItem>Banco IBM S.A.</asp:ListItem>
                        <asp:ListItem>Banco Industrial do Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Industrial e Comercial S.A.</asp:ListItem>
                        <asp:ListItem>Banco Indusval S.A.</asp:ListItem>
                        <asp:ListItem>Banco Investcred Unibanco S.A.</asp:ListItem>
                        <asp:ListItem>Banco Itaú BBA S.A.</asp:ListItem>
                        <asp:ListItem>Banco ItaúBank S.A.</asp:ListItem>
                        <asp:ListItem>Banco Itaucard S.A.</asp:ListItem>
                        <asp:ListItem>Banco Itaucred Financiamentos S.A.</asp:ListItem>
                        <asp:ListItem>Banco J. P. Morgan S.A.</asp:ListItem>
                        <asp:ListItem>Banco J. Safra S.A.</asp:ListItem>
                        <asp:ListItem>Banco JBS S.A.</asp:ListItem>
                        <asp:ListItem>Banco John Deere S.A.</asp:ListItem>
                        <asp:ListItem>Banco Luso Brasileiro S.A.</asp:ListItem>
                        <asp:ListItem>Banco Mercantil do Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Modal S.A.</asp:ListItem>
                        <asp:ListItem>Banco Opportunity S.A.</asp:ListItem>
                        <asp:ListItem>Banco Panamericano S.A.</asp:ListItem>
                        <asp:ListItem>Banco Paulista S.A.</asp:ListItem>
                        <asp:ListItem>Banco Pine S.A.</asp:ListItem>
                        <asp:ListItem>Banco Prosper S.A.</asp:ListItem>
                        <asp:ListItem>Banco Rabobank International Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Real S.A.</asp:ListItem>
                        <asp:ListItem>Banco Rendimento S.A.</asp:ListItem>
                        <asp:ListItem>Banco Rodobens S.A.</asp:ListItem>
                        <asp:ListItem>Banco Rural Mais S.A.</asp:ListItem>
                        <asp:ListItem>Banco Rural S.A.</asp:ListItem>
                        <asp:ListItem>Banco Safra S.A.</asp:ListItem>
                        <asp:ListItem>Banco Santander (Brasil) S.A.</asp:ListItem>
                        <asp:ListItem>Banco Schahin S.A.</asp:ListItem>
                        <asp:ListItem>Banco Simples S.A.</asp:ListItem>
                        <asp:ListItem>Banco Société Générale Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Sofisa S.A.</asp:ListItem>
                        <asp:ListItem>Banco Standard de Investimentos S.A.</asp:ListItem>
                        <asp:ListItem>Banco Sumitomo Mitsui Brasileiro S.A.</asp:ListItem>
                        <asp:ListItem>Banco Topázio S.A.</asp:ListItem>
                        <asp:ListItem>Banco Toyota do Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Triângulo S.A.</asp:ListItem>
                        <asp:ListItem>Banco Volkswagen S.A.</asp:ListItem>
                        <asp:ListItem>Banco Volvo (Brasil) S.A.</asp:ListItem>
                        <asp:ListItem>Banco Votorantim S.A.</asp:ListItem>
                        <asp:ListItem>Banco VR S.A.</asp:ListItem>
                        <asp:ListItem>Banco Western Union do Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco WestLB do Brasil S.A.</asp:ListItem>
                        <asp:ListItem>Banco Yamaha Motor S.A.</asp:ListItem>
                        <asp:ListItem>BANESTES S.A. Banco do Estado do Espírito Santo</asp:ListItem>
                        <asp:ListItem>Banif-Banco Internacional do Funchal (Brasil)S.A.</asp:ListItem>
                        <asp:ListItem>Bank of America Merrill Lynch Banco Múltiplo S.A.</asp:ListItem>
                        <asp:ListItem>BB Banco Popular do Brasil S.A.</asp:ListItem>
                        <asp:ListItem>BES Investimento do Brasil S.A.- Banco de Investimento</asp:ListItem>
                        <asp:ListItem>BPN Brasil Banco Múltiplo S.A.</asp:ListItem>
                        <asp:ListItem>BRB - Banco de Brasília S.A.</asp:ListItem>
                        <asp:ListItem>Caixa Econômica Federal</asp:ListItem>
                        <asp:ListItem>Citibank S.A.</asp:ListItem>
                        <asp:ListItem>Concórdia Banco S.A.</asp:ListItem>
                        <asp:ListItem>Deutsche Bank S.A. - Banco Alemão</asp:ListItem>
                        <asp:ListItem>Dresdner Bank Brasil S.A. - Banco Múltiplo</asp:ListItem>
                        <asp:ListItem>Goldman Sachs do Brasil Banco Múltiplo S.A.</asp:ListItem>
                        <asp:ListItem>Hipercard Banco Múltiplo S.A.</asp:ListItem>
                        <asp:ListItem>HSBC Bank Brasil S.A. - Banco Múltiplo</asp:ListItem>
                        <asp:ListItem>ING Bank N.V.</asp:ListItem>
                        <asp:ListItem>Itaú Unibanco Holding S.A.</asp:ListItem>
                        <asp:ListItem>Itaú Unibanco S.A.</asp:ListItem>
                        <asp:ListItem>JPMorgan Chase Bank</asp:ListItem>
                        <asp:ListItem>Standard Chartered Bank (Brasil) S/A-Bco Invest.</asp:ListItem>
                        <asp:ListItem>UNIBANCO - União de Bancos Brasileiros S.A.</asp:ListItem>
                        <asp:ListItem>Unicard Banco Múltiplo S.A.</asp:ListItem>
                    </asp:DropDownList>
                </li>
                <li>
                    <asp:Label ID="Label19" runat="server" Text="Agência" AssociatedControlID="TextBoxAgencia"></asp:Label>
                    <asp:TextBox ID="TextBoxAgencia" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label20" runat="server" Text="Operação" AssociatedControlID="TextBoxOperacao"></asp:Label>
                    <asp:TextBox ID="TextBoxOperacao" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label21" runat="server" Text="Conta" AssociatedControlID="TextBoxConta"></asp:Label>
                    <asp:TextBox ID="TextBoxConta" runat="server" MaxLength="20" Width="150px"></asp:TextBox>
                </li>
                <li>
                    <asp:Label ID="Label22" runat="server" Text="Tipo" AssociatedControlID="DropDownListTipo"></asp:Label>
                    <asp:DropDownList ID="DropDownListTipo" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="CONTA CORRENTA">Conta Correnta</asp:ListItem>
                        <asp:ListItem Value="CONTA POUPANÇA">Conta Poupança</asp:ListItem>
                    </asp:DropDownList>
                </li>
                
                </asp:Panel>

                <li style="list-style-type:none;">
                    <br />
                </li>
                <li style="list-style-type:none;">
                    <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" onclick="ButtonSalvar_Click" />
                    <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False" onclick="ButtonCancelar_Click" />  
                </li>
            </ol>
        </div>
      </div>

</asp:Content>
