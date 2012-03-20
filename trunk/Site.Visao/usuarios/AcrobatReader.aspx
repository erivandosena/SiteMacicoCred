<%@ Page Title="" Language="C#" MasterPageFile="~/administradores/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="AcrobatReader.aspx.cs" Inherits="Site.Visao.usuarios.AcrobatReader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="mainbarAdmin">
        <div class="article">
          <h2><span>Acrobat Reader não encontrado!</span></h2>
          <div class="clr"></div>
          <p>O Acrobat Reader, software da Adobe que permite ler e imprimir documentos eletrônicos no formato PDF não está instalado.</p>
          <p>Clique no link abaixo para baixar e instalar uma versão atualizada do Acrobat Reader neste computador antes de usar esta aplicação.</p>
        </div>
        <div class="article">
            <ol>
              <li>
              <a href="http://get.adobe.com/br/reader/" target="_blank">Download do Acrobat Reader</a>
              </li>
            </ol>
        </div>
      </div>

</asp:Content>
