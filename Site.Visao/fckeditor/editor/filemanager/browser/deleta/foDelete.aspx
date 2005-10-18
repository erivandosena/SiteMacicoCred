<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="foDelete.aspx.cs" Inherits="Site.Visao.fckeditor.editor.filemanager.browser.deleta.foDelete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            Selecione o arquivo para excluir:</p>
        <p>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            </asp:RadioButtonList>
        </p>
        <p>
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Excluir Arquivo" /></p>
        <p>
            <asp:Label ID="lblStatus" runat="server"></asp:Label></p>
        <p>
            <strong>Clique no [X] da janela para fechar.</strong></p>
    </div>
    </form>
</body>
</html>
