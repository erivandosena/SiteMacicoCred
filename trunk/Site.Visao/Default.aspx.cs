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
    public partial class Default : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                DS_Site.WebsiteRow rowSite = objCntrWebsite.SelecionaWebSite();
                if (!"".Equals(rowSite.web_slogan))
                {
                    Page.Title += " - " + rowSite.web_slogan;
                }

                if (Label1.Visible = !"".Equals(rowSite.web_banner))
                {
                    Label1.Text = rowSite.web_banner;
                }
                if (Label2.Visible = Label3.Visible = !"".Equals(rowSite.web_info_titulo))
                {
                    Label2.Text = rowSite.web_info_titulo;
                    Label3.Text = rowSite.web_info_resumo += "<p class='spec'><a href='Informativo.aspx' class='rm'>Leia mais</a></p>";
                }

            }
        }

        private string ChamaTitulo()
        {
            return objCntrWebsite.SelecionaWebSite().web_titulo;
        }

    }

}
