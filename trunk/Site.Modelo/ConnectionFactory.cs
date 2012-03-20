using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using NHibernate.Cfg;

namespace Site.Modelo
{
    public class ConnectionFactory
    {
        private Configuration _objConf = null;

        private static ISessionFactory _objFactory = null;

        public ConnectionFactory()
                {
                    try
                    {
                        this.objConf = new Configuration().Configure();
                        this.objConf.AddClass(typeof(Site.Modelo.Website));
                        this.objConf.AddClass(typeof(Site.Modelo.Usuario));
                        this.objConf.AddClass(typeof(Site.Modelo.Link));
                        this.objConf.AddClass(typeof(Site.Modelo.Pagina));
                        this.objConf.AddClass(typeof(Site.Modelo.Loja));
                        this.objConf.AddClass(typeof(Site.Modelo.Cliente));
                        this.objConf.AddClass(typeof(Site.Modelo.Banco));
                        this.objConf.AddClass(typeof(Site.Modelo.Proposta));
                        this.objConf.AddClass(typeof(Site.Modelo.Comissao));
                        this.objConf.AddClass(typeof(Site.Modelo.Contrato));
                        objFactory = objConf.BuildSessionFactory();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

        public Configuration objConf
        {
            get { return _objConf; }
            set { _objConf = value; }
        }

        public static ISessionFactory objFactory
        {
            get { return _objFactory; }
            set { _objFactory = value; }
        }

        public static ISessionFactory getConnection()
        {
            if (objFactory == null)
            {
                ConnectionFactory objGlobal = new ConnectionFactory();
            }
            return objFactory;
        }
    }
}
