using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Site.Controle;

namespace Site.Visao
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["WebSite"] != null)
            {
                CarregaWebSite();
            }
            else
            {
                CarregaDadosSite();
            }

            CarregaMenus();
            CarregaLinks();
            CarregaBancos();
            CarregaLojas();
        }

        private void CarregaDadosSite()
        {
            DS_Site.WebsiteDataTable dtSite = cntrWebsite.Seleciona();

            if (Cache["WebSite"] != null)
            {
                Cache.Remove("WebSite");
            }
            try
            {
                Cache.Insert("WebSite", dtSite, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(1));
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
            CarregaWebSite();
        }
        private void CarregaWebSite()
        {
            try
            {
                DS_Site.WebsiteDataTable dtSite = (DS_Site.WebsiteDataTable)Cache["WebSite"];

                foreach (DS_Site.WebsiteRow rowSite in dtSite.Rows)
                {
                    LabelTitContato.Visible = !"".Equals(dtSite.Rows.Count > 0);
                    Label1.Visible = LabelTitContato.Visible;
                    Label2.Text = rowSite.web_titulo;

                    if (Cache["Titulo"] != null)
                    {
                        Cache.Remove("Titulo");
                    }
                    Cache.Insert("Titulo", rowSite.web_titulo, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(1));

                    if (!"".Equals(rowSite.web_endereco))
                    {
                        Label1.Text += "<li>" + rowSite.web_endereco + "</li>";
                    }
                    if (!"".Equals(rowSite.web_cep) || !"".Equals(rowSite.web_cidade) || !"".Equals(rowSite.web_estado))
                    {
                        string cep = string.Empty;
                        if (!"".Equals(rowSite.web_cep))
                        {
                            cep = "CEP: ";
                        }
                        Label1.Text += "<li>" + cep + rowSite.web_cep + " " + rowSite.web_cidade + " " + rowSite.web_estado + "</li>";
                    }
                    if (!"".Equals(rowSite.web_telefone))
                    {
                        Label1.Text += "<li>Telefone: " + rowSite.web_telefone + "</li>";
                    }
                    Label1.Text += "<li>E-mail: <a href='mailto:" + rowSite.web_email + "'>" + rowSite.web_email + "</a></li>";
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        private void CarregaMenus()
        {
            try
            {
                DS_Site.PaginaDataTable dtMenu = cntrPagina.SelecionaMenu("Topo");
                DataListMenuTopo.DataSource = dtMenu;
                DataListMenuTopo.DataBind();

                dtMenu.Clear();
                dtMenu = cntrPagina.SelecionaMenu("Lateral");
                DataListMenuLateral.DataSource = dtMenu;
                DataListMenuLateral.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        private void CarregaLinks()
        {
            try
            {
                DS_Site.LinkDataTable dtLink = cntrLink.SelecionaLinkTipo("INSS");
                DataListInss.DataSource = dtLink;
                DataListInss.DataBind();

                dtLink.Clear();
                dtLink = cntrLink.SelecionaLinkTipo("Bancos");
                DataListBancos.DataSource = dtLink;
                DataListBancos.DataBind();

                dtLink.Clear();
                dtLink = cntrLink.SelecionaLinkTipo("Fatores & Tabelas");
                DataListFatTab.DataSource = dtLink;
                DataListFatTab.DataBind();

                dtLink.Clear();
                dtLink = cntrLink.SelecionaLinkTipo("Úteis");
                DataListUteis.DataSource = dtLink;
                DataListUteis.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        private void CarregaLojas()
        {
            try
            {
                DS_Site.LojaDataTable dtLoja = cntrLoja.SelecionaLojas();
                if (Label3.Visible = dtLoja.Rows.Count > 0)
                {
                    DataListLojas.DataSource = dtLoja;
                    DataListLojas.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        private void CarregaBancos()
        {
            try
            {
                DS_Site.BancoDataTable dtBanco = cntrBanco.SelecionaBancos();
                if (Label4.Visible = dtBanco.Count > 0)
                {
                    Repeater1.DataSource = dtBanco;
                    Repeater1.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        private string ChamaTitulo()
        {
            cntrWebsite objCntrWebsite = new cntrWebsite();
            return objCntrWebsite.SelecionaWebSite().web_titulo;
        }

    }
}