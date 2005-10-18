using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site.Controle;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Site.Visao
{
    public partial class Corretor : System.Web.UI.Page
    {
        string senhaDoc;
        cntrWebsite objCntrWebsite = new cntrWebsite();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Cache["Titulo"] != null)
            {
                Page.Title = Cache.Get("Titulo").ToString() + " - Corretores";
            }
            else
            {
                Page.Title = ChamaTitulo() + " - Corretores";
            }

            Label26.Visible = TextBoxFormalizacao.Visible = Button1.Visible = User.IsInRole("Administrador") || User.IsInRole("Operador");

            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    DS_Site.WebsiteRow rowWebsite = objCntrWebsite.SelecionaWebSite();
                    string termo = "Ao PROCESSAR E UTILIZAR OS SEUS DADOS PESSOAIS, nos comprometemos com os seguintes pontos:\n\n" +
                        "  1. Seus dados pessoais serão processados e utilizados apenas por à " + rowWebsite.web_titulo +
                        " e suas informações pessoais não serão transferidas para terceiros.\n\n" +
                        "  2. Nós iremos arquivar apenas os dados necessários para os procedimentos relativos ao cadastro do corretor.\n" +
                        "      Ao fornecer seus dados pessoais e enviar este formulário, você está concordando com o armazenamento e o uso deles, desde que relacionados ao cadastro.\n\n" +
                        "  3. Para proteger suas informações contra qualquer acesso desautorizado ou mal uso, seus dados pessoais serão criptografados em documento digital e protegidos por uma senha de segurança.\n\n" +
                        "Por favor, se você tem alguma dúvida entre em contato através do e-mail: " + rowWebsite.web_email;
                    TextBoxTermosUso.Text = termo;
                }
                else
                {
                    Label27.Visible = false;
                    TextBoxTermosUso.Visible = false;
                }
            }
        }

        protected void ButtonEnvia_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (!Page.IsValid) return;
            {
                string nomeAnexo = "Cadastro-" + Util.Util.SubstituiCaractEspacAcentos(DateTime.Now + " " + TextBoxNome.Text.Trim()).ToLower() + ".pdf";

                try
                {
                    try
                    {
                        EnviaEmail(nomeAnexo);
                    }

                    catch (Exception)
                    {
                        ButtonEnvia.Enabled = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Erro", "alert('Ocorreu um erro ao enviar, verifique suas informações e tente novamente!'); window.location='Corretor.aspx';", true);
                    }

                }
                finally
                {
                    LimpaControles(this);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso", @"alert('Solicitação submetida com sucesso!\n\nConsulte seu e-mail e verifique o recebimento desta solicitação.\n\nATENÇÃO!\nAnote a sua senha abaixo, para visualizar e imprimir o documento lhe enviado.\n\nSenha de Segurança: " + senhaDoc + "'); window.location='Corretor.aspx';", true);
                }

            }

        }

        private MemoryStream GeraFormularioPDF(string senha)
        {
            DS_Site.WebsiteRow rowWebsite = objCntrWebsite.SelecionaWebSite();

            string imagePath = Server.MapPath("~/Arquivos/image/");

            Document document = new Document(PageSize.A4, 36, 36, 36, 36);

            MemoryStream memoryStream = new MemoryStream();

            PdfWriter pdfW = PdfWriter.GetInstance(document, memoryStream);
            
            if(!string.IsNullOrEmpty(senha)) pdfW.SetEncryption(PdfWriter.STRENGTH128BITS, senha, senha, PdfWriter.AllowAssembly);

            document.AddTitle("Formulário de solicitação de cadastro de corretor - Gerado online");
            document.AddAuthor("Maciço CRED");
            document.AddSubject("Cadastro de Corretor - www.macicocred.com.br");
            document.AddKeywords("cadastro, corretor, vendas, online, macicocred, rwd");
            document.AddHeader("Corretor", "Cadastro");
            document.AddCreationDate();
            document.AddProducer();

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

            Cell celEsquerdo = new Cell(new Chunk("Data emissão: " + string.Format("{0:d}", DateTime.Now), FontFactory.GetFont("Arial", 9)));
            celEsquerdo.Border = Rectangle.NO_BORDER;
            celEsquerdo.HorizontalAlignment = Element.ALIGN_LEFT;
            celEsquerdo.BackgroundColor = new iTextSharp.text.Color(250, 250, 250);

            Cell celCentro = new Cell();
            celCentro.Border = Rectangle.NO_BORDER;
            celCentro.HorizontalAlignment = Element.ALIGN_CENTER;
            celCentro.BackgroundColor = new iTextSharp.text.Color(250, 250, 250);

            Cell celDireiro = new Cell(new Chunk("Cadastro sujeito à análise", FontFactory.GetFont("Arial", 9)));
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

            iTextSharp.text.Table tableTitulo = new iTextSharp.text.Table(1);
            tableTitulo.Width = 100;
            tableTitulo.DefaultCellBorderWidth = 0;
            tableTitulo.BorderWidth = 0;
            tableTitulo.Spacing = 5;

            Cell cell = new Cell(new Phrase("CADASTRO DE CORRETOR", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 18, Font.BOLD)));
            cell.Border = Rectangle.NO_BORDER;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tableTitulo.AddCell(cell);
            cell = new Cell(new Phrase(" "));
            cell.Border = Rectangle.NO_BORDER;
            tableTitulo.AddCell(cell);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela1 = new PdfPTable(1);
            tabela1.WidthPercentage = 100;

            PdfPCell celula1 = new PdfPCell();
            celula1 = new PdfPCell(campoTexto("NOME: ", TextBoxNome.Text.ToUpper()));
            tabela1.AddCell(celula1);

            celula1 = new PdfPCell(campoTexto("ENDEREÇO RESIDENCIAL: ", TextBoxEndResidencial.Text.ToUpper()));
            tabela1.AddCell(celula1);

            celula1 = new PdfPCell(campoTexto("ENDEREÇO COMERCIAL: ", TextBoxEndComercial.Text.ToUpper()));
            tabela1.AddCell(celula1);

            celula1 = new PdfPCell(campoTexto("E-MAIL: ", TextBoxEmail.Text.ToLower()));
            tabela1.AddCell(celula1);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela2 = new PdfPTable(3);
            tabela2.WidthPercentage = 100;
            tabela2.SetWidths(new int[] { 220, 220, 155 });

            PdfPCell celula2 = new PdfPCell();
            tabela2.AddCell(campoTexto("BAIRRO: ", TextBoxBairro.Text.ToUpper()));
            tabela2.AddCell(campoTexto("CIDADE: ", TextBoxCidade.Text.ToUpper()));
            tabela2.AddCell(campoTexto("UF: ", DropDownListEstado.SelectedValue));

            tabela2.AddCell(campoTexto("TEL. FIXO: ", TextBoxTel.Text));
            tabela2.AddCell(campoTexto("TEL. CELULAR: ", TextBoxCel.Text));
            tabela2.AddCell(campoTexto("CEP: ", TextBoxCep.Text));

            tabela2.AddCell(campoTexto("CPF: ", TextBoxCpf.Text));
            tabela2.AddCell(campoTexto("RG: ", TextBoxRg.Text));
            tabela2.AddCell(campoTexto("DT NASC: ", TextBoxNascimneto.Text));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela2_1 = new PdfPTable(3);
            tabela2_1.WidthPercentage = 100;
            tabela2_1.SetWidths(new int[] { 285, 155, 155 });

            tabela2_1.AddCell(campoTexto("BANCO: ", DropDownListBanco.SelectedValue.ToUpper()));
            tabela2_1.AddCell(campoTexto("AGÊNCIA: ", TextBoxAgencia.Text));
            tabela2_1.AddCell(campoTexto("CONTA: ", TextBoxConta.Text));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela3 = new PdfPTable(2);
            tabela3.WidthPercentage = 100;
            tabela3.SetWidths(new int[] { 298, 298 });

            PdfPCell celula3 = new PdfPCell();
            tabela3.AddCell(campoTexto("TIPO DE CONTA: ", DropDownListTipo.SelectedValue.ToUpper()));
            tabela3.AddCell(campoTexto("OPERAÇÃO: ", TextBoxOperacao.Text));

            tabela3.AddCell(campoTexto("META PROPOSTA (PRODUÇÃO)", string.Empty));
            tabela3.AddCell(campoTexto("R$: ", TextBoxMeta.Text));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela4 = new PdfPTable(1);
            tabela4.WidthPercentage = 100;

            PdfPCell celula4 = new PdfPCell();
            celula4 = new PdfPCell(new Phrase("ATIVIDADES ANTERIORES", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD)));
            celula4.HorizontalAlignment = Element.ALIGN_CENTER;
            tabela4.AddCell(celula4);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela5 = new PdfPTable(2);
            tabela5.WidthPercentage = 100;
            tabela5.SetWidths(new int[] { 298, 298 });

            PdfPCell celula5Esquerda = new PdfPCell(campoTexto("ATIVIDADE", string.Empty));
            celula5Esquerda.HorizontalAlignment = Element.ALIGN_CENTER;
            tabela5.AddCell(celula5Esquerda);

            PdfPCell celula5Direita = new PdfPCell(campoTexto("CONTATO", string.Empty));
            celula5Direita.HorizontalAlignment = Element.ALIGN_CENTER;
            tabela5.AddCell(celula5Direita);

            tabela5.AddCell(campoTexto(string.Empty, TextBoxAtiv1.Text.ToUpper()));
            tabela5.AddCell(campoTexto(string.Empty, TextBoxCont1.Text.ToUpper()));

            tabela5.AddCell(campoTexto(string.Empty, TextBoxAtiv2.Text.ToUpper()));
            tabela5.AddCell(campoTexto(string.Empty, TextBoxCont2.Text.ToUpper()));

            tabela5.AddCell(campoTexto(string.Empty, TextBoxAtiv3.Text.ToUpper()));
            tabela5.AddCell(campoTexto(string.Empty, TextBoxCont3.Text.ToUpper()));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela6 = new PdfPTable(1);
            tabela6.WidthPercentage = 100;

            PdfPCell celula6 = new PdfPCell();
            celula6 = new PdfPCell(new Phrase("FORMALIZAÇÃO (DESCRIÇÃO OBRIGATÓRIA)", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula6.HorizontalAlignment = Element.ALIGN_CENTER;
            tabela6.AddCell(celula6);

            PdfPCell celula7 = new PdfPCell();
            celula7 = new PdfPCell(campoTexto(string.Empty, TextBoxFormalizacao.Text.ToUpper()));
            celula7.FixedHeight = 110;
            tabela6.AddCell(celula7);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela7 = new PdfPTable(1);
            tabela7.WidthPercentage = 100;

            PdfPCell celula8 = new PdfPCell();
            celula8 = new PdfPCell(new Phrase("TERMO DE RESPONSABILIDADE", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.BOLD)));
            celula8.HorizontalAlignment = Element.ALIGN_CENTER;
            celula8.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            celula8.PaddingTop = 5;
            tabela7.AddCell(celula8);

            Paragraph paragrafo1 = new Paragraph();
            paragrafo1.Add(new Phrase("             Eu "+TextBoxNome.Text.ToUpper()+", abaixo assinado e devidamente qualificado, na condição de corretor autônomo, " +
                "declaro-me fiel depositário do material da " + rowWebsite.web_titulo.ToUpper() + ", que se " +
                "destina à angariação de contratos de consignação, bem como de senha de acesso pessoal a banco(s). Estou ciente de que " +
                "responderei civil e criminalmente pelo uso indevido que fizer do aludido material, ao mesmo tempo em que me obrigo a " +
                "prestar as indispensáveis contas da produção alcançada, sempre que instalado a fazê-lo, além de promover a entrega " +
                "imediata dos contratos e quaisquer outros documentos porventura assinados pelos novos clientes angariados. " +
                "Fico ciente que caso através da mesma ocorra fraude nos contratos, me responsabilizo pelo ressarcimento do " +
                "valor integral ao banco de origem. Esclareço, por último, que os meus serviços são de natureza autônoma, " +
                "não me achando adstrito a horário e subordinação hierárquica, e não possuindo, destarte, nenhum vínculo " +
                "trabalhista com a entidade acima mencionada.", FontFactory.GetFont("Verdana", 9, Font.NORMAL)));

            paragrafo1.Alignment = Element.ALIGN_JUSTIFIED;
            paragrafo1.SetLeading(1.0f, 1.0f);
            celula8.AddElement(paragrafo1);
            celula8.PaddingTop = 10;
            celula8.PaddingBottom = 10;
            tabela7.AddCell(celula8);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela8 = new PdfPTable(2);
            tabela8.WidthPercentage = 100;
            tabela8.SetWidths(new int[] { 298, 298 });

            tabela8.AddCell(new Phrase("LOCAL E DATA:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela8.AddCell(new Phrase("ASSINATURA:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela9 = new PdfPTable(1);
            tabela9.WidthPercentage = 100;

            PdfPCell celula9 = new PdfPCell();
            celula9 = new PdfPCell(new Phrase("DOCUMENTOS NECESSÁRIOS (CÓPIAS):", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD)));
            celula9.PaddingTop = 5;
            celula9.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            tabela9.AddCell(celula9);

            Paragraph paragrafo2 = new Paragraph();
            paragrafo2.Add(new Phrase("•	RG\n•	CPF\n•	COMPROVANTE DE RESIDÊNCIA\n•	COMPROVANTE DE CONTA EM BANCO (CORRENTE ou POUPANÇA)", FontFactory.GetFont("Verdana", 9, Font.NORMAL)));
            paragrafo2.SetLeading(1.0f, 1.0f);
            celula9.AddElement(paragrafo2);
            celula9.Border = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
            celula9.PaddingTop = 5;
            celula9.PaddingBottom = 5;
            tabela9.AddCell(celula9);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela10 = new PdfPTable(2);
            tabela10.WidthPercentage = 100;
            tabela10.SetWidths(new int[] { 298, 298 });

            PdfPCell celula10VaziaEsquerda = new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10VaziaEsquerda.Border = Rectangle.NO_BORDER;
            celula10VaziaEsquerda.FixedHeight = 40;
            tabela10.AddCell(celula10VaziaEsquerda);

            PdfPCell celula10VaziaDireita = new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10VaziaDireita.Border = Rectangle.NO_BORDER;
            celula10VaziaDireita.FixedHeight = 40;
            tabela10.AddCell(celula10VaziaDireita);

            PdfPCell celula10Esquerda1 = new PdfPCell(new Phrase("______________________________", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Esquerda1.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Esquerda1.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Esquerda1);

            PdfPCell celula10Direita1 = new PdfPCell(new Phrase("______________________________", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Direita1.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Direita1.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Direita1);

            PdfPCell celula10Esquerda2 = new PdfPCell(new Phrase("Visto da Empresa", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Esquerda2.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Esquerda2.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Esquerda2);

            PdfPCell celula10Direita2 = new PdfPCell(new Phrase("Supervisor", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Direita2.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Direita2.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Direita2);

            /* ------------------------------------------------------------------------------------- */

            document.Add(tableTimble);
            document.Add(tableCabecalho);
            document.Add(tableTitulo);
            document.Add(tabela1);
            document.Add(tabela2);
            document.Add(tabela2_1);
            document.Add(tabela3);
            document.Add(tabela4);
            document.Add(tabela5);
            document.Add(tabela6);
            document.Add(tabela7);
            document.Add(tabela8);
            document.Add(tabela9);
            document.Add(tabela10);

            document.Close();

            return memoryStream;
        }

        private MemoryStream GeraFormularioManualPDF()
        {
            DS_Site.WebsiteRow rowWebsite = objCntrWebsite.SelecionaWebSite();

            string imagePath = Server.MapPath("~/Arquivos/image/");

            Document document = new Document(PageSize.A4, 36, 36, 36, 36);

            MemoryStream memoryStream = new MemoryStream();

            PdfWriter pdfW = PdfWriter.GetInstance(document, memoryStream);

            document.AddTitle("Formulário de solicitação de cadastro de corretor - Preenchimento manual");
            document.AddAuthor("Maciço CRED");
            document.AddSubject("Cadastro de Corretor - www.macicocred.com.br");
            document.AddKeywords("cadastro, corretor, vendas, macicocred, rwd");
            document.AddHeader("Corretor", "Cadastro");
            document.AddCreationDate();
            document.AddProducer();

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

            Cell celEsquerdo = new Cell(new Chunk("Data emissão: " + string.Format("{0:d}", DateTime.Now), FontFactory.GetFont("Arial", 9)));
            celEsquerdo.Border = Rectangle.NO_BORDER;
            celEsquerdo.HorizontalAlignment = Element.ALIGN_LEFT;
            celEsquerdo.BackgroundColor = new iTextSharp.text.Color(250, 250, 250);

            Cell celCentro = new Cell();
            celCentro.Border = Rectangle.NO_BORDER;
            celCentro.HorizontalAlignment = Element.ALIGN_CENTER;
            celCentro.BackgroundColor = new iTextSharp.text.Color(250, 250, 250);

            Cell celDireiro = new Cell(new Chunk("Cadastro sujeito à análise", FontFactory.GetFont("Arial", 9)));
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

            iTextSharp.text.Table tableTitulo = new iTextSharp.text.Table(1);
            tableTitulo.Width = 100;
            tableTitulo.DefaultCellBorderWidth = 0;
            tableTitulo.BorderWidth = 0;
            tableTitulo.Spacing = 5;

            Cell cell = new Cell(new Phrase("CADASTRO DE CORRETOR", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 18, Font.BOLD)));
            cell.Border = Rectangle.NO_BORDER;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tableTitulo.AddCell(cell);
            cell = new Cell(new Phrase(" "));
            cell.Border = Rectangle.NO_BORDER;
            tableTitulo.AddCell(cell);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela1 = new PdfPTable(1);
            tabela1.WidthPercentage = 100;

            PdfPCell celula1 = new PdfPCell();
            celula1 = new PdfPCell(new Phrase("NOME:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela1.AddCell(celula1);

            celula1 = new PdfPCell(new Phrase("ENDEREÇO RESIDENCIAL:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela1.AddCell(celula1);

            celula1 = new PdfPCell(new Phrase("ENDEREÇO COMERCIAL:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela1.AddCell(celula1);

            celula1 = new PdfPCell(new Phrase("E-MAIL:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela1.AddCell(celula1);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela2 = new PdfPTable(3);
            tabela2.WidthPercentage = 100;
            tabela2.SetWidths(new int[] { 220, 220, 155 });

            PdfPCell celula2 = new PdfPCell();
            tabela2.AddCell(new Phrase("BAIRRO:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela2.AddCell(new Phrase("CIDADE:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela2.AddCell(new Phrase("UF:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            tabela2.AddCell(new Phrase("TELEFONE:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela2.AddCell(new Phrase("CELULAR:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela2.AddCell(new Phrase("CEP:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            tabela2.AddCell(new Phrase("CPF:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela2.AddCell(new Phrase("RG:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela2.AddCell(new Phrase("DT NASC:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela2_1 = new PdfPTable(3);
            tabela2_1.WidthPercentage = 100;
            tabela2_1.SetWidths(new int[] { 285, 155, 155 });

            tabela2_1.AddCell(new Phrase("BANCO:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela2_1.AddCell(new Phrase("AGÊNCIA:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela2_1.AddCell(new Phrase("CONTA:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela3 = new PdfPTable(2);
            tabela3.WidthPercentage = 100;
            tabela3.SetWidths(new int[] { 298, 298 });

            PdfPCell celula3 = new PdfPCell();
            tabela3.AddCell(new Phrase("TIPO:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela3.AddCell(new Phrase("OPERAÇÃO:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            tabela3.AddCell(new Phrase("META PROPOSTA (PRODUÇÃO)", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela3.AddCell(new Phrase("R$:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela4 = new PdfPTable(1);
            tabela4.WidthPercentage = 100;

            PdfPCell celula4 = new PdfPCell();
            celula4 = new PdfPCell(new Phrase("ATIVIDADES ANTERIORES", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD)));
            celula4.HorizontalAlignment = Element.ALIGN_CENTER;
            tabela4.AddCell(celula4);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela5 = new PdfPTable(2);
            tabela5.WidthPercentage = 100;
            tabela5.SetWidths(new int[] { 298, 298 });

            PdfPCell celula5Esquerda = new PdfPCell(new Phrase("ATIVIDADE", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula5Esquerda.HorizontalAlignment = Element.ALIGN_CENTER;
            tabela5.AddCell(celula5Esquerda);

            PdfPCell celula5Direita = new PdfPCell(new Phrase("CONTATO", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula5Direita.HorizontalAlignment = Element.ALIGN_CENTER;
            tabela5.AddCell(celula5Direita);

            tabela5.AddCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela5.AddCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            tabela5.AddCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela5.AddCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            tabela5.AddCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela5.AddCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela6 = new PdfPTable(1);
            tabela6.WidthPercentage = 100;

            PdfPCell celula6 = new PdfPCell();
            celula6 = new PdfPCell(new Phrase("FORMALIZAÇÃO (DESCRIÇÃO OBRIGATÓRIA)", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula6.HorizontalAlignment = Element.ALIGN_CENTER;
            tabela6.AddCell(celula6);

            PdfPCell celula7 = new PdfPCell();
            celula7 = new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula7.FixedHeight = 110;
            tabela6.AddCell(celula7);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela7 = new PdfPTable(1);
            tabela7.WidthPercentage = 100;

            PdfPCell celula8 = new PdfPCell();
            celula8 = new PdfPCell(new Phrase("TERMO DE RESPONSABILIDADE", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.BOLD)));
            celula8.HorizontalAlignment = Element.ALIGN_CENTER;
            celula8.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            celula8.PaddingTop = 5;
            tabela7.AddCell(celula8);

            Paragraph paragrafo1 = new Paragraph();
            paragrafo1.Add(new Phrase("             Eu, abaixo assinado e devidamente qualificado, na condição de corretor autônomo, " +
                "declaro-me fiel depositário do material da " + rowWebsite.web_titulo.ToUpper() + ", que se " +
                "destina à angariação de contratos de consignação, bem como de senha de acesso pessoal a banco(s). Estou ciente de que " +
                "responderei civil e criminalmente pelo uso indevido que fizer do aludido material, ao mesmo tempo em que me obrigo a " +
                "prestar as indispensáveis contas da produção alcançada, sempre que instalado a fazê-lo, além de promover a entrega " +
                "imediata dos contratos e quaisquer outros documentos porventura assinados pelos novos clientes angariados. " +
                "Fico ciente que caso através da mesma ocorra fraude nos contratos, me responsabilizo pelo ressarcimento do " +
                "valor integral ao banco de origem. Esclareço, por último, que os meus serviços são de natureza autônoma, " +
                "não me achando adstrito a horário e subordinação hierárquica, e não possuindo, destarte, nenhum vínculo " +
                "trabalhista com a entidade acima mencionada.", FontFactory.GetFont("Verdana", 9, Font.NORMAL)));

            paragrafo1.Alignment = Element.ALIGN_JUSTIFIED;
            paragrafo1.SetLeading(1.0f, 1.0f);
            celula8.AddElement(paragrafo1);
            celula8.PaddingTop = 10;
            celula8.PaddingBottom = 10;
            tabela7.AddCell(celula8);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela8 = new PdfPTable(2);
            tabela8.WidthPercentage = 100;
            tabela8.SetWidths(new int[] { 298, 298 });

            tabela8.AddCell(new Phrase("LOCAL E DATA:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            tabela8.AddCell(new Phrase("ASSINATURA:", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela9 = new PdfPTable(1);
            tabela9.WidthPercentage = 100;

            PdfPCell celula9 = new PdfPCell();
            celula9 = new PdfPCell(new Phrase("DOCUMENTOS NECESSÁRIOS (CÓPIAS):", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.BOLD)));
            celula9.PaddingTop = 5;
            celula9.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
            tabela9.AddCell(celula9);

            Paragraph paragrafo2 = new Paragraph();
            paragrafo2.Add(new Phrase("•	RG\n•	CPF\n•	COMPROVANTE DE RESIDÊNCIA\n•	COMPROVANTE DE CONTA EM BANCO (CORRENTE ou POUPANÇA)", FontFactory.GetFont("Verdana", 9, Font.NORMAL)));
            paragrafo2.SetLeading(1.0f, 1.0f);
            celula9.AddElement(paragrafo2);
            celula9.Border = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
            celula9.PaddingTop = 5;
            celula9.PaddingBottom = 5;
            tabela9.AddCell(celula9);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela10 = new PdfPTable(2);
            tabela10.WidthPercentage = 100;
            tabela10.SetWidths(new int[] { 298, 298 });

            PdfPCell celula10VaziaEsquerda = new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10VaziaEsquerda.Border = Rectangle.NO_BORDER;
            celula10VaziaEsquerda.FixedHeight = 40;
            tabela10.AddCell(celula10VaziaEsquerda);

            PdfPCell celula10VaziaDireita = new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10VaziaDireita.Border = Rectangle.NO_BORDER;
            celula10VaziaDireita.FixedHeight = 40;
            tabela10.AddCell(celula10VaziaDireita);

            PdfPCell celula10Esquerda1 = new PdfPCell(new Phrase("______________________________", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Esquerda1.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Esquerda1.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Esquerda1);

            PdfPCell celula10Direita1 = new PdfPCell(new Phrase("______________________________", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Direita1.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Direita1.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Direita1);

            PdfPCell celula10Esquerda2 = new PdfPCell(new Phrase("Visto da Empresa", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Esquerda2.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Esquerda2.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Esquerda2);

            PdfPCell celula10Direita2 = new PdfPCell(new Phrase("Supervisor", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Direita2.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Direita2.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Direita2);

            /* ------------------------------------------------------------------------------------- */

            document.Add(tableTimble);
            document.Add(tableCabecalho);
            document.Add(tableTitulo);
            document.Add(tabela1);
            document.Add(tabela2);
            document.Add(tabela2_1);
            document.Add(tabela3);
            document.Add(tabela4);
            document.Add(tabela5);
            document.Add(tabela6);
            document.Add(tabela7);
            document.Add(tabela8);
            document.Add(tabela9);
            document.Add(tabela10);

            document.Close();

            return memoryStream;
        }

        private static Paragraph campoTexto(string normal, string negrito)
        {
            Phrase pn = default(Phrase);
            Phrase pb = default(Phrase);

            Paragraph paragrafo = new Paragraph();
            Font textoNormal = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL);
            Font textoBold = FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD);

            pn = new Phrase(normal, textoNormal);
            pb = new Phrase(negrito, textoBold);

            paragrafo.Add(pn);
            paragrafo.Add(pb);

            return paragrafo;
        }

        void EnviaEmail(string nomeAnexo)
        {
            DS_Site.WebsiteRow Site = objCntrWebsite.SelecionaWebSite();

            try
            {

                string UrlSite = string.Concat("http://", HttpContext.Current.Request.Url.Authority);
                
                string CorpoEmailAdmin = "<br /><table align='center' width='600' border='1' cellspacing='10' cellpadding='0' " +
                                    "bordercolor='#CCCCCC' style='font-family:Tahoma, Geneva, sans-serif;font-size:small'>" +
                                    "<tr>" +
                                    "<td bgcolor='#EEEEEE' valign='top' style='border:0'>" +
                                    "<table width='600' border='0' cellspacing='10' cellpadding='0'>" +
                                    "<tr>" +
                                    "<td>" +
                                    "<a href='" + UrlSite + "' target='_blank'>" +
                                    "<img src='" + UrlSite + "/Arquivos/image/logo.gif' border='0' align='middle' /></a>" +
                                    "</td>" +
                                    "<td align='center'><strong>CADASTRO DE CORRETOR</strong></td>" +
                                    "</tr>" +
                                    "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0;'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'>" +
                                      "<tr>" +
                                        "<td width='599'><p>Prezado <strong>Administrador</strong> do site " + Site.web_titulo + ",</p>" +
                                          "<p>Segue em anexo, documento para sua análise referente o pedido de <strong>Cadastro de Corretor</strong> solicitado por <strong>" + TextBoxNome.Text.ToUpper() +
                                          "</strong> em "+DateTime.Now.ToShortDateString()+"." +
                                          "</p></td>" +
                                        "</tr>" +
                                      "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td style='border:0'></td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'> " +
                                      "<tr>" +
                                        "<td width='100'>E-mail do solicitante:</td>" +
                                        "<td> " + TextBoxEmail.Text.ToLower() + " </td>" +
                                      "</tr>" +
                                      "<tr>" +
                                        "<td>Senha de segurança do documento do solicitante:</td>" +
                                        "<td> " + GeraSenha() + " </td>" +
                                        "</tr>" +
                                      "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'>" +
                                    "<tr>" +
                                    "<td>IP do solicitante:</td>" +
                                    "<td>" + Request.UserHostAddress + "</td>" +
                                    "</tr>" +
                                    "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td style='border:0'></td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td style='border:0;font-size:smaller' align='center'>&copy; " +
                                    "<a href='" + UrlSite + "' target='_blank'>" + HttpContext.Current.Request.Url.Authority +
                                    "</a> | Produzido por: <a href='" + ConfigurationManager.AppSettings["AdminSite"].ToString() + "' target='_blank'>RWD</a>" +
                                    "</td>" +
                                    "</tr>" +
                                    "</table>";

                string CorpoEmail = "<br /><table align='center' width='600' border='1' cellspacing='10' cellpadding='0' " +
                                    "bordercolor='#CCCCCC' style='font-family:Tahoma, Geneva, sans-serif;font-size:small'>" +
                                    "<tr>" +
                                    "<td bgcolor='#EEEEEE' valign='top' style='border:0'>" +
                                    "<table width='600' border='0' cellspacing='10' cellpadding='0'>" +
                                    "<tr>" +
                                    "<td>" +
                                    "<a href='" + UrlSite + "' target='_blank'>" +
                                    "<img src='" + UrlSite + "/Arquivos/image/logo.gif' border='0' align='middle' /></a>" +
                                    "</td>" +
                                    "<td align='center'><strong>CADASTRO DE CORRETOR</strong></td>" +
                                    "</tr>" +
                                    "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0;'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'>" +
                                      "<tr>" +
                                        "<td width='599'><p>Prezado(a) <strong>" + TextBoxNome.Text.ToUpper() + "</strong>,</p>" +
                                          "<p>Segue em anexo o documento referente sua solicitação do <strong>Cadastro de Corretor</strong> no site <a href='" + UrlSite + "' target='_blank'>" + HttpContext.Current.Request.Url.Authority + "</a> em "+DateTime.Now.ToShortDateString()+".<br />" +
                                          "Abra o documento informando sua senha de segurança anotada no momento da solicitação, confira seus dados, leia o termo de responsabilidade, imprima, assine e entregue em nossa loja para análise." +
                                          "</p></td>" +
                                        "</tr>" +
                                      "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                     "<td style='border:0'></td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'> " +
                                      "<tr>" +
                                        "<td>Observação:</td>" +
                                        "<td>Caso tenha se esquecido de anotar sua senha de segurança entre em contato com <a href='mailto:" +
                                        Site.web_email + "' target='_blank'>" + Site.web_titulo + "</a> solicitando a senha ou realize um novo cadastro.</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                        "<td>Novo cadastro:</td>" +
                                        "<td><a href='" + UrlSite + "/Corretor.aspx' target='_blank'>Fazer nova solicitação de cadastro</a></td>" +
                                        "</tr>" +
                                      "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'>" +
                                    "<tr>" +
                                    "<td>IP do seu servidor:</td>" +
                                    "<td>" + Request.UserHostAddress + "</td>" +
                                    "</tr>" +
                                    "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td style='border:0'></td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td style='border:0;font-size:smaller' align='center'>&copy; " +
                                    "<a href='" + UrlSite + "' target='_blank'>" + HttpContext.Current.Request.Url.Authority +
                                    "</a> | Produzido por: <a href='" + ConfigurationManager.AppSettings["AdminSite"].ToString() + "' target='_blank'>RWD</a>" +
                                    "</td>" +
                                    "</tr>" +
                                    "</table>";

                //Admin
                Util.Util.EnviaEmailAnexo(
                    TextBoxNome.Text.ToUpper() + "<" + TextBoxEmail.Text.ToLower() + ">",
                    "Administrador<" + Site.web_email + ">",
                    "Solicitação de Cadastro de Corretor",
                    CorpoEmailAdmin.ToString(), nomeAnexo, GeraFormularioPDF(string.Empty));
                //solicitante
                Util.Util.EnviaEmailAnexo(
                    Site.web_titulo + "<" + Site.web_email + ">",
                    TextBoxNome.Text.ToUpper() + "<" + TextBoxEmail.Text.ToLower() + ">",
                    "Sua solicitação de Cadastro de Corretor",
                    CorpoEmail.ToString(), nomeAnexo, GeraFormularioPDF(senhaDoc));
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void LimpaControles(Control pai)
        {
            foreach (Control ctl in pai.Controls) if (ctl is TextBox) ((TextBox)ctl).Text = string.Empty;
                else if (ctl.Controls.Count > 0) LimpaControles(ctl);
            foreach (Control ctl in pai.Controls) if (ctl is DropDownList) ((DropDownList)ctl).SelectedIndex = -1;
                else if (ctl.Controls.Count > 0) LimpaControles(ctl);
        }

        private string ChamaTitulo()
        {
            return objCntrWebsite.SelecionaWebSite().web_titulo;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Response.ContentType = "application/pdf";
                    Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
                    Response.AppendHeader("Content-Type", "application/pdf");
                    Response.AppendHeader("Content-Disposition", "attachment; filename=Formulario-cadastro-corretor.pdf");
                    Response.OutputStream.Write(GeraFormularioManualPDF().GetBuffer(), 0, GeraFormularioManualPDF().GetBuffer().Length);
                    Response.End();
                }
                catch (Exception ex)
                {
                    throw (new Exception(ex.Message));
                }
            }
            finally
            {
                Response.OutputStream.Flush();
                Response.OutputStream.Close();
            }
        }

        private iTextSharp.text.Image DrawText(string ImagePath, string text)
        {
            try
            {
                System.Drawing.Color FontColor = System.Drawing.Color.Black;
                System.Drawing.Color FontBackColor = System.Drawing.Color.White;
                string FontName = "Arial";
                int FontSize = 8;
                int ImageHeight = 25;
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

        private string GeraSenha()
        {
            int Tamanho = 4; // Numero de digitos da senha
            string senha = string.Empty;
            for (int i = 0; i < Tamanho; i++)
            {
                Random random = new Random();
                int codigo = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString();
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            senhaDoc = senha;

            return senha;
        }

    }
}