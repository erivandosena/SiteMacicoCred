using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Site.Controle;

namespace Site.Visao
{
    public partial class Loja : System.Web.UI.Page
    {
        private String cod
        {
            get
            {
                string id = Request.QueryString["c"];
                if (id == null || id == string.Empty)
                    return "";
                else
                    return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["Titulo"] != null)
            {
                Page.Title = Cache.Get("Titulo").ToString();
            }
            else
            {
                Page.Title = ChamaTitulo();
            }

            if (!IsPostBack) 
            {

                if (!"".Equals(cod))
                {
                    cntrLoja objCntrLoja = new cntrLoja();
                    DS_Site.LojaRow rowLoja = objCntrLoja.SelecionaLoja(cod);

                    Page.Title += " - " + rowLoja.loj_nome;
                    Label1.Text = rowLoja.loj_nome;
                    if (!string.IsNullOrEmpty(rowLoja.loj_foto))
                    {
                        Image1.Visible = true;
                        Image1.ImageUrl = "~/Arquivos/image/" + rowLoja.loj_foto;
                    }
                    if (!"".Equals(rowLoja.loj_endereco))
                    {
                        Label2.Text = "<li>" + rowLoja.loj_endereco + "</li>";
                    }
                    if (!"".Equals(rowLoja.loj_cep) || !"".Equals(rowLoja.loj_cidade) || !"".Equals(rowLoja.loj_estado))
                    {
                        string cep = string.Empty;
                        if (!"".Equals(rowLoja.loj_cep))
                        {
                            cep = "CEP: ";
                        }
                        Label2.Text += "<li>" + cep + rowLoja.loj_cep + " " + rowLoja.loj_cidade + " " + rowLoja.loj_estado + "</li>";
                    }
                    if (!"".Equals(rowLoja.loj_telefone))
                    {
                        Label2.Text += "<li>Telefone: " + rowLoja.loj_telefone + "</li>";
                    }
                    if (!"".Equals(rowLoja.loj_email))
                    {
                        Label2.Text += "<li>E-mail: <a href='mailto:" + rowLoja.loj_email + "'>" + rowLoja.loj_email + "</a></li>";
                    }

                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        private string ChamaTitulo()
        {
            cntrWebsite objCntrWebsite = new cntrWebsite();
            return objCntrWebsite.SelecionaWebSite().web_titulo;
        }

    }
}
