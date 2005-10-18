using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrProposta
    {
        public cntrProposta()
        {

        }

        Proposta objProposta;

        public Boolean Salva(DS_Site.PropostaRow pProposta)
        {
            Boolean flagReturn = false;
            if (pProposta.pro_cod == null || pProposta.pro_cod == "")
            {
                this.objProposta = new Proposta();
                this.objProposta.pro_nb = pProposta.pro_nb;
                this.objProposta.pro_nit = pProposta.pro_nit;
                this.objProposta.pro_especie = pProposta.pro_especie;
                this.objProposta.pro_forma_receb_benef = pProposta.pro_forma_receb_benef;
                this.objProposta.pro_banco = pProposta.pro_banco;
                this.objProposta.pro_agencia = pProposta.pro_agencia;
                this.objProposta.pro_operacao = pProposta.pro_operacao;
                this.objProposta.pro_conta = pProposta.pro_conta;
                this.objProposta.pro_solicitado = pProposta.pro_solicitado;
                this.objProposta.pro_plano = pProposta.pro_plano;
                this.objProposta.pro_prestacao = pProposta.pro_prestacao;
                this.objProposta.pro_liber_emprestimo = pProposta.pro_liber_emprestimo;
                this.objProposta.pro_banco_emprestimo = pProposta.pro_banco_emprestimo;
                this.objProposta.pro_cidade_emprestimo = pProposta.pro_cidade_emprestimo;
                this.objProposta.pro_agencia_emprestimo = pProposta.pro_agencia_emprestimo;
                this.objProposta.pro_operacao_emprestimo = pProposta.pro_operacao_emprestimo;
                this.objProposta.pro_conta_emprestimo = pProposta.pro_conta_emprestimo;
                this.objProposta.pro_usuario = Usuario.RecuperaUsuario(pProposta.pro_usuario);
                this.objProposta.pro_observacoes = pProposta.pro_observacoes;
                this.objProposta.pro_doc1 = pProposta.pro_doc1;
                this.objProposta.pro_doc2 = pProposta.pro_doc2;
                this.objProposta.pro_doc3 = pProposta.pro_doc3;
                this.objProposta.pro_doc4 = pProposta.pro_doc4;
                this.objProposta.pro_doc5 = pProposta.pro_doc5;
                this.objProposta.pro_status = pProposta.pro_status;
                this.objProposta.pro_cliente = Cliente.RecuperaCliente(pProposta.pro_cliente);
                this.objProposta.pro_bancos = Banco.RecuperaBanco(pProposta.pro_bancos);
                this.objProposta.pro_tipo = pProposta.pro_tipo;
                this.objProposta.pro_data = pProposta.pro_data;

                try
                {
                    flagReturn = this.objProposta.Insere();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            else
            {
                this.objProposta = Proposta.RecuperaProposta(pProposta.pro_cod);
                this.objProposta.pro_nb = pProposta.pro_nb;
                this.objProposta.pro_nit = pProposta.pro_nit;
                this.objProposta.pro_especie = pProposta.pro_especie;
                this.objProposta.pro_forma_receb_benef = pProposta.pro_forma_receb_benef;
                this.objProposta.pro_banco = pProposta.pro_banco;
                this.objProposta.pro_agencia = pProposta.pro_agencia;
                this.objProposta.pro_operacao = pProposta.pro_operacao;
                this.objProposta.pro_conta = pProposta.pro_conta;
                this.objProposta.pro_solicitado = pProposta.pro_solicitado;
                this.objProposta.pro_plano = pProposta.pro_plano;
                this.objProposta.pro_prestacao = pProposta.pro_prestacao;
                this.objProposta.pro_liber_emprestimo = pProposta.pro_liber_emprestimo;
                this.objProposta.pro_banco_emprestimo = pProposta.pro_banco_emprestimo;
                this.objProposta.pro_cidade_emprestimo = pProposta.pro_cidade_emprestimo;
                this.objProposta.pro_agencia_emprestimo = pProposta.pro_agencia_emprestimo;
                this.objProposta.pro_operacao_emprestimo = pProposta.pro_operacao_emprestimo;
                this.objProposta.pro_conta_emprestimo = pProposta.pro_conta_emprestimo;
                this.objProposta.pro_usuario = Usuario.RecuperaUsuario(pProposta.pro_usuario);
                this.objProposta.pro_observacoes = pProposta.pro_observacoes;
                this.objProposta.pro_doc1 = pProposta.pro_doc1;
                this.objProposta.pro_doc2 = pProposta.pro_doc2;
                this.objProposta.pro_doc3 = pProposta.pro_doc3;
                this.objProposta.pro_doc4 = pProposta.pro_doc4;
                this.objProposta.pro_doc5 = pProposta.pro_doc5;
                this.objProposta.pro_status = pProposta.pro_status;
                this.objProposta.pro_cliente = Cliente.RecuperaCliente(pProposta.pro_cliente);
                this.objProposta.pro_bancos = Banco.RecuperaBanco(pProposta.pro_bancos);
                this.objProposta.pro_tipo = pProposta.pro_tipo;
                this.objProposta.pro_data = pProposta.pro_data;

                try
                {
                    flagReturn = this.objProposta.Atualiza();
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
            if (Contrato.RecuperaContratoProposta(Proposta.RecuperaProposta(pCod)).Count > 0)
                return flagReturn;
            else

            try
            {
                flagReturn = Proposta.Deleta(pCod);
            }
            catch (Exception e)
            {
                // Tratar Mensagens de Erro aqui!!!
                throw e;
            }
            return flagReturn;
        }

        public DS_Site.PropostaRow SelecionaProposta(string pCod)
        {
            DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();
            DS_Site.PropostaRow rowProposta = dtProposta.NewPropostaRow();

            try
            {
                this.objProposta = Proposta.RecuperaProposta(pCod);
                rowProposta.pro_cod = this.objProposta.pro_cod;
                rowProposta.pro_nb = this.objProposta.pro_nb;
                rowProposta.pro_nit = this.objProposta.pro_nit;
                rowProposta.pro_especie = this.objProposta.pro_especie;
                rowProposta.pro_forma_receb_benef = this.objProposta.pro_forma_receb_benef;
                rowProposta.pro_banco = this.objProposta.pro_banco;
                rowProposta.pro_agencia = this.objProposta.pro_agencia;
                rowProposta.pro_operacao = this.objProposta.pro_operacao;
                rowProposta.pro_conta = this.objProposta.pro_conta;
                rowProposta.pro_solicitado = this.objProposta.pro_solicitado;
                rowProposta.pro_plano = this.objProposta.pro_plano;
                rowProposta.pro_prestacao = this.objProposta.pro_prestacao;
                rowProposta.pro_liber_emprestimo = this.objProposta.pro_liber_emprestimo;
                rowProposta.pro_banco_emprestimo = this.objProposta.pro_banco_emprestimo;
                rowProposta.pro_cidade_emprestimo = this.objProposta.pro_cidade_emprestimo;
                rowProposta.pro_agencia_emprestimo = this.objProposta.pro_agencia_emprestimo;
                rowProposta.pro_operacao_emprestimo = this.objProposta.pro_operacao_emprestimo;
                rowProposta.pro_conta_emprestimo = this.objProposta.pro_conta_emprestimo;
                rowProposta.pro_usuario = this.objProposta.pro_usuario.usu_cod;
                rowProposta.pro_observacoes = this.objProposta.pro_observacoes;
                rowProposta.pro_doc1 = this.objProposta.pro_doc1;
                rowProposta.pro_doc2 = this.objProposta.pro_doc2;
                rowProposta.pro_doc3 = this.objProposta.pro_doc3;
                rowProposta.pro_doc4 = this.objProposta.pro_doc4;
                rowProposta.pro_doc5 = this.objProposta.pro_doc5;
                rowProposta.pro_status = this.objProposta.pro_status;
                rowProposta.pro_cliente = this.objProposta.pro_cliente.cli_cod;
                rowProposta.pro_bancos = this.objProposta.pro_bancos.ban_cod;
                rowProposta.pro_tipo = this.objProposta.pro_tipo;
                rowProposta.pro_data = this.objProposta.pro_data;

            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return rowProposta;
        }

        public static DS_Site.PropostaDataTable SelecionaPropostas()
        {
            DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();

            try
            {
                IList listPropostas = Proposta.RecuperaPropostas();
                for (int i = 0; i < listPropostas.Count; i++)
                {
                    Proposta objProposta = (Proposta)listPropostas[i];
                    dtProposta.AddPropostaRow(
                    objProposta.pro_cod,
                    objProposta.pro_nb,
                    objProposta.pro_nit,
                    objProposta.pro_especie,
                    objProposta.pro_forma_receb_benef,
                    objProposta.pro_banco,
                    objProposta.pro_agencia,
                    objProposta.pro_operacao,
                    objProposta.pro_conta,
                    objProposta.pro_solicitado,
                    objProposta.pro_plano,
                    objProposta.pro_prestacao,
                    objProposta.pro_liber_emprestimo,
                    objProposta.pro_banco_emprestimo,
                    objProposta.pro_cidade_emprestimo,
                    objProposta.pro_agencia_emprestimo,
                    objProposta.pro_operacao_emprestimo,
                    objProposta.pro_conta_emprestimo,
                    objProposta.pro_usuario.usu_cod,
                    objProposta.pro_observacoes,
                    objProposta.pro_doc1,
                    objProposta.pro_doc2,
                    objProposta.pro_doc3,
                    objProposta.pro_doc4,
                    objProposta.pro_doc5,
                    objProposta.pro_status,
                    objProposta.pro_cliente.cli_cod,
                    objProposta.pro_bancos.ban_cod,
                    objProposta.pro_tipo,
                    objProposta.pro_data);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtProposta;
        }

        public static DS_Site.PropostaDataTable SelecionaPropostaCliente(string pCliente)
        {
            DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();

            try
            {
                IList listPropostas = Proposta.RecuperaPropostaCliente(Cliente.RecuperaCliente(pCliente));
                for (int i = 0; i < listPropostas.Count; i++)
                {
                    Proposta objProposta = (Proposta)listPropostas[i];
                    dtProposta.AddPropostaRow(
                    objProposta.pro_cod,
                    objProposta.pro_nb,
                    objProposta.pro_nit,
                    objProposta.pro_especie,
                    objProposta.pro_forma_receb_benef,
                    objProposta.pro_banco,
                    objProposta.pro_agencia,
                    objProposta.pro_operacao,
                    objProposta.pro_conta,
                    objProposta.pro_solicitado,
                    objProposta.pro_plano,
                    objProposta.pro_prestacao,
                    objProposta.pro_liber_emprestimo,
                    objProposta.pro_banco_emprestimo,
                    objProposta.pro_cidade_emprestimo,
                    objProposta.pro_agencia_emprestimo,
                    objProposta.pro_operacao_emprestimo,
                    objProposta.pro_conta_emprestimo,
                    objProposta.pro_usuario.usu_cod,
                    objProposta.pro_observacoes,
                    objProposta.pro_doc1,
                    objProposta.pro_doc2,
                    objProposta.pro_doc3,
                    objProposta.pro_doc4,
                    objProposta.pro_doc5,
                    objProposta.pro_status,
                    objProposta.pro_cliente.cli_cod,
                    objProposta.pro_bancos.ban_cod,
                    objProposta.pro_tipo,
                    objProposta.pro_data);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtProposta;
        }

        public static DS_Site.PropostaDataTable SelecionaPropostaStatus(string pStatus)
        {
            DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();

            try
            {
                IList listPropostas = Proposta.RecuperaPropostaStatus(pStatus);
                for (int i = 0; i < listPropostas.Count; i++)
                {
                    Proposta objProposta = (Proposta)listPropostas[i];
                    dtProposta.AddPropostaRow(
                    objProposta.pro_cod,
                    objProposta.pro_nb,
                    objProposta.pro_nit,
                    objProposta.pro_especie,
                    objProposta.pro_forma_receb_benef,
                    objProposta.pro_banco,
                    objProposta.pro_agencia,
                    objProposta.pro_operacao,
                    objProposta.pro_conta,
                    objProposta.pro_solicitado,
                    objProposta.pro_plano,
                    objProposta.pro_prestacao,
                    objProposta.pro_liber_emprestimo,
                    objProposta.pro_banco_emprestimo,
                    objProposta.pro_cidade_emprestimo,
                    objProposta.pro_agencia_emprestimo,
                    objProposta.pro_operacao_emprestimo,
                    objProposta.pro_conta_emprestimo,
                    objProposta.pro_usuario.usu_cod,
                    objProposta.pro_observacoes,
                    objProposta.pro_doc1,
                    objProposta.pro_doc2,
                    objProposta.pro_doc3,
                    objProposta.pro_doc4,
                    objProposta.pro_doc5,
                    objProposta.pro_status,
                    objProposta.pro_cliente.cli_cod,
                    objProposta.pro_bancos.ban_cod,
                    objProposta.pro_tipo,
                    objProposta.pro_data);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtProposta;
        }

        public static DS_Site.PropostaDataTable SelecionaPropostaUsuario(string pUsuario)
        {
            DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();

            try
            {
                IList listPropostas = Proposta.RecuperaPropostaUsuario(Usuario.RecuperaUsuario(pUsuario));
                for (int i = 0; i < listPropostas.Count; i++)
                {
                    Proposta objProposta = (Proposta)listPropostas[i];
                    dtProposta.AddPropostaRow(
                    objProposta.pro_cod,
                    objProposta.pro_nb,
                    objProposta.pro_nit,
                    objProposta.pro_especie,
                    objProposta.pro_forma_receb_benef,
                    objProposta.pro_banco,
                    objProposta.pro_agencia,
                    objProposta.pro_operacao,
                    objProposta.pro_conta,
                    objProposta.pro_solicitado,
                    objProposta.pro_plano,
                    objProposta.pro_prestacao,
                    objProposta.pro_liber_emprestimo,
                    objProposta.pro_banco_emprestimo,
                    objProposta.pro_cidade_emprestimo,
                    objProposta.pro_agencia_emprestimo,
                    objProposta.pro_operacao_emprestimo,
                    objProposta.pro_conta_emprestimo,
                    objProposta.pro_usuario.usu_cod,
                    objProposta.pro_observacoes,
                    objProposta.pro_doc1,
                    objProposta.pro_doc2,
                    objProposta.pro_doc3,
                    objProposta.pro_doc4,
                    objProposta.pro_doc5,
                    objProposta.pro_status,
                    objProposta.pro_cliente.cli_cod,
                    objProposta.pro_bancos.ban_cod,
                    objProposta.pro_tipo,
                    objProposta.pro_data);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtProposta;
        }

        public static DS_Site.PropostaDataTable SelecionaPropostaLoja(string pLoja)
        {
            DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();

            try
            {
                IList listPropostas = Proposta.RecuperaPropostaLoja(Loja.RecuperaLoja(pLoja));
                for (int i = 0; i < listPropostas.Count; i++)
                {
                    Proposta objProposta = (Proposta)listPropostas[i];
                    dtProposta.AddPropostaRow(
                    objProposta.pro_cod,
                    objProposta.pro_nb,
                    objProposta.pro_nit,
                    objProposta.pro_especie,
                    objProposta.pro_forma_receb_benef,
                    objProposta.pro_banco,
                    objProposta.pro_agencia,
                    objProposta.pro_operacao,
                    objProposta.pro_conta,
                    objProposta.pro_solicitado,
                    objProposta.pro_plano,
                    objProposta.pro_prestacao,
                    objProposta.pro_liber_emprestimo,
                    objProposta.pro_banco_emprestimo,
                    objProposta.pro_cidade_emprestimo,
                    objProposta.pro_agencia_emprestimo,
                    objProposta.pro_operacao_emprestimo,
                    objProposta.pro_conta_emprestimo,
                    objProposta.pro_usuario.usu_cod,
                    objProposta.pro_observacoes,
                    objProposta.pro_doc1,
                    objProposta.pro_doc2,
                    objProposta.pro_doc3,
                    objProposta.pro_doc4,
                    objProposta.pro_doc5,
                    objProposta.pro_status,
                    objProposta.pro_cliente.cli_cod,
                    objProposta.pro_bancos.ban_cod,
                    objProposta.pro_tipo,
                    objProposta.pro_data);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtProposta;
        }

        public static DS_Site.PropostaDataTable SelecionaPropostaUsuarioStatus(string pUsuario, string pStatus)
        {
            DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();

            try
            {
                IList listPropostas = Proposta.RecuperaPropostaUsuarioStatus(Usuario.RecuperaUsuario(pUsuario), pStatus);
                for (int i = 0; i < listPropostas.Count; i++)
                {
                    Proposta objProposta = (Proposta)listPropostas[i];
                    dtProposta.AddPropostaRow(
                    objProposta.pro_cod,
                    objProposta.pro_nb,
                    objProposta.pro_nit,
                    objProposta.pro_especie,
                    objProposta.pro_forma_receb_benef,
                    objProposta.pro_banco,
                    objProposta.pro_agencia,
                    objProposta.pro_operacao,
                    objProposta.pro_conta,
                    objProposta.pro_solicitado,
                    objProposta.pro_plano,
                    objProposta.pro_prestacao,
                    objProposta.pro_liber_emprestimo,
                    objProposta.pro_banco_emprestimo,
                    objProposta.pro_cidade_emprestimo,
                    objProposta.pro_agencia_emprestimo,
                    objProposta.pro_operacao_emprestimo,
                    objProposta.pro_conta_emprestimo,
                    objProposta.pro_usuario.usu_cod,
                    objProposta.pro_observacoes,
                    objProposta.pro_doc1,
                    objProposta.pro_doc2,
                    objProposta.pro_doc3,
                    objProposta.pro_doc4,
                    objProposta.pro_doc5,
                    objProposta.pro_status,
                    objProposta.pro_cliente.cli_cod,
                    objProposta.pro_bancos.ban_cod,
                    objProposta.pro_tipo,
                    objProposta.pro_data);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtProposta;
        }
    }
}
