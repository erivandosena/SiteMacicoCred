using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace Site.Modelo
{
    public class Pagina
    {
        #region Campos

        private String _pag_cod;
        private String _pag_nome;
        private String _pag_descricao;
        private String _pag_conteudo;
        private String _pag_posicao;

        #endregion

        #region Construtores

        public Pagina()
        {
            
        }

        public Pagina(string pCod, string pNome, string pDescricao, string pConteudo, string pPosicao)
        {
            this.pag_cod = pCod;
            this.pag_nome = pNome;
            this.pag_descricao = pDescricao;
            this.pag_conteudo = pConteudo;
            this.pag_posicao = pPosicao;
        }

        #endregion

        #region Propriedades

        public String pag_cod
        {
            get
            {
                return _pag_cod;
            }
            set
            {
                _pag_cod = value;
            }
        }

        public String pag_nome
        {
            get
            {
                return _pag_nome;
            }
            set
            {
                _pag_nome = value;
            }
        }

        public String pag_descricao
        {
            get
            {
                return _pag_descricao;
            }
            set
            {
                _pag_descricao = value;
            }
        }

        public String pag_conteudo
        {
            get
            {
                return _pag_conteudo;
            }
            set
            {
                _pag_conteudo = value;
            }
        }

        public String pag_posicao
        {
            get
            {
                return _pag_posicao;
            }
            set
            {
                _pag_posicao = value;
            }
        }

        #endregion

        #region Metodos

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
            Pagina objPagina = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objPagina = (Pagina)objSession.Load(typeof(Site.Modelo.Pagina), pCod);
                objSession.Delete(objPagina);
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

        public static Pagina RecuperaPagina(string pCod)
        {
            Pagina objPagina = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objPagina = (Pagina)objSession.Load(typeof(Site.Modelo.Pagina), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objPagina;
        }

        public static IList RecuperaPaginas()
        {
            IList listaPaginas;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                listaPaginas = objSession.CreateCriteria(typeof(Site.Modelo.Pagina)).AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("pag_cod")))).List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaPaginas = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaPaginas;
        }

        public static IList RecuperaPaginasMenu(string pPosicao)
        {
            IList listaPaginas;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Pagina));
                criteria.Add(Expression.Eq("pag_posicao", pPosicao));
                criteria.AddOrder(Order.Asc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("pag_cod"))));
                listaPaginas = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaPaginas;
        }

        #endregion
    }
}
