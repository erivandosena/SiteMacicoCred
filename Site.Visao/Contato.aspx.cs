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
using Site.Util;
using Site.Controle;

namespace Site.Visao
{
    public partial class Contato : System.Web.UI.Page
    {
        cntrWebsite objCntrWebsite = new cntrWebsite();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["Titulo"] != null)
            {
                Page.Title = Cache.Get("Titulo").ToString() + " - Contato";
            }
            else
            {
                Page.Title = ChamaTitulo() + " - Contato";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string SiteEmail = objCntrWebsite.SelecionaWebSite().web_email;

            try
            {

                string UrlSite = string.Concat("http://", HttpContext.Current.Request.Url.Authority);
                string CorpoEmail = "<br /><table align='center' width='600' border='1' cellspacing='10' cellpadding='0' " +
                                    "bordercolor='#CCCCCC' style='font-family:Tahoma, Geneva, sans-serif;font-size:small'>" +
                                    "<tr>" +
                                    "<td bgcolor='#EEEEEE' valign='top' style='border:0'>" +
                                    "<table width='600' border='0' cellspacing='10' cellpadding='0'>" +
                                    "<tr>" +
                                    "<td>" +
                                    "<a href='" + UrlSite + "' target='_blank'>" +
                                    "<img src='" + UrlSite + "/Arquivos/image/logo.gif' border='0' align='middle' /></a>" +
                                    "</td>" +
                                    "<td align='center'><strong>FORMUL&Aacute;RIO DE CONTATO</strong></td>" +
                                    "</tr>" +
                                    "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0;'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'>" +
                                    "<tr>" +
                                    "<td width='120'>Nome:</td>" +
                                    "<td>" + TextBoxNome.Text.ToUpper() + "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td>E-mail:</td>" +
                                    "<td>" + TextBoxEmail.Text.ToLower() + "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td>Telefone:</td>" +
                                    "<td>" + TextBoxTelefone.Text + "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td>Assunto:</td>" +
                                    "<td>" + TextBoxAssunto.Text.ToUpper() + "</td>" +
                                    "</tr>" +
                                    "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td style='border:0'></td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'>" +
                                    "<tr>" +
                                    "<td width='120'>Mensagem:</td>" +
                                    "<td>" + TextBoxMensagem.Text + "</td>" +
                                    "</tr>" +
                                    "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'>" +
                                    "<tr>" +
                                    "<td width='120'>IP do contato:</td>" +
                                    "<td>" + Request.UserHostAddress + "</td>" +
                                    "</tr>" +
                                    "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td style='border:0'></td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td style='border:0;font-size:smaller' align='center'>&copy; " +
                                    "<a href='" + UrlSite + "' target='_blank'>" + HttpContext.Current.Request.Url.Authority +
                                    "</a> | Produzido por: <a href='" + ConfigurationManager.AppSettings["AdminSite"].ToString() + "' target='_blank'>RWD</a>" +
                                    "</td>" +
                                    "</tr>" +
                                    "</table>";

                Util.Util.EnviaEmail(
                    TextBoxNome.Text.ToUpper() + "<" + TextBoxEmail.Text.ToLower() + ">",
                    SiteEmail,
                    "Contato do website sobre " + TextBoxAssunto.Text.ToUpper(),
                    CorpoEmail.ToString());

                Util.Util.EnviaEmail(SiteEmail,
                    TextBoxEmail.Text.ToLower(),
                    "Sua cópia do contato " + TextBoxAssunto.Text.ToUpper() + " em " + HttpContext.Current.Request.Url.Authority,
                    CorpoEmail.ToString());

                LimpaControles(this);
                LabelMensagem.Text = "<font color='#009900'>Enviado com sucesso!</font>";
            }
            catch (Exception)
            {
                LabelMensagem.Text = "<font color='#FF0000'>Falha no envio!</font>";
            }
        }

        protected void LimpaControles(Control pai)
        {
            foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
                else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        }

        private string ChamaTitulo()
        {
            return objCntrWebsite.SelecionaWebSite().web_titulo;
        }
    }
}
