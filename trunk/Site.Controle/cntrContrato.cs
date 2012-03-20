using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrContrato
    {
        public cntrContrato()
        {

        }

        Contrato objContrato;

        public Boolean Salva(DS_Site.ContratoRow pContrato)
        {
            Boolean flagReturn = false;
            if (pContrato.con_cod == null || pContrato.con_cod == "")
            {
                this.objContrato = new Contrato();
                this.objContrato.con_numero = pContrato.con_numero;
                this.objContrato.con_data_liberacao = pContrato.con_data_liberacao;
                this.objContrato.con_taxa = pContrato.con_taxa;
                this.objContrato.con_valor = pContrato.con_valor;
                this.objContrato.con_tipo = pContrato.con_tipo;
                this.objContrato.con_proposta = Proposta.RecuperaProposta(pContrato.con_proposta);
                this.objContrato.con_comissao = Comissao.RecuperaComissao(pContrato.con_comissao);
               
                try
                {
                    flagReturn = this.objContrato.Insere();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            else
            {
                this.objContrato = Contrato.RecuperaContrato(pContrato.con_cod);
                this.objContrato.con_cod = pContrato.con_cod;
                this.objContrato.con_numero = pContrato.con_numero;
                this.objContrato.con_data_liberacao = pContrato.con_data_liberacao;
                this.objContrato.con_taxa = pContrato.con_taxa;
                this.objContrato.con_valor = pContrato.con_valor;
                this.objContrato.con_tipo = pContrato.con_tipo;
                this.objContrato.con_proposta = Proposta.RecuperaProposta(pContrato.con_proposta);
                this.objContrato.con_comissao = Comissao.RecuperaComissao(pContrato.con_comissao);

                try
                {
                    flagReturn = this.objContrato.Atualiza();
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
            try
            {
                flagReturn = Contrato.Deleta(pCod);
            }
            catch (Exception e)
            {
                // Tratar Mensagens de Erro aqui!!!
                throw e;
            }
            return flagReturn;
        }

        public DS_Site.ContratoRow SelecionaContrato(string pCod)
        {
            DS_Site.ContratoDataTable dtContrato = new DS_Site.ContratoDataTable();
            DS_Site.ContratoRow rowContrato = dtContrato.NewContratoRow();

            try
            {
                this.objContrato = Contrato.RecuperaContrato(pCod);
                rowContrato.con_cod = this.objContrato.con_cod;
                rowContrato.con_numero = this.objContrato.con_numero;
                rowContrato.con_data_liberacao = this.objContrato.con_data_liberacao;
                rowContrato.con_taxa = this.objContrato.con_taxa;
                rowContrato.con_valor = this.objContrato.con_valor;
                rowContrato.con_tipo = this.objContrato.con_tipo;
                rowContrato.con_proposta = this.objContrato.con_proposta.pro_cod;
                rowContrato.con_comissao = this.objContrato.con_comissao.com_cod;

            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return rowContrato;
        }

        public DS_Site.ContratoRow SelecionaContratoPorComissao(string pComissao)
        {
            DS_Site.ContratoDataTable dtContrato = new DS_Site.ContratoDataTable();
            DS_Site.ContratoRow rowContrato = dtContrato.NewContratoRow();

            Contrato oContrato = new Contrato();
            try
            {
                IList listContratos = Contrato.RecuperaContratoComissao(Comissao.RecuperaComissao(pComissao));
                for (int i = 0; i < listContratos.Count; i++)
                {
                    oContrato = (Contrato)listContratos[i];
                    dtContrato.AddContratoRow(
                    oContrato.con_cod,
                    oContrato.con_numero,
                    oContrato.con_data_liberacao,
                    oContrato.con_taxa,
                    oContrato.con_valor,
                    oContrato.con_tipo,
                    oContrato.con_proposta.pro_cod,
                    oContrato.con_comissao.com_cod);
                }

                rowContrato.con_cod = oContrato.con_cod;
                rowContrato.con_numero = oContrato.con_numero;
                rowContrato.con_data_liberacao = oContrato.con_data_liberacao;
                rowContrato.con_taxa = oContrato.con_taxa;
                rowContrato.con_valor = oContrato.con_valor;
                rowContrato.con_tipo = oContrato.con_tipo;
                rowContrato.con_proposta = oContrato.con_proposta.pro_cod;
                rowContrato.con_comissao = oContrato.con_comissao.com_cod;
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return rowContrato;
        }

        public static DS_Site.ContratoDataTable SelecionaContratoComissao(string pComissao)
        {
            DS_Site.ContratoDataTable dtContrato = new DS_Site.ContratoDataTable();

            try
            {
                IList listContratos = Contrato.RecuperaContratoComissao(Comissao.RecuperaComissao(pComissao));
                for (int i = 0; i < listContratos.Count; i++)
                {
                    Contrato objContrato = (Contrato)listContratos[i];
                    dtContrato.AddContratoRow(
                    objContrato.con_cod,
                    objContrato.con_numero,
                    objContrato.con_data_liberacao,
                    objContrato.con_taxa,
                    objContrato.con_valor,
                    objContrato.con_tipo,
                    objContrato.con_proposta.pro_cod,
                    objContrato.con_comissao.com_cod);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtContrato;
        }

    }
}
