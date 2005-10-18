<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CadCliente.aspx.cs" Inherits="Site.Visao.usuarios.CadCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../scripts/JSMascaras.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
    <div class="mainbar">
        <div class="formulario">
            <fieldset>
            <legend>DADOS PESSOAIS</legend> 
                <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxNome" Text="Nome: "></asp:Label>
                <asp:TextBox ID="TextBoxNome" runat="server" Width="450px" MaxLength="80"></asp:TextBox>
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
                <asp:TextBox ID="TextBoxCpf" runat="server" Width="100px" MaxLength="14" onkeyup="formataCPF(this,event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxCpf" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <span style="margin-left: -60px;">
                <asp:Label ID="Label5" runat="server" AssociatedControlID="TextBoxRg" Text="RG: "></asp:Label>
                <asp:TextBox ID="TextBoxRg" runat="server" Width="100px" MaxLength="25"></asp:TextBox>
                </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxRg" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <span style="margin-left: -14px;">
                <asp:Label ID="Label6" runat="server" AssociatedControlID="TextBoxRgDtaEmis" Text="Data Emissão: "></asp:Label>
                <asp:TextBox ID="TextBoxRgDtaEmis" runat="server" Width="65px" MaxLength="10" onkeyup="formataData(this,event);"></asp:TextBox>
                </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxRgDtaEmis" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />
                
                <asp:Label ID="Label7" runat="server" AssociatedControlID="TextBoxNatural" Text="Naturalidade: "></asp:Label>
                <asp:TextBox ID="TextBoxNatural" runat="server" Width="100px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxNatural" ErrorMessage="*"></asp:RequiredFieldValidator>

                <asp:Label ID="Label8" runat="server" AssociatedControlID="DropDownListRgUf" Text="Estado: "></asp:Label>
                <span style="float: left;">
                <asp:DropDownList ID="DropDownListRgUf" runat="server">
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
                </span>
                <span style="float: left;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownListRgUf" ErrorMessage="*"></asp:RequiredFieldValidator>
                </span>
                
                <br />
                
                <asp:Label ID="Label9" runat="server" AssociatedControlID="TextBoxDatNasc" Text="Data Nascimento: "></asp:Label>
                <asp:TextBox ID="TextBoxDatNasc" runat="server" Width="100px" MaxLength="10" onkeyup="formataData(this,event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxDatNasc" ErrorMessage="*"></asp:RequiredFieldValidator>

                <asp:Label ID="Label10" runat="server" AssociatedControlID="DropDownListSexo" Text="Sexo: "></asp:Label>
                <span style="float: left;">
                <asp:DropDownList ID="DropDownListSexo" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="MASCULINO">Masculino</asp:ListItem>
                    <asp:ListItem Value="FEMININO">Feminino</asp:ListItem>
                </asp:DropDownList>
                </span>
                <span style="float: left;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDownListSexo" ErrorMessage="*"></asp:RequiredFieldValidator>
                </span>
                
                <br />
                
                <asp:Label ID="Label11" runat="server" AssociatedControlID="TextBoxTel" Text="Telefone Próprio: "></asp:Label>
                <asp:TextBox ID="TextBoxTel" runat="server" Width="100px" MaxLength="14" onkeyup="formataTelefone(this,event);"></asp:TextBox>
                
                <span style="margin-left: 9px;">
                <asp:Label ID="Label12" runat="server" AssociatedControlID="TextBoxTel2" Text="Telefone Recado: "></asp:Label>
                <asp:TextBox ID="TextBoxTel2" runat="server" Width="100px" MaxLength="14" onkeyup="formataTelefone(this,event);"></asp:TextBox>
                </span>
                
                <br />
                
                <asp:Label ID="Label13" runat="server" AssociatedControlID="TextBoxRenda" Text="Valor Renda R$: "></asp:Label>
                <asp:TextBox ID="TextBoxRenda" runat="server" Width="100px" onkeyup="formataValor(this,event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="TextBoxRenda" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <asp:Label ID="LabelEmail" runat="server" AssociatedControlID="TextBoxEmail" Text="E-mail: " Visible="False"></asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server" Width="220px" Visible="False"></asp:TextBox>
            </fieldset>

            <fieldset>
            <legend>DADOS RESIDENCIAIS</legend>
                <asp:Label ID="Label14" runat="server" AssociatedControlID="TextBoxEndereco" Text="Endereço: "></asp:Label>
                <asp:TextBox ID="TextBoxEndereco" runat="server" Width="450px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBoxEndereco" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />
                
                <asp:Label ID="Label15" runat="server" AssociatedControlID="TextBoxReferencia" Text="Ponto Referência: "></asp:Label>
                <asp:TextBox ID="TextBoxReferencia" runat="server" Width="450px" MaxLength="50"></asp:TextBox>
                
                <br />
                
                <asp:Label ID="Label16" runat="server" AssociatedControlID="TextBoxCep" Text="CEP: "></asp:Label>
                <asp:TextBox ID="TextBoxCep" runat="server" Width="100px" MaxLength="9" onkeyup="formataCEP(this,event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBoxCep" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <asp:Label ID="Label17" runat="server" AssociatedControlID="TextBoxBairro" Text="Bairro: "></asp:Label>
                <asp:TextBox ID="TextBoxBairro" runat="server" Width="150px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBoxBairro" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <br />

                <asp:Label ID="Label18" runat="server" AssociatedControlID="TextBoxCidade" Text="Cidade: "></asp:Label>
                <asp:TextBox ID="TextBoxCidade" runat="server" Width="100px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBoxCidade" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                <asp:Label ID="Label19" runat="server" AssociatedControlID="DropDownListUf" Text="Estado: "></asp:Label>
                <span style="float: left;">
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
                </span>
                <span style="float: left;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="DropDownListUf" ErrorMessage="*"></asp:RequiredFieldValidator>   
                </span>
            </fieldset>

            <fieldset>
            <legend>DADOS DE BENEFÍCIO</legend> 
                <asp:Label ID="Label20" runat="server" AssociatedControlID="TextBoxNb1" Text="1º NB: "></asp:Label>
                <asp:TextBox ID="TextBoxNb1" runat="server" Width="157px" MaxLength="15" onkeyup="formataInteiro(this,event);"></asp:TextBox>

                <asp:Label ID="Label21" runat="server" AssociatedControlID="TextBoxNb2" Text="2º NB: "></asp:Label>
                <asp:TextBox ID="TextBoxNb2" runat="server" Width="157px" MaxLength="15" onkeyup="formataInteiro(this,event);"></asp:TextBox>
            </fieldset>

            <br />

            <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" onclick="ButtonSalvar_Click" />
            <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False" onclick="ButtonCancelar_Click" />
        </div> 
    </div>  
        <div class="article">    
            <asp:LoginView ID="LoginView1" runat="server">
                    <RoleGroups>
                        <asp:RoleGroup Roles="Administrador">
                            <ContentTemplate>

                                <asp:Panel ID="Panel1" runat="server" Visible="False" Style="margin-top: -30px;">
                                <div class="formulario">
                                    <fieldset style="margin-left: 175px;"><legend>PROPOSTAS</legend></fieldset>
                                </div>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    Width="100%" BackColor="#E6EDE6" BorderColor="White" BorderStyle="Ridge" 
                                    BorderWidth="0px" CellPadding="3" CellSpacing="1" GridLines="None" 
                                    DataKeyNames="pro_cod,pro_usuario,pro_doc1,pro_doc2,pro_doc3,pro_doc4,pro_doc5,pro_status,pro_data" 
                                    EnableModelValidation="True" onrowcreated="GridView1_RowCreated" onrowdeleting="GridView1_RowDeleting" 
                                    AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
                                    PageSize="50" onrowcommand="GridView1_RowCommand" Style="margin-top: -20px;">
                                    <FooterStyle BackColor="#4d5152" ForeColor="Black" />
                                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                    <Columns>
                                        <asp:HyperLinkField DataNavigateUrlFields="pro_cod,pro_status" DataNavigateUrlFormatString="CadProposta.aspx?pg={0}&amp;status={1}" DataTextField="pro_cod" DataTextFormatString="Abrir Nº{0}" HeaderText="Edição" />
                                                     
                                        <asp:TemplateField HeaderText="Agente/Data">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("pro_agente") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="pro_solicitado" HeaderText="Valor Solicitado" DataFormatString="{0:C}"/>
                                        <asp:ButtonField ButtonType="Button" CommandName="PRO" Text="Baixar" HeaderText="Proposta" />
                                        <asp:ButtonField ButtonType="Button" CommandName="DOC" Text="Baixar" HeaderText="Documentos" />
                                        <asp:CommandField DeleteText="Deletar" HeaderText="Exclusão" ShowDeleteButton="True" />
                                                      
                                        <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("pro_status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Font-Bold="True" />
                                        </asp:TemplateField> 
                                    </Columns>
                                    <PagerSettings PageButtonCount="60" />
                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Left" />
                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle HorizontalAlign="Left" BackColor="#4d5152" Font-Bold="True" ForeColor="#65CDE7" />
                                </asp:GridView>
                                </asp:Panel>     
                                
                            </ContentTemplate>
                        </asp:RoleGroup>
                    </RoleGroups>
            </asp:LoginView>
        </div>
    </div>

</asp:Content>
