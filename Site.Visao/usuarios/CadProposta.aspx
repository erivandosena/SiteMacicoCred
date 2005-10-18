<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CadProposta.aspx.cs" Inherits="Site.Visao.usuarios.CadProposta" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../scripts/JSMascaras.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbar">
        <div class="formulario">
            <fieldset>
            <legend>INDICAR PROPONENTE</legend>
                <br />
                <asp:Label ID="Label38" runat="server" AssociatedControlID="TextBoxNumeroCpf" Text="Informe o CPF: "></asp:Label>
                <asp:TextBox ID="TextBoxNumeroCpf" runat="server" Width="100px" MaxLength="14" onkeyup="formataCPF(this,event);"></asp:TextBox>
                <asp:Button ID="ButtonBusca" runat="server" Text="Localizar" 
                    OnClientClick="this.disabled = true; this.value = 'Pesquisando...';" 
                    UseSubmitBehavior="False" 
                    CausesValidation="False" onclick="ButtonBusca_Click" />
                <asp:Button ID="ButtonAltera" runat="server" Text="Editar" 
                OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
                UseSubmitBehavior="False" 
                CausesValidation="False" Enabled="False" onclick="ButtonAltera_Click" />
                <br />
            </fieldset>

            <asp:Panel ID="Panel1" runat="server" Visible="False">
            
            <fieldset>
            <legend>DADOS PESSOAIS DO PROPONENTE</legend> 
                <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxNome" Text="Nome: "></asp:Label>
                <asp:TextBox ID="TextBoxNome" runat="server" Width="450px" MaxLength="80" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />
                
                <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxMae" Text="Mãe: "></asp:Label>
                <asp:TextBox ID="TextBoxMae" runat="server" Width="450px" MaxLength="80"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxMae" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />
                
                <asp:Label ID="Label3" runat="server" AssociatedControlID="TextBoxPai" Text="Pai: "></asp:Label>
                <asp:TextBox ID="TextBoxPai" runat="server" Width="450px" MaxLength="80"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPai" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />
                
                <asp:Label ID="Label4" runat="server" AssociatedControlID="TextBoxCpf" Text="CPF: "></asp:Label>
                <asp:TextBox ID="TextBoxCpf" runat="server" Width="100px" MaxLength="14" onkeyup="formataCPF(this,event);" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxCpf" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <asp:Label ID="Label5" runat="server" AssociatedControlID="TextBoxRg" Text="RG: " Style="margin-left: -60px;"></asp:Label>
                <asp:TextBox ID="TextBoxRg" runat="server" Width="100px" MaxLength="25"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxRg" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <asp:Label ID="Label6" runat="server" AssociatedControlID="TextBoxRgDtaEmis" Text="Data Emissão: " Style="margin-left: -14px;"></asp:Label>
                <asp:TextBox ID="TextBoxRgDtaEmis" runat="server" Width="65px" MaxLength="10" onkeyup="formataData(this,event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxRgDtaEmis" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />

                <asp:Label ID="Label41" runat="server" AssociatedControlID="TextBoxNb1" Text="Benefício 1: "></asp:Label>
                <asp:TextBox ID="TextBoxNb1" runat="server" Width="157px" MaxLength="15" ReadOnly="True"></asp:TextBox>

                <asp:Label ID="Label50" runat="server" AssociatedControlID="TextBoxNb2" Text="Benefício 2: "></asp:Label>
                <asp:TextBox ID="TextBoxNb2" runat="server" Width="157px" MaxLength="15" ReadOnly="True"></asp:TextBox>

                <br />
                
                <asp:Label ID="Label7" runat="server" AssociatedControlID="TextBoxNatural" Text="Naturalidade: "></asp:Label>
                <asp:TextBox ID="TextBoxNatural" runat="server" Width="100px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxNatural" ErrorMessage="*"></asp:RequiredFieldValidator>

                <asp:Label ID="Label8" runat="server" AssociatedControlID="DropDownListRgUf" Text="Estado: "></asp:Label>
                <asp:DropDownList ID="DropDownListRgUf" runat="server" Style="float: left;">
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownListRgUf" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />
                
                <asp:Label ID="Label9" runat="server" AssociatedControlID="TextBoxDatNasc" Text="Data Nascimento: "></asp:Label>
                <asp:TextBox ID="TextBoxDatNasc" runat="server" Width="100px" MaxLength="10" onkeyup="formataData(this,event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxDatNasc" ErrorMessage="*"></asp:RequiredFieldValidator>

                <asp:Label ID="Label10" runat="server" AssociatedControlID="DropDownListSexo" Text="Sexo: "></asp:Label>
                <asp:DropDownList ID="DropDownListSexo" runat="server" Style="float: left;">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="MASCULINO">Masculino</asp:ListItem>
                    <asp:ListItem Value="FEMININO">Feminino</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDownListSexo" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />
                
                <asp:Label ID="Label11" runat="server" AssociatedControlID="TextBoxTel" Text="Telefone Próprio: "></asp:Label>
                <asp:TextBox ID="TextBoxTel" runat="server" Width="100px" MaxLength="14" onkeyup="formataTelefone(this,event);"></asp:TextBox>
                
                <span style="margin-left: 9px;">
                <asp:Label ID="Label12" runat="server" AssociatedControlID="TextBoxTel2" Text="Telefone Recado: "></asp:Label>
                <asp:TextBox ID="TextBoxTel2" runat="server" Width="100px" MaxLength="14" onkeyup="formataTelefone(this,event);"></asp:TextBox>
                </span>

                <br />
                
                <asp:Label ID="Label21" runat="server" AssociatedControlID="TextBoxRenda" Text="Valor Renda R$: "></asp:Label>
                <asp:TextBox ID="TextBoxRenda" runat="server" Width="100px" onkeyup="formataValor(this,event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TextBoxRenda" ErrorMessage="*"></asp:RequiredFieldValidator>

                <asp:Label ID="LabelEmail" runat="server" AssociatedControlID="TextBoxEmail" Text="E-mail: " Visible="False"></asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server" Width="220px" Visible="False"></asp:TextBox>
            </fieldset>
           
            <fieldset>
            <legend>DADOS RESIDENCIAIS</legend>
                <asp:Label ID="Label13" runat="server" AssociatedControlID="TextBoxEndereco" Text="Endereço: "></asp:Label>
                <asp:TextBox ID="TextBoxEndereco" runat="server" Width="450px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBoxEndereco" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />
                
                <asp:Label ID="Label14" runat="server" AssociatedControlID="TextBoxReferencia" Text="Ponto Referência: "></asp:Label>
                <asp:TextBox ID="TextBoxReferencia" runat="server" Width="450px" MaxLength="50"></asp:TextBox>
                
                <br />
                
                <asp:Label ID="Label15" runat="server" AssociatedControlID="TextBoxCep" Text="CEP: "></asp:Label>
                <asp:TextBox ID="TextBoxCep" runat="server" Width="100px" MaxLength="9" onkeyup="formataCEP(this,event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBoxCep" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <asp:Label ID="Label16" runat="server" AssociatedControlID="TextBoxBairro" Text="Bairro: "></asp:Label>
                <asp:TextBox ID="TextBoxBairro" runat="server" Width="150px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBoxBairro" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />

                <asp:Label ID="Label17" runat="server" AssociatedControlID="TextBoxCidade" Text="Cidade: "></asp:Label>
                <asp:TextBox ID="TextBoxCidade" runat="server" Width="100px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBoxCidade" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <asp:Label ID="Label18" runat="server" AssociatedControlID="DropDownListUf" Text="Estado: "></asp:Label>
                <asp:DropDownList ID="DropDownListUf" runat="server" Style="float: left;">
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="DropDownListUf" ErrorMessage="*"></asp:RequiredFieldValidator>   
            </fieldset>

            </asp:Panel>
           
            <fieldset>
            <legend>DADOS DO BENEFÍCIO</legend> 
                <asp:Label ID="Label19" runat="server" AssociatedControlID="TextBoxNb" Text="NB: "></asp:Label>
                <asp:TextBox ID="TextBoxNb" runat="server" Width="157px" MaxLength="15" onkeyup="formataInteiro(this,event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBoxNb" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <asp:Label ID="Label20" runat="server" AssociatedControlID="TextBoxNit" Text="NIT: "></asp:Label>
                <asp:TextBox ID="TextBoxNit" runat="server" Width="157px" MaxLength="15" onkeyup="formataInteiro(this,event);"></asp:TextBox>
                
                <br />
                
                <asp:Label ID="Label22" runat="server" AssociatedControlID="DropDownListEspecie" Text="Espécie Benefício: "></asp:Label>
                <asp:DropDownList ID="DropDownListEspecie" runat="server" Width="450" Style="float: left;">
                <asp:ListItem></asp:ListItem>
                    <Asp:Listitem Value="01 PENSÃO POR MORTE DE TRABALHADOR RURAL">01 Pensão por Morte de Trabalhador Rural</Asp:Listitem>
                    <Asp:Listitem Value="02 PENSÃO POR MORTE ACIDENTARIA-TRAB. RURAL">02 Pensão por Morte Acidentaria-Trab. Rural</Asp:Listitem>
                    <Asp:Listitem Value="03 PENSÃO POR MORTE DE EMPREGADOR RURAL">03 Pensão por Morte de Empregador Rural</Asp:Listitem>
                    <Asp:Listitem Value="04 APOSENTADORIA POR INVALIDEZ-TRAB. RURAL">04 Aposentadoria por Invalidez-Trab. Rural</Asp:Listitem>
                    <Asp:Listitem Value="05 APOSENT. INVALIDEZ ACIDENTARIA-TRAB.RURAL">05 Aposent. Invalidez Acidentaria-Trab.Rural</Asp:Listitem>
                    <Asp:Listitem Value="06 APOSENT. INVALIDEZ EMPREGADOR RURAL">06 Aposent. Invalidez Empregador Rural</Asp:Listitem>
                    <Asp:Listitem Value="07 APOSENTADORIA POR VELHICE - TRAB. RURAL">07 Aposentadoria por Velhice - Trab. Rural</Asp:Listitem>
                    <Asp:Listitem Value="08 APOSENT. POR IDADE - EMPREGADOR RURAL">08 Aposent. por Idade - Empregador Rural</Asp:Listitem>
                    <Asp:Listitem Value="19 PENSÃO DE ESTUDANTE (LEI 7.004/82)">19 Pensão de Estudante (Lei 7.004/82)</Asp:Listitem>
                    <Asp:Listitem Value="20 PENSÃO POR MORTE DE EX-DIPLOMATA">20 Pensão por Morte de Ex-Diplomata</Asp:Listitem>
                    <Asp:Listitem Value="21 PENSÃO POR MORTE PREVIDENCIARIA">21 Pensão por Morte Previdenciaria</Asp:Listitem>
                    <Asp:Listitem Value="22 PENSÃO POR MORTE ESTATUTARIA">22 Pensão por Morte Estatutaria</Asp:Listitem>
                    <Asp:Listitem Value="23 PENSÃO POR MORTE DE EX-COMBATENTE">23 Pensão por Morte de Ex-Combatente</Asp:Listitem>
                    <Asp:Listitem Value="24 PENSÃO ESPECIAL (ATO INSTITUCIONAL)">24 Pensão Especial (Ato Institucional)</Asp:Listitem>
                    <Asp:Listitem Value="26 PENSÃO POR MORTE ESPECIAL">26 Pensão por Morte Especial</Asp:Listitem>
                    <Asp:Listitem Value="27 PENSÃO MORTE SERVIDOR PUBLICO FEDERAL">27 Pensão Morte Servidor Publico Federal</Asp:Listitem>
                    <Asp:Listitem Value="28 PENSÃO POR MORTE REGIME GERAL">28 Pensão por Morte Regime Geral</Asp:Listitem>
                    <Asp:Listitem Value="29 PENSÃO POR MORTE EX-COMBATENTE MARITIMO">29 Pensão por Morte Ex-Combatente Maritimo</Asp:Listitem>
                    <Asp:Listitem Value="32 APOSENTADORIA INVALIDEZ PREVIDENCIARIA">32 Aposentadoria Invalidez Previdenciaria</Asp:Listitem>
                    <Asp:Listitem Value="33 APOSENTADORIA INVALIDEZ AERONAUTA">33 Aposentadoria Invalidez Aeronauta</Asp:Listitem>
                    <Asp:Listitem Value="34 APOSENT. INVAL. EX-COMBATENTE MARITIMO">34 Aposent. Inval. Ex-Combatente Maritimo</Asp:Listitem>
                    <Asp:Listitem Value="37 APOSENTADORIA EXTRANUMERARIO CAPIN">37 Aposentadoria Extranumerario Capin</Asp:Listitem>
                    <Asp:Listitem Value="38 APOSENT. EXTRANUM. FUNCIONARIO PUBLICO">38 Aposent. Extranum. Funcionario Publico</Asp:Listitem>
                    <Asp:Listitem Value="41 APOSENTADORIA POR IDADE">41 Aposentadoria por Idade</Asp:Listitem>
                    <Asp:Listitem Value="42 APOSENTADORIA POR TEMPO DE CONTRIBUICAO">42 Aposentadoria por Tempo de Contribuicao</Asp:Listitem>
                    <Asp:Listitem Value="43 APOSENT. POR TEMPO SERVICO EX-COMBATENTE">43 Aposent. por Tempo Servico Ex-Combatente</Asp:Listitem>
                    <Asp:Listitem Value="44 APOSENTADORIA ESPECIAL DE AERONAUTA">44 Aposentadoria Especial De Aeronauta</Asp:Listitem>
                    <Asp:Listitem Value="45 APOSENT. TEMPO SERVICO JORNALISTA">45 Aposent. Tempo Servico Jornalista</Asp:Listitem>
                    <Asp:Listitem Value="46 APOSENTADORIA ESPECIAL">46 Aposentadoria Especial</Asp:Listitem>
                    <Asp:Listitem Value="49 APOSENTADORIA ORDINARIA">49 Aposentadoria Ordinaria</Asp:Listitem>
                    <Asp:Listitem Value="51 APOSENT. INVALIDEZ EXTINTO PLANO BASICO">51 Aposent. Invalidez Extinto Plano Basico</Asp:Listitem>
                    <Asp:Listitem Value="52 APOSENT. IDADE EXTINTO PLANO BASICO">52 Aposent. Idade Extinto Plano Basico</Asp:Listitem>
                    <Asp:Listitem Value="54 PENSÃO ESPECIAL VITALICIA - LEI 9793/99">54 Pensão Especial Vitalicia - Lei 9793/99</Asp:Listitem>
                    <Asp:Listitem Value="55 PENSÃO POR MORTE EXTINTO PLANO BASICO">55 Pensão por Morte Extinto Plano Basico</Asp:Listitem>
                    <Asp:Listitem Value="56 PENSÃO VITALICIA SINDROME TALIDOMIDA">56 Pensão Vitalicia Sindrome Talidomida</Asp:Listitem>
                    <Asp:Listitem Value="57 APOSENT. TEMPO DE SERVICO DE PROFESSOR">57 Aposent. Tempo de Servico de Professor</Asp:Listitem>
                    <Asp:Listitem Value="58 APOSENTADORIA DE ANISTIADOS">58 Aposentadoria de Anistiados</Asp:Listitem>
                    <Asp:Listitem Value="59 PENSÃO POR MORTE DE ANISTIADOS">59 Pensão por Morte de Anistiados</Asp:Listitem>
                    <Asp:Listitem Value="60 PENSÃO ESPECIAL PORTADOR DE SIDA">60 Pensão Especial Portador de Sida</Asp:Listitem>
                    <Asp:Listitem Value="72 APOSENT. TEMPO SERVICO - LEI DE GUERRA">72 Aposent. Tempo Servico - Lei de Guerra</Asp:Listitem>
                    <Asp:Listitem Value="78 APOSENTADORIA IDADE - LEI DE GUERRA">78 Aposentadoria Idade - Lei de Guerra</Asp:Listitem>
                    <Asp:Listitem Value="81 APOSENTADORIA COMPULSORIA EX-SASSE">81 Aposentadoria Compulsoria Ex-Sasse</Asp:Listitem>
                    <Asp:Listitem Value="82 APOSENTADORIA TEMPO DE SERVICO EX-SASSE">82 Aposentadoria Tempo de Servico Ex-Sasse</Asp:Listitem>
                    <Asp:Listitem Value="83 APOSENTADORIA POR INVALIDEZ EX-SASSE">83 Aposentadoria por Invalidez Ex-Sasse</Asp:Listitem>
                    <Asp:Listitem Value="84 PENSÃO POR MORTE EX-SASSE">84 Pensão por Morte Ex-Sasse</Asp:Listitem>
                    <Asp:Listitem Value="89 PENSÃO ESP. VITIMAS HEMODIALISE-CARUARU">89 Pensão Esp. Vitimas Hemodialise-Caruaru</Asp:Listitem>
                    <Asp:Listitem Value="92 APOSENT. INVALIDEZ ACIDENTE TRABALHO">92 Aposent. Invalidez Acidente Trabalho</Asp:Listitem>
                    <Asp:Listitem Value="93 PENSÃO POR MORTE ACIDENTE DO TRABALHO">93 Pensão por Morte Acidente do Trabalho</Asp:Listitem>
                    <Asp:Listitem Value="96 PENSÃO ESPECIAL PARA AS PESSOAS ATINGIDAS PELA HANSENÍASE">96 Pensão Especial para as Pessoas Atingidas pela Hanseníase</Asp:Listitem>
                </asp:DropDownList> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="DropDownListEspecie" ErrorMessage="*"></asp:RequiredFieldValidator>

                <br />
                
                <asp:Label ID="Label23" runat="server" AssociatedControlID="DropDownListFormaRec" Text="Forma de Recebimento do Benefício: " Width="230"></asp:Label>
                <asp:DropDownList ID="DropDownListFormaRec" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownListFormaRec_SelectedIndexChanged" Style="float: left;">
                   <asp:ListItem></asp:ListItem>
                   <asp:ListItem Value="CONTA CORRENTA">Conta Correnta</asp:ListItem>
                   <asp:ListItem Value="CARTÃO MAGNÉTICO">Cartão Magnético</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="DropDownListFormaRec" ErrorMessage="*"></asp:RequiredFieldValidator> 
                
                <br />
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                
                <asp:Label ID="Label24" runat="server" AssociatedControlID="DropDownListBancoRec" Text="Banco: "></asp:Label>
                <asp:DropDownList ID="DropDownListBancoRec" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="BANCO BRADESCO">237 Banco Bradesco S.A.</asp:ListItem>
                    <asp:ListItem Value="BANCO DO BRASIL">001 Banco do Brasil S.A.</asp:ListItem>
                    <asp:ListItem Value="BANCO DO NORDESTE DO BRASIL">004 Banco do Nordeste do Brasil S.A.</asp:ListItem>
                    <asp:ListItem Value="BANCO REAL">356 Banco Real S.A.</asp:ListItem>
                    <asp:ListItem Value="BANCO SANTANDER">033 Banco Santander (Brasil) S.A.</asp:ListItem>
                    <asp:ListItem Value="CAIXA ECONÔMICA FEDERAL">104 Caixa Econômica Federal</asp:ListItem>
                    <asp:ListItem Value="HSBC BANK BRASIL">399 HSBC Bank Brasil S.A. - Banco Múltiplo</asp:ListItem>
                    <asp:ListItem Value="ITAÚ UNIBANCO">341 Itaú Unibanco S.A.</asp:ListItem>
                    <asp:ListItem Value="UNIBANCO">409 UNIBANCO - União de Bancos Brasileiros S.A.</asp:ListItem>
                </asp:DropDownList>
                
                <br />
                
                <asp:Label ID="Label25" runat="server" AssociatedControlID="TextBoxAgencia" Text="Agência: "></asp:Label>
                <asp:TextBox ID="TextBoxAgencia" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                
                <asp:Label ID="Label26" runat="server" AssociatedControlID="TextBoxOperacao" Text="Operação: " Style="margin-left: -24px;"></asp:Label>
                <asp:TextBox ID="TextBoxOperacao" runat="server" Width="50px" MaxLength="10"></asp:TextBox>
                
                <asp:Label ID="Label27" runat="server" AssociatedControlID="TextBoxConta" Text="Conta: " Style="margin-left: -28px;"></asp:Label>
                <asp:TextBox ID="TextBoxConta" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
                
                <br />

                </asp:Panel>
                
                <asp:Label ID="Label28" runat="server" AssociatedControlID="TextBoxSolicitado" Text="Valor Solicitado R$: "></asp:Label>
                <asp:TextBox ID="TextBoxSolicitado" runat="server" Width="95px" onkeyup="formataValor(this,event);"></asp:TextBox>

                <span style="margin-left: 15px;">
                <asp:Label ID="Label29" runat="server" AssociatedControlID="TextBoxPrestacao" Text="Valor Prestação R$: "></asp:Label>
                <asp:TextBox ID="TextBoxPrestacao" runat="server" Width="85px" onkeyup="formataValor(this,event);"></asp:TextBox>
                </span>
                 
                <asp:Label ID="Label30" runat="server" AssociatedControlID="DropDownListPlano" Text="Plano: " Style="margin-left: -40px;"></asp:Label>
                <asp:DropDownList ID="DropDownListPlano" runat="server">
                   <asp:ListItem></asp:ListItem>
                   <asp:ListItem Value="24">24</asp:ListItem>
                   <asp:ListItem Value="36">36</asp:ListItem>
                   <asp:ListItem Value="48">48</asp:ListItem>
                   <asp:ListItem Value="59">59</asp:ListItem>
                   <asp:ListItem Value="60">60</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="DropDownListPlano" ErrorMessage="*"></asp:RequiredFieldValidator>
                 
               <br />

               <asp:Label ID="Label31" runat="server" AssociatedControlID="DropDownListLibEmp" Text="Liberação do Empréstimo: " Width="150"></asp:Label>
               <asp:DropDownList ID="DropDownListLibEmp" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownListLibEmp_SelectedIndexChanged" Style="float: left;">
                   <asp:ListItem></asp:ListItem>
                   <asp:ListItem Value="TED">TED</asp:ListItem>
                   <asp:ListItem Value="OP PARA O BANCO">OP para o banco</asp:ListItem>
               </asp:DropDownList>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="DropDownListLibEmp" ErrorMessage="*"></asp:RequiredFieldValidator>  
               
               <br />
                
                <asp:Panel ID="Panel3" runat="server" Visible="False">
               
               <span style="margin-left: 0px;">
               <asp:Label ID="Label32" runat="server" AssociatedControlID="DropDownListBancoEmp" Text="Banco: "></asp:Label>
                <asp:DropDownList ID="DropDownListBancoEmp" runat="server" Width="280px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="BANCO BRADESCO">237 Banco Bradesco S.A.</asp:ListItem>
                    <asp:ListItem Value="BANCO DO BRASIL">001 Banco do Brasil S.A.</asp:ListItem>
                    <asp:ListItem Value="BANCO DO NORDESTE DO BRASIL">004 Banco do Nordeste do Brasil S.A.</asp:ListItem>
                    <asp:ListItem Value="BANCO REAL">356 Banco Real S.A.</asp:ListItem>
                    <asp:ListItem Value="BANCO SANTANDER">033 Banco Santander (Brasil) S.A.</asp:ListItem>
                    <asp:ListItem Value="CAIXA ECONÔMICA FEDERAL">104 Caixa Econômica Federal</asp:ListItem>
                    <asp:ListItem Value="HSBC BANK BRASIL">399 HSBC Bank Brasil S.A. - Banco Múltiplo</asp:ListItem>
                    <asp:ListItem Value="ITAÚ UNIBANCO">341 Itaú Unibanco S.A.</asp:ListItem>
                    <asp:ListItem Value="UNIBANCO">409 UNIBANCO - União de Bancos Brasileiros S.A.</asp:ListItem>
                </asp:DropDownList>
                </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="DropDownListBancoEmp" ErrorMessage="*"></asp:RequiredFieldValidator>
               
               <asp:Label ID="Label33" runat="server" AssociatedControlID="TextBoxCidadeBancoEmp" Text="Cidade: " Style="margin-left: -55px;"></asp:Label>
               <asp:TextBox ID="TextBoxCidadeBancoEmp" runat="server" Width="100" MaxLength="30"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBoxCidadeBancoEmp" ErrorMessage="*"></asp:RequiredFieldValidator>
               
               <br />
               </asp:Panel>
               <asp:Panel ID="Panel4" runat="server" Visible="False">
               
               <asp:Label ID="Label34" runat="server" AssociatedControlID="TextBoxAgenciaEmp" Text="Agência: "></asp:Label>
               <asp:TextBox ID="TextBoxAgenciaEmp" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
               
               <asp:Label ID="Label35" runat="server" AssociatedControlID="TextBoxOpAgenciaEmp" Text="Operação: " Style="margin-left: -24px;"></asp:Label>
               <asp:TextBox ID="TextBoxOpAgenciaEmp" runat="server" Width="50px" MaxLength="10"></asp:TextBox>
               
               <asp:Label ID="Label36" runat="server" AssociatedControlID="TextBoxContaEmp" Text="Conta: " Style="margin-left: -24px;"></asp:Label>
               <asp:TextBox ID="TextBoxContaEmp" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
               </asp:Panel>         
        </fieldset>

            <fieldset>
                <legend>DADOS DO BANCO CONSIGNADO</legend>           
                    <asp:Label ID="Label39" runat="server" AssociatedControlID="DropDownListBanco" Text="Banco: "></asp:Label>
                    <asp:DropDownList ID="DropDownListBanco" runat="server" DataSourceID="ObjectDataSourceBanco" DataTextField="ban_nome" DataValueField="ban_cod" Style="float:left;">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSourceBanco" runat="server" SelectMethod="RecuperaBancos" TypeName="Site.Modelo.Banco"></asp:ObjectDataSource>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="DropDownListBanco" ErrorMessage="*"></asp:RequiredFieldValidator>
                   
                   <asp:Label ID="Label40" runat="server" AssociatedControlID="DropDownListTipo" Text="Tipo: " Style="margin-left: 43px"></asp:Label>
                    <asp:DropDownList ID="DropDownListTipo" runat="server" Style="float:left;">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>NOVO</asp:ListItem>
                        <asp:ListItem>REFIN</asp:ListItem>
                        <asp:ListItem>RECOMPRA</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="DropDownListTipo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </fieldset>
        
            <fieldset>
                <legend>DADOS DO AGENTE</legend>           
                    <asp:Label ID="Label37" runat="server" AssociatedControlID="TextBoxAgente" Text="Nome: "></asp:Label>
                    <asp:TextBox ID="TextBoxAgente" runat="server" Width="290" ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="TextBoxAgente" ErrorMessage="*"></asp:RequiredFieldValidator>

                    <asp:Label ID="Label49" runat="server" AssociatedControlID="TextBoxAgente" Text="Código: " Style="margin-left: -60px;"></asp:Label>
                    <asp:TextBox ID="TextBoxCodCorretor" runat="server" Width="50" onkeyup="formataInteiro(this,event);"></asp:TextBox>
                    <asp:Button ID="ButtonCorretor" runat="server" Text="Ok" 
                    onclick="ButtonCorretor_Click" />
            </fieldset>
        
            <fieldset>
                <legend>DOCUMENTOS DIGITALIZADOS</legend>
                   <asp:Label ID="Label42" runat="server" AssociatedControlID="FileUpload1" Text="Documento 1: "></asp:Label>
                   <asp:FileUpload ID="FileUpload1" runat="server" />
                   
                   <br />
                   
                   <asp:Label ID="Label43" runat="server" AssociatedControlID="FileUpload2" Text="Documento 2: "></asp:Label>
                   <asp:FileUpload ID="FileUpload2" runat="server" />
                   
                   <br />
                   
                   <asp:Label ID="Label44" runat="server" AssociatedControlID="FileUpload3" Text="Documento 3: "></asp:Label>
                   <asp:FileUpload ID="FileUpload3" runat="server" />
                   
                   <br />
                   
                   <asp:Label ID="Label45" runat="server" AssociatedControlID="FileUpload4" Text="Documento 4: "></asp:Label>
                   <asp:FileUpload ID="FileUpload4" runat="server" />
                   
                   <br />
                   
                   <asp:Label ID="Label46" runat="server" AssociatedControlID="FileUpload5" Text="Documento 5: "></asp:Label>
                   <asp:FileUpload ID="FileUpload5" runat="server" />

                   <br />
                   
                   <asp:Label ID="Label51" runat="server" AssociatedControlID="TextBoxObs" Text="Observação:"></asp:Label>
                   <asp:TextBox ID="TextBoxObs" runat="server" Width="450" Height="100" TextMode="MultiLine"></asp:TextBox>
            </fieldset>

            <br />
            
            <asp:Label ID="Label48" runat="server" Text="Arquivos enviados: " Visible="False"></asp:Label>
                        
            <br />
            
            <asp:Button ID="ButtonExcluiArq" runat="server" CausesValidation="False" Text="Excluir arquivo" onclick="ButtonExcluiArq_Click" Enabled="False" />
 
            <br />

            <asp:Label ID="Label47" runat="server" Text="" ForeColor="#FB3200"></asp:Label>
            
            <br />
            
            <asp:Button ID="ButtonSalvar" runat="server" Text="Enviar" onclick="ButtonSalvar_Click" />
             
                <asp:LoginView ID="LoginView1" runat="server">
                    <RoleGroups>
                        <asp:RoleGroup Roles="Administrador">
                            <ContentTemplate>
                                <asp:Button ID="ButtonAceitar" runat="server" Text="Aprovar" onclick="ButtonAceitar_Click"/>
                                <asp:Button ID="ButtonNegar" runat="server" Text="Negar" onclick="ButtonNegar_Click"/>
                            </ContentTemplate>
                        </asp:RoleGroup>
                    </RoleGroups>
                </asp:LoginView>
            <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False" onclick="ButtonCancelar_Click" />
            
        </div>  
    </div>

</asp:Content>
