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
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        private DS_Site.UsuarioDataTable dtUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if(cntrUsuario.Exclui(dtUsuario[e.RowIndex].usu_cod))
                CarregaGrid();
                else
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "cadDependentes", @"alert('Exclusão não autorizada!\n\nExistem Propostas ou Comissões que dependem deste Usuário.');", true);
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadUsuario.aspx", false);
        }
        void CarregaGrid()
        {
            try
            {
                dtUsuario = cntrUsuario.SelecionaUsuarios();
                GridView1.DataSource = dtUsuario;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

    }

}
