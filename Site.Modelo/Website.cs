using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace Site.Modelo
{
    //classe
    public class Website
    {
        //atributos
        private string _web_cod;
        private string _web_titulo;
        private string _web_slogan;
        private string _web_endereco;
        private string _web_cep;
        private string _web_cidade;
        private string _web_estado;
        private string _web_telefone;
        private string _web_email;
        private string _web_info_titulo;
        private string _web_info_resumo;
        private string _web_info_conteudo;
        private DateTime _web_info_data;
        private string _web_banner;

        //construtores
        public Website()
        {

        }

        public Website(string web_cod, string web_titulo, string web_slogan, string web_endereco, string web_cep, string web_cidade, string web_estado, string web_telefone, string web_email, string web_info_titulo, string web_info_resumo, string web_info_conteudo, DateTime web_info_data, string web_banner)
        {
            this.web_cod = web_cod;
            this.web_titulo = web_titulo;
            this.web_slogan = web_slogan;
            this.web_endereco = web_endereco;
            this.web_cep = web_cep;
            this.web_cidade = web_cidade;
            this.web_estado = web_estado;
            this.web_telefone = web_telefone;
            this.web_email = web_email;
            this.web_info_titulo = web_info_titulo;
            this.web_info_resumo = web_info_resumo;
            this.web_info_conteudo = web_info_conteudo;
            this.web_info_data = web_info_data;
            this.web_banner = web_banner;
        }

        //gets e sets
        public string web_cod
        {
            get { return _web_cod; }
            set { _web_cod = value; }
        }
        public string web_titulo
        {
            get { return _web_titulo; }
            set { _web_titulo = value; }
        }
        public string web_slogan
        {
            get { return _web_slogan; }
            set { _web_slogan = value; }
        }
        public string web_endereco
        {
            get { return _web_endereco; }
            set { _web_endereco = value; }
        }
        public string web_cep
        {
            get { return _web_cep; }
            set { _web_cep = value; }
        }
        public string web_cidade
        {
            get { return _web_cidade; }
            set { _web_cidade = value; }
        }
        public string web_estado
        {
            get { return _web_estado; }
            set { _web_estado = value; }
        }
        public string web_telefone
        {
            get { return _web_telefone; }
            set { _web_telefone = value; }
        }
        public string web_email
        {
            get { return _web_email; }
            set { _web_email = value; }
        }
        public string web_info_titulo
        {
            get { return _web_info_titulo; }
            set { _web_info_titulo = value; }
        }
        public string web_info_resumo
        {
            get { return _web_info_resumo; }
            set { _web_info_resumo = value; }
        }
        public string web_info_conteudo
        {
            get { return _web_info_conteudo; }
            set { _web_info_conteudo = value; }
        }
        public DateTime web_info_data
        {
            get { return _web_info_data; }
            set { _web_info_data = value; }
        }
        public string web_banner
        {
            get { return _web_banner; }
            set { _web_banner = value; }
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

        public static Website RecuperaWebsite(string pCod)
        {
            Website objWebsite = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objWebsite = (Website)objSession.Load(typeof(Site.Modelo.Website), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objWebsite;
        }

        public static IList RecuperaWebsite()
        {
            IList listaWebsite;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                listaWebsite = objSession.CreateCriteria(typeof(Site.Modelo.Website)).List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaWebsite = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaWebsite;
        }

        public static IList RecuperaWebsiteMax()
        {
            IList listaWebsite;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                listaWebsite = objSession.CreateCriteria(typeof(Site.Modelo.Website)).SetProjection(Projections.Max("web_cod")).List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaWebsite = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaWebsite;
        } 

    }
}
