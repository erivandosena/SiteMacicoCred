using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrLink
    {
        public cntrLink()
        {

        }

        Link objLink;

        public Boolean Salva(DS_Site.LinkRow pLink)
        {
            Boolean flagReturn = false;
            if (pLink.lin_cod == null || pLink.lin_cod == "")
            {
                this.objLink = new Link();
                this.objLink.lin_nome = pLink.lin_nome;
                this.objLink.lin_tipo = pLink.lin_tipo;
                this.objLink.lin_url = pLink.lin_url;

                try
                {
                    flagReturn = this.objLink.Insere();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            else
            {
                this.objLink = Link.RecuperaLink(pLink.lin_cod);
                this.objLink.lin_cod = pLink.lin_cod;
                this.objLink.lin_nome = pLink.lin_nome;
                this.objLink.lin_tipo = pLink.lin_tipo;
                this.objLink.lin_url = pLink.lin_url;

                try
                {
                    flagReturn = this.objLink.Atualiza();
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
                flagReturn = Link.Deleta(pCod);
            }
            catch (Exception e)
            {
                // Tratar Mensagens de Erro aqui!!!
                throw e;
            }
            return flagReturn;
        }

        public DS_Site.LinkRow SelecionaLink(string pCod)
        {
            DS_Site.LinkDataTable dtLink = new DS_Site.LinkDataTable();
            DS_Site.LinkRow rowLink = dtLink.NewLinkRow();

            try
            {
                this.objLink = Link.RecuperaLink(pCod);
                rowLink.lin_cod = pCod;
                rowLink.lin_nome = this.objLink.lin_nome;
                rowLink.lin_tipo = this.objLink.lin_tipo;
                rowLink.lin_url = this.objLink.lin_url;
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return rowLink;
        }

        public static DS_Site.LinkDataTable SelecionaLinks()
        {
            DS_Site.LinkDataTable dtLink = new DS_Site.LinkDataTable();

            try
            {
                IList listLinks = Link.RecuperaLinks();
                for (int i = 0; i < listLinks.Count; i++)
                {
                    Link objLink = (Link)listLinks[i];
                    dtLink.AddLinkRow(
                    objLink.lin_cod,
                    objLink.lin_nome,
                    objLink.lin_tipo,
                    objLink.lin_url);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtLink;
        }

        public static DS_Site.LinkDataTable SelecionaLinkTipo(string pTipo)
        {
            DS_Site.LinkDataTable dtLink = new DS_Site.LinkDataTable();

            try
            {
                IList listLinks = Link.RecuperaLinksTipo(pTipo);
                for (int i = 0; i < listLinks.Count; i++)
                {
                    Link objLink = (Link)listLinks[i];
                    dtLink.AddLinkRow(
                    objLink.lin_cod,
                    objLink.lin_nome,
                    objLink.lin_tipo,
                    objLink.lin_url);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtLink;
        }

    }
}
