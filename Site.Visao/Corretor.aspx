<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Corretor.aspx.cs" Inherits="Site.Visao.Corretor" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Scripts/JSMascaras.js" type="text/javascript"></script>

    <script type="text/javascript">
        function submitOnce(myButton) {
            // Client side validation
            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false) {
                    return false;
                }
            }

            if (myButton.getAttribute('type') == 'button') {
                myButton.disabled = true;
                myButton.value = "Enviando...";
            }
            return true;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="mainbar">
        <div class="article">
          <h2><span>Cadastro </span>de Corretor</h2>
          <p>Informe todas as informações solicitadas no formulário abaixo, após enviar, 
              confira se recebeu no e-mail cadastrado um documento contendo o termo de 
              responsabilidade, <strong>imprima</strong>, <strong>assine</strong> e entregue em nossa loja para análise.</p>
          <div class="clr"></div>
            <ol>
                <li>
                <asp:Label ID="Label1" runat="server" Text="Nome completo " AssociatedControlID="TextBoxNome">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxNome"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxNome" runat="server" CssClass="text" MaxLength="80"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label2" runat="server" Text="Endereço residencial " AssociatedControlID="TextBoxEndResidencial">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxEndResidencial"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxEndResidencial" runat="server" CssClass="text" MaxLength="100"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label3" runat="server" Text="Endereço comercial " AssociatedControlID="TextBoxEndComercial"></asp:Label>
                <asp:TextBox ID="TextBoxEndComercial" runat="server" CssClass="text" MaxLength="100"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label4" runat="server" Text="Bairro " AssociatedControlID="TextBoxBairro">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxBairro"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxBairro" runat="server" CssClass="text" MaxLength="50" Width="240px"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label5" runat="server" Text="CEP " AssociatedControlID="TextBoxCep">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxCep"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxCep" runat="server" CssClass="text" MaxLength="9" Width="240px" onKeyUp="formataCEP(this,event);"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label6" runat="server" Text="Cidade " AssociatedControlID="TextBoxCidade">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxCidade"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxCidade" runat="server" CssClass="text" MaxLength="30" Width="240px"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label7" runat="server" Text="Estado " AssociatedControlID="DropDownListEstado">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="DropDownListEstado"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:DropDownList ID="DropDownListEstado" runat="server" CssClass="select" Width="246px">
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
                <asp:Label ID="Label8" runat="server" Text="Telefone fixo " AssociatedControlID="TextBoxTel"></asp:Label>
                <asp:TextBox ID="TextBoxTel" runat="server" CssClass="text" MaxLength="14" Width="240px" onKeyUp="formataTelefone(this,event);"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label9" runat="server" Text="Telefone celular " AssociatedControlID="TextBoxCel"></asp:Label>
                <asp:TextBox ID="TextBoxCel" runat="server" CssClass="text" MaxLength="14" Width="240px" onkeyup="formataTelefone(this,event);"></asp:TextBox>
                </li>

                <li><asp:Label ID="Label10" runat="server" Text="E-mail " AssociatedControlID="TextBoxEmail">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxEmail"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="text" MaxLength="50" Width="240px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Width="240px" ErrorMessage="E-mail inválido." ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </li>

                <li>
                <asp:Label ID="Label11" runat="server" Text="Data de nascimento " AssociatedControlID="TextBoxNascimneto">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxNascimneto"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxNascimneto" runat="server" CssClass="text" MaxLength="10" Width="240px" onkeyup="formataData(this,event);"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Width="240px" ErrorMessage="Data inválida." ControlToValidate="TextBoxNascimneto" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
                </li>

                <li>
                <asp:Label ID="Label12" runat="server" Text="CPF " AssociatedControlID="TextBoxCpf">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxCpf"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxCpf" runat="server" CssClass="text" MaxLength="14" Width="240px" onKeyUp="formataCPF(this,event);"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label13" runat="server" Text="RG " AssociatedControlID="TextBoxRg">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxRg"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxRg" runat="server" CssClass="text" MaxLength="25" Width="240px"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label14" runat="server" Text="Banco que você possui conta: " AssociatedControlID="DropDownListBanco">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="DropDownListBanco"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:DropDownList ID="DropDownListBanco" runat="server" CssClass="select">
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
                    <asp:ListItem>Standard Chartered Bank (Brasil) S/A–Bco Invest.</asp:ListItem>
                    <asp:ListItem>UNIBANCO - União de Bancos Brasileiros S.A.</asp:ListItem>
                    <asp:ListItem>Unicard Banco Múltiplo S.A.</asp:ListItem>
                </asp:DropDownList>
                </li>

                <li>
                <asp:Label ID="Label15" runat="server" Text="Agência " AssociatedControlID="TextBoxAgencia">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxAgencia"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxAgencia" runat="server" CssClass="text" MaxLength="10" Width="240px"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label16" runat="server" Text="Operação " AssociatedControlID="TextBoxOperacao"></asp:Label>
                <asp:TextBox ID="TextBoxOperacao" runat="server" CssClass="text" MaxLength="10" Width="240px"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label17" runat="server" Text="Conta " AssociatedControlID="TextBoxConta">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxConta"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxConta" runat="server" CssClass="text" MaxLength="20" Width="240px"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label18" runat="server" Text="Tipo " AssociatedControlID="DropDownListTipo">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="DropDownListTipo"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:DropDownList ID="DropDownListTipo" runat="server" CssClass="select" Width="246px">
                   <asp:ListItem></asp:ListItem>
                   <asp:ListItem Value="CONTA CORRENTA">Conta Correnta</asp:ListItem>
                   <asp:ListItem Value="CONTA POUPANÇA">Conta Poupança</asp:ListItem>
                </asp:DropDownList>
                </li>

                <li>
                <asp:Label ID="Label19" runat="server" Text="Meta proposta R$ (produção) " AssociatedControlID="TextBoxMeta">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxMeta"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxMeta" runat="server" CssClass="text" MaxLength="20" Width="240px" onkeyup="formataValor(this,event);"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label20" runat="server" Text="1ª Atividade anterior " AssociatedControlID="TextBoxAtiv1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxAtiv1"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxAtiv1" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label21" runat="server" Text="Contato (Ex: nome e telefone) " AssociatedControlID="TextBoxCont1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxAtiv1"></asp:RequiredFieldValidator>
                </asp:Label>
                <asp:TextBox ID="TextBoxCont1" runat="server" CssClass="text" MaxLength="50" Width="240px"></asp:TextBox>
                </li>
                  
                <li>
                <asp:Label ID="Label22" runat="server" Text="2ª Atividade anterior" AssociatedControlID="TextBoxAtiv2"></asp:Label>
                <asp:TextBox ID="TextBoxAtiv2" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label23" runat="server" Text="Contato (Ex: nome e telefone)" AssociatedControlID="TextBoxCont2"></asp:Label>
                <asp:TextBox ID="TextBoxCont2" runat="server" CssClass="text" MaxLength="50" Width="240px"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label24" runat="server" Text="3ª Atividade anterior" AssociatedControlID="TextBoxAtiv3"></asp:Label>
                <asp:TextBox ID="TextBoxAtiv3" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label25" runat="server" Text="Contato (Ex: nome e telefone)" AssociatedControlID="TextBoxCont3"></asp:Label>
                <asp:TextBox ID="TextBoxCont3" runat="server" CssClass="text" MaxLength="50" Width="240px"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label26" runat="server" Text="Formalização (descrição)" AssociatedControlID="TextBoxFormalizacao"></asp:Label>
                <asp:TextBox ID="TextBoxFormalizacao" runat="server" CssClass="textarea" TextMode="MultiLine" Columns="50" Rows="8"></asp:TextBox>
                </li>

                <li>
                <asp:Label ID="Label27" runat="server" Text="Termos de uso" AssociatedControlID="TextBoxTermosUso"></asp:Label>
                <asp:TextBox ID="TextBoxTermosUso" runat="server" TextMode="MultiLine"  CssClass="textarea" Width="100%" ReadOnly="True" Rows="19" Font-Names="Verdana" Font-Size="9pt" />
                </li>

                <asp:Button ID="Button1" runat="server" Text="Gerar formulário para preenchimento manual" onclick="Button1_Click" Visible="False" Style="margin-top:16px;" CausesValidation="False"/>

                <li>
                <asp:Button ID="ButtonEnvia" runat="server" CssClass="envia" Text="Enviar" 
                        onclick="ButtonEnvia_Click" CausesValidation="False" 
                        OnClientClick="submitOnce(this);" UseSubmitBehavior="False"/>
                </li>
            </ol>
        </div>

    </div>
</asp:Content>
