using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace Site.Modelo
{
    public class Banco
    {
        private string _ban_cod;
        private string _ban_nome;
        private string _ban_site;
        private string _ban_logo;

        public Banco()
        {
        }

        public Banco(string ban_cod, string ban_nome, string ban_site, string ban_logo)
        {
            this.ban_cod = ban_cod;
            this.ban_nome = ban_nome;
            this.ban_site = ban_site;
            this.ban_logo = ban_logo;
        }

        public string ban_cod
        {
            get { return _ban_cod; }
            set { _ban_cod = value; }
        }

        public string ban_nome
        {
            get { return _ban_nome; }
            set { _ban_nome = value; }
        }

        public string ban_site
        {
            get { return _ban_site; }
            set { _ban_site = value; }
        }

        public string ban_logo
        {
            get { return _ban_logo; }
            set { _ban_logo = value; }
        }

        public Boolean Insere()
        {
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objSession.Save(this);
                objTransaction.Commit();
                objSession.Close();
                return true;
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
        }

        public Boolean Atualiza()
        {
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objSession.Update(this);
                objTransaction.Commit();
                objSession.Close();
                return true;
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
        }

        public static Boolean Deleta(string pCod)
        {
            Banco objBanco = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objBanco = (Banco)objSession.Load(typeof(Site.Modelo.Banco), pCod);
                objSession.Delete(objBanco);
                objTransaction.Commit();
                objSession.Close();
                return true;
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
        }

        public static Banco RecuperaBanco(string pCod)
        {
            Banco objBanco = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objBanco = (Banco)objSession.Load(typeof(Site.Modelo.Banco), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objBanco;
        }

        public static IList RecuperaBancos()
        {
            IList listaBanco;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                listaBanco = objSession.CreateCriteria(typeof(Site.Modelo.Banco)).AddOrder(Order.Asc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("ban_cod")))).List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaBanco = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaBanco;
        }

    }
}
