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
    public partial class ListaPaginas : System.Web.UI.Page
    {
        /*
        private DS_Site.PaginaDataTable dtPagina
        {
            set { ViewState["dtPagina"] = value; }
            get
            {
                object o = ViewState["dtPagina"];
                if (o == null)
                    return null;
                else
                    return (DS_Site.PaginaDataTable)o;
            }
        }
        */

        private DS_Site.PaginaDataTable dtPagina;

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        void CarregaGrid()
        {
            try
            {
                dtPagina = cntrPagina.Seleciona();
                GridView1.DataSource = dtPagina;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadPagina.aspx", false);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                cntrPagina.Exclui(dtPagina[e.RowIndex].pag_cod);
                CarregaGrid();
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
                LinkButton btnExclui = e.Row.Cells[4].Controls[0] as LinkButton;
                btnExclui.OnClientClick = "if (confirm('Tem certeza que deseja incluir este registro?') == false) return false;";
            }
        }

    }

}
