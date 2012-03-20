<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CadSite.aspx.cs" Inherits="Site.Visao.administradores.CadSite" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../scripts/JSMascaras.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
        <h2><span>Manutenção/cadastro do Site</span></h2>
        <div class="clr"></div>
            <ol>
              <li>
                  <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxTitulo" Text="Título"></asp:Label>
                  <asp:TextBox ID="TextBoxTitulo" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                  &nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxTitulo" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
              </li>
              <li>
                  <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxSlogan" Text="Slogan"></asp:Label>
                  <asp:TextBox ID="TextBoxSlogan" runat="server" MaxLength="100" Width="400px"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label3" runat="server" AssociatedControlID="TextBoxEndereco" Text="Endereço"></asp:Label>
                  <asp:TextBox ID="TextBoxEndereco" runat="server" MaxLength="100" Width="400px"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label4" runat="server" AssociatedControlID="TextBoxCep" Text="CEP"></asp:Label>
                  <asp:TextBox ID="TextBoxCep" runat="server" MaxLength="9" Width="100px" onkeyup="formataCEP(this,event);"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label5" runat="server" AssociatedControlID="TextBoxCidade" Text="Cidade"></asp:Label>
                  <asp:TextBox ID="TextBoxCidade" runat="server" MaxLength="20" Width="100px"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label6" runat="server" AssociatedControlID="TextBoxEstado" Text="Estado"></asp:Label>
                  <asp:TextBox ID="TextBoxEstado" runat="server" MaxLength="20" Width="100px"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label7" runat="server" AssociatedControlID="TextBoxTelefone" Text="Telefone"></asp:Label>
                  <asp:TextBox ID="TextBoxTelefone" runat="server" MaxLength="14" Width="100px" onkeyup="formataTelefone(this,event);"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label8" runat="server" AssociatedControlID="TextBoxEmail" Text="E-mail"></asp:Label>
                  <asp:TextBox ID="TextBoxEmail" runat="server" MaxLength="50" Width="400px"></asp:TextBox>
                  &nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="E-mail inválido." ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
              </li>
              <li>
                  <asp:Label ID="Label9" runat="server" AssociatedControlID="TextBoxTitInfo" Text="Título do Informativo"></asp:Label>
                  <asp:TextBox ID="TextBoxTitInfo" runat="server" MaxLength="100" Width="600"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label10" runat="server" AssociatedControlID="FCKResumoInfo" Text="Introdução do Informativo"></asp:Label>
                  <FCKeditorV2:FCKeditor ID="FCKResumoInfo" runat="server" BasePath="~/fckeditor/" Height="300px"></FCKeditorV2:FCKeditor>
              </li>
              <li>
                  <asp:Label ID="Label11" runat="server" AssociatedControlID="FCKConteudoInfo" Text="Conteúdo do Informativo"></asp:Label>
                  <FCKeditorV2:FCKeditor ID="FCKConteudoInfo" runat="server" BasePath="~/fckeditor/" Height="450px"></FCKeditorV2:FCKeditor>
              </li>
              <li>
                  <asp:Label ID="Label12" runat="server" AssociatedControlID="FCKBanner" Text="Publicidade(Largura máxima 600px)"></asp:Label>
                  <FCKeditorV2:FCKeditor ID="FCKBanner" runat="server" BasePath="~/fckeditor/" Height="400px"></FCKeditorV2:FCKeditor>
              </li>
              <li>
                  <p>&nbsp;</p> 
                  <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" onclick="ButtonSalvar_Click" />
                  <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False" onclick="ButtonCancelar_Click" /> 
             </li>
             <li>
                 <p><asp:Label ID="Label13" runat="server" ForeColor="#FB3200"></asp:Label></p>
             </li>
           </ol>
        </div>
      </div>

</asp:Content>
