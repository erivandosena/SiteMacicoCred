using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site.Controle;

namespace Site.Visao.administradores
{
    public partial class CadBanco : System.Web.UI.Page
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
                        cntrBanco objCntrBanco = new cntrBanco();
                        DS_Site.BancoRow rowBanco = objCntrBanco.SelecionaBanco(cod);
                        TextBoxNome.Text = rowBanco.ban_nome;
                        TextBoxSite.Text = rowBanco.ban_site;
                        TextBoxImagem.Text = rowBanco.ban_logo;
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
                DS_Site.BancoDataTable dtBanco = new DS_Site.BancoDataTable();
                DS_Site.BancoRow rowBanco = dtBanco.NewBancoRow();

                rowBanco.ban_cod = cod;
                rowBanco.ban_nome = TextBoxNome.Text.Trim();
                rowBanco.ban_site = TextBoxSite.Text.Trim().ToLower();
                rowBanco.ban_logo = TextBoxImagem.Text.Trim().ToLower();

                cntrBanco objCntrBanco = new cntrBanco();
                objCntrBanco.Salva(rowBanco);

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
            Response.Redirect("ListaBanco.aspx", false);
        }
    }
}