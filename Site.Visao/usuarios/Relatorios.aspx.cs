using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site.Controle;
using System.Text;
using System.IO;
using System.Security.Cryptography; 

namespace Site.Visao.usuarios
{
    public partial class Relatorios : System.Web.UI.Page
    {
        string lsCod;
        string lsData1;
        string lsData2;
        private static byte[] chave = { };
        private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGrid();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CarregaGrid();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            var contador = 1;
            cntrLoja objCntrLoja = new cntrLoja();
            cntrContrato objCntrContrato = new cntrContrato();
            DS_Site.ContratoDataTable dtContrato = new DS_Site.ContratoDataTable();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                lsCod = GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString();
                lsData1 = GridView1.DataKeys[e.Row.RowIndex].Values[2].ToString();
                lsData2 = GridView1.DataKeys[e.Row.RowIndex].Values[3].ToString();

                contador += GridView1.Rows.Count;
                e.Row.Cells[0].Text = contador.ToString();

                dtContrato = cntrContrato.SelecionaContratoComissao(GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString());

                Decimal Total = 0;
                foreach (DS_Site.ContratoRow row in dtContrato.Rows)
                {
                    Total += (row.con_valor * (decimal)row.con_taxa) / 100;
                }

                e.Row.Cells[2].Text = string.Format("{0:c}", Total);

                e.Row.Cells[3].Text = objCntrLoja.SelecionaLoja(GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString()).loj_nome;
            }
        }

        void CarregaGrid()
        {
            cntrUsuario objCntrUsuario = new cntrUsuario();
            cntrComissao objCntrComissao = new cntrComissao();
            DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();
            try
            {
                dtComissao = cntrComissao.SelecionaComissaoUsuarioStatus(objCntrUsuario.SelecionaUsuarioNome(User.Identity.Name).usu_cod, "F");
                GridView1.DataSource = dtComissao;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void lbDetalhe_Click(object sender, EventArgs e)
        {
            lsCod = Criptografar(lsCod, "9F3D326E7E7E80F6DDB580CDAFCDBA56");
            lsData1 = Criptografar(lsData1, "9F3D326E7E7E80F6DDB580CDAFCDBA56");
            lsData2 = Criptografar(lsData2, "9F3D326E7E7E80F6DDB580CDAFCDBA56");
            Response.Redirect("RelatorioDetalhe.aspx?r=" + lsCod + "&a=" + lsData1 + "&f=" + lsData2);
        }

        private string Criptografar(string valor, string chaveCriptografia)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();
                input = Encoding.UTF8.GetBytes(valor); 
                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

    }
}