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
using Site.Util;

using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Site.Visao.administradores
{
    public partial class CadLoja : System.Web.UI.Page
    {
        private static string sImgFile;
        private static string imgFileName;
        private static string imgFileNameCad;

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
            litError.Text = string.Empty;

            if (!Page.IsPostBack)
            {
                try
                {
                    if (!"".Equals(cod))
                    {
                        cntrLoja objCntrLoja = new cntrLoja();
                        DS_Site.LojaRow rowLoja = objCntrLoja.SelecionaLoja(cod);
                        TextBoxNome.Text = rowLoja.loj_nome;
                        TextBoxEndereco.Text = rowLoja.loj_endereco;
                        TextBoxCep.Text = rowLoja.loj_cep;
                        TextBoxCidade.Text = rowLoja.loj_cidade;
                        TextBoxEstado.Text = rowLoja.loj_estado;
                        TextBoxTelefone.Text = rowLoja.loj_telefone;
                        TextBoxEmail.Text = rowLoja.loj_email;

                        if (!string.IsNullOrEmpty(rowLoja.loj_foto))
                        {
                            pnlResulado.Visible = true;
                            //PnlUpload.Visible = 
                            // pnlCutImage.Visible = false;
                            imgResultado.ImageUrl = "~/Arquivos/image/" + rowLoja.loj_foto;
                            imgFileName = rowLoja.loj_foto;
                            imgFileNameCad = rowLoja.loj_foto;
                        }
                        else
                        {
                            imgFileName = string.Empty;
                        }
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
                DS_Site.LojaDataTable dtLoja = new DS_Site.LojaDataTable();
                DS_Site.LojaRow rowLoja = dtLoja.NewLojaRow();

                rowLoja.loj_cod = cod;
                rowLoja.loj_nome = TextBoxNome.Text.Trim().ToUpper();
                rowLoja.loj_endereco = TextBoxEndereco.Text.ToUpper();
                rowLoja.loj_cep = TextBoxCep.Text.Trim();
                rowLoja.loj_cidade = TextBoxCidade.Text.Trim().ToUpper();
                rowLoja.loj_estado = TextBoxEstado.Text.Trim().ToUpper();
                rowLoja.loj_telefone = TextBoxTelefone.Text.Trim();
                rowLoja.loj_email = TextBoxEmail.Text.Trim().ToLower();
                rowLoja.loj_foto = imgFileName;

                cntrLoja objCntrLoja = new cntrLoja();
                objCntrLoja.Salva(rowLoja);

                excluiImgTemp();

                Retorna();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            excluiImgTemp();
            if (string.IsNullOrEmpty(imgFileNameCad))
            {
                excluiImgFinal();
            }
            Retorna();
        }
        void Retorna()
        {
            Response.Redirect("ListaLojas.aspx", false);
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            excluiImgTemp();

            //Verificar se existe algum arquivo
            if (fupImage.HasFile)
            {
                bool bValido = false;
                string sPath = Server.MapPath("~/Arquivos/image/"); //caminho onde vai ser salva
                string fileName = fupImage.FileName;
                fileName = Util.Util.SubstituiCaractEspacAcentos(fileName);
                sImgFile = sPath + fileName;

                //Verifica se é imagem
                string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
                foreach (string ext in new string[] { ".gif", ".png", ".jpeg", ".jpg" })
                {
                    if (fileExtension == ext)
                        bValido = true;
                }

                if (bValido)
                {
                    try
                    {
                        //Cria o diretorio se ainda não existir
                        if (!Directory.Exists(sPath))
                            Directory.CreateDirectory(sPath);

                        //Salvar imagem
                        fupImage.SaveAs(sImgFile);

                        pnlCutImage.Visible = true;
                        //PnlUpload.Visible = false;
                        imgPhoto.ImageUrl = "~/Arquivos/image/" + fileName;

                    }
                    catch (Exception ex)
                    {
                        litError.Text = "Ocorreu o seguinte erro:" + ex;

                    }
                }
                else
                {
                    litError.Text = "O arquivo selecionado não e válido";
                }
            }
            else
            {
                litError.Text = "Nenhum arquivo selecionado";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Validando se foi selecionada alguma parte da imagem.
            if (string.IsNullOrEmpty(Request.Form["x"]))
            {
                litError.Text = "Selecione a parte da imagem a ser recortada!";
            }
            else
            {
                int x = Convert.ToInt32(Request.Form["x"]);
                int y = Convert.ToInt32(Request.Form["y"]);
                int w = Convert.ToInt32(Request.Form["w"]);
                int h = Convert.ToInt32(Request.Form["h"]);

                //Verificar se a parte selecionada é maior que zero.
                if (w < 1 || h < 1)
                    litError.Text = "Selecione a parte da imagem a ser recortada!";
                else
                {
                    //Cortar imagem
                    Rectangle cropRect = new Rectangle(x, y, w, h);
                    Bitmap src = System.Drawing.Image.FromFile(sImgFile) as Bitmap;
                    Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

                    using (Graphics g = Graphics.FromImage(target))
                    {
                        g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), cropRect, GraphicsUnit.Pixel);
                    }

                    string sFileName = Util.Util.SubstituiCaractEspacAcentos(TextBoxNome.Text.ToLower() + " " + TextBoxCidade.Text.ToLower()) + ".jpg";
                    //Salvar imagem recortada
                    target.Save(Server.MapPath("~/Arquivos/image/") + sFileName);

                    //Exibir imagem recortada
                    pnlCutImage.Visible = false;
                    pnlResulado.Visible = true;
                    imgResultado.ImageUrl = "~/Arquivos/image/" + sFileName;
                    imgFileName = sFileName;

                    target.Dispose();
                    src.Dispose();

                    excluiImgTemp();
                }
            }
        }

        void excluiImgTemp()
        {
            if (File.Exists(sImgFile))
                File.Delete(sImgFile);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            excluiImgFinal();
        }

        void excluiImgFinal()
        {
            string sPath = Server.MapPath("~/Arquivos/image/" + imgFileName);
            if (File.Exists(sPath))
            {
                File.Delete(sPath);
                imgFileName = string.Empty;
                pnlResulado.Visible = false;
            }
        }
    }
}
