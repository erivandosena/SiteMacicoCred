using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site.Controle;

namespace Site.Visao
{
    public partial class Informativo : System.Web.UI.Page
    {
        cntrWebsite objCntrWebsite = new cntrWebsite();

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

            DS_Site.WebsiteRow rowSite = objCntrWebsite.SelecionaWebSite();
            if (Label1.Visible = !"".Equals(rowSite.web_info_titulo))
            {
                Page.Title += " - " + rowSite.web_info_titulo;
                Label1.Text = rowSite.web_info_titulo;
                Label2.Text = string.Format("Publicado, {0:D}", rowSite.web_info_data);
                Label3.Text = rowSite.web_info_conteudo;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }

        private string ChamaTitulo()
        {
            return objCntrWebsite.SelecionaWebSite().web_titulo;
        }
    }
}