using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrPagina
    {
        #region Construtor

        public cntrPagina()
        {

        }

        #endregion

        #region Campos

        Pagina objPagina;
        
        #endregion

        #region Metodos

        public Boolean Salva(DS_Site.PaginaRow pPagina)
        {
            Boolean flagReturn = false;
            if (pPagina.pag_cod == null || pPagina.pag_cod == "")
            {
                this.objPagina = new Pagina();
                this.objPagina.pag_nome = pPagina.pag_nome;
                this.objPagina.pag_descricao = pPagina.pag_descricao;
                this.objPagina.pag_conteudo = pPagina.pag_conteudo;
                this.objPagina.pag_posicao = pPagina.pag_posicao;
                try
                {
                    flagReturn = this.objPagina.Insere();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            else
            {
                this.objPagina = Pagina.RecuperaPagina(pPagina.pag_cod);
                this.objPagina.pag_cod = objPagina.pag_cod;
                this.objPagina.pag_nome = pPagina.pag_nome;
                this.objPagina.pag_descricao = pPagina.pag_descricao;
                this.objPagina.pag_conteudo = pPagina.pag_conteudo;
                this.objPagina.pag_posicao = pPagina.pag_posicao;
                try
                {
                    flagReturn = this.objPagina.Atualiza();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            return flagReturn;
        }

        public DS_Site.PaginaRow Seleciona(string pCod)
        {
            DS_Site.PaginaDataTable dtPagina = new DS_Site.PaginaDataTable();
            DS_Site.PaginaRow linhaPagina = dtPagina.NewPaginaRow();

            try
            {
                this.objPagina = Pagina.RecuperaPagina(pCod);
                linhaPagina.pag_cod = pCod;
                linhaPagina.pag_nome = this.objPagina.pag_nome;
                linhaPagina.pag_descricao = this.objPagina.pag_descricao;
                linhaPagina.pag_conteudo = this.objPagina.pag_conteudo;
                linhaPagina.pag_posicao= this.objPagina.pag_posicao;
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return linhaPagina;
        }

        public static DS_Site.PaginaDataTable Seleciona()
        {
            DS_Site.PaginaDataTable dtPagina = new DS_Site.PaginaDataTable();

            try
            {
                IList listPaginas = Pagina.RecuperaPaginas();
                for (int i = 0; i < listPaginas.Count; i++)
                {
                    Pagina objPagina = (Pagina)listPaginas[i];
                        dtPagina.AddPaginaRow(
                        objPagina.pag_cod, 
                        objPagina.pag_nome, 
                        objPagina.pag_descricao, 
                        objPagina.pag_conteudo, 
                        objPagina.pag_posicao);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtPagina;
        }

        public static DS_Site.PaginaDataTable SelecionaMenu(string pPosicao)
        {
            DS_Site.PaginaDataTable dtPagina = new DS_Site.PaginaDataTable();

            try
            {
                IList listPaginas = Pagina.RecuperaPaginasMenu(pPosicao);
                for (int i = 0; i < listPaginas.Count; i++)
                {
                    Pagina objPagina = (Pagina)listPaginas[i];
                    dtPagina.AddPaginaRow(
                    objPagina.pag_cod,
                    objPagina.pag_nome,
                    objPagina.pag_descricao,
                    objPagina.pag_conteudo,
                    objPagina.pag_posicao);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtPagina;
        }

        public static Boolean Exclui(string pCod)
        {
            Boolean flagReturn = false;
            try
            {
                flagReturn = Pagina.Deleta(pCod);
            }
            catch (Exception e)
            {
                // Tratar Mensagens de Erro aqui!!!
                throw e;
            }
            return flagReturn;
        }

        #endregion
    }
}
