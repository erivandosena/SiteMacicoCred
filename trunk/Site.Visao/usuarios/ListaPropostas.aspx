<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="ListaPropostas.aspx.cs" Inherits="Site.Visao.usuarios.ListaPropostas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="../scripts/JSMascaras.js" type="text/javascript"></script>

    <script type='text/javascript'>
        var nVer = navigator.appVersion;
        var nAgt = navigator.userAgent;
        var browserName = navigator.appName;
        var fullVersion = '' + parseFloat(navigator.appVersion);
        var majorVersion = parseInt(navigator.appVersion, 10);
        var nameOffset, verOffset, ix;

        // In Opera, the true version is after "Opera" or after "Version"
        if ((verOffset = nAgt.indexOf("Opera")) != -1) {
            browserName = "Opera";
            fullVersion = nAgt.substring(verOffset + 6);
            if ((verOffset = nAgt.indexOf("Version")) != -1)
                fullVersion = nAgt.substring(verOffset + 8);
        }
        // In MSIE, the true version is after "MSIE" in userAgent
        else if ((verOffset = nAgt.indexOf("MSIE")) != -1) {
            browserName = "Microsoft Internet Explorer";
            fullVersion = nAgt.substring(verOffset + 5);
        }
        // In Chrome, the true version is after "Chrome" 
        else if ((verOffset = nAgt.indexOf("Chrome")) != -1) {
            browserName = "Chrome";
            fullVersion = nAgt.substring(verOffset + 7);
        }
        // In Safari, the true version is after "Safari" or after "Version" 
        else if ((verOffset = nAgt.indexOf("Safari")) != -1) {
            browserName = "Safari";
            fullVersion = nAgt.substring(verOffset + 7);
            if ((verOffset = nAgt.indexOf("Version")) != -1)
                fullVersion = nAgt.substring(verOffset + 8);
        }
        // In Firefox, the true version is after "Firefox" 
        else if ((verOffset = nAgt.indexOf("Firefox")) != -1) {
            browserName = "Firefox";
            fullVersion = nAgt.substring(verOffset + 8);
        }
        // In most other browsers, "name/version" is at the end of userAgent 
        else if ((nameOffset = nAgt.lastIndexOf(' ') + 1) < (verOffset = nAgt.lastIndexOf('/'))) {
            browserName = nAgt.substring(nameOffset, verOffset);
            fullVersion = nAgt.substring(verOffset + 1);
            if (browserName.toLowerCase() == browserName.toUpperCase()) {
                browserName = navigator.appName;
            }
        }
        // trim the fullVersion string at semicolon/space if present
        if ((ix = fullVersion.indexOf(";")) != -1) fullVersion = fullVersion.substring(0, ix);
        if ((ix = fullVersion.indexOf(" ")) != -1) fullVersion = fullVersion.substring(0, ix);

        majorVersion = parseInt('' + fullVersion, 10);
        if (isNaN(majorVersion)) {
            fullVersion = '' + parseFloat(navigator.appVersion);
            majorVersion = parseInt(navigator.appVersion, 10);
        }

        if (browserName == "Opera") {
            //Opera
            var acrobat_installed = navigator.mimeTypes && navigator.mimeTypes["application/pdf"]

            if (!acrobat_installed) {
                window.location = 'AcrobatReader.aspx';
            }

        }
        else {
            if (browserName == "Chrome") {
                //Google Chrome
                var acrobat_installed = navigator.mimeTypes && navigator.mimeTypes["application/pdf"]

                if (!acrobat_installed) {
                    window.location = 'AcrobatReader.aspx';
                }

            }
            else {
                if (browserName == "Firefox") {
                    //Mozila Firefox
                    var acrobat_installed = navigator.mimeTypes && navigator.mimeTypes["application/pdf"]

                    if (!acrobat_installed) {
                        window.location = 'AcrobatReader.aspx';
                    }

                }
                else {
                    if (browserName == "Safari") {

                        //Safari

                    }
                    else {
                        if (browserName == "Microsoft Internet Explorer") {

                            //IE
                            var version = null;
                            if (window.ActiveXObject) {
                                var control = null;
                                try {
                                    // AcroPDF.PDF is used by version 7 and later
                                    control = new ActiveXObject('AcroPDF.PDF');
                                } catch (e) {
                                    // Do nothing
                                }
                                if (!control) {
                                    try {
                                        // PDF.PdfCtrl is used by version 6 and earlier
                                        control = new ActiveXObject('PDF.PdfCtrl');
                                    } catch (e) {
                                        //return;
                                    }
                                }
                                if (control) {
                                    isInstalled = true;
                                    version = control.GetVersions().split(',');
                                    version = version[0].split('=');
                                    version = parseFloat(version[1]);
                                }
                            } else {
                                window.location = 'AcrobatReader.aspx';
                            }

                        }
                    }
                }
            }
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainbarAdmin">
        <div class="article">
          <h2><span>Manutenção de Propostas</span></h2>
          <div class="clr"></div>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
          <asp:Label ID="Label4" runat="server" AssociatedControlID="TextBoxUsuario" Text="Busca por Código do Usuário: "></asp:Label>
          <asp:TextBox ID="TextBoxUsuario" runat="server" Width="100px" onkeyup="formataInteiro(this,event);"></asp:TextBox>
            &nbsp;
            <asp:Button ID="ButtonBusca" runat="server" Text="Localizar" 
               OnClientClick="this.disabled = true; this.value = 'Pesquisando...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" onclick="ButtonBusca_Click"/>
            <asp:Button ID="ButtonLista" runat="server" Text="Todos" 
               OnClientClick="this.disabled = true; this.value = 'Aguarde...';" 
               UseSubmitBehavior="False" 
               CausesValidation="False" onclick="ButtonLista_Click"/>
               </asp:Panel>
        </div>
        <div class="article">
            <ol>
              <li>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                      onrowcreated="GridView1_RowCreated" onrowdeleting="GridView1_RowDeleting" 
                      Width="100%" BackColor="#E6EDE6" BorderColor="White" BorderStyle="Ridge" 
                      BorderWidth="0px" CellPadding="3" CellSpacing="1" GridLines="None" 
                      onrowcommand="GridView1_RowCommand" DataKeyNames="pro_cod,pro_cliente,pro_doc1,pro_doc2,pro_doc3,pro_doc4,pro_doc5,pro_status" 
                      EnableModelValidation="True" AllowPaging="True" 
                      onpageindexchanging="GridView1_PageIndexChanging" PageSize="50">
                      <FooterStyle BackColor="#4d5152" ForeColor="Black" />
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <Columns>
                          <asp:HyperLinkField DataNavigateUrlFields="pro_cod,pro_status" DataNavigateUrlFormatString="CadProposta.aspx?pg={0}&amp;status={1}" DataTextField="pro_cod" DataTextFormatString="Visualizar Nº{0}" HeaderText="Análise" />
                          
                          <asp:TemplateField HeaderText="Proponente">
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Bind("pro_cliente") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                          <asp:BoundField DataField="pro_data" HeaderText="Data/Hora" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"/>

                          <asp:ButtonField ButtonType="Button" CommandName="PRO" Text="Baixar" HeaderText="Proposta" />
                          <asp:ButtonField ButtonType="Button" CommandName="DOC" Text="Baixar" HeaderText="Documentos" />
                          <asp:CommandField DeleteText="Deletar" HeaderText="Exclusão" ShowDeleteButton="True" />
                          
                          <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("pro_status") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Font-Bold="True" />
                         </asp:TemplateField>
                      </Columns>
                      <PagerSettings PageButtonCount="60" Position="TopAndBottom" />
                      <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Left" />
                      <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle HorizontalAlign="Left" BackColor="#4d5152" Font-Bold="True" ForeColor="#65CDE7" />
                  </asp:GridView>
                  <asp:Label ID="LabelVazio" runat="server" Visible="False"></asp:Label>
              </li>
            </ol>
        </div>
      </div>

</asp:Content>
