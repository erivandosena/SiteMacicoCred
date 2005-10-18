using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace Site.Modelo
{
    public class Loja
    {
        private string _loj_cod;
        private string _loj_nome;
        private string _loj_endereco;
        private string _loj_cidade;
        private string _loj_estado;
        private string _loj_cep;
        private string _loj_telefone;
        private string _loj_email;
        private string _loj_foto;
        
        public Loja()
        {

        }

        public Loja(string loj_cod, string loj_nome, string loj_endereco, string loj_cidade, string loj_estado, string loj_cep, string loj_telefone, string loj_email, string loj_foto)
        {
            this.loj_cod = loj_cod;
            this.loj_nome = loj_nome;
            this.loj_telefone = loj_endereco;
            this.loj_cidade = loj_cidade;
            this.loj_estado = loj_estado;
            this.loj_cep = loj_cep;
            this.loj_telefone = loj_telefone;
            this.loj_email = loj_email;
            this.loj_foto = loj_foto;
        }

        public string loj_cod
        {
            get { return _loj_cod; }
            set { _loj_cod = value; }
        }
        public string loj_nome
        {
            get { return _loj_nome; }
            set { _loj_nome = value; }
        }
        public string loj_endereco
        {
            get { return _loj_endereco; }
            set { _loj_endereco = value; }
        }
        public string loj_cidade
        {
            get { return _loj_cidade; }
            set { _loj_cidade = value; }
        }
        public string loj_estado
        {
            get { return _loj_estado; }
            set { _loj_estado = value; }
        }
        public string loj_cep
        {
            get { return _loj_cep; }
            set { _loj_cep = value; }
        }
        public string loj_telefone
        {
            get { return _loj_telefone; }
            set { _loj_telefone = value; }
        }
        public string loj_email
        {
            get { return _loj_email; }
            set { _loj_email = value; }
        }
        public string loj_foto
        {
            get { return _loj_foto; }
            set { _loj_foto = value; }
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
            Loja objLoja = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objLoja = (Loja)objSession.Load(typeof(Site.Modelo.Loja), pCod);
                objSession.Delete(objLoja);
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

        public static Loja RecuperaLoja(string pCod)
        {
            Loja objLoja = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objLoja = (Loja)objSession.Load(typeof(Site.Modelo.Loja), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objLoja;
        }

        public static IList RecuperaLojas()
        {
            IList listaLoja;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                listaLoja = objSession.CreateCriteria(typeof(Site.Modelo.Loja)).AddOrder(Order.Asc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("loj_cod")))).List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaLoja = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaLoja;
        }
    }
}
