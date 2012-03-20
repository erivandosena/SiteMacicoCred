<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="Site.Visao.Contato" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Scripts/JSMascaras.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbar">
        <div class="article">
          <h2><span>Contate-nos</span></h2>
          <div class="clr"></div>
          <p>Entre em contato conosco para solicitar mais informações sobre nossos serviços, 
              enviar as suas sugestões, comentários e quaisquer perguntas sobre o conteúdo 
              deste site.</p>
        </div>
        <div class="article">
          <h2><span>Aguardamos</span> seu contato</h2>
          <div class="clr"></div>
            <ol>
              <li>
                  <asp:Label ID="Label1" runat="server" Text="Nome " AssociatedControlID="TextBoxNome">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxNome"></asp:RequiredFieldValidator>
                  </asp:Label>
                  <asp:TextBox ID="TextBoxNome" runat="server" CssClass="text" MaxLength="100"></asp:TextBox>
              </li>
              <li><asp:Label ID="Label2" runat="server" Text="E-mail " AssociatedControlID="TextBoxEmail">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxEmail"></asp:RequiredFieldValidator>
                  </asp:Label>
                  <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="text" MaxLength="100"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="E-mail inválido." ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
              </li>
              <li>
                  <asp:Label ID="Label3" runat="server" Text="Telefone" AssociatedControlID="TextBoxTelefone"></asp:Label>
                  <asp:TextBox ID="TextBoxTelefone" runat="server" CssClass="text" MaxLength="14" onkeyup="formataTelefone(this,event);"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label4" runat="server" Text="Assunto " AssociatedControlID="TextBoxAssunto">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxAssunto"></asp:RequiredFieldValidator>
                  </asp:Label>
                  <asp:TextBox ID="TextBoxAssunto" runat="server" CssClass="text" MaxLength="50"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label5" runat="server" Text="Mensagem " AssociatedControlID="TextBoxMensagem">
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obrigatório." ControlToValidate="TextBoxMensagem"></asp:RequiredFieldValidator>
                  </asp:Label>
                  <asp:TextBox ID="TextBoxMensagem" runat="server" CssClass="textarea" TextMode="MultiLine" Columns="50" Rows="8"></asp:TextBox>
              </li>
              <li>
                  <asp:Button ID="Button1" runat="server" CssClass="envia" Text="Enviar" onclick="Button1_Click" />
              </li>
              <li>
                  <p><asp:Label ID="LabelMensagem" runat="server" Text="" CssClass="mensagem"></asp:Label></p>
              </li>
            </ol>
        </div>
      </div>

</asp:Content>
