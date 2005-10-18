using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrUsuario
    {
        public cntrUsuario()
        {

        }

        Usuario objUsuario;

        public Boolean Salva(DS_Site.UsuarioRow pUsuario)
        {
            Boolean flagReturn = false;
            if (pUsuario.usu_cod == null || pUsuario.usu_cod == "")
            {
                this.objUsuario = new Usuario();
                this.objUsuario.usu_nome = pUsuario.usu_nome;
                this.objUsuario.usu_senha = pUsuario.usu_senha;
                this.objUsuario.usu_email = pUsuario.usu_email;
                this.objUsuario.usu_loja = Loja.RecuperaLoja(pUsuario.usu_loja);
                this.objUsuario.usu_ativo = pUsuario.usu_ativo;
                this.objUsuario.usu_funcao = pUsuario.usu_funcao;
                this.objUsuario.usu_nome_completo = pUsuario.usu_nome_completo;
                this.objUsuario.usu_cpf = pUsuario.usu_cpf;
                this.objUsuario.usu_rg = pUsuario.usu_rg;
                this.objUsuario.usu_data_nascimento = string.IsNullOrEmpty(pUsuario.usu_data_nascimento) ? Convert.ToDateTime("1/1/0001") : Convert.ToDateTime(pUsuario.usu_data_nascimento);
                this.objUsuario.usu_endereco_res = pUsuario.usu_endereco_res;
                this.objUsuario.usu_endereco_com = pUsuario.usu_endereco_com;
                this.objUsuario.usu_bairro = pUsuario.usu_bairro;
                this.objUsuario.usu_cep = pUsuario.usu_cep;
                this.objUsuario.usu_cidade = pUsuario.usu_cidade;
                this.objUsuario.usu_uf = pUsuario.usu_uf;
                this.objUsuario.usu_tel_fixo = pUsuario.usu_tel_fixo;
                this.objUsuario.usu_tel_cel = pUsuario.usu_tel_cel;
                this.objUsuario.usu_banco = pUsuario.usu_banco;
                this.objUsuario.usu_agencia = pUsuario.usu_agencia;
                this.objUsuario.usu_conta = pUsuario.usu_conta;
                this.objUsuario.usu_operacao = pUsuario.usu_operacao;
                this.objUsuario.usu_tipo_conta = pUsuario.usu_tipo_conta;
                try
                {
                    flagReturn = this.objUsuario.Insere();
                }
                catch (Exception e)
                {
                    // Tratar mensagens de erro aqui!
                    throw e;
                }
            }
            else
            {
                this.objUsuario = Usuario.RecuperaUsuario(pUsuario.usu_cod);
                this.objUsuario.usu_cod = objUsuario.usu_cod;
                this.objUsuario.usu_nome = pUsuario.usu_nome;
                this.objUsuario.usu_senha = pUsuario.usu_senha;
                this.objUsuario.usu_email = pUsuario.usu_email;
                this.objUsuario.usu_loja = Loja.RecuperaLoja(pUsuario.usu_loja);
                this.objUsuario.usu_ativo = pUsuario.usu_ativo;
                this.objUsuario.usu_funcao = pUsuario.usu_funcao;
                this.objUsuario.usu_nome_completo = pUsuario.usu_nome_completo;
                this.objUsuario.usu_cpf = pUsuario.usu_cpf;
                this.objUsuario.usu_rg = pUsuario.usu_rg;
                this.objUsuario.usu_data_nascimento = string.IsNullOrEmpty(pUsuario.usu_data_nascimento) ? Convert.ToDateTime("1/1/0001") : Convert.ToDateTime(pUsuario.usu_data_nascimento);
                this.objUsuario.usu_endereco_res = pUsuario.usu_endereco_res;
                this.objUsuario.usu_endereco_com = pUsuario.usu_endereco_com;
                this.objUsuario.usu_bairro = pUsuario.usu_bairro;
                this.objUsuario.usu_cep = pUsuario.usu_cep;
                this.objUsuario.usu_cidade = pUsuario.usu_cidade;
                this.objUsuario.usu_uf = pUsuario.usu_uf;
                this.objUsuario.usu_tel_fixo = pUsuario.usu_tel_fixo;
                this.objUsuario.usu_tel_cel = pUsuario.usu_tel_cel;
                this.objUsuario.usu_banco = pUsuario.usu_banco;
                this.objUsuario.usu_agencia = pUsuario.usu_agencia;
                this.objUsuario.usu_conta = pUsuario.usu_conta;
                this.objUsuario.usu_operacao = pUsuario.usu_operacao;
                this.objUsuario.usu_tipo_conta = pUsuario.usu_tipo_conta;
                try
                {
                    flagReturn = this.objUsuario.Atualiza();
                }
                catch (Exception e)
                {
                    // Tratar mensagens de erro aqui!
                    throw e;
                }
            }
            return flagReturn;
        }

        public static Boolean Exclui(string pCod)
        {
            Boolean flagReturn = false;

            //verifica se este objeto a excluir possui dependencias com outros objetos
            if (Proposta.RecuperaPropostaUsuario(Usuario.RecuperaUsuario(pCod)).Count > 0 || Comissao.RecuperaComissaoUsuario(Usuario.RecuperaUsuario(pCod)).Count > 0)
                return flagReturn;
            else

            try
            {
                flagReturn = Usuario.Deleta(pCod);
            }
            catch (Exception e)
            {
                // Tratar mensagens de erro aqui!
                throw e;
            }
            return flagReturn;
        }

        public DS_Site.UsuarioRow SelecionaUsuario(string pCod)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();
            DS_Site.UsuarioRow linhaUsuario = dtUsuario.NewUsuarioRow();

            try
            {
                this.objUsuario = Usuario.RecuperaUsuario(pCod);
                linhaUsuario.usu_cod = pCod;
                linhaUsuario.usu_nome = this.objUsuario.usu_nome;
                linhaUsuario.usu_senha = this.objUsuario.usu_senha;
                linhaUsuario.usu_email = this.objUsuario.usu_email;
                linhaUsuario.usu_loja = this.objUsuario.usu_loja.loj_cod;
                linhaUsuario.usu_ativo = this.objUsuario.usu_ativo;
                linhaUsuario.usu_funcao = this.objUsuario.usu_funcao;
                linhaUsuario.usu_nome_completo = this.objUsuario.usu_nome_completo;
                linhaUsuario.usu_cpf = this.objUsuario.usu_cpf;
                linhaUsuario.usu_rg = this.objUsuario.usu_rg;
                linhaUsuario.usu_data_nascimento = string.Format("{0:d}", this.objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", this.objUsuario.usu_data_nascimento);
                linhaUsuario.usu_endereco_res = this.objUsuario.usu_endereco_res;
                linhaUsuario.usu_endereco_com = this.objUsuario.usu_endereco_com;
                linhaUsuario.usu_bairro = this.objUsuario.usu_bairro;
                linhaUsuario.usu_cep = this.objUsuario.usu_cep;
                linhaUsuario.usu_cidade = this.objUsuario.usu_cidade;
                linhaUsuario.usu_uf = this.objUsuario.usu_uf;
                linhaUsuario.usu_tel_fixo = this.objUsuario.usu_tel_fixo;
                linhaUsuario.usu_tel_cel = this.objUsuario.usu_tel_cel;
                linhaUsuario.usu_banco = this.objUsuario.usu_banco;
                linhaUsuario.usu_agencia = this.objUsuario.usu_agencia;
                linhaUsuario.usu_conta = this.objUsuario.usu_conta;
                linhaUsuario.usu_operacao = this.objUsuario.usu_operacao;
                linhaUsuario.usu_tipo_conta = this.objUsuario.usu_tipo_conta;
            }
            catch (Exception e)
            {
                // Tratar mensagens de erro aqui!
                throw e;
            }

            return linhaUsuario;
        }

        public static DS_Site.UsuarioDataTable SelecionaUsuarioLoja(string pLoja)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarioLoja(Loja.RecuperaLoja(pLoja));
                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    Usuario objUsuario = (Usuario)listUsuarios[i];
                    dtUsuario.AddUsuarioRow(
                    objUsuario.usu_cod,
                    objUsuario.usu_nome,
                    objUsuario.usu_senha,
                    objUsuario.usu_email,
                    objUsuario.usu_loja.loj_cod,
                    objUsuario.usu_ativo,
                    objUsuario.usu_funcao,
                    objUsuario.usu_nome_completo,
                    objUsuario.usu_cpf,
                    objUsuario.usu_rg,
                    string.Format("{0:d}", objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", objUsuario.usu_data_nascimento),
                    objUsuario.usu_endereco_res,
                    objUsuario.usu_endereco_com,
                    objUsuario.usu_bairro,
                    objUsuario.usu_cep,
                    objUsuario.usu_cidade,
                    objUsuario.usu_uf,
                    objUsuario.usu_tel_fixo,
                    objUsuario.usu_tel_cel,
                    objUsuario.usu_banco,
                    objUsuario.usu_agencia,
                    objUsuario.usu_conta,
                    objUsuario.usu_operacao,
                    objUsuario.usu_tipo_conta);
                }
            }
            catch (Exception e)
            {
                // Tratar mensagens de erro aqui!
                throw e;
            }

            return dtUsuario;
        }

        public static DS_Site.UsuarioDataTable SelecionaUsuarios()
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarios();
                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    Usuario objUsuario = (Usuario)listUsuarios[i];
                    dtUsuario.AddUsuarioRow(
                    objUsuario.usu_cod,
                    objUsuario.usu_nome,
                    objUsuario.usu_senha,
                    objUsuario.usu_email,
                    objUsuario.usu_loja.loj_cod,
                    objUsuario.usu_ativo,
                    objUsuario.usu_funcao,
                    objUsuario.usu_nome_completo,
                    objUsuario.usu_cpf,
                    objUsuario.usu_rg,
                    string.Format("{0:d}", objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", objUsuario.usu_data_nascimento),
                    objUsuario.usu_endereco_res,
                    objUsuario.usu_endereco_com,
                    objUsuario.usu_bairro,
                    objUsuario.usu_cep,
                    objUsuario.usu_cidade,
                    objUsuario.usu_uf,
                    objUsuario.usu_tel_fixo,
                    objUsuario.usu_tel_cel,
                    objUsuario.usu_banco,
                    objUsuario.usu_agencia,
                    objUsuario.usu_conta,
                    objUsuario.usu_operacao,
                    objUsuario.usu_tipo_conta); 
                }
            }
            catch (Exception e)
            {
                // Tratar mensagens de erro aqui!
                throw e;
            }

            return dtUsuario;
        }

        public static DS_Site.UsuarioDataTable SelecionaUsuariosPorFuncao(string pFuncao)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuariosPorFuncao(pFuncao);
                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    Usuario objUsuario = (Usuario)listUsuarios[i];
                    dtUsuario.AddUsuarioRow(
                    objUsuario.usu_cod,
                    objUsuario.usu_nome,
                    objUsuario.usu_senha,
                    objUsuario.usu_email,
                    objUsuario.usu_loja.loj_cod,
                    objUsuario.usu_ativo,
                    objUsuario.usu_funcao,
                    objUsuario.usu_nome_completo,
                    objUsuario.usu_cpf,
                    objUsuario.usu_rg,
                    string.Format("{0:d}", objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", objUsuario.usu_data_nascimento),
                    objUsuario.usu_endereco_res,
                    objUsuario.usu_endereco_com,
                    objUsuario.usu_bairro,
                    objUsuario.usu_cep,
                    objUsuario.usu_cidade,
                    objUsuario.usu_uf,
                    objUsuario.usu_tel_fixo,
                    objUsuario.usu_tel_cel,
                    objUsuario.usu_banco,
                    objUsuario.usu_agencia,
                    objUsuario.usu_conta,
                    objUsuario.usu_operacao,
                    objUsuario.usu_tipo_conta);
                }
            }
            catch (Exception e)
            {
                // Tratar mensagens de erro aqui!
                throw e;
            }

            return dtUsuario;
        }

        public static DS_Site.UsuarioDataTable SelecionaUsuarioPorCPFeFuncao(string pCPF, string pFuncao)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarioPorCPFeFuncao(pCPF, pFuncao);
                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    Usuario objUsuario = (Usuario)listUsuarios[i];
                    dtUsuario.AddUsuarioRow(
                    objUsuario.usu_cod,
                    objUsuario.usu_nome,
                    objUsuario.usu_senha,
                    objUsuario.usu_email,
                    objUsuario.usu_loja.loj_cod,
                    objUsuario.usu_ativo,
                    objUsuario.usu_funcao,
                    objUsuario.usu_nome_completo,
                    objUsuario.usu_cpf,
                    objUsuario.usu_rg,
                    string.Format("{0:d}", objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", objUsuario.usu_data_nascimento),
                    objUsuario.usu_endereco_res,
                    objUsuario.usu_endereco_com,
                    objUsuario.usu_bairro,
                    objUsuario.usu_cep,
                    objUsuario.usu_cidade,
                    objUsuario.usu_uf,
                    objUsuario.usu_tel_fixo,
                    objUsuario.usu_tel_cel,
                    objUsuario.usu_banco,
                    objUsuario.usu_agencia,
                    objUsuario.usu_conta,
                    objUsuario.usu_operacao,
                    objUsuario.usu_tipo_conta);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtUsuario;
        }

        public static DS_Site.UsuarioDataTable SelecionaUsuarioPorNomeFuncao(string pNome, string pFuncao)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarioPorNomeFuncao(pNome, pFuncao);
                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    Usuario objUsuario = (Usuario)listUsuarios[i];
                    dtUsuario.AddUsuarioRow(
                    objUsuario.usu_cod,
                    objUsuario.usu_nome,
                    objUsuario.usu_senha,
                    objUsuario.usu_email,
                    objUsuario.usu_loja.loj_cod,
                    objUsuario.usu_ativo,
                    objUsuario.usu_funcao,
                    objUsuario.usu_nome_completo,
                    objUsuario.usu_cpf,
                    objUsuario.usu_rg,
                    string.Format("{0:d}", objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", objUsuario.usu_data_nascimento),
                    objUsuario.usu_endereco_res,
                    objUsuario.usu_endereco_com,
                    objUsuario.usu_bairro,
                    objUsuario.usu_cep,
                    objUsuario.usu_cidade,
                    objUsuario.usu_uf,
                    objUsuario.usu_tel_fixo,
                    objUsuario.usu_tel_cel,
                    objUsuario.usu_banco,
                    objUsuario.usu_agencia,
                    objUsuario.usu_conta,
                    objUsuario.usu_operacao,
                    objUsuario.usu_tipo_conta);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtUsuario;
        }

        public static DS_Site.UsuarioDataTable SelecionaOperadorOuCorretor(string pOperador, string pCorretor)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarioOperadorOuCorretor(pOperador, pCorretor);
                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    Usuario objUsuario = (Usuario)listUsuarios[i];
                    dtUsuario.AddUsuarioRow(
                    objUsuario.usu_cod,
                    objUsuario.usu_nome,
                    objUsuario.usu_senha,
                    objUsuario.usu_email,
                    objUsuario.usu_loja.loj_cod,
                    objUsuario.usu_ativo,
                    objUsuario.usu_funcao,
                    objUsuario.usu_nome_completo,
                    objUsuario.usu_cpf,
                    objUsuario.usu_rg,
                    string.Format("{0:d}", objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", objUsuario.usu_data_nascimento),
                    objUsuario.usu_endereco_res,
                    objUsuario.usu_endereco_com,
                    objUsuario.usu_bairro,
                    objUsuario.usu_cep,
                    objUsuario.usu_cidade,
                    objUsuario.usu_uf,
                    objUsuario.usu_tel_fixo,
                    objUsuario.usu_tel_cel,
                    objUsuario.usu_banco,
                    objUsuario.usu_agencia,
                    objUsuario.usu_conta,
                    objUsuario.usu_operacao,
                    objUsuario.usu_tipo_conta);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtUsuario;
        }

        public static DS_Site.UsuarioDataTable SelecionaUsuariosProposta()
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuariosProposta();
                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    Usuario objUsuario = (Usuario)listUsuarios[i];
                    dtUsuario.AddUsuarioRow(
                    objUsuario.usu_cod,
                    objUsuario.usu_nome,
                    objUsuario.usu_senha,
                    objUsuario.usu_email,
                    objUsuario.usu_loja.loj_cod,
                    objUsuario.usu_ativo,
                    objUsuario.usu_funcao,
                    objUsuario.usu_nome_completo,
                    objUsuario.usu_cpf,
                    objUsuario.usu_rg,
                    string.Format("{0:d}", objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", objUsuario.usu_data_nascimento),
                    objUsuario.usu_endereco_res,
                    objUsuario.usu_endereco_com,
                    objUsuario.usu_bairro,
                    objUsuario.usu_cep,
                    objUsuario.usu_cidade,
                    objUsuario.usu_uf,
                    objUsuario.usu_tel_fixo,
                    objUsuario.usu_tel_cel,
                    objUsuario.usu_banco,
                    objUsuario.usu_agencia,
                    objUsuario.usu_conta,
                    objUsuario.usu_operacao,
                    objUsuario.usu_tipo_conta);
                }
            }
            catch (Exception e)
            {
                // Tratar mensagens de erro aqui!
                throw e;
            }

            return dtUsuario;
        }

        public DS_Site.UsuarioRow SelecionaUsuarioNome(string pNome)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();
            DS_Site.UsuarioRow rowUsuario = dtUsuario.NewUsuarioRow();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarioNome(pNome);

                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    this.objUsuario = (Usuario)listUsuarios[i];

                    rowUsuario.usu_cod = this.objUsuario.usu_cod;
                    rowUsuario.usu_nome = this.objUsuario.usu_nome;
                    rowUsuario.usu_senha = this.objUsuario.usu_senha;
                    rowUsuario.usu_email = this.objUsuario.usu_email;
                    rowUsuario.usu_loja = this.objUsuario.usu_loja.loj_cod;
                    rowUsuario.usu_ativo = this.objUsuario.usu_ativo;
                    rowUsuario.usu_funcao = this.objUsuario.usu_funcao;
                    rowUsuario.usu_nome_completo = this.objUsuario.usu_nome_completo;
                    rowUsuario.usu_cpf = this.objUsuario.usu_cpf;
                    rowUsuario.usu_rg = this.objUsuario.usu_rg;
                    rowUsuario.usu_data_nascimento = rowUsuario.usu_data_nascimento = string.Format("{0:d}", this.objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", this.objUsuario.usu_data_nascimento);
                    rowUsuario.usu_endereco_res = this.objUsuario.usu_endereco_res;
                    rowUsuario.usu_endereco_com = this.objUsuario.usu_endereco_com;
                    rowUsuario.usu_bairro = this.objUsuario.usu_bairro;
                    rowUsuario.usu_cep = this.objUsuario.usu_cep;
                    rowUsuario.usu_cidade = this.objUsuario.usu_cidade;
                    rowUsuario.usu_uf = this.objUsuario.usu_uf;
                    rowUsuario.usu_tel_fixo = this.objUsuario.usu_tel_fixo;
                    rowUsuario.usu_tel_cel = this.objUsuario.usu_tel_cel;
                    rowUsuario.usu_banco = this.objUsuario.usu_banco;
                    rowUsuario.usu_agencia = this.objUsuario.usu_agencia;
                    rowUsuario.usu_conta = this.objUsuario.usu_conta;
                    rowUsuario.usu_operacao = this.objUsuario.usu_operacao;
                    rowUsuario.usu_tipo_conta = this.objUsuario.usu_tipo_conta;
                }
            }

            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui!
                throw e;
            }

            return rowUsuario;
        }

        public DS_Site.UsuarioRow SelecionaUsuarioEmail(string pEmail)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();
            DS_Site.UsuarioRow rowUsuario = dtUsuario.NewUsuarioRow();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarioEmail(pEmail);

                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    this.objUsuario = (Usuario)listUsuarios[i];

                    rowUsuario.usu_cod = this.objUsuario.usu_cod;
                    rowUsuario.usu_nome = this.objUsuario.usu_nome;
                    rowUsuario.usu_senha = this.objUsuario.usu_senha;
                    rowUsuario.usu_email = this.objUsuario.usu_email;
                    rowUsuario.usu_loja = this.objUsuario.usu_loja.loj_cod;
                    rowUsuario.usu_ativo = this.objUsuario.usu_ativo;
                    rowUsuario.usu_funcao = this.objUsuario.usu_funcao;
                    rowUsuario.usu_nome_completo = this.objUsuario.usu_nome_completo;
                    rowUsuario.usu_cpf = this.objUsuario.usu_cpf;
                    rowUsuario.usu_rg = this.objUsuario.usu_rg;
                    rowUsuario.usu_data_nascimento = rowUsuario.usu_data_nascimento = string.Format("{0:d}", this.objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", this.objUsuario.usu_data_nascimento);
                    rowUsuario.usu_endereco_res = this.objUsuario.usu_endereco_res;
                    rowUsuario.usu_endereco_com = this.objUsuario.usu_endereco_com;
                    rowUsuario.usu_bairro = this.objUsuario.usu_bairro;
                    rowUsuario.usu_cep = this.objUsuario.usu_cep;
                    rowUsuario.usu_cidade = this.objUsuario.usu_cidade;
                    rowUsuario.usu_uf = this.objUsuario.usu_uf;
                    rowUsuario.usu_tel_fixo = this.objUsuario.usu_tel_fixo;
                    rowUsuario.usu_tel_cel = this.objUsuario.usu_tel_cel;
                    rowUsuario.usu_banco = this.objUsuario.usu_banco;
                    rowUsuario.usu_agencia = this.objUsuario.usu_agencia;
                    rowUsuario.usu_conta = this.objUsuario.usu_conta;
                    rowUsuario.usu_operacao = this.objUsuario.usu_operacao;
                    rowUsuario.usu_tipo_conta = this.objUsuario.usu_tipo_conta;
                }
            }

            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui!
                throw e;
            }

            return rowUsuario;
        }

        public DS_Site.UsuarioRow SelecionaUsuarioCpf(string pCpf)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();
            DS_Site.UsuarioRow rowUsuario = dtUsuario.NewUsuarioRow();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarioCpf(pCpf);

                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    this.objUsuario = (Usuario)listUsuarios[i];

                    rowUsuario.usu_cod = this.objUsuario.usu_cod;
                    rowUsuario.usu_nome = this.objUsuario.usu_nome;
                    rowUsuario.usu_senha = this.objUsuario.usu_senha;
                    rowUsuario.usu_email = this.objUsuario.usu_email;
                    rowUsuario.usu_loja = this.objUsuario.usu_loja.loj_cod;
                    rowUsuario.usu_ativo = this.objUsuario.usu_ativo;
                    rowUsuario.usu_funcao = this.objUsuario.usu_funcao;
                    rowUsuario.usu_nome_completo = this.objUsuario.usu_nome_completo;
                    rowUsuario.usu_cpf = this.objUsuario.usu_cpf;
                    rowUsuario.usu_rg = this.objUsuario.usu_rg;
                    rowUsuario.usu_data_nascimento = rowUsuario.usu_data_nascimento = string.Format("{0:d}", this.objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", this.objUsuario.usu_data_nascimento);
                    rowUsuario.usu_endereco_res = this.objUsuario.usu_endereco_res;
                    rowUsuario.usu_endereco_com = this.objUsuario.usu_endereco_com;
                    rowUsuario.usu_bairro = this.objUsuario.usu_bairro;
                    rowUsuario.usu_cep = this.objUsuario.usu_cep;
                    rowUsuario.usu_cidade = this.objUsuario.usu_cidade;
                    rowUsuario.usu_uf = this.objUsuario.usu_uf;
                    rowUsuario.usu_tel_fixo = this.objUsuario.usu_tel_fixo;
                    rowUsuario.usu_tel_cel = this.objUsuario.usu_tel_cel;
                    rowUsuario.usu_banco = this.objUsuario.usu_banco;
                    rowUsuario.usu_agencia = this.objUsuario.usu_agencia;
                    rowUsuario.usu_conta = this.objUsuario.usu_conta;
                    rowUsuario.usu_operacao = this.objUsuario.usu_operacao;
                    rowUsuario.usu_tipo_conta = this.objUsuario.usu_tipo_conta;
                }
            }

            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui!
                throw e;
            }

            return rowUsuario;
        }

        public DS_Site.UsuarioRow SelecionaUsuarioPorLoja(string pLoja)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();
            DS_Site.UsuarioRow rowUsuario = dtUsuario.NewUsuarioRow();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarioLoja(Loja.RecuperaLoja(pLoja));

                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    this.objUsuario = (Usuario)listUsuarios[i];

                    rowUsuario.usu_cod = this.objUsuario.usu_cod;
                    rowUsuario.usu_nome = this.objUsuario.usu_nome;
                    rowUsuario.usu_senha = this.objUsuario.usu_senha;
                    rowUsuario.usu_email = this.objUsuario.usu_email;
                    rowUsuario.usu_loja = this.objUsuario.usu_loja.loj_cod;
                    rowUsuario.usu_ativo = this.objUsuario.usu_ativo;
                    rowUsuario.usu_funcao = this.objUsuario.usu_funcao;
                    rowUsuario.usu_nome_completo = this.objUsuario.usu_nome_completo;
                    rowUsuario.usu_cpf = this.objUsuario.usu_cpf;
                    rowUsuario.usu_rg = this.objUsuario.usu_rg;
                    rowUsuario.usu_data_nascimento = string.Format("{0:d}", this.objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", this.objUsuario.usu_data_nascimento);
                    rowUsuario.usu_endereco_res = this.objUsuario.usu_endereco_res;
                    rowUsuario.usu_endereco_com = this.objUsuario.usu_endereco_com;
                    rowUsuario.usu_bairro = this.objUsuario.usu_bairro;
                    rowUsuario.usu_cep = this.objUsuario.usu_cep;
                    rowUsuario.usu_cidade = this.objUsuario.usu_cidade;
                    rowUsuario.usu_uf = this.objUsuario.usu_uf;
                    rowUsuario.usu_tel_fixo = this.objUsuario.usu_tel_fixo;
                    rowUsuario.usu_tel_cel = this.objUsuario.usu_tel_cel;
                    rowUsuario.usu_banco = this.objUsuario.usu_banco;
                    rowUsuario.usu_agencia = this.objUsuario.usu_agencia;
                    rowUsuario.usu_conta = this.objUsuario.usu_conta;
                    rowUsuario.usu_operacao = this.objUsuario.usu_operacao;
                    rowUsuario.usu_tipo_conta = this.objUsuario.usu_tipo_conta;
                }
            }

            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui!
                throw e;
            }

            return rowUsuario;
        }

        public DS_Site.UsuarioRow SelecionaUsuarioPorCodigo(string pCod)
        {
            DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();
            DS_Site.UsuarioRow rowUsuario = dtUsuario.NewUsuarioRow();

            try
            {
                IList listUsuarios = Usuario.RecuperaUsuarioPorCodigo(pCod);

                for (int i = 0; i < listUsuarios.Count; i++)
                {
                    this.objUsuario = (Usuario)listUsuarios[i];

                    rowUsuario.usu_cod = this.objUsuario.usu_cod;
                    rowUsuario.usu_nome = this.objUsuario.usu_nome;
                    rowUsuario.usu_senha = this.objUsuario.usu_senha;
                    rowUsuario.usu_email = this.objUsuario.usu_email;
                    rowUsuario.usu_loja = this.objUsuario.usu_loja.loj_cod;
                    rowUsuario.usu_ativo = this.objUsuario.usu_ativo;
                    rowUsuario.usu_funcao = this.objUsuario.usu_funcao;
                    rowUsuario.usu_nome_completo = this.objUsuario.usu_nome_completo;
                    rowUsuario.usu_cpf = this.objUsuario.usu_cpf;
                    rowUsuario.usu_rg = this.objUsuario.usu_rg;
                    rowUsuario.usu_data_nascimento = string.Format("{0:d}", this.objUsuario.usu_data_nascimento).Equals("1/1/0001") ? string.Empty : string.Format("{0:d}", this.objUsuario.usu_data_nascimento);
                    rowUsuario.usu_endereco_res = this.objUsuario.usu_endereco_res;
                    rowUsuario.usu_endereco_com = this.objUsuario.usu_endereco_com;
                    rowUsuario.usu_bairro = this.objUsuario.usu_bairro;
                    rowUsuario.usu_cep = this.objUsuario.usu_cep;
                    rowUsuario.usu_cidade = this.objUsuario.usu_cidade;
                    rowUsuario.usu_uf = this.objUsuario.usu_uf;
                    rowUsuario.usu_tel_fixo = this.objUsuario.usu_tel_fixo;
                    rowUsuario.usu_tel_cel = this.objUsuario.usu_tel_cel;
                    rowUsuario.usu_banco = this.objUsuario.usu_banco;
                    rowUsuario.usu_agencia = this.objUsuario.usu_agencia;
                    rowUsuario.usu_conta = this.objUsuario.usu_conta;
                    rowUsuario.usu_operacao = this.objUsuario.usu_operacao;
                    rowUsuario.usu_tipo_conta = this.objUsuario.usu_tipo_conta;
                }
            }

            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui!
                throw e;
            }

            return rowUsuario;
        }

    }
}
