using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site.Controle;

namespace Site.Visao.administradores
{
    public partial class ListaBanco : System.Web.UI.Page
    {
        private DS_Site.BancoDataTable dtBanco;

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadBanco.aspx");
        }
        void CarregaGrid()
        {
            try
            {
                dtBanco = cntrBanco.SelecionaBancos();
                GridView1.DataSource = dtBanco;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnExclui = e.Row.Cells[3].Controls[0] as LinkButton;
                btnExclui.OnClientClick = "if (confirm('Tem certeza que deseja incluir este registro?') == false) return false;";
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                cntrBanco.Exclui(dtBanco[e.RowIndex].ban_cod);
                CarregaGrid();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}