using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site.Util;
using System.Web.Security;
using Site.Controle;

namespace Site.Visao.administradores
{
    public partial class MasterPageAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["Titulo"] != null)
            {
                Label2.Text = Cache.Get("Titulo").ToString();
            }
            else
            {
                Label2.Text = ChamaTitulo();
            }

            Page.Title = Label2.Text + " | Administrativo (" + HttpContext.Current.User.Identity.Name + ") " + DateTime.Now;

            if (Page.User.IsInRole("Corretor"))
            {
                Label1.Text = "Corretor";
            }
            if (Page.User.IsInRole("Operador"))
            {
                Label1.Text = "Operador";
            }
            if (Page.User.IsInRole("Administrador"))
            {
                Label1.Text = "Administrativa";
                LoginView7.Visible = false;
            }

            if (!IsPostBack)
            {
               LabelSaldacao.Text = Saldacao();

                if (HttpContext.Current.User != null)
                {
                    if (HttpContext.Current.User.Identity != null)
                    {
                        if (HttpContext.Current.User.Identity is FormsIdentity)
                        {
                            FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                            FormsAuthenticationTicket ticket = id.Ticket;
                            string userData = ticket.UserData.Replace(",", " e ");
                            LabelRole.Text = userData;
                        }
                    }
                }
            }
        }

        private static string Saldacao()
        {
            DateTime msgData = DateTime.Now;

            if (msgData.Hour > 6 && msgData.Hour < 12)
                return "Bom dia!";
            else if (msgData.Hour >= 12 && msgData.Hour < 18)
                return "Boa tarde!";
            else
                return "Boa noite!";
        }

        private static string ChamaTitulo()
        {
            string titulo = string.Empty;
            DS_Site.WebsiteDataTable dtSite = cntrWebsite.Seleciona();
            foreach (DS_Site.WebsiteRow rowSite in dtSite.Rows)
            {
                titulo = rowSite.web_titulo;
            }
            return titulo;
        }
    }
}