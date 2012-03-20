using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Site.Controle;

namespace Site.Visao.administradores
{
    public partial class CadSite : System.Web.UI.Page
    {

        private static string cod;

        cntrWebsite objCntrWebsite = new cntrWebsite();

        protected void Page_Load(object sender, EventArgs e)
        {
            String codigo = objCntrWebsite.SelecionaWebSite().web_cod;
            if (string.IsNullOrEmpty(codigo))
            {
                cod = "";
            }
            else
            {
                cod = codigo.ToString();
            }

            if (!IsPostBack)
            {
                try
                {
                    preencheCampos();
                }
                catch (Exception)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        private void preencheCampos()
        {
            try
            {
                if (!"".Equals(cod))
                {

                    DS_Site.WebsiteRow rowWebsite = objCntrWebsite.SelecionaWebSite();

                    TextBoxTitulo.Text = rowWebsite.web_titulo;
                    TextBoxSlogan.Text = rowWebsite.web_slogan;
                    TextBoxEndereco.Text = rowWebsite.web_endereco;
                    TextBoxCep.Text = rowWebsite.web_cep;
                    TextBoxCidade.Text = rowWebsite.web_cidade;
                    TextBoxEstado.Text = rowWebsite.web_estado;
                    TextBoxTelefone.Text = rowWebsite.web_telefone;
                    TextBoxEmail.Text = rowWebsite.web_email;
                    TextBoxTitInfo.Text = rowWebsite.web_info_titulo;
                    FCKConteudoInfo.Value = rowWebsite.web_info_conteudo;
                    FCKResumoInfo.Value = rowWebsite.web_info_resumo;
                    FCKBanner.Value = rowWebsite.web_banner;
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DS_Site.WebsiteDataTable dtWebsite = new DS_Site.WebsiteDataTable();
                DS_Site.WebsiteRow rowWebsite = dtWebsite.NewWebsiteRow();

                rowWebsite.web_cod = cod;
                rowWebsite.web_titulo = TextBoxTitulo.Text.Trim();
                rowWebsite.web_slogan = TextBoxSlogan.Text.Trim();
                rowWebsite.web_endereco = TextBoxEndereco.Text.Trim();
                rowWebsite.web_cep = TextBoxCep.Text.Trim();
                rowWebsite.web_cidade = TextBoxCidade.Text.Trim();
                rowWebsite.web_estado = TextBoxEstado.Text.Trim();
                rowWebsite.web_telefone = TextBoxTelefone.Text.Trim();
                rowWebsite.web_email = TextBoxEmail.Text.Trim().ToLower();
                rowWebsite.web_info_titulo = TextBoxTitInfo.Text.Trim();
                rowWebsite.web_info_resumo = FCKResumoInfo.Value;
                rowWebsite.web_info_conteudo = FCKConteudoInfo.Value;
                rowWebsite.web_info_data = Convert.ToDateTime(string.Format("{0:d}", DateTime.Now));
                rowWebsite.web_banner = FCKBanner.Value;

                if (objCntrWebsite.Salva(rowWebsite))
                {
                    Label13.Text = "<script type='text/javascript'>alert('Salvo com sucesso!');</script>";
                }
                else
                {
                    Label13.Text = "Erro ao salvar!";
                }

            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }

}
