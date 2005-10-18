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
using System.IO;

namespace Site.Visao.administradores
{
    public partial class ListaLojas : System.Web.UI.Page
    {
        private DS_Site.LojaDataTable dtLoja;

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadLoja.aspx");
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

                string sPath = Server.MapPath("~/Arquivos/image/" + dtLoja[e.RowIndex].loj_foto);
                if (File.Exists(sPath))
                {
                    File.Delete(sPath);
                }

                if(cntrLoja.Exclui(dtLoja[e.RowIndex].loj_cod))
                CarregaGrid();
                else
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "cadDependentes", @"alert('Exclusão não autorizada!\n\nExistem Usuários ou Propostas ou Comissões que dependem desta Loja.');", true);
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        void CarregaGrid()
        {
            try
            {
                dtLoja = cntrLoja.SelecionaLojas();
                GridView1.DataSource = dtLoja;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }

}
