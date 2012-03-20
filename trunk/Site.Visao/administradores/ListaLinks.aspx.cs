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
    public partial class ListaLinks : System.Web.UI.Page
    {
        private DS_Site.LinkDataTable dtLink;

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadLink.aspx");
        }
        void CarregaGrid()
        {
            try
            {
                dtLink = cntrLink.SelecionaLinks();
                GridView1.DataSource = dtLink;
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
                cntrLink.Exclui(dtLink[e.RowIndex].lin_cod);
                CarregaGrid();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }

}
