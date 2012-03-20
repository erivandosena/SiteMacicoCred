<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CadPagina.aspx.cs" Inherits="Site.Visao.administradores.CadPagina" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script language="javascript" type="text/javascript">
        function ValidateFCK(source, args) {

            var fckBody = FCKeditorAPI.GetInstance('<%=FCKConteudo.ClientID %>');
            args.IsValid = fckBody.GetXHTML(true) != "";
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
        <h2><span>Cadastro da Página</span></h2>
                    <div class="clr"></div>
            <ol>
              <li>
                  <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxNome" Text="Nome"></asp:Label>
                  <asp:TextBox ID="TextBoxNome" runat="server" Width="150px" MaxLength="35"></asp:TextBox>
                  &nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
              </li>
              <li>
                  <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxDescricao" Text="Descrição:"></asp:Label>
                  <asp:TextBox ID="TextBoxDescricao" runat="server" MaxLength="100" Width="400px"></asp:TextBox>
              </li>
              <li>
                  <asp:Label ID="Label3" runat="server" AssociatedControlID="FCKConteudo" Text="Conteúdo"></asp:Label>
                  <FCKeditorV2:FCKeditor ID="FCKConteudo" runat="server" BasePath="~/fckeditor/" Height="550px"></FCKeditorV2:FCKeditor>
                  &nbsp;
                  <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Campo obrigatório." ClientValidationFunction="ValidateFCK" ValidateEmptyText="True" ControlToValidate="FCKConteudo"></asp:CustomValidator>
              </li>
              <li>
                  <asp:Label ID="Label4" runat="server" AssociatedControlID="DropDownListPosicao" Text="Menu"></asp:Label>
                  <asp:DropDownList ID="DropDownListPosicao" runat="server">
                      <asp:ListItem Selected="True" Value=""></asp:ListItem>
                      <asp:ListItem Value="Topo">Topo</asp:ListItem>
                      <asp:ListItem Value="Lateral">Lateral</asp:ListItem>
                  </asp:DropDownList>
                  &nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListPosicao" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
              </li>
              <li>
                  <p>&nbsp;</p> 
                  <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" onclick="ButtonSalvar_Click" />
                  <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False" onclick="ButtonCancelar_Click" />  
              </li>
            </ol>
        </div>
      </div>

</asp:Content>
