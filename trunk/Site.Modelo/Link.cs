using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace Site.Modelo
{
    public class Link
    {
        private string _lin_cod; 
        private string _lin_nome; 
        private string _lin_tipo; 
        private string _lin_url;

        public Link() {
        }

        public Link(string lin_cod, string lin_nome, string lin_tipo, string lin_url)
        {
            this.lin_cod = lin_cod;
            this.lin_nome = lin_nome;
            this.lin_tipo = lin_tipo;
            this.lin_url = lin_url;
        }

        public string lin_cod
        {
            get { return _lin_cod; }
            set { _lin_cod = value; }
        }
        public string lin_nome
        {
            get { return _lin_nome; }
            set { _lin_nome = value; }
        }
        public string lin_tipo
        {
            get { return _lin_tipo; }
            set { _lin_tipo = value; }
        }
        public string lin_url
        {
            get { return _lin_url; }
            set { _lin_url = value; }
        }

        //métodos
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
            Link objLink = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objLink = (Link)objSession.Load(typeof(Site.Modelo.Link), pCod);
                objSession.Delete(objLink);
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

        public static Link RecuperaLink(string pCod)
        {
            Link objLink = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objLink = (Link)objSession.Load(typeof(Site.Modelo.Link), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objLink;
        }

        public static IList RecuperaLinks()
        {
            IList listaLink;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                listaLink = objSession.CreateCriteria(typeof(Site.Modelo.Link)).AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("lin_cod")))).List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaLink = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaLink;
        }

        

        public static IList RecuperaLinksTipo(string pTipo)
        {
            IList listaLink;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Link));
                criteria.Add(Expression.Eq("lin_tipo", pTipo));
                criteria.AddOrder(Order.Asc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("lin_cod"))));
                listaLink = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaLink;
        }
    }
}
