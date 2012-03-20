using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Site.Modelo
{
    public class Proposta
    {
        private string _pro_cod;
        private string _pro_nb;
        private string _pro_nit;
        private string _pro_especie;
        private string _pro_forma_receb_benef;
        private string _pro_banco;
        private string _pro_agencia;
        private string _pro_operacao;
        private string _pro_conta;
        private Decimal _pro_solicitado;
        private string _pro_plano;
        private Decimal _pro_prestacao;
        private string _pro_liber_emprestimo;
        private string _pro_banco_emprestimo;
        private string _pro_cidade_emprestimo;
        private string _pro_agencia_emprestimo;
        private string _pro_operacao_emprestimo;
        private string _pro_conta_emprestimo;
        private Usuario _pro_usuario;
        private string _pro_observacoes;
        private string _pro_doc1;
        private string _pro_doc2;
        private string _pro_doc3;
        private string _pro_doc4;
        private string _pro_doc5;
        private string _pro_status;
        private Cliente _pro_cliente;
        private Banco _pro_bancos;
        private string _pro_tipo;
        private DateTime _pro_data;

        public Proposta()
        {

        }

        public Proposta(
            string pro_cod,
            string pro_nb,
            string pro_nit,
            string pro_especie,
            string pro_forma_receb_benef,
            string pro_banco,
            string pro_agencia,
            string pro_operacao,
            string pro_conta,
            Decimal pro_solicitado,
            string pro_plano,
            Decimal pro_prestacao,
            string pro_liber_emprestimo,
            string pro_banco_emprestimo,
            string pro_cidade_emprestimo,
            string pro_agencia_emprestimo,
            string pro_operacao_emprestimo,
            string pro_conta_emprestimo,
            Usuario pro_usuario,
            string pro_observacoes,
            string pro_doc1,
            string pro_doc2,
            string pro_doc3,
            string pro_doc4,
            string pro_doc5,
            string pro_status,
            Cliente pro_cliente,
            Banco pro_bancos,
            string pro_tipo,
            DateTime pro_data)
        {
            this.pro_cod = pro_cod;
            this.pro_nb = pro_nb;
            this.pro_nit = pro_nit;
            this.pro_especie = pro_especie;
            this.pro_forma_receb_benef = pro_forma_receb_benef;
            this.pro_banco = pro_banco;
            this.pro_agencia = pro_agencia;
            this.pro_operacao = pro_operacao;
            this.pro_conta = pro_conta;
            this.pro_solicitado = pro_solicitado;
            this.pro_plano = pro_plano;
            this.pro_prestacao = pro_prestacao;
            this.pro_liber_emprestimo = pro_liber_emprestimo;
            this.pro_banco_emprestimo = pro_banco_emprestimo;
            this.pro_cidade_emprestimo = pro_cidade_emprestimo;
            this.pro_agencia_emprestimo = pro_agencia_emprestimo;
            this.pro_operacao_emprestimo = pro_operacao_emprestimo;
            this.pro_conta_emprestimo = pro_conta_emprestimo;
            this.pro_usuario = pro_usuario;
            this.pro_observacoes = pro_observacoes;
            this.pro_doc1 = pro_doc1;
            this.pro_doc2 = pro_doc2;
            this.pro_doc3 = pro_doc3;
            this.pro_doc4 = pro_doc4;
            this.pro_doc5 = pro_doc5;
            this.pro_status = pro_status;
            this.pro_cliente = pro_cliente;
            this.pro_bancos = pro_bancos;
            this.pro_tipo = pro_tipo;
            this.pro_data = pro_data;
        }

        public string pro_cod
        {
            get { return _pro_cod; }
            set { _pro_cod = value; }
        }
        public string pro_nb
        {
            get { return _pro_nb; }
            set { _pro_nb = value; }
        }
        public string pro_nit
        {
            get { return _pro_nit; }
            set { _pro_nit = value; }
        }
        public string pro_especie
        {
            get { return _pro_especie; }
            set { _pro_especie = value; }
        }
        public string pro_forma_receb_benef
        {
            get { return _pro_forma_receb_benef; }
            set { _pro_forma_receb_benef = value; }
        }
        public string pro_banco
        {
            get { return _pro_banco; }
            set { _pro_banco = value; }
        }
        public string pro_agencia
        {
            get { return _pro_agencia; }
            set { _pro_agencia = value; }
        }
        public string pro_operacao
        {
            get { return _pro_operacao; }
            set { _pro_operacao = value; }
        }
        public string pro_conta
        {
            get { return _pro_conta; }
            set { _pro_conta = value; }
        }
        public Decimal pro_solicitado
        {
            get { return _pro_solicitado; }
            set { _pro_solicitado = value; }
        }
        public string pro_plano
        {
            get { return _pro_plano; }
            set { _pro_plano = value; }
        }
        public Decimal pro_prestacao
        {
            get { return _pro_prestacao; }
            set { _pro_prestacao = value; }
        }
        public string pro_liber_emprestimo
        {
            get { return _pro_liber_emprestimo; }
            set { _pro_liber_emprestimo = value; }
        }
        public string pro_banco_emprestimo
        {
            get { return _pro_banco_emprestimo; }
            set { _pro_banco_emprestimo = value; }
        }
        public string pro_cidade_emprestimo
        {
            get { return _pro_cidade_emprestimo; }
            set { _pro_cidade_emprestimo = value; }
        }
        public string pro_agencia_emprestimo
        {
            get { return _pro_agencia_emprestimo; }
            set { _pro_agencia_emprestimo = value; }
        }
        public string pro_operacao_emprestimo
        {
            get { return _pro_operacao_emprestimo; }
            set { _pro_operacao_emprestimo = value; }
        }
        public string pro_conta_emprestimo
        {
            get { return _pro_conta_emprestimo; }
            set { _pro_conta_emprestimo = value; }
        }
        public Usuario pro_usuario
        {
            get { return _pro_usuario; }
            set { _pro_usuario = value; }
        }
        public string pro_observacoes
        {
            get { return _pro_observacoes; }
            set { _pro_observacoes = value; }
        }
        public string pro_doc1
        {
            get { return _pro_doc1; }
            set { _pro_doc1 = value; }
        }
        public string pro_doc2
        {
            get { return _pro_doc2; }
            set { _pro_doc2 = value; }
        }
        public string pro_doc3
        {
            get { return _pro_doc3; }
            set { _pro_doc3 = value; }
        }
        public string pro_doc4
        {
            get { return _pro_doc4; }
            set { _pro_doc4 = value; }
        }
        public string pro_doc5
        {
            get { return _pro_doc5; }
            set { _pro_doc5 = value; }
        }
        public string pro_status
        {
            get { return _pro_status; }
            set { _pro_status = value; }
        }
        public Cliente pro_cliente
        {
            get { return _pro_cliente; }
            set { _pro_cliente = value; }
        }
        public Banco pro_bancos
        {
            get { return _pro_bancos; }
            set { _pro_bancos = value; }
        }
        public string pro_tipo
        {
            get { return _pro_tipo; }
            set { _pro_tipo = value; }
        }
        public DateTime pro_data
        {
            get { return _pro_data; }
            set { _pro_data = value; }
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
            Proposta objProposta = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objProposta = (Proposta)objSession.Load(typeof(Site.Modelo.Proposta), pCod);
                objSession.Delete(objProposta);
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

        public static Proposta RecuperaProposta(string pCod)
        {
            Proposta objProposta = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objProposta = (Proposta)objSession.Load(typeof(Site.Modelo.Proposta), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objProposta;
        }

        public static IList RecuperaPropostas()
        {
            IList listaProposta;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                //listaProposta = objSession.CreateCriteria(typeof(Site.Modelo.Proposta)).AddOrder(Order.Desc("pro_cod")).List();
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Proposta));
                criteria.AddOrder(Order.Desc( Projections.Cast(NHibernateUtil.Int32, Projections.Property("pro_cod")) ));
                listaProposta = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaProposta = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaProposta;
        }

        public static IList RecuperaPropostaCliente(Cliente pCliente)
        {
            IList listaProposta;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Proposta));
                criteria.Add(Expression.Eq("pro_cliente", pCliente));
                criteria.AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("pro_cod"))));
                listaProposta = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaProposta;
        }

        public static IList RecuperaPropostaLoja(Loja pLoja)
        {
            IList listaProposta;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                var subCriteria = DetachedCriteria.For(typeof(Usuario)).SetProjection(Projections.Property("usu_cod")).Add(Expression.Eq("usu_loja", pLoja));
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Proposta)).SetResultTransformer(new DistinctRootEntityResultTransformer()).Add(Expression.Eq("pro_status", "R")).Add(Subqueries.PropertyIn("pro_usuario", subCriteria)); 
                criteria.AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("pro_cod"))));   
                listaProposta = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaProposta;
        }

        public static IList RecuperaPropostaUsuario(Usuario pUsuario)
        {
            IList listaProposta;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Proposta));
                criteria.Add(Expression.Eq("pro_usuario", pUsuario));
                criteria.AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("pro_cod"))));
                listaProposta = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaProposta;
        }

        public static IList RecuperaPropostaStatus(string pStatus)
        {
            IList listaProposta;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Proposta));
                criteria.Add(Expression.Eq("pro_status", pStatus));
                criteria.AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("pro_cod"))));
                listaProposta = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaProposta;
        }

        public static IList RecuperaPropostaUsuarioStatus(Usuario pUsuario, string pStatus)
        {
            IList listaProposta;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Proposta));
                criteria.Add(Expression.Eq("pro_usuario", pUsuario)).Add(Expression.Eq("pro_status", pStatus));
                criteria.AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("pro_cod"))));
                listaProposta = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaProposta;
        }

        public static IList RecuperaPropostaBanco(Banco pBanco)
        {
            IList listaProposta;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Proposta));
                criteria.Add(Expression.Eq("pro_bancos", pBanco));
                criteria.AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("pro_cod"))));
                listaProposta = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaProposta;
        }
    }
}
