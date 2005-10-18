using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace Site.Modelo
{
    public class Contrato
    {

        private string _con_cod; 
        private string _con_numero; 
        private DateTime _con_data_liberacao; 
        private Double _con_taxa; 
        private Decimal _con_valor; 
        private string _con_tipo; 
        private Proposta _con_proposta;
        private Comissao _con_comissao;

        public Contrato()
        {
        }

        public Contrato(string con_cod, string con_numero, DateTime con_data_liberacao, Double con_taxa, Decimal con_valor, string con_tipo, Proposta con_proposta, Comissao con_comissao)
        {
            this.con_cod = con_cod; 
            this.con_numero = con_numero; 
            this.con_data_liberacao = con_data_liberacao; 
            this.con_taxa = con_taxa; 
            this.con_valor = con_valor; 
            this.con_tipo = con_tipo; 
            this.con_proposta = con_proposta;
            this.con_comissao = con_comissao;
        }

        public string con_cod { get { return _con_cod; } set { _con_cod = value; } }
        public string con_numero { get { return _con_numero; } set { _con_numero = value; } }
        public DateTime con_data_liberacao { get { return _con_data_liberacao; } set { _con_data_liberacao = value; } }
        public Double con_taxa { get { return _con_taxa; } set { _con_taxa = value; } }
        public Decimal con_valor { get { return _con_valor; } set { _con_valor = value; } }
        public string con_tipo { get { return _con_tipo; } set { _con_tipo = value; } }
        public Proposta con_proposta { get { return _con_proposta; } set { _con_proposta = value; } }
        public Comissao con_comissao { get { return _con_comissao; } set { _con_comissao = value; } }

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
            Contrato objContrato = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objContrato = (Contrato)objSession.Load(typeof(Site.Modelo.Contrato), pCod);
                objSession.Delete(objContrato);
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

        public static Contrato RecuperaContrato(string pCod)
        {
            Contrato objContrato = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objContrato = (Contrato)objSession.Load(typeof(Site.Modelo.Contrato), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objContrato;
        }

        public static IList RecuperaContratoProposta(Proposta pProposta)
        {
            IList listaContrato;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Contrato));
                criteria.Add(Expression.Eq("con_proposta", pProposta));
                criteria.AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("con_cod"))));
                listaContrato = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaContrato;
        }

        public static IList RecuperaContratoComissao(Comissao pComissao)
        {
            IList listaContrato;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Contrato));
                criteria.Add(Expression.Eq("con_comissao", pComissao));
                criteria.AddOrder(Order.Desc("con_data_liberacao"));
                listaContrato = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaContrato;
        }

    }

}
