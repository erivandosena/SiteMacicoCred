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
    public partial class Pagina : System.Web.UI.Page
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
                    cntrPagina objCntrPagina = new cntrPagina();
                    DS_Site.PaginaRow rowPagina = objCntrPagina.Seleciona(cod);
                    Label1.Text = rowPagina.pag_nome;
                    Label2.Text = rowPagina.pag_conteudo;
                    Page.Title += " - " + rowPagina.pag_nome;
                    if (!"".Equals(rowPagina.pag_descricao))
                        Page.Title += ", " + rowPagina.pag_descricao;
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
