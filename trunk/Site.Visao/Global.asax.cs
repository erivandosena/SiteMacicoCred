using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using log4net;
using log4net.Config;
using System.IO;
using System.Security.Principal;

namespace Site.Visao
{
    public class Global : System.Web.HttpApplication
    {
        private log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start(object sender, EventArgs e)
        {
            string configFilePath = Server.MapPath("~/App_Data/Log/Log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFilePath));
            /*
            logger.Debug("\n=================== NÍVEL DEBUGAÇÃO ===================");
            logger.Info("\n=================== NÍVEL INFORMAÇÃO ===================");
            logger.Warn("\n=================== NÍVEL ADVERTÊNCIA ===================");
            logger.Error("\n=================== NÍVEL ERRO ===================");
            logger.Fatal("\n=================== NÍVEL FATALIDADE ===================");
            */
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity != null)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        HttpContext.Current.User = new GenericPrincipal(id, roles);

                    }
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException();
            logger.Error("App_Error", ex);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}