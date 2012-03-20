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
    public partial class Negado : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["Titulo"] != null)
            {
                Page.Title = Cache.Get("Titulo").ToString() + " - Desautorizado";
            }
            else
            {
                Page.Title = ChamaTitulo() + " - Desautorizado";
            }

            if (!IsPostBack)
            {
                if ((HttpContext.Current.User.IsInRole("Operador")) || (HttpContext.Current.User.IsInRole("Corretor")))
                    Response.Redirect("~/usuarios/");
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
        private string ChamaTitulo()
        {
            cntrWebsite objCntrWebsite = new cntrWebsite();
            return objCntrWebsite.SelecionaWebSite().web_titulo;
        }
    }
}
