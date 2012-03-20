using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrCliente
    {

        public cntrCliente()
        {

        }

        Cliente objCliente;

        public Boolean Salva(DS_Site.ClienteRow pCliente)
        {
            Boolean flagReturn = false;
            if (pCliente.cli_cod == null || pCliente.cli_cod == "")
            {
                this.objCliente = new Cliente();
                this.objCliente.cli_nome = pCliente.cli_nome;
                this.objCliente.cli_nasc = pCliente.cli_nasc;
                this.objCliente.cli_sexo = pCliente.cli_sexo;
                this.objCliente.cli_cpf = pCliente.cli_cpf;
                this.objCliente.cli_rg = pCliente.cli_rg;
                this.objCliente.cli_dt_emissao = pCliente.cli_dt_emissao;
                this.objCliente.cli_telefone = pCliente.cli_telefone;
                this.objCliente.cli_telefone2 = pCliente.cli_telefone2;
                this.objCliente.cli_mae = pCliente.cli_mae;
                this.objCliente.cli_pai = pCliente.cli_pai;
                this.objCliente.cli_naturalidade = pCliente.cli_naturalidade;
                this.objCliente.cli_natural_uf = pCliente.cli_natural_uf;
                this.objCliente.cli_endereco = pCliente.cli_endereco;
                this.objCliente.cli_bairro = pCliente.cli_bairro;
                this.objCliente.cli_referencia = pCliente.cli_referencia;
                this.objCliente.cli_cep = pCliente.cli_cep;
                this.objCliente.cli_cidade = pCliente.cli_cidade;
                this.objCliente.cli_uf = pCliente.cli_uf;
                this.objCliente.cli_renda = pCliente.cli_renda;
                this.objCliente.cli_data_cadastro = pCliente.cli_data_cadastro;
                this.objCliente.cli_email = pCliente.cli_email;
                this.objCliente.cli_senha = pCliente.cli_senha;
                this.objCliente.cli_nb1 = pCliente.cli_nb1;
                this.objCliente.cli_nb2 = pCliente.cli_nb2;

                try
                {
                    flagReturn = this.objCliente.Insere();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            else
            {
                this.objCliente = Cliente.RecuperaCliente(pCliente.cli_cod);
                this.objCliente.cli_cod = pCliente.cli_cod;
                this.objCliente.cli_nome = pCliente.cli_nome;
                this.objCliente.cli_nasc = pCliente.cli_nasc;
                this.objCliente.cli_sexo = pCliente.cli_sexo;
                this.objCliente.cli_cpf = pCliente.cli_cpf;
                this.objCliente.cli_rg = pCliente.cli_rg;
                this.objCliente.cli_dt_emissao = pCliente.cli_dt_emissao;
                this.objCliente.cli_telefone = pCliente.cli_telefone;
                this.objCliente.cli_telefone2 = pCliente.cli_telefone2;
                this.objCliente.cli_mae = pCliente.cli_mae;
                this.objCliente.cli_pai = pCliente.cli_pai;
                this.objCliente.cli_naturalidade = pCliente.cli_naturalidade;
                this.objCliente.cli_natural_uf = pCliente.cli_natural_uf;
                this.objCliente.cli_endereco = pCliente.cli_endereco;
                this.objCliente.cli_bairro = pCliente.cli_bairro;
                this.objCliente.cli_referencia = pCliente.cli_referencia;
                this.objCliente.cli_cep = pCliente.cli_cep;
                this.objCliente.cli_cidade = pCliente.cli_cidade;
                this.objCliente.cli_uf = pCliente.cli_uf;
                this.objCliente.cli_renda = pCliente.cli_renda;
                this.objCliente.cli_data_cadastro = pCliente.cli_data_cadastro;
                this.objCliente.cli_email = pCliente.cli_email;
                this.objCliente.cli_senha = pCliente.cli_senha;
                this.objCliente.cli_nb1 = pCliente.cli_nb1;
                this.objCliente.cli_nb2 = pCliente.cli_nb2;

                try
                {
                    flagReturn = this.objCliente.Atualiza();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            return flagReturn;
        }

        public static Boolean Exclui(string pCod)
        {
            Boolean flagReturn = false;

            //verifica se este objeto a excluir possui dependencias com outros objetos
            if (Proposta.RecuperaPropostaCliente(Cliente.RecuperaCliente(pCod)).Count > 0)
                return flagReturn;
            else

            try
            {
                flagReturn = Cliente.Deleta(pCod);
            }
            catch (Exception e)
            {
                // Tratar Mensagens de Erro aqui!!!
                throw e;
            }
            return flagReturn;
        }

        public DS_Site.ClienteRow SelecionaCliente(string pCod)
        {
            DS_Site.ClienteDataTable dtCliente = new DS_Site.ClienteDataTable();
            DS_Site.ClienteRow rowCliente = dtCliente.NewClienteRow();

            try
            {
                this.objCliente = Cliente.RecuperaCliente(pCod);
                rowCliente.cli_cod = this.objCliente.cli_cod;
                rowCliente.cli_nome = this.objCliente.cli_nome;
                rowCliente.cli_nasc = this.objCliente.cli_nasc;
                rowCliente.cli_sexo = this.objCliente.cli_sexo;
                rowCliente.cli_cpf = this.objCliente.cli_cpf;
                rowCliente.cli_rg = this.objCliente.cli_rg;
                rowCliente.cli_dt_emissao = this.objCliente.cli_dt_emissao;
                rowCliente.cli_telefone = this.objCliente.cli_telefone;
                rowCliente.cli_telefone2 = this.objCliente.cli_telefone2;
                rowCliente.cli_mae = this.objCliente.cli_mae;
                rowCliente.cli_pai = this.objCliente.cli_pai;
                rowCliente.cli_naturalidade = this.objCliente.cli_naturalidade;
                rowCliente.cli_natural_uf = this.objCliente.cli_natural_uf;
                rowCliente.cli_endereco = this.objCliente.cli_endereco;
                rowCliente.cli_bairro = this.objCliente.cli_bairro;
                rowCliente.cli_referencia = this.objCliente.cli_referencia;
                rowCliente.cli_cep = this.objCliente.cli_cep;
                rowCliente.cli_cidade = this.objCliente.cli_cidade;
                rowCliente.cli_uf = this.objCliente.cli_uf;
                rowCliente.cli_renda = this.objCliente.cli_renda;
                rowCliente.cli_data_cadastro = this.objCliente.cli_data_cadastro;
                rowCliente.cli_email = this.objCliente.cli_email;
                rowCliente.cli_senha = this.objCliente.cli_senha;
                rowCliente.cli_nb1 = this.objCliente.cli_nb1;
                rowCliente.cli_nb2 = this.objCliente.cli_nb2;
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return rowCliente;
        }

        public static DS_Site.ClienteDataTable SelecionaClientes()
        {
            DS_Site.ClienteDataTable dtCliente = new DS_Site.ClienteDataTable();

            try
            {
                IList listClientes = Cliente.RecuperaClientes();
                for (int i = 0; i < listClientes.Count; i++)
                {
                    Cliente objCliente = (Cliente)listClientes[i];
                    dtCliente.AddClienteRow(
                    objCliente.cli_cod,
                    objCliente.cli_nome,
                    objCliente.cli_nasc,
                    objCliente.cli_sexo,
                    objCliente.cli_cpf,
                    objCliente.cli_rg,
                    objCliente.cli_dt_emissao,
                    objCliente.cli_telefone,
                    objCliente.cli_telefone2,
                    objCliente.cli_mae,
                    objCliente.cli_pai,
                    objCliente.cli_naturalidade,
                    objCliente.cli_natural_uf,
                    objCliente.cli_endereco,
                    objCliente.cli_bairro,
                    objCliente.cli_referencia,
                    objCliente.cli_cep,
                    objCliente.cli_cidade,
                    objCliente.cli_uf,
                    objCliente.cli_renda,
                    objCliente.cli_data_cadastro,
                    objCliente.cli_email,
                    objCliente.cli_senha,
                    objCliente.cli_nb1,
                    objCliente.cli_nb2);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtCliente;
        }

        public DS_Site.ClienteRow SelecionaClienteCpf(string pCPF)
        {
            DS_Site.ClienteDataTable dtCliente = new DS_Site.ClienteDataTable();
            DS_Site.ClienteRow rowCliente = dtCliente.NewClienteRow();

            Cliente oCliente = new Cliente();
            try
            {
                IList listClientes = Cliente.RecuperaClienteCpf(pCPF);
                for (int i = 0; i < listClientes.Count; i++)
                {
                    oCliente = (Cliente)listClientes[i];
                    dtCliente.AddClienteRow(
                    oCliente.cli_cod,
                    oCliente.cli_nome,
                    oCliente.cli_nasc,
                    oCliente.cli_sexo,
                    oCliente.cli_cpf,
                    oCliente.cli_rg,
                    oCliente.cli_dt_emissao,
                    oCliente.cli_telefone,
                    oCliente.cli_telefone2,
                    oCliente.cli_mae,
                    oCliente.cli_pai,
                    oCliente.cli_naturalidade,
                    oCliente.cli_natural_uf,
                    oCliente.cli_endereco,
                    oCliente.cli_bairro,
                    oCliente.cli_referencia,
                    oCliente.cli_cep,
                    oCliente.cli_cidade,
                    oCliente.cli_uf,
                    oCliente.cli_renda,
                    oCliente.cli_data_cadastro,
                    oCliente.cli_email,
                    oCliente.cli_senha,
                    oCliente.cli_nb1,
                    oCliente.cli_nb2);
                }

                rowCliente.cli_cod = oCliente.cli_cod;
                rowCliente.cli_nome = oCliente.cli_nome;
                rowCliente.cli_nasc = oCliente.cli_nasc;
                rowCliente.cli_sexo = oCliente.cli_sexo;
                rowCliente.cli_cpf = oCliente.cli_cpf;
                rowCliente.cli_rg = oCliente.cli_rg;
                rowCliente.cli_dt_emissao = oCliente.cli_dt_emissao;
                rowCliente.cli_telefone = oCliente.cli_telefone;
                rowCliente.cli_telefone2 = oCliente.cli_telefone2;
                rowCliente.cli_mae = oCliente.cli_mae;
                rowCliente.cli_pai = oCliente.cli_pai;
                rowCliente.cli_naturalidade = oCliente.cli_naturalidade;
                rowCliente.cli_natural_uf = oCliente.cli_natural_uf;
                rowCliente.cli_endereco = oCliente.cli_endereco;
                rowCliente.cli_bairro = oCliente.cli_bairro;
                rowCliente.cli_referencia = oCliente.cli_referencia;
                rowCliente.cli_cep = oCliente.cli_cep;
                rowCliente.cli_cidade = oCliente.cli_cidade;
                rowCliente.cli_uf = oCliente.cli_uf;
                rowCliente.cli_renda = oCliente.cli_renda;
                rowCliente.cli_data_cadastro = oCliente.cli_data_cadastro;
                rowCliente.cli_email = oCliente.cli_email;
                rowCliente.cli_senha = oCliente.cli_senha;
                rowCliente.cli_nb1 = oCliente.cli_nb1;
                rowCliente.cli_nb2 = oCliente.cli_nb2;

            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return rowCliente;
        }

        public static DS_Site.ClienteDataTable SelecionaClientePorCpf(string pCPF)
        {
            DS_Site.ClienteDataTable dtCliente = new DS_Site.ClienteDataTable();

            try
            {
                IList listClientes = Cliente.RecuperaClienteCpf(pCPF);
                for (int i = 0; i < listClientes.Count; i++)
                {
                    Cliente objCliente = (Cliente)listClientes[i];
                    dtCliente.AddClienteRow(
                    objCliente.cli_cod,
                    objCliente.cli_nome,
                    objCliente.cli_nasc,
                    objCliente.cli_sexo,
                    objCliente.cli_cpf,
                    objCliente.cli_rg,
                    objCliente.cli_dt_emissao,
                    objCliente.cli_telefone,
                    objCliente.cli_telefone2,
                    objCliente.cli_mae,
                    objCliente.cli_pai,
                    objCliente.cli_naturalidade,
                    objCliente.cli_natural_uf,
                    objCliente.cli_endereco,
                    objCliente.cli_bairro,
                    objCliente.cli_referencia,
                    objCliente.cli_cep,
                    objCliente.cli_cidade,
                    objCliente.cli_uf,
                    objCliente.cli_renda,
                    objCliente.cli_data_cadastro,
                    objCliente.cli_email,
                    objCliente.cli_senha,
                    objCliente.cli_nb1,
                    objCliente.cli_nb2);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtCliente;
        }

        public static DS_Site.ClienteDataTable SelecionaClientePorNome(string pNome)
        {
            DS_Site.ClienteDataTable dtCliente = new DS_Site.ClienteDataTable();

            try
            {
                IList listClientes = Cliente.RecuperaClienteNome(pNome);
                for (int i = 0; i < listClientes.Count; i++)
                {
                    Cliente objCliente = (Cliente)listClientes[i];
                    dtCliente.AddClienteRow(
                    objCliente.cli_cod,
                    objCliente.cli_nome,
                    objCliente.cli_nasc,
                    objCliente.cli_sexo,
                    objCliente.cli_cpf,
                    objCliente.cli_rg,
                    objCliente.cli_dt_emissao,
                    objCliente.cli_telefone,
                    objCliente.cli_telefone2,
                    objCliente.cli_mae,
                    objCliente.cli_pai,
                    objCliente.cli_naturalidade,
                    objCliente.cli_natural_uf,
                    objCliente.cli_endereco,
                    objCliente.cli_bairro,
                    objCliente.cli_referencia,
                    objCliente.cli_cep,
                    objCliente.cli_cidade,
                    objCliente.cli_uf,
                    objCliente.cli_renda,
                    objCliente.cli_data_cadastro,
                    objCliente.cli_email,
                    objCliente.cli_senha,
                    objCliente.cli_nb1,
                    objCliente.cli_nb2);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtCliente;
        }

    }
}
