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
    public partial class CadLink : System.Web.UI.Page
    {
        private String cod
        {
            get
            {
                string id = Request.QueryString["pg"];
                if (id == null || id == string.Empty)
                    return "";
                else
                    return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (!"".Equals(cod))
                    {
                        cntrLink objCntrLink = new cntrLink();
                        DS_Site.LinkRow rowLink = objCntrLink.SelecionaLink(cod);
                        TextBoxNome.Text = rowLink.lin_nome;
                        TextBoxUrl.Text = rowLink.lin_url;
                        DropDownListTipo.SelectedValue = rowLink.lin_tipo;
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }
        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DS_Site.LinkDataTable dtLink = new DS_Site.LinkDataTable();
                DS_Site.LinkRow rowLink = dtLink.NewLinkRow();

                rowLink.lin_cod = cod;
                rowLink.lin_nome = TextBoxNome.Text.Trim();
                rowLink.lin_url = TextBoxUrl.Text.Trim().ToLower();
                rowLink.lin_tipo = DropDownListTipo.SelectedValue;

                cntrLink objCntrLink = new cntrLink();
                objCntrLink.Salva(rowLink);

                Retorna();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Retorna();
        }

        void Retorna()
        {
            Response.Redirect("ListaLinks.aspx", false);
        }
    }
}
