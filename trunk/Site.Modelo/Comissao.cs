using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace Site.Modelo
{
    public class Comissao
    {
        private string _com_cod;
        private DateTime _com_data_abertura;
        private DateTime _com_data_fechamento;
        private Loja _com_loja;
        private Usuario _com_usuario;
        private string _com_status;
        private IList _com_contrato;

        public Comissao()
        {
        }

        public Comissao(string com_cod, DateTime com_data_abertura, DateTime com_data_fechamento, Loja com_loja, Usuario com_usuario, string com_status)
        {
            this.com_cod = com_cod;
            this.com_data_abertura = com_data_abertura;
            this.com_data_fechamento = com_data_fechamento;
            this.com_loja = com_loja;
            this.com_usuario = com_usuario;
            this.com_status = com_status;
        }


        public string com_cod { get { return _com_cod; } set { _com_cod = value; } }
        public DateTime com_data_abertura { get { return _com_data_abertura; } set { _com_data_abertura = value; } }
        public DateTime com_data_fechamento { get { return _com_data_fechamento; } set { _com_data_fechamento = value; } }
        public Loja com_loja { get { return _com_loja; } set { _com_loja = value; } }
        public Usuario com_usuario { get { return _com_usuario; } set { _com_usuario = value; } }
        public string com_status { get { return _com_status; } set { _com_status = value; } }
        public IList com_contrato { get { return _com_contrato; } set { _com_contrato = value; } }

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
            Comissao objComissao = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objComissao = (Comissao)objSession.Load(typeof(Site.Modelo.Comissao), pCod);
                objSession.Delete(objComissao);
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



        public static Comissao RecuperaComissao(string pCod)
        {
            Comissao objComissao = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objComissao = (Comissao)objSession.Load(typeof(Site.Modelo.Comissao), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objComissao;
        }

        public static IList RecuperaComissoes()
        {
            IList listaComissao;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                listaComissao = objSession.CreateCriteria(typeof(Site.Modelo.Comissao)).AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("com_cod")))).List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaComissao = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaComissao;
        }

        public static IList RecuperaComissaoUsuario(Usuario pUsuario)
        {
            IList listaComissao;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Comissao));
                criteria.Add(Expression.Eq("com_usuario", pUsuario));
                criteria.AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("com_cod"))));
                listaComissao = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaComissao;
        }

        public static IList RecuperaComissaoLoja(Loja pLoja)
        {
            IList listaComissao;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Comissao));
                criteria.Add(Expression.Eq("com_loja", pLoja));
                listaComissao = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaComissao;
        }

        public static IList RecuperaComissaoUsuarioStatus(Usuario pUsuario, string pStatus)
        {
            IList listaComissao;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Comissao));
                criteria.Add(Expression.Eq("com_usuario", pUsuario)).Add(Expression.Eq("com_status", pStatus));
                criteria.AddOrder(Order.Desc("com_data_fechamento"));
                listaComissao = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaComissao;
        }

        public static IList RecuperaComissaoStatus(string pStatus)
        {
            IList listaComissao;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Comissao));
                criteria.Add(Expression.Eq("com_status", pStatus));
                listaComissao = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaComissao;
        }
    }
}
