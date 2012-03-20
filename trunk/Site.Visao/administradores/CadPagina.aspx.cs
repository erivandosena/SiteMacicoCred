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
    public partial class CadPagina : System.Web.UI.Page
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
                        cntrPagina objCntrPagina = new cntrPagina();
                        DS_Site.PaginaRow rowPagina = objCntrPagina.Seleciona(cod);
                        TextBoxNome.Text = rowPagina.pag_nome;
                        TextBoxDescricao.Text = rowPagina.pag_descricao;
                        FCKConteudo.Value = rowPagina.pag_conteudo;
                        DropDownListPosicao.SelectedValue = rowPagina.pag_posicao;
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
                DS_Site.PaginaDataTable dtPagina = new DS_Site.PaginaDataTable();
                DS_Site.PaginaRow rowPagina = dtPagina.NewPaginaRow();

                rowPagina.pag_cod = cod;
                rowPagina.pag_nome = TextBoxNome.Text.Trim();
                rowPagina.pag_descricao = TextBoxDescricao.Text.Trim();
                rowPagina.pag_conteudo = FCKConteudo.Value;
                rowPagina.pag_posicao = DropDownListPosicao.SelectedValue;

                cntrPagina objCntrPagina = new cntrPagina();
                objCntrPagina.Salva(rowPagina);

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
            Response.Redirect("ListaPaginas.aspx", false);
        }
    }
}
