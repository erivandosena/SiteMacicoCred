using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;


namespace Site.Visao.fckeditor.editor.filemanager.browser.deleta
{
	public partial class foDelete : System.Web.UI.Page
	{
    string Arquivo = "";
    string NomeArq = "";
	protected void Page_Load(object sender, EventArgs e)
		{
Arquivo = Request.QueryString["FileNAme"];

        if (!IsPostBack)
        {
            if (Arquivo != null)
            {
                SelecionaArquivo();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

    }
    private void SelecionaArquivo()
    {
        //define o diretorio e o vetor
        ArrayList valores = new ArrayList();
        //pega os arquivos do diretorio
        string[] Arquivos = Directory.GetFiles(Request.MapPath("/Arquivos/"), Arquivo, SearchOption.AllDirectories);
        //faz a iteração através da lista , substitui o caminho e inclui no listbox com o método add
        int i;
        for (i = 0; i <= Arquivos.Length - 1; i += i + 1)
        {
            NomeArq = Arquivos[i];
            valores.Add(NomeArq);
        }
        //vincula o listbox ao controle de dados
        ListBox1.DataSource = valores;
        ListBox1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Se for selecionado algum item da lista
        if (ListBox1.SelectedIndex > -1) 
        {
            try
            {
                FileInfo arq = new FileInfo(ListBox1.SelectedItem.Text);
                if (arq.Exists)
                {
                    arq.Delete();
                    SelecionaArquivo();
                    lblStatus.Text = "Arquivo excluído com sucesso!";
                }
            }
            catch (Exception erro)
            {
                lblStatus.Text = "Erro ao excluir aquivo. <br />" + erro;
            }   
        }
        else
        {
            lblStatus.Text = "Selecione o arquivo na lista!";
        }
    }

   }
}