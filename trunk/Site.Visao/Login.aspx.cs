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
    public partial class Login : System.Web.UI.Page
    {
        cntrUsuario objCntrUsuario = new cntrUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["Titulo"] != null)
            {
                Page.Title = Cache.Get("Titulo").ToString() + " - Login";
            }
            else
            {
                Page.Title = ChamaTitulo() + " - Login";
            }

            if (User.Identity.IsAuthenticated && Request.QueryString["ReturnUrl"] != null) Response.Redirect("~/Negado.aspx");
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            DS_Site.UsuarioRow rowUsuario = objCntrUsuario.SelecionaUsuarioNome(Login2.UserName);

            if (!string.IsNullOrEmpty(rowUsuario.usu_cod))
            {
                if (rowUsuario.usu_senha == FormsAuthentication.HashPasswordForStoringInConfigFile(Login2.Password, "MD5"))
                {
                    //e.Authenticated = true;
                    //ou
                    //FormsAuthentication.RedirectFromLoginPage(rowUsuario.usu_nome, Login1.RememberMeSet); 
                    //ou
                    FormsAuthenticationTicket Authticket = new FormsAuthenticationTicket(
                        1,
                        rowUsuario.usu_nome,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(60),
                        Login2.RememberMeSet,
                        rowUsuario.usu_funcao,
                        FormsAuthentication.FormsCookiePath);

                    string hash = FormsAuthentication.Encrypt(Authticket);

                    HttpCookie Authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                    if (Authticket.IsPersistent) Authcookie.Expires = Authticket.Expiration;

                    Response.Cookies.Add(Authcookie);

                    string url = Request.QueryString["ReturnUrl"];
                    if (url == null)
                    {
                        url = "~/administradores/Default.aspx";
                    }
                    Response.Redirect(url);
                }
                else
                {
                    e.Authenticated = false;
                }
            }
            else
            {
                e.Authenticated = false;
            }

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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            DS_Site.UsuarioRow rowUsuario = objCntrUsuario.SelecionaUsuarioNome(Login2.UserName.Trim());

            if (!string.IsNullOrEmpty(rowUsuario.usu_nome))
            {
                string senhaEmail = GeraSenha();
                DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();

                DS_Site.UsuarioRow rowUsuarioSenha = dtUsuario.NewUsuarioRow();
                rowUsuarioSenha = rowUsuario;
                rowUsuarioSenha.usu_senha = FormsAuthentication.HashPasswordForStoringInConfigFile(senhaEmail, "MD5").ToString();

                if (objCntrUsuario.Salva(rowUsuarioSenha))
                {

                    cntrWebsite objCntrWebsite = new cntrWebsite();
                    DS_Site.WebsiteRow Site = objCntrWebsite.SelecionaWebSite();
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
                                            "<td align='center'><strong>ACESSO AO SITE</strong></td>" +
                                            "</tr>" +
                                            "</table>" +
                                            "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "<td bgcolor='#F9F9F9' valign='top' style='border:0;'>" +
                                            "<table border='0' cellspacing='10' cellpadding='0'>" +
                                              "<tr>" +
                                                "<td width='599'><p>Prezado(a) <strong>" + rowUsuario.usu_nome_completo + "</strong>,</p>" +
                                                  "<p>Segue nome de usuário e senha para acesso na <a href='" + UrlSite + "/Login.aspx' target='_blank'>área restrita</a> do site " + HttpContext.Current.Request.Url.Authority + "<br />" +
                                                "</p></td>" +
                                                "</tr>" +
                                              "</table>" +
                                            "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "<td style='border:0'></td>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "<td bgcolor='#F9F9F9' valign='top' style='border:0'>" +
                                            "<table border='0' cellspacing='10' cellpadding='0'> " +
                                              "<tr>" +
                                                "<td width='100'>Usuário:</td>" +
                                                "<td>" + rowUsuario.usu_nome + "</td>" +
                                              "</tr>" +
                                              "<tr>" +
                                                "<td>Senha:</td>" +
                                                "<td>" + senhaEmail + "</td>" +
                                                "</tr>" +
                                              "</table>" +
                                            "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "<td bgcolor='#F9F9F9' valign='top' style='border:0'>" +
                                            "<table border='0' cellspacing='10' cellpadding='0'>" +
                                            "<tr>" +
                                            "<td width='100'>IP do emissor:</td>" +
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
                            Site.web_titulo + "<" + Site.web_email + ">",
                            rowUsuario.usu_nome_completo + "<" + rowUsuario.usu_email + ">",
                            "Informações de Login",
                            CorpoEmail.ToString());

                        Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Sucesso", "alert('Uma nova senha foi enviada para seu endereço de e-mail.');", true);
                    }
                    catch (Exception)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Erro1", "alert('Erro ao processar! Entre em contato com a " + Site.web_titulo + " e informe seu problema.');", true);
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Erro2", "alert('Informe seu nome de usuário!');", true);
            }
        }

        private string GeraSenha()
        {
            int Tamanho = 6; // Numero de digitos da senha
            string senha = string.Empty;
            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();
                int codigo = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString();
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }

            return senha;
        }

    }
}
