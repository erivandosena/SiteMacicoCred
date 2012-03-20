﻿using System;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Site.Util;

namespace Site.Visao.usuarios
{
    public partial class ListaPropostas : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LabelVazio.Visible = !CarregaGrid();
            }
            Panel1.Visible = User.IsInRole("Administrador");
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            cntrCliente objCntrCliente = new cntrCliente();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = objCntrCliente.SelecionaCliente(GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString()).cli_nome;

                Button btnImprime = e.Row.Cells[3].Controls[0] as Button;
                Button btnDownload = e.Row.Cells[4].Controls[0] as Button;
                LinkButton btnExclui = e.Row.Cells[5].Controls[0] as LinkButton;

                btnDownload.Enabled = !string.IsNullOrEmpty(GridView1.DataKeys[e.Row.RowIndex].Values[2].ToString()) && User.IsInRole("Administrador");
                btnExclui.Enabled = btnImprime.Enabled = User.IsInRole("Administrador");

                if (User.IsInRole("Administrador"))
                {
                    btnExclui.OnClientClick = "if (confirm('Tem certeza que deseja incluir este registro?') == false) return false;";
                }

                string status = GridView1.DataKeys[e.Row.RowIndex].Values[7].ToString();
                if (status == "N")
                {
                    e.Row.Cells[6].Text = "Nova";
                }
                if (status == "R")
                {
                    e.Row.Cells[6].Text = "Recusada";
                }
                if (status == "C")
                {
                    e.Row.Cells[6].Text = "Corrigida";
                }
                if (status == "A")
                {
                    e.Row.Cells[6].Text = "Aprovada";
                }
                if (status == "D")
                {
                    e.Row.Cells[6].Text = "Negada";
                }
                if (status == "F")
                {
                    e.Row.Cells[6].Text = "Faturada";
                }

            }

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string caminho = this.Server.MapPath("~\\Arquivos\\documentos\\");
                string sPath1 = caminho + GridView1.DataKeys[e.RowIndex].Values[2].ToString();

                if (cntrProposta.Exclui(GridView1.DataKeys[e.RowIndex].Values[0].ToString()))
                {
                    CarregaGrid();
                    if (File.Exists(sPath1))
                    {
                        File.Delete(sPath1);
                    }
                }
                else
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "cadDependentes", @"alert('Exclusão não autorizada!\n\nExistem Contratos que dependem desta Proposta.');", true);
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        private bool CarregaGrid()
        {
            cntrUsuario objCntrUsuario = new cntrUsuario();
            cntrLoja objCntrLoja = new cntrLoja();
            DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();

            try
            {
                if (User.IsInRole("Corretor"))
                {
                    dtProposta = cntrProposta.SelecionaPropostaUsuarioStatus(objCntrUsuario.SelecionaUsuarioNome(User.Identity.Name).usu_cod, "R");
                }
                if (User.IsInRole("Operador"))
                {
                    dtProposta = cntrProposta.SelecionaPropostaLoja(objCntrUsuario.SelecionaUsuarioNome(User.Identity.Name).usu_loja);
                }
                if (User.IsInRole("Administrador"))
                {
                    dtProposta = cntrProposta.SelecionaPropostas();
                }

                GridView1.DataSource = dtProposta;
                GridView1.DataBind();

                if (GridView1.Rows.Count > 0)
                    return true;
                else
                    LabelVazio.Text = "Não existem propostas no momento!";
                return false;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "PRO")
            {
                string proCod = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)][0].ToString();

                try
                {
                    Response.Clear();
                    Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
                    Response.AppendHeader("Content-Type", "application/pdf");
                    Response.AppendHeader("Content-Disposition", "attachment; filename=Proposta-" + proCod + ".pdf");
                    Response.OutputStream.Write(GeraPDF(proCod).GetBuffer(), 0, GeraPDF(proCod).GetBuffer().Length);
                    Response.End();

                    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    //sb.Append("<script type='text/javascript'>");
                    //sb.Append("window.open('../Arquivos/documentos/" + arquivo.Substring(arquivo.LastIndexOf("\\") + 1) + "','_blank');");
                    //sb.Append("</script>");
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "Impressao", sb.ToString());
                }

                catch (DocumentException de)
                {
                    throw de;
                }
                catch (IOException ioe)
                {
                    throw ioe;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            if (e.CommandName == "DOC")
            {
                string proCod = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)][0].ToString();
                string proDoc = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)][2].ToString();

                try
                {
                    string pdfPath = Server.MapPath("~\\App_Data\\Documentos\\") + proDoc;
                    System.Net.WebClient client = new System.Net.WebClient();
                    Byte[] buffer = client.DownloadData(pdfPath);
                    Response.Clear();
                    Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
                    Response.AppendHeader("Content-Type", "application/pdf");
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + pdfPath.Substring(pdfPath.LastIndexOf("\\") + 1));
                    Response.OutputStream.Write(buffer, 0, buffer.Length);
                    Response.End();

                }

                catch (DocumentException de)
                {
                    throw de;
                }
                catch (IOException ioe)
                {
                    throw ioe;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            CarregaGrid();
        }

        private MemoryStream GeraPDF(string pro_cod)
        {
            cntrWebsite objCntrWebsite = new cntrWebsite();
            DS_Site.WebsiteRow rowWebsite = objCntrWebsite.SelecionaWebSite();

            cntrProposta objCntrProposta = new cntrProposta();
            DS_Site.PropostaRow rowProposta = objCntrProposta.SelecionaProposta(pro_cod);

            cntrCliente objCntrCliente = new cntrCliente();
            DS_Site.ClienteRow rowClienteProposta = objCntrCliente.SelecionaCliente(rowProposta.pro_cliente);

            string docsPath = Server.MapPath("~/Arquivos/documentos/");
            string imagePath = Server.MapPath("~/Arquivos/image/");

            //Rectangle pagina = new Rectangle(595, 842);
            //pagina.BackgroundColor = new Color(255, 255, 255);
            //Document document = new Document(pagina, 36, 36, 72, 72);

            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document(PageSize.A4, 36, 36, 36, 36);

            PdfWriter pdfW = PdfWriter.GetInstance(document, memoryStream);
            //pdfW.SetEncryption(PdfWriter.STRENGTH128BITS, "1234321", "1234321", PdfWriter.AllowAssembly);

            document.AddTitle("Proposta " + pro_cod + " - " + rowClienteProposta.cli_nome);
            document.AddAuthor("Maciço CRED");
            document.AddSubject("Proposta INSS - www.macicocred.com.br");
            document.AddKeywords("proposta, emprestimo, consignado, inss, macicocred, rwd");
            document.AddHeader("Emprestimo Consignado", "Proposta");
            document.AddCreationDate();
            document.AddProducer();

            //HeaderFooter header = new HeaderFooter(new Phrase("Este é o cabeçalho"), false);
            //document.Header = header;

            //HeaderFooter footer = new HeaderFooter(new Phrase("Página:"), true);
            //document.Footer = footer;

            document.Open();

            /* ------------------------------------------------------------------------------------- */

            iTextSharp.text.Table tableCabecalho = new iTextSharp.text.Table(3);
            int[] larguras = new int[] { 198, 198, 198 };
            tableCabecalho.Locked = true;
            tableCabecalho.SetWidths(larguras);
            tableCabecalho.Width = 523;
            tableCabecalho.DefaultCellBorderWidth = 0;
            tableCabecalho.BorderWidth = 0;
            tableCabecalho.Spacing = 5;

            Cell celEsquerdo = new Cell(new Chunk("Data: " + string.Format("{0:d}", rowProposta.pro_data), FontFactory.GetFont("Arial", 9)));
            celEsquerdo.Border = Rectangle.NO_BORDER;
            celEsquerdo.HorizontalAlignment = Element.ALIGN_LEFT;
            celEsquerdo.BackgroundColor = new iTextSharp.text.Color(250, 250, 250);

            Cell celCentro = new Cell(new Phrase("PROPOSTA", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 18, Font.BOLD)));
            celCentro.Border = Rectangle.NO_BORDER;
            celCentro.HorizontalAlignment = Element.ALIGN_CENTER;
            celCentro.BackgroundColor = new iTextSharp.text.Color(250, 250, 250);

            Cell celDireiro = new Cell(new Chunk(string.Format("{0}{1:00}", "Nº: ", Convert.ToInt32(pro_cod)), FontFactory.GetFont("Arial", 9)));
            celDireiro.Border = Rectangle.NO_BORDER;
            celDireiro.HorizontalAlignment = Element.ALIGN_RIGHT;
            celDireiro.BackgroundColor = new iTextSharp.text.Color(250, 250, 250);

            tableCabecalho.AddCell(celEsquerdo);
            tableCabecalho.AddCell(celCentro);
            tableCabecalho.AddCell(celDireiro);

            /* ------------------------------------------------------------------------------------- */

            iTextSharp.text.Table tableTimble = new iTextSharp.text.Table(2);
            int[] widths = new int[] { 150, 445 };
            tableTimble.Locked = true;
            tableTimble.SetWidths(widths);
            tableTimble.Width = 523;
            tableTimble.DefaultCellBorderWidth = 0;
            tableTimble.BorderWidth = 0;
            tableTimble.Spacing = 5;

            Cell celTitulo = new Cell(new Phrase(rowWebsite.web_titulo + " " + rowWebsite.web_slogan, FontFactory.GetFont(FontFactory.HELVETICA, 14, Font.BOLD)));
            celTitulo.Add(new Phrase("\n" + rowWebsite.web_endereco + " CEP:" + rowWebsite.web_cep + " " + rowWebsite.web_cidade + " " + rowWebsite.web_estado, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
            celTitulo.Add(new Phrase("\nSite:" + HttpContext.Current.Request.Url.Authority + " E-mail:" + rowWebsite.web_email + " Tel.:" + rowWebsite.web_telefone, FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL)));
            celTitulo.Border = Rectangle.NO_BORDER;
            celTitulo.BackgroundColor = new iTextSharp.text.Color(215, 215, 215);

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath + "logo.gif");
            img.Alignment = Element.ALIGN_LEFT | iTextSharp.text.Image.TEXTWRAP;
            img.ScaleAbsolute(50, 60);

            Cell celLogo = new Cell();
            celLogo.Border = Rectangle.NO_BORDER;
            celLogo.HorizontalAlignment = Element.ALIGN_RIGHT;
            celLogo.BackgroundColor = new iTextSharp.text.Color(215, 215, 215);
            celLogo.AddElement(img);

            tableTimble.AddCell(celLogo);
            tableTimble.AddCell(celTitulo);

            /* ------------------------------------------------------------------------------------- */

            iTextSharp.text.Image imgRWD = DrawText(Path.GetTempPath() + @"\rwd.jpg", "RWD Sistemas Web - www.rwd.net.br");
            imgRWD.ScalePercent(62f);
            imgRWD.Alignment = Element.ALIGN_RIGHT | iTextSharp.text.Image.TEXTWRAP;
            imgRWD.Border = 0;
            imgRWD.SetAbsolutePosition(26, 296);
            document.Add(imgRWD);

            /* ------------------------------------------------------------------------------------- */

            iTextSharp.text.Table table = new iTextSharp.text.Table(1);
            table.Width = 100;
            table.DefaultCellBorderWidth = 0;
            table.BorderWidth = 0;
            table.Spacing = 5;

            Cell cell = new Cell();
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new Cell(new Phrase("DADOS PESSOAIS\n", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new Cell();
            cell.VerticalAlignment = Element.ALIGN_LEFT;

            cell.Add(campoRegistro("Nome do Proponente: ", rowClienteProposta.cli_nome, " CPF: ", rowClienteProposta.cli_cpf));
            cell.Add(campoRegistro("RG: ", rowClienteProposta.cli_rg, " Data de Expedição: ", string.Format("{0:d}", rowClienteProposta.cli_dt_emissao)));
            cell.Add(campoRegistro("Data de Nascimento: ", string.Format("{0:d}", rowClienteProposta.cli_nasc), " Sexo: ", rowClienteProposta.cli_sexo));
            cell.Add(campoRegistro("Nome da Mãe: ", rowClienteProposta.cli_mae, " Nome do Pai: ", rowClienteProposta.cli_pai));
            cell.Add(campoRegistro("Natutalidade: ", rowClienteProposta.cli_naturalidade, " UF: ", rowClienteProposta.cli_natural_uf));
            cell.Add(campoRegistro("Telefone 1: ", rowClienteProposta.cli_telefone, " Telefone 2: ", rowClienteProposta.cli_telefone2));
            table.AddCell(cell);

            /* ------------------------------------------------------------------------------------- */

            cell = new Cell();
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new Cell(new Phrase("DADOS RESIDENCIAIS\n", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new Cell();
            cell.Add(campoRegistro("Endereço: ", rowClienteProposta.cli_endereco, string.Empty, string.Empty));
            cell.Add(campoRegistro("Ponto de Referência: ", rowClienteProposta.cli_referencia, string.Empty, string.Empty));
            cell.Add(campoRegistro("CEP: ", rowClienteProposta.cli_cep, " Bairro: ", rowClienteProposta.cli_bairro));
            cell.Add(campoRegistro("Cidade: ", rowClienteProposta.cli_cidade, " UF: ", rowClienteProposta.cli_uf));
            table.AddCell(cell);

            /* ------------------------------------------------------------------------------------- */

            cell = new Cell();
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new Cell(new Phrase("DADOS DO BENEFÍCIO\n", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new Cell();
            cell.Add(campoRegistro("NB: ", rowProposta.pro_nb, " NIT: ", rowProposta.pro_nit));
            cell.Add(campoRegistro("Valor da renda: ", string.Format("{0:C2}", rowClienteProposta.cli_renda), string.Empty, string.Empty));
            cell.Add(campoRegistro("Espécie do Benefício: ", rowProposta.pro_especie, string.Empty, string.Empty));
            cell.Add(campoRegistro("Forma de Recebimento do Benefício: ", rowProposta.pro_forma_receb_benef, " Banco: ", rowProposta.pro_banco));
            cell.Add(campoRegistro("Agência: ", rowProposta.pro_agencia, " Operação: ", rowProposta.pro_operacao));
            cell.Add(campoRegistro("Conta: ", rowProposta.pro_conta, " Valor Solicitado: ", string.Format("{0:C2}", rowProposta.pro_solicitado)));
            cell.Add(campoRegistro("Valor da Prestação: ", string.Format("{0:C2}", rowProposta.pro_prestacao), " Plano: ", rowProposta.pro_plano));
            cell.Add(campoRegistro("Liberação do Empréstimo: ", rowProposta.pro_liber_emprestimo, " Banco: ", rowProposta.pro_banco_emprestimo));
            cell.Add(campoRegistro("Cidade: ", rowProposta.pro_cidade_emprestimo, " Agência: ", rowProposta.pro_agencia_emprestimo));
            cell.Add(campoRegistro("Operação: ", rowProposta.pro_operacao_emprestimo, " Conta: ", rowProposta.pro_conta_emprestimo));
            table.AddCell(cell);

            /* ------------------------------------------------------------------------------------- */

            cell = new Cell();
            cell.Border = Rectangle.NO_BORDER;
            table.AddCell(cell);

            cell = new Cell(new Phrase("DADOS DO OPERADOR/CORRETOR\n", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            /* ------------------------------------------------------------------------------------- */

            iTextSharp.text.Table tabelaOper = new iTextSharp.text.Table(2);
            tabelaOper.Width = 100;
            tabelaOper.DefaultCellBorderWidth = 0;
            tabelaOper.BorderWidth = 0;
            tabelaOper.Spacing = 2;
            tabelaOper.SetWidths(new int[] { 297, 297 });

            cntrUsuario objCntrUsuario = new cntrUsuario();
            DS_Site.UsuarioRow rowUsuario = objCntrUsuario.SelecionaUsuario(rowProposta.pro_usuario);
            cntrLoja objCntrLoja = new cntrLoja();

            string cidade = objCntrLoja.SelecionaLoja(rowUsuario.usu_loja).loj_cidade.ToLower();

            char primeiraLetra = char.ToUpper(cidade[0]);
            cidade = primeiraLetra + cidade.Substring(1);

            Cell celulaOper = new Cell();
            celulaOper.Border = Rectangle.LEFT_BORDER;
            celulaOper.Add(campoRegistro("Nome: ", "Corretor".Equals(rowUsuario.usu_funcao) ? rowUsuario.usu_nome_completo : rowUsuario.usu_nome + " (" + rowUsuario.usu_funcao + ")", "Corretor".Equals(rowUsuario.usu_funcao) ? " Código: " : string.Empty, "Corretor".Equals(rowUsuario.usu_funcao) ? rowUsuario.usu_cod : string.Empty));
            tabelaOper.AddCell(celulaOper);

            celulaOper = new Cell();
            celulaOper.Border = Rectangle.RIGHT_BORDER;
            celulaOper.Add(campoRegistro("Loja: ", objCntrLoja.SelecionaLoja(rowUsuario.usu_loja).loj_nome, " Cidade: ", cidade));
            tabelaOper.AddCell(celulaOper);

            if ("Corretor".Equals(rowUsuario.usu_funcao))
            {
                celulaOper = new Cell();
                celulaOper.Border = Rectangle.LEFT_BORDER;
                celulaOper.Add(campoRegistro("Banco: ", rowUsuario.usu_banco, " Agência: ", rowUsuario.usu_agencia));
                tabelaOper.AddCell(celulaOper);

                celulaOper = new Cell();
                celulaOper.Border = Rectangle.RIGHT_BORDER;
                celulaOper.Add(campoRegistro("Conta: ", rowUsuario.usu_conta, " Operação: ", rowUsuario.usu_operacao));
                tabelaOper.AddCell(celulaOper);
            }

            /* ------------------------------------------------------------------------------------- */

            iTextSharp.text.Table tableObs = new iTextSharp.text.Table(1);
            tableObs.Width = 100;
            tableObs.DefaultCellBorderWidth = 0;
            tableObs.BorderWidth = 0;
            tableObs.Spacing = 5;

            Cell cellObs = new Cell();
            cellObs.Border = Rectangle.TOP_BORDER;
            tableObs.AddCell(cellObs);

            cellObs = new Cell(new Phrase("OBSERVAÇÃO", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD)));
            cellObs.HorizontalAlignment = Element.ALIGN_CENTER;
            tableObs.AddCell(cellObs);

            cellObs = new Cell();
            Paragraph paragrafo = new Paragraph();
            paragrafo.Alignment = Element.ALIGN_JUSTIFIED;
            paragrafo.Add(new Phrase(rowProposta.pro_observacoes, FontFactory.GetFont("Verdana", 8, Font.NORMAL)));
            cellObs.Add(paragrafo);
            tableObs.AddCell(cellObs);

            /* ------------------------------------------------------------------------------------- */

            document.Add(tableTimble);
            document.Add(tableCabecalho);
            document.Add(table);
            document.Add(tabelaOper);
            document.Add(tableObs);

            if (!string.IsNullOrEmpty(rowProposta.pro_doc1) && File.Exists(docsPath + rowProposta.pro_doc1))
            {
                iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(docsPath + rowProposta.pro_doc1);
                img1.Alignment = Element.ALIGN_CENTER;

                if (img1.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                }

                document.NewPage();
                document.Add(img1);
            }
            if (!string.IsNullOrEmpty(rowProposta.pro_doc2) && File.Exists(docsPath + rowProposta.pro_doc2))
            {
                iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(docsPath + rowProposta.pro_doc2);
                img2.Alignment = Element.ALIGN_CENTER;

                if (img2.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                }

                document.NewPage();
                document.Add(img2);
            }
            if (!string.IsNullOrEmpty(rowProposta.pro_doc3) && File.Exists(docsPath + rowProposta.pro_doc3))
            {
                iTextSharp.text.Image img3 = iTextSharp.text.Image.GetInstance(docsPath + rowProposta.pro_doc3);
                img3.Alignment = Element.ALIGN_CENTER;

                if (img3.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                }

                document.NewPage();
                document.Add(img3);
            }
            if (!string.IsNullOrEmpty(rowProposta.pro_doc4) && File.Exists(docsPath + rowProposta.pro_doc4))
            {
                iTextSharp.text.Image img4 = iTextSharp.text.Image.GetInstance(docsPath + rowProposta.pro_doc4);
                img4.Alignment = Element.ALIGN_CENTER;

                if (img4.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                }

                document.NewPage();
                document.Add(img4);
            }
            if (!string.IsNullOrEmpty(rowProposta.pro_doc5) && File.Exists(docsPath + rowProposta.pro_doc5))
            {
                iTextSharp.text.Image img5 = iTextSharp.text.Image.GetInstance(docsPath + rowProposta.pro_doc5);
                img5.Alignment = Element.ALIGN_CENTER;

                if (img5.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A5.Rotate());
                }

                document.NewPage();
                document.Add(img5);
            }

            document.Close();

            return memoryStream;
        }

        private static Paragraph campoRegistro(string negrito1, string normal1, string negrito2, string normal2)
        {
            Phrase tb1, tb2 = default(Phrase);
            Phrase tn1, tn2 = default(Phrase);
            Paragraph paragrafo = new Paragraph();
            Font textoNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.NORMAL);
            Font textoBold = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.BOLD);

            tb1 = new Phrase(negrito1, textoBold);
            tn1 = new Phrase(normal1, textoNormal);
            tb2 = new Phrase(negrito2, textoBold);
            tn2 = new Phrase(normal2, textoNormal);
            paragrafo.Add(tb1);
            paragrafo.Add(tn1);
            paragrafo.Add(tb2);
            paragrafo.Add(tn2);

            return paragrafo;
        }

        private iTextSharp.text.Image DrawText(string ImagePath, string text)
        {
            try
            {
                System.Drawing.Color FontColor = System.Drawing.Color.Black;
                System.Drawing.Color FontBackColor = System.Drawing.Color.White;
                string FontName = "Arial";
                int FontSize = 8;
                int ImageHeight = 14;
                int ImageWidth = 200;
                System.Drawing.Bitmap ImageText = new System.Drawing.Bitmap(ImageWidth, ImageHeight);

                System.Drawing.Graphics ImageGraphics = System.Drawing.Graphics.FromImage(ImageText);

                System.Drawing.Font ImageFont = new System.Drawing.Font(FontName, FontSize);
                System.Drawing.PointF ImagePointF = new System.Drawing.PointF(2, 2);
                System.Drawing.SolidBrush BrushForeColor = new System.Drawing.SolidBrush(FontColor);
                System.Drawing.SolidBrush BrushBackColor = new System.Drawing.SolidBrush(FontBackColor);

                ImageGraphics.FillRectangle(BrushBackColor, 0, 0, ImageWidth, ImageHeight);
                ImageGraphics.DrawString(text, ImageFont, BrushForeColor, ImagePointF);

                saveJpeg(ImagePath, RotateImg(ImageText, -90.0f, System.Drawing.Color.Transparent), 100L);
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }

            return iTextSharp.text.Image.GetInstance(ImagePath);
        }

        public static System.Drawing.Bitmap RotateImg(System.Drawing.Bitmap bmp, float angle, System.Drawing.Color bkColor)
        {
            int w = bmp.Width;
            int h = bmp.Height;
            System.Drawing.Imaging.PixelFormat pf = default(System.Drawing.Imaging.PixelFormat);
            if (bkColor == System.Drawing.Color.Transparent)
            {
                pf = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = bmp.PixelFormat;
            }

            System.Drawing.Bitmap tempImg = new System.Drawing.Bitmap(w, h, pf);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(tempImg);
            g.Clear(bkColor);
            g.DrawImageUnscaled(bmp, 0, 0);
            g.Dispose();

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddRectangle(new System.Drawing.RectangleF(0f, 0f, w, h));
            System.Drawing.Drawing2D.Matrix mtrx = new System.Drawing.Drawing2D.Matrix();

            mtrx.Rotate(angle);

            System.Drawing.RectangleF rct = path.GetBounds(mtrx);
            System.Drawing.Bitmap newImg = new System.Drawing.Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pf);
            g = System.Drawing.Graphics.FromImage(newImg);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tempImg, 0, 0);
            g.Dispose();
            tempImg.Dispose();

            return newImg;
        }

        private void saveJpeg(string path, System.Drawing.Bitmap img, long quality)
        {

            System.Drawing.Imaging.EncoderParameter qualityParam = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            System.Drawing.Imaging.ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        private System.Drawing.Imaging.ImageCodecInfo getEncoderInfo(string mimeType)
        {
            System.Drawing.Imaging.ImageCodecInfo[] codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();

            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        protected void ButtonBusca_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxUsuario.Text.Trim().Length > 0)
                {
                    DS_Site.PropostaDataTable dtProposta = cntrProposta.SelecionaPropostaUsuario(TextBoxUsuario.Text.Trim());
                    GridView1.DataSource = dtProposta;
                    GridView1.DataBind();

                    GridView1.Visible = User.IsInRole("Administrador") || User.IsInRole("Operador") || User.IsInRole("Corretor");

                    ButtonLista.Enabled = dtProposta.Count < 2;

                    if (GridView1.Rows.Count == 0)
                        Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "naoEncontrado", "alert('Nenhum registro encontrato para o código " + TextBoxUsuario.Text + "');", true);
                    else
                        TextBoxUsuario.Text = string.Empty;
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "campoVazio", "alert('Informe um valor completo para pesquisa!');", true);
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "naoEncontrado", "alert('Nenhum registro encontrato para o código " + TextBoxUsuario.Text + "');", true);
            }
        }

        protected void ButtonLista_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }
}
