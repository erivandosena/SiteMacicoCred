using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrComissao
    {
        public cntrComissao()
        {

        }

        Comissao objComissao;

        public string Salva(DS_Site.ComissaoRow pComissao)
        {

            if (pComissao.com_cod == null || pComissao.com_cod == "")
            {
                this.objComissao = new Comissao();
                this.objComissao.com_data_abertura = pComissao.com_data_abertura;
                this.objComissao.com_data_fechamento = pComissao.com_data_fechamento;
                this.objComissao.com_loja = Loja.RecuperaLoja(pComissao.com_loja);
                this.objComissao.com_usuario = Usuario.RecuperaUsuario(pComissao.com_usuario);
                this.objComissao.com_status = pComissao.com_status;
                
                try
                {
                    this.objComissao.Insere();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            else
            {
                this.objComissao = Comissao.RecuperaComissao(pComissao.com_cod);
                this.objComissao.com_cod = pComissao.com_cod;
                this.objComissao.com_data_abertura = pComissao.com_data_abertura;
                this.objComissao.com_data_fechamento = pComissao.com_data_fechamento;
                this.objComissao.com_loja = Loja.RecuperaLoja(pComissao.com_loja);
                this.objComissao.com_usuario = Usuario.RecuperaUsuario(pComissao.com_usuario);
                this.objComissao.com_status = pComissao.com_status;

                try
                {
                    this.objComissao.Atualiza();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            return this.objComissao.com_cod;
        }

        public static Boolean Exclui(string pCod)
        {
            Boolean flagReturn = false;

            //verifica se este objeto a excluir possui dependencias com outros objetos
            if (Contrato.RecuperaContratoComissao(Comissao.RecuperaComissao(pCod)).Count > 0)
                return flagReturn;
            else

            try
            {
                flagReturn = Comissao.Deleta(pCod);
            }
            catch (Exception e)
            {
                // Tratar Mensagens de Erro aqui!!!
                throw e;
            }
            return flagReturn;
        }

        public DS_Site.ComissaoRow SelecionaComissao(string pCod)
        {
            DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();
            DS_Site.ComissaoRow rowComissao = dtComissao.NewComissaoRow();

            try
            {
                this.objComissao = Comissao.RecuperaComissao(pCod);
                rowComissao.com_cod = this.objComissao.com_cod;
                rowComissao.com_data_abertura = this.objComissao.com_data_abertura;
                rowComissao.com_data_fechamento = this.objComissao.com_data_fechamento;
                rowComissao.com_loja = this.objComissao.com_loja.loj_cod;
                rowComissao.com_usuario = this.objComissao.com_usuario.usu_cod;
                rowComissao.com_status = this.objComissao.com_status;
               
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return rowComissao;
        }

        public static DS_Site.ComissaoDataTable SelecionaComissoes()
        {
            DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();

            try
            {
                IList listComissaos = Comissao.RecuperaComissoes();
                for (int i = 0; i < listComissaos.Count; i++)
                {
                    Comissao objComissao = (Comissao)listComissaos[i];
                    dtComissao.AddComissaoRow(
                    objComissao.com_cod,
                    objComissao.com_data_abertura,
                    objComissao.com_data_fechamento,
                    objComissao.com_loja.loj_cod,
                    objComissao.com_usuario.usu_cod,
                    objComissao.com_status,
                    objComissao.com_contrato.Count);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtComissao;
        }

        public static DS_Site.ComissaoDataTable SelecionaComissaoLoja(string pLoja)
        {
            DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();

            try
            {
                IList listComissaos = Comissao.RecuperaComissaoLoja(Loja.RecuperaLoja(pLoja));
                for (int i = 0; i < listComissaos.Count; i++)
                {
                    Comissao objComissao = (Comissao)listComissaos[i];
                    dtComissao.AddComissaoRow(
                    objComissao.com_cod,
                    objComissao.com_data_abertura,
                    objComissao.com_data_fechamento,
                    objComissao.com_loja.loj_cod,
                    objComissao.com_usuario.usu_cod,
                    objComissao.com_status,
                    objComissao.com_contrato.Count);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtComissao;
        }

        public static DS_Site.ComissaoDataTable SelecionaComissaoUsuarioStatus(string pUsuario, string pStatus)
        {
            DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();

            try
            {
                IList listComissaos = Comissao.RecuperaComissaoUsuarioStatus(Usuario.RecuperaUsuario(pUsuario), pStatus);
                for (int i = 0; i < listComissaos.Count; i++)
                {
                    Comissao objComissao = (Comissao)listComissaos[i];
                    dtComissao.AddComissaoRow(
                    objComissao.com_cod,
                    objComissao.com_data_abertura,
                    objComissao.com_data_fechamento,
                    objComissao.com_loja.loj_cod,
                    objComissao.com_usuario.usu_cod,
                    objComissao.com_status,
                    objComissao.com_contrato.Count);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtComissao;
        }

        public static DS_Site.ComissaoDataTable SelecionaComissaoStatus(string pStatus)
        {
            DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();

            try
            {
                IList listComissaos = Comissao.RecuperaComissaoStatus(pStatus);
                for (int i = 0; i < listComissaos.Count; i++)
                {
                    Comissao objComissao = (Comissao)listComissaos[i];
                    dtComissao.AddComissaoRow(
                    objComissao.com_cod,
                    objComissao.com_data_abertura,
                    objComissao.com_data_fechamento,
                    objComissao.com_loja.loj_cod,
                    objComissao.com_usuario.usu_cod,
                    objComissao.com_status,
                    objComissao.com_contrato.Count);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtComissao;
        }
    }
}
