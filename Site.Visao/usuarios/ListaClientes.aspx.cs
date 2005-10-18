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

namespace Site.Visao.usuarios
{
    public partial class ListaClientes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                CarregaGrid();
            }

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if(cntrCliente.Exclui(GridView1.DataKeys[e.RowIndex].Values[0].ToString()))
                CarregaGrid();
                else
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "cadDependentes", @"alert('Exclusão não autorizada!\n\nExistem Propostas que dependem deste Cliente.');", true);
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        void CarregaGrid()
        {
            DS_Site.ClienteDataTable dtCliente = new DS_Site.ClienteDataTable();

            try
            {
                dtCliente = cntrCliente.SelecionaClientes();
                GridView1.DataSource = dtCliente;
                GridView1.DataBind();

                GridView1.Visible = User.IsInRole("Administrador") || User.IsInRole("Operador");

                ButtonLista.Enabled = dtCliente.Count < 2;
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
                btnExclui.Enabled = false;

                if (User.IsInRole("Administrador"))
                {
                    btnExclui.Enabled = true;
                    btnExclui.OnClientClick = "if (confirm('Tem certeza que deseja incluir este registro?') == false) return false;";
                }

            }
        }

        protected void ButtonBusca_Click(object sender, EventArgs e)
        {
            DS_Site.ClienteDataTable dtCliente = new DS_Site.ClienteDataTable();

            if (TextBoxCpf.Text.Trim().Length > 13)
            {
                TextBoxNome.Text = string.Empty;

                dtCliente = cntrCliente.SelecionaClientePorCpf(TextBoxCpf.Text.Trim());
                GridView1.DataSource = dtCliente;
                GridView1.DataBind();

                GridView1.Visible = User.IsInRole("Administrador") || User.IsInRole("Operador") || User.IsInRole("Corretor");

                ButtonLista.Enabled = dtCliente.Count < 2;

                if (GridView1.Rows.Count == 0)
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "naoEncontrado1", "alert('Nenhum registro encontrato com o CPF Nº " + TextBoxCpf.Text + "');", true);
                else
                    TextBoxCpf.Text = string.Empty;
            }
            else
            {
                if (TextBoxNome.Text.Trim().Length > 2)
                {
                    TextBoxCpf.Text = string.Empty;

                    dtCliente = cntrCliente.SelecionaClientePorNome(TextBoxNome.Text.Trim().ToUpper());
                    GridView1.DataSource = dtCliente;
                    GridView1.DataBind();

                    GridView1.Visible = GridView1.Visible = User.IsInRole("Administrador") || User.IsInRole("Operador") || User.IsInRole("Corretor");

                    ButtonLista.Enabled = dtCliente.Count < 2;

                    if (GridView1.Rows.Count == 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "naoEncontrado2", "alert('Nenhum registro encontrato com o nome " + TextBoxNome.Text + "');", true);
                        TextBoxNome.Focus();
                    }
                    else
                        TextBoxNome.Text = string.Empty;
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "campoVazio", "alert('Informe um valor completo para pesquisa!');", true);
                }
            }

        }

        protected void ButtonLista_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        protected void ButtonNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadCliente.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CarregaGrid();
        }
    }
}
