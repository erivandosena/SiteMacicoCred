using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrWebsite
    {
        Website objWebsite;

        public cntrWebsite()
        {

        }

        public Boolean Salva(DS_Site.WebsiteRow pWebsite)
        {
            Boolean flagReturn = false;
            if (pWebsite.web_cod == null || pWebsite.web_cod == "")
            {
                this.objWebsite = new Website();
                this.objWebsite.web_titulo = pWebsite.web_titulo;
                this.objWebsite.web_slogan = pWebsite.web_slogan;
                this.objWebsite.web_endereco = pWebsite.web_endereco;
                this.objWebsite.web_cep = pWebsite.web_cep;
                this.objWebsite.web_cidade = pWebsite.web_cidade;
                this.objWebsite.web_estado = pWebsite.web_estado;
                this.objWebsite.web_telefone = pWebsite.web_telefone;
                this.objWebsite.web_email = pWebsite.web_email;
                this.objWebsite.web_info_titulo = pWebsite.web_info_titulo;
                this.objWebsite.web_info_resumo = pWebsite.web_info_resumo;
                this.objWebsite.web_info_conteudo = pWebsite.web_info_conteudo;
                this.objWebsite.web_info_data = pWebsite.web_info_data;
                this.objWebsite.web_banner = pWebsite.web_banner;

                try
                {
                    flagReturn = this.objWebsite.Insere();
                }
                catch (Exception e)
                {
                    // Tratar mensagens de erro aqui!
                    throw e;
                }
            }
            else
            {
                this.objWebsite = Website.RecuperaWebsite(pWebsite.web_cod);
                this.objWebsite.web_cod = pWebsite.web_cod;
                this.objWebsite.web_titulo = pWebsite.web_titulo;
                this.objWebsite.web_slogan = pWebsite.web_slogan;
                this.objWebsite.web_endereco = pWebsite.web_endereco;
                this.objWebsite.web_cep = pWebsite.web_cep;
                this.objWebsite.web_cidade = pWebsite.web_cidade;
                this.objWebsite.web_estado = pWebsite.web_estado;
                this.objWebsite.web_telefone = pWebsite.web_telefone;
                this.objWebsite.web_email = pWebsite.web_email;
                this.objWebsite.web_info_titulo = pWebsite.web_info_titulo;
                this.objWebsite.web_info_resumo = pWebsite.web_info_resumo;
                this.objWebsite.web_info_conteudo = pWebsite.web_info_conteudo;
                this.objWebsite.web_info_data = pWebsite.web_info_data;
                this.objWebsite.web_banner = pWebsite.web_banner;

                try
                {
                    flagReturn = this.objWebsite.Atualiza();
                }
                catch (Exception e)
                {
                    // Tratar mensagens de erro aqui!
                    throw e;
                }
            }
            return flagReturn;
        }

        public DS_Site.WebsiteRow SelecionaWebSite()
        {
            DS_Site.WebsiteDataTable dtWebsite = new DS_Site.WebsiteDataTable();
            DS_Site.WebsiteRow rowWebsite = dtWebsite.NewWebsiteRow();

            try
            {
                this.objWebsite = Website.RecuperaWebsite(Website.RecuperaWebsiteMax().Count.ToString());
                rowWebsite.web_cod = this.objWebsite.web_cod;
                rowWebsite.web_titulo = this.objWebsite.web_titulo;
                rowWebsite.web_slogan = this.objWebsite.web_slogan;
                rowWebsite.web_endereco = this.objWebsite.web_endereco;
                rowWebsite.web_cep = this.objWebsite.web_cep;
                rowWebsite.web_cidade = this.objWebsite.web_cidade;
                rowWebsite.web_estado = this.objWebsite.web_estado;
                rowWebsite.web_telefone = this.objWebsite.web_telefone;
                rowWebsite.web_email = this.objWebsite.web_email;
                rowWebsite.web_info_titulo = this.objWebsite.web_info_titulo;
                rowWebsite.web_info_resumo = this.objWebsite.web_info_resumo;
                rowWebsite.web_info_conteudo = this.objWebsite.web_info_conteudo;
                rowWebsite.web_info_data = this.objWebsite.web_info_data;
                rowWebsite.web_banner = this.objWebsite.web_banner;
            }
            catch (Exception e)
            {
                // Tratar mensagens de erro aqui!
                throw e;
            }

            return rowWebsite;
        }

        public static DS_Site.WebsiteDataTable Seleciona()
        {
            DS_Site.WebsiteDataTable dtWebsite = new DS_Site.WebsiteDataTable();

            try
            {

                IList listWebsites = Website.RecuperaWebsite();
                for (int i = 0; i < listWebsites.Count; i++)
                {
                    Website objWebsite = (Website)listWebsites[i];
                    dtWebsite.AddWebsiteRow(
                    objWebsite.web_cod,
                    objWebsite.web_titulo,
                    objWebsite.web_slogan,
                    objWebsite.web_endereco,
                    objWebsite.web_cep,
                    objWebsite.web_cidade,
                    objWebsite.web_estado,
                    objWebsite.web_telefone,
                    objWebsite.web_email,
                    objWebsite.web_info_titulo,
                    objWebsite.web_info_resumo,
                    objWebsite.web_info_conteudo,
                    objWebsite.web_info_data,
                    objWebsite.web_banner);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui!
                throw e;
            }

            return dtWebsite;
        }

    }
}
