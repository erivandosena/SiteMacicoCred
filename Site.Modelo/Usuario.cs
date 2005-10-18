using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using NHibernate.Cfg;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Site.Modelo
{
    public class Usuario
    {
        private String _usu_cod;
        private String _usu_nome;
        private String _usu_senha;
        private String _usu_email;
        private Loja _usu_loja;
        private Boolean _usu_ativo;
        private String _usu_funcao;
        private String _usu_nome_completo;
        private String _usu_cpf;
        private String _usu_rg;
        private DateTime _usu_data_nascimento;
        private String _usu_endereco_res;
        private String _usu_endereco_com;
        private String _usu_bairro;
        private String _usu_cep;
        private String _usu_cidade;
        private String _usu_uf;
        private String _usu_tel_fixo;
        private String _usu_tel_cel;
        private String _usu_banco;
        private String _usu_agencia;
        private String _usu_conta;
        private String _usu_operacao;
        private String _usu_tipo_conta;

        public Usuario()
        {

        }

        public Usuario(
            string pCod,
            string pNome,
            string pSenha,
            string pEmail,
            Loja pLocal,
            bool pAtivo,
            string pFuncao,
            string pNomeCompleto,
            string pCpf,
            string pRg,
            DateTime pData_nascimento,
            string pEndereco_res,
            string pEndereco_com,
            string pBairro,
            string pCep,
            string pCidade,
            string pUf,
            string pTel_fixo,
            string pTel_cel,
            string pBanco,
            string pAgencia,
            string pConta,
            string pOperacao,
            string pTipo_conta)
        {
            this.usu_cod = pCod;
            this.usu_nome = pNome;
            this.usu_senha = pSenha;
            this.usu_email = pEmail;
            this.usu_loja = pLocal;
            this.usu_ativo = pAtivo;
            this.usu_funcao = pFuncao;
            this.usu_nome_completo = pNomeCompleto;
            this.usu_cpf = pCpf;
            this.usu_rg = pRg;
            this.usu_data_nascimento = pData_nascimento;
            this.usu_endereco_res = pEndereco_res;
            this.usu_endereco_com = pEndereco_com;
            this.usu_bairro = pBairro;
            this.usu_cep = pCep;
            this.usu_cidade = pCidade;
            this.usu_uf = pUf;
            this.usu_tel_fixo = pTel_fixo;
            this.usu_tel_cel = pTel_cel;
            this.usu_banco = pBanco;
            this.usu_agencia = pAgencia;
            this.usu_conta = pConta;
            this.usu_operacao = pOperacao;
            this.usu_tipo_conta = pTipo_conta;
        }

        public String usu_cod
        {
            get { return _usu_cod; }
            set { _usu_cod = value; }
        }

        public String usu_nome
        {
            get { return _usu_nome; }
            set { _usu_nome = value; }
        }

        public String usu_senha
        {
            get { return _usu_senha; }
            set { _usu_senha = value; }
        }

        public String usu_email
        {
            get { return _usu_email; }
            set { _usu_email = value; }
        }

        public Loja usu_loja
        {
            get { return _usu_loja; }
            set { _usu_loja = value; }
        }

        public Boolean usu_ativo
        {
            get { return _usu_ativo; }
            set { _usu_ativo = value; }
        }

        public String usu_funcao
        {
            get { return _usu_funcao; }
            set { _usu_funcao = value; }
        }

        public String usu_nome_completo
        {
            get { return _usu_nome_completo; }
            set { _usu_nome_completo = value; }
        }

        public String usu_cpf
        {
            get { return _usu_cpf; }
            set { _usu_cpf = value; }
        }

        public string usu_rg
        {
            get { return _usu_rg; }
            set { _usu_rg = value; }
        }

        public DateTime usu_data_nascimento
        {
            get { return _usu_data_nascimento; }
            set { _usu_data_nascimento = value; }
        }

        public string usu_endereco_res
        {
            get { return _usu_endereco_res; }
            set { _usu_endereco_res = value; }
        }

        public string usu_endereco_com
        {
            get { return _usu_endereco_com; }
            set { _usu_endereco_com = value; }
        }

        public string usu_bairro
        {
            get { return _usu_bairro; }
            set { _usu_bairro = value; }
        }

        public string usu_cep
        {
            get { return _usu_cep; }
            set { _usu_cep = value; }
        }

        public string usu_cidade
        {
            get { return _usu_cidade; }
            set { _usu_cidade = value; }
        }

        public string usu_uf
        {
            get { return _usu_uf; }
            set { _usu_uf = value; }
        }

        public string usu_tel_fixo
        {
            get { return _usu_tel_fixo; }
            set { _usu_tel_fixo = value; }
        }

        public string usu_tel_cel
        {
            get { return _usu_tel_cel; }
            set { _usu_tel_cel = value; }
        }

        public string usu_banco
        {
            get { return _usu_banco; }
            set { _usu_banco = value; }
        }

        public string usu_agencia
        {
            get { return _usu_agencia; }
            set { _usu_agencia = value; }
        }

        public string usu_conta
        {
            get { return _usu_conta; }
            set { _usu_conta = value; }
        }

        public string usu_operacao
        {
            get { return _usu_operacao; }
            set { _usu_operacao = value; }
        }

        public string usu_tipo_conta
        {
            get { return _usu_tipo_conta; }
            set { _usu_tipo_conta = value; }
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
            Usuario objUsuario = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objUsuario = (Usuario)objSession.Load(typeof(Site.Modelo.Usuario), pCod);
                objSession.Delete(objUsuario);
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

        public static Usuario RecuperaUsuario(string pCod)
        {
            Usuario objUsuario = null;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                objUsuario = (Usuario)objSession.Load(typeof(Site.Modelo.Usuario), pCod);
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return objUsuario;
        }

        public static IList RecuperaUsuarios()
        {
            IList listaUsuarios;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                listaUsuarios = objSession.CreateCriteria(typeof(Site.Modelo.Usuario)).AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("usu_cod")))).List();
                objSession.Close();
            }
            catch (Exception e)
            {
                listaUsuarios = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaUsuarios;
        }

        public static IList RecuperaUsuarioPorCodigo(string pCod)
        {
            IList listaUsuarios;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario));
                criteria.Add(Expression.Eq("usu_cod", pCod));
                listaUsuarios = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaUsuarios;
        }

        public static IList RecuperaUsuariosPorFuncao(string pFuncao)
        {
            IList listaUsuarios;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {

                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario));
                criteria.Add(Expression.Eq("usu_funcao", pFuncao)).AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("usu_cod"))));
                listaUsuarios = criteria.List();
                objSession.Close();


            }
            catch (Exception e)
            {
                listaUsuarios = null;
                objTransaction.Rollback();
                throw e;
            }
            return listaUsuarios;
        }

        public static IList RecuperaUsuarioPorCPFeFuncao(string pCPF, string pFuncao)
        {
            IList listaUsuario;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario));
                criteria.Add(Expression.Eq("usu_cpf", pCPF)).Add(Expression.Eq("usu_funcao", pFuncao));
                listaUsuario = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaUsuario;
        }

        public static IList RecuperaUsuarioPorNomeFuncao(string pNome, string pFuncao)
        {
            IList listaUsuario;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario));
                criteria.Add(Expression.Like("usu_nome_completo", "%"+pNome+"%")).Add(Expression.Eq("usu_funcao", pFuncao));
                listaUsuario = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaUsuario;
        }

        public static IList RecuperaUsuarioLoja(Loja pLoja)
        {
            IList listaUsuarios;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario));
                criteria.Add(Expression.Eq("usu_loja", pLoja)).AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("usu_cod"))));
                listaUsuarios = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaUsuarios;
        }

        public static IList RecuperaUsuarioNome(string pLogin)
        {
            IList listaUsuarios;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario));
                criteria.Add(Expression.Eq("usu_nome", pLogin));
                listaUsuarios = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaUsuarios;
        }

        public static IList RecuperaUsuarioEmail(string pEmail)
        {
            IList listaUsuarios;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario));
                criteria.Add(Expression.Eq("usu_email", pEmail));
                listaUsuarios = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaUsuarios;
        }

        public static IList RecuperaUsuarioCpf(string pCpf)
        {
            IList listaUsuarios;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario));
                criteria.Add(Expression.Eq("usu_cpf", pCpf));
                listaUsuarios = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaUsuarios;
        }

        public static IList RecuperaUsuariosProposta()
        {
            IList listaUsuario;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                var subCriteria = DetachedCriteria.For(typeof(Proposta)).SetProjection(Projections.Property("pro_usuario")).Add(Expression.Eq("pro_status", "A"));
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario)).SetResultTransformer(new DistinctRootEntityResultTransformer()).Add(Expression.Eq("usu_funcao", "Corretor")).Add(Subqueries.PropertyIn("usu_cod", subCriteria));
                criteria.AddOrder(Order.Desc(Projections.Cast(NHibernateUtil.Int32, Projections.Property("usu_cod"))));
                listaUsuario = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaUsuario;
        }

        public static IList RecuperaUsuarioOperadorOuCorretor(string pOperador, string pCorretor)
        {
            IList listaUsuario;
            ISession objSession = ConnectionFactory.getConnection().OpenSession();
            ITransaction objTransaction = objSession.BeginTransaction();
            try
            {
                ICriteria criteria = objSession.CreateCriteria(typeof(Site.Modelo.Usuario));
                criteria.Add(Restrictions.Or(Restrictions.Eq("usu_funcao", pOperador), Restrictions.Eq("usu_funcao", pCorretor)));
                listaUsuario = criteria.List();
                objSession.Close();
            }
            catch (Exception e)
            {
                objTransaction.Rollback();
                objSession.Close();
                throw e;
            }
            return listaUsuario;
        }
    }
}
