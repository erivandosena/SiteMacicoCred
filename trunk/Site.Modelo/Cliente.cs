using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;

namespace Site.Modelo
{
    public class Cliente
    {
        private string _cli_cod;
        private string _cli_nome;
        private DateTime _cli_nasc;
        private string _cli_sexo;
        private string _cli_cpf;
        private string _cli_rg;
        private DateTime _cli_dt_emissao;
        private string _cli_telefone;
        private string _cli_telefone2;
        private string _cli_mae;
        private string _cli_pai;
        private string _cli_naturalidade;
        private string _cli_natural_uf;
        private string _cli_endereco;
        private string _cli_bairro;
        private string _cli_referencia;
        private string _cli_cep;
        private string _cli_cidade;
        private string _cli_uf;
        private Decimal _cli_renda;
        private DateTime _cli_data_cadastro;
        private string _cli_email;
        private string _cli_senha;
        private string _cli_nb1;
        private string _cli_nb2;
       

        public Cliente()
        {

        }

        public Cliente(
            string cli_cod,
            string cli_nome,
            DateTime cli_nasc,
            string cli_sexo,
            string cli_cpf,
            string cli_rg,
            DateTime cli_dt_emissao,
            string cli_telefone,
            string cli_telefone2,
            string cli_mae,
            string cli_pai,
            string cli_naturalidade,
            string cli_natural_uf,
            string cli_endereco,
            string cli_bairro,
            string cli_referencia,
            string cli_cep,
            string cli_cidade,
            string cli_uf,
            Decimal cli_renda,
            DateTime cli_data_cadastro,
            string cli_email,
            string cli_senha,
            string cli_nb1,
            string cli_nb2)
        {
            this.cli_cod = cli_cod;
            this.cli_nome = cli_nome;
            this.cli_nasc = cli_nasc;
            this.cli_sexo = cli_sexo;
            this.cli_cpf = cli_cpf;
            this.cli_rg = cli_rg;
            this.cli_dt_emissao = cli_dt_emissao;
            this.cli_telefone = cli_telefone;
            this.cli_telefone2 = cli_telefone2;
            this.cli_mae = cli_mae;
            this.cli_pai = cli_pai;
            this.cli_naturalidade = cli_naturalidade;
            this.cli_natural_uf = cli_natural_uf;
            this.cli_endereco = cli_endereco;
            this.cli_bairro = cli_bairro;
            this.cli_referencia = cli_referencia;
            this.cli_cep = cli_cep;
            this.cli_cidade = cli_cidade;
            this.cli_uf = cli_uf;
            this.cli_renda = cli_renda;
            this.cli_data_cadastro = cli_data_cadastro;
            this.cli_email = cli_email;
            this.cli_senha = cli_senha;
            this.cli_nb1 = cli_nb1;
            this.cli_nb2 = cli_nb2;
           
        }

        public string cli_cod
        {
            get { return _cli_cod; }
            set { _cli_cod = value; }
        }
        public string cli_nome
        {
            get { return _cli_nome; }
            set { _cli_nome = value; }
        }
        public DateTime cli_nasc
        {
            get { return _cli_nasc; }
            set { _cli_nasc = value; }
        }
        public string cli_sexo
        {
            get { return _cli_sexo; }
            set { _cli_sexo = value; }
        }
        public string cli_cpf
        {
            get { return _cli_cpf; }
            set { _cli_cpf = value; }
        }
        public string cli_rg
        {
            get { return _cli_rg; }
            set { _cli_rg = value; }
        }
        public DateTime cli_dt_emissao
        {
            get { return _cli_dt_emissao; }
            set { _cli_dt_emissao = value; }
        }
        public string cli_telefone
        {
            get { return _cli_telefone; }
            set { _cli_telefone = value; }
        }
        public string cli_telefone2
        {
            get { return _cli_telefone2; }
            set { _cli_telefone2 = value; }
        }
        public string cli_mae
        {
            get { return _cli_mae; }
            set { _cli_mae = value; }
        }
        public string cli_pai
        {
            get { return _cli_pai; }
            set { _cli_pai = value; }
        }
        public string cli_naturalidade
        {
            get { return _cli_naturalidade; }
            set { _cli_naturalidade = value; }
        }
        public string cli_natural_uf
        {
            get { return _cli_natural_uf; }
            set { _cli_natural_uf = value; }
        }
        public string cli_endereco
        {
            get { return _cli_endereco; }
            set { _cli_endereco = value; }
        }
        public string cli_bairro
        {
            get { return _cli_bairro; }
            set { _cli_bairro = value; }
        }
        public string cli_referencia
        {
            get { return _cli_referencia; }
            set { _cli_referencia = value; }
        }
        public string cli_cep
        {
            get { return _cli_cep; }
            set { _cli_cep = value; }
        }
        public string cli_cidade
        {
            get { return _cli_cidade; }
            set { _cli_cidade = value; }
        }
        public string cli_uf
        {
            get { return _cli_uf; }
            set { _cli_uf = value; }
        }
        public Decimal cli_renda
        {
            get { return _cli_renda; }
            set { _cli_renda = value; }
        }
        public DateTime cli_data_cadastro
        {
            get { return _cli_data_cadastro; }
            set { _cli_data_cadastro = value; }
        }
        public string cli_email
        {
            get { return _cli_email; }
            set { _cli_email = value; }
        }
        public string cli_senha
        {
            get { return _cli_senha; }
            set { _cli_senha = value; }
        }
        public string cli_nb1
        {
            get { return _cli_nb1; }
            set { _cli_nb1 = value; }
        }
        public string cli_nb2
        {
            get { return _cli_nb2; }
            set { _cli_nb2 = value; }
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
            Cliente objCliente = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objCliente = (Cliente)objSession.Load(typeof(Site.Modelo.Cliente), pCod);
                objSession.Delete(objCliente);
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

        public static Cliente RecuperaCliente(string pCod)
        {
            Cliente objCliente = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objCliente = (Cliente)objSession.Load(typeof(Site.Modelo.Cliente), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objCliente;
        }

        public static IList RecuperaClientes()
        {
            IList listaCliente;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                listaCliente = objSession.CreateCriteria(typeof(Site.Modelo.Cliente)).AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("cli_cod")))).List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaCliente = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaCliente;
        }

        public static IList RecuperaClienteCpf(string pCPF)
        {
            IList listaClientes;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Cliente));
                criteria.Add(Expression.Eq("cli_cpf", pCPF));
                listaClientes = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaClientes;
        }

        public static IList RecuperaClienteNome(string pNome)
        {
            IList listaClientes;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Cliente));
                criteria.Add(Expression.Like("cli_nome", "%"+pNome+"%"));
                listaClientes = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaClientes;
        }

    }
}
