<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="CadLoja.aspx.cs" Inherits="Site.Visao.administradores.CadLoja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../scripts/JSMascaras.js" type="text/javascript"></script>
    
    <script src="../scripts/jquery/jquery.min.js" type="text/javascript"></script>
    <script src="../scripts/jcrop/jquery.Jcrop.min.js" type="text/javascript"></script>
    <link href="../scripts/jcrop/css/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    
    <script language="Javascript" type="text/javascript">
        jQuery(document).ready(function () {
            $('.cropbox').Jcrop({
                bgColor: 'black',
                bgOpacity: .4,
                setSelect: [100, 100, 500, 400],
                //aspectRatio: 16 / 9,
                onChange: updateCoords,
                onSelect: updateCoords
            });
        });

        function updateCoords(c) {
            $('#x').val(c.x);
            $('#y').val(c.y);
            $('#w').val(c.w);
            $('#h').val(c.h);
        };
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
        <h2><span>Cadastro da Loja</span></h2>
                    <div class="clr"></div>
            <ol>
              <li>
                  <asp:Label ID="Label1" runat="server" AssociatedControlID="TextBoxNome" Text="Nome"></asp:Label>
                  <asp:TextBox ID="TextBoxNome" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                  &nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNome" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
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
                  &nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxCidade" ErrorMessage="Campo obrigatório."></asp:RequiredFieldValidator>
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
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="E-mail inválido." ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
              </li>
              <li>
                    <!-- Panel de Upload -->
                    <asp:Panel ID="PnlUpload" runat="server">
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Imagem" AssociatedControlID="fupImage"></asp:Label>
                            <asp:FileUpload ID="fupImage" runat="server" />
                            &nbsp; 
                            <asp:Button ID="btnUpload" runat="server" Text="Enviar..." onclick="btnUpload_Click" CausesValidation="False" />
                        </div>
                    </asp:Panel>
                    <asp:Label ID="litError" runat="server" ForeColor="Red"></asp:Label>
                    <!-- Panel de Upload -->
                 
                    <!-- Panel de seleção e recorte de imagem -->
                    <asp:Panel ID="pnlCutImage" runat="server" Visible="false">
                        <div>
                            <!-- Imagem recebida por upload -->
                            <br />
                            <asp:Image CssClass="cropbox" ID="imgPhoto" runat="server" />
                 
                            <!-- Campos que registram a posição e a parte selecionada -->
                            <input id="x" name="x" type="hidden" />
                            <input id="y" name="y" type="hidden" />
                            <input id="w" name="w" type="hidden" />
                            <input id="h" name="h" type="hidden" />
                                  
                        </div>
                        <div>
                            <br />
                            <asp:Button ID="btnSave" runat="server" Text="Recortar" onclick="btnSave_Click" />
                        </div>
                    </asp:Panel>
                    <!-- Panel de seleção e recorte de imagem -->
                 
                    <!-- Panel resultado -->
                    <asp:Panel ID="pnlResulado" runat="server" Visible="false">
                        <div>
                            <br />
                           <asp:Image ID="imgResultado" runat="server" />
                        </div>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Excluir Imagem" 
                            CausesValidation="False" onclick="Button1_Click" />
                    </asp:Panel>
                    <!-- Panel resultado -->

              </li>
              <li>
                  <br />
                  <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" onclick="ButtonSalvar_Click" />
                  <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" CausesValidation="False" onclick="ButtonCancelar_Click" />  
              </li>
            </ol>
        </div>
      </div>

</asp:Content>
