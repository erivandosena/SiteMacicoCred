using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Site.Controle;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Site.Visao.usuarios
{
    public partial class RelatorioDetalhe : System.Web.UI.Page
    {
        Object cod;
        Object inicio;
        Object final;
        private static byte[] chave = { };
        private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };

        protected void Page_Load(object sender, EventArgs e)
        {
            cod = Request.QueryString["r"];
            inicio = Request.QueryString["a"];
            final = Request.QueryString["f"];

            if (cod == null)
            {
                Response.Redirect("Relatorios.aspx");
            }
            else
            {
                cod = Descriptografar(cod.ToString(), "9F3D326E7E7E80F6DDB580CDAFCDBA56");
            }

            if (inicio == null)
            {
                Response.Redirect("Relatorios.aspx");
            }
            else
            {
                inicio = Descriptografar(inicio.ToString(), "9F3D326E7E7E80F6DDB580CDAFCDBA56");
            }
            if (final == null)
            {
                Response.Redirect("Relatorios.aspx");
            }
            else
            {
                final = Descriptografar(final.ToString(), "9F3D326E7E7E80F6DDB580CDAFCDBA56");
            }

            if (!IsPostBack)
            {
                LabelTitRelatorio.Font.Size = 12;
                LabelTitRelatorio.Text += " entre <strong>" + inicio.ToString() + "</strong> a <strong>" + final.ToString() + "</strong>";
                CarregaGrid();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Decimal Total1 = 0;
            Decimal Total2 = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {
                Total1 += Decimal.Parse(row.Cells[4].Text);
                Total2 += Decimal.Parse(row.Cells[2].Text);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Contratos: " + GridView1.Rows.Count;
                e.Row.Cells[1].Text = "Totais: ";
                e.Row.Cells[2].Text = string.Format("{0:c}", Total2);
                e.Row.Cells[4].Text = string.Format("{0:c}", Total1);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            cntrCliente objCntrCliente = new cntrCliente();
            cntrProposta objCntrProposta = new cntrProposta();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var proposta = objCntrProposta.SelecionaProposta(GridView1.DataKeys[e.Row.RowIndex].Values[3].ToString());
                var cliente = objCntrCliente.SelecionaCliente(proposta.pro_cliente);

                e.Row.Cells[0].Text = proposta.pro_banco_emprestimo;

                e.Row.Cells[4].Text = string.Format("{0:n}", Convert.ToDecimal(GridView1.DataKeys[e.Row.RowIndex].Values[2].ToString()) * Convert.ToDecimal(GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString()) / 100);

                e.Row.Cells[5].Text = proposta.pro_plano;

                e.Row.Cells[7].Text = cliente.cli_nome;

                e.Row.Cells[8].Text = cliente.cli_cpf;
            }
        }

        void CarregaGrid()
        {
            try
            {
                DS_Site.ContratoDataTable dtContrato = cntrContrato.SelecionaContratoComissao(cod.ToString());
                GridView1.DataSource = dtContrato;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        private string Descriptografar(string valor, string chaveCriptografia)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();

                input = new byte[valor.Length];
                input = Convert.FromBase64String(valor.Replace(" ", "+"));

                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                Response.Redirect("Relatorios.aspx");
                return string.Empty;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            cntrWebsite objCntrWebsite = new cntrWebsite();
            cntrUsuario objCntrUsuario = new cntrUsuario();

            var corretor = objCntrUsuario.SelecionaUsuarioNome(User.Identity.Name);

            HtmlForm form = new HtmlForm();
            string attachment = "attachment;filename=" + Util.Util.SubstituiCaractEspacAcentos("Relatorio " + DateTime.Now.ToShortDateString() + " " + corretor.usu_nome_completo + " " + corretor.usu_cod) + ".doc";
            Response.ClearContent();
            Response.Buffer = true;
            Response.ContentType = "application/msword";
            Response.AddHeader("content-disposition", attachment);
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            GridView1.Style.Value = "width:auto;overflow:hidden;";
            form.Controls.Add(GridView1);
            this.Controls.Add(form);
            form.RenderControl(htextw);
            Response.Write("<font size='4'>" + LabelTitRelatorio.Text + "</font>");
            Response.Write(string.Empty);
            Response.Write(stw.ToString());
            Response.Write(string.Empty);
            string rodape = "© " + objCntrWebsite.SelecionaWebSite().web_titulo + " " + HttpContext.Current.Request.Url.Authority + " | RWD Sistemas Web - www.rwd.net.br";
            Response.Write("<font size='1'>" + System.Web.HttpUtility.HtmlEncode(rodape) + "</font>");
            Response.End();
        }

    }
}