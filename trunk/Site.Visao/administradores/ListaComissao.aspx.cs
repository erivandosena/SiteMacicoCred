using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site.Controle;

namespace Site.Visao.administradores
{
    public partial class ListaComissao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGrid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadComissao.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CarregaGrid();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            cntrUsuario objCntrUsuario = new cntrUsuario();
            cntrLoja objCntrLoja = new cntrLoja();
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = objCntrUsuario.SelecionaUsuario(GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString()).usu_nome_completo;
                DS_Site.LojaRow rowLoja = objCntrLoja.SelecionaLoja(GridView1.DataKeys[e.Row.RowIndex].Values[2].ToString());
                e.Row.Cells[3].Text = rowLoja.loj_nome + "/" + rowLoja.loj_cidade;

                string status = GridView1.DataKeys[e.Row.RowIndex].Values[3].ToString();
                if (status == "A")
                {
                    e.Row.Cells[4].Text = "Aberto";
                }
                if (status == "F")
                {
                    e.Row.Cells[4].Text = "Fechado";
                }

                LinkButton btnExclui = e.Row.Cells[5].Controls[0] as LinkButton;
                btnExclui.OnClientClick = "if (confirm('Tem certeza que deseja incluir este registro?') == false) return false;";

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (cntrComissao.Exclui(GridView1.DataKeys[e.RowIndex].Values[0].ToString()))
                    CarregaGrid();
                else
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "cadDependentes", @"alert('Exclusão não autorizada!\n\nExistem Contratos que dependem deste relatório de Comissão.');", true);
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        void CarregaGrid()
        {
            DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();

            try
            {
                dtComissao = cntrComissao.SelecionaComissoes();
                GridView1.DataSource = dtComissao;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}