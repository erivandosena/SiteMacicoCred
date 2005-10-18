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

namespace Site.Visao.administradores
{
    public partial class CadComissao : System.Web.UI.Page
    {
        string cod;
        string fechado;
        string codContrato;

        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonEncerrar.OnClientClick = @"if (confirm('ATENÇÃO!\nAo encerrar este relatório, não poderá fazer qualquer outra alteração na data atual. Deseja encerrar?') == false) return false;";

            if (DropDownListNomeOper.Enabled = string.IsNullOrEmpty(Request.QueryString["pg"]))
            {
                cod = "";
            }
            else
            {
                cod = Request.QueryString["pg"];
            }

            if (DropDownListNomeOper.Enabled = string.IsNullOrEmpty(Request.QueryString["con"]))
            {
                codContrato = "";
            }
            else
            {
                codContrato = Request.QueryString["con"];
            }

            if (!IsPostBack)
            {
                DropDownListBanco.Items.Insert(0, new System.Web.UI.WebControls.ListItem(string.Empty, string.Empty));
                DropDownListBanco.AppendDataBoundItems = true;

                CarregaCorretores();

                try
                {
                    if (!"".Equals(cod))
                    {
                        cntrComissao objCntrComissao = new cntrComissao();
                        DS_Site.ComissaoRow rowComissao = objCntrComissao.SelecionaComissao(cod);

                        TextBoxDtAber.Text = string.Format("{0:G}", rowComissao.com_data_abertura);
                        TextBoxDtFech.Text = string.Format("{0:G}", rowComissao.com_data_fechamento);

                        fechado = rowComissao.com_status;
                        DropDownListNomeOper.SelectedValue = rowComissao.com_usuario;

                        CarregaPropostasAprovadas();

                        ButtonConfirma.Text = "Adicionar";

                        CarregaGrid();

                        ButtonConfirma.Enabled = rowComissao.com_status.Equals("A");
                        ButtonEncerrar.Enabled = GridView1.Rows.Count > 0 && rowComissao.com_status.Equals("A");
                        Label3.Visible = TextBoxDtFech.Visible = ButtonReabrir.Enabled = rowComissao.com_status.Equals("F");
                        
                        TimeSpan dif = DateTime.Now.Subtract(rowComissao.com_data_fechamento);
                        ButtonReabrir.Enabled = dif.Days < 30 && rowComissao.com_status.Equals("F");

                        ButtonImprimir.Enabled = GridView1.Rows.Count > 0 && rowComissao.com_status.Equals("F");

                        if (!"".Equals(codContrato))
                        {
                            cntrContrato objCntrContrato = new cntrContrato();
                            DS_Site.ContratoRow rowContrato = objCntrContrato.SelecionaContrato(codContrato);

                            TextBoxContrato.Text = rowContrato.con_numero;
                            TextBoxData.Text = string.Format("{0:d}", rowContrato.con_data_liberacao);
                            DropDownListComissao.SelectedValue = rowContrato.con_taxa.ToString();
                            TextBoxValor.Text = string.Format("{0:n}",rowContrato.con_valor);
                            DropDownListTipo.SelectedValue = rowContrato.con_tipo;

                            cntrProposta objCntrProposta = new cntrProposta();
                            DS_Site.PropostaRow rowProposta = objCntrProposta.SelecionaProposta(rowContrato.con_proposta);

                            DropDownListBanco.SelectedValue = rowProposta.pro_bancos;
                            DropDownListTipo.SelectedValue = rowProposta.pro_tipo;
                            DropDownListPlano.SelectedValue = rowProposta.pro_plano;
                            TextBoxValor.Text = string.Format("{0:n}", rowProposta.pro_solicitado);
                            TextBoxValorPrestacao.Text = string.Format("{0:n}", rowProposta.pro_prestacao);
                            TextBoxPag.Text = string.Format("{0:n}", Convert.ToDecimal(TextBoxValor.Text) * Convert.ToDecimal(DropDownListComissao.SelectedValue) / 100);
                        }

                    }
                    else
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                        ButtonEncerrar.Enabled = ButtonReabrir.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("ListaComissao.aspx");
                }
            }
        }

        protected void ButtonConfirma_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(cod))
                {
                    cntrUsuario objCntrUsuario = new cntrUsuario();

                    DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();
                    DS_Site.ComissaoRow rowComissao = dtComissao.NewComissaoRow();

                    rowComissao.com_data_abertura = DateTime.Now;
                    rowComissao.com_data_fechamento = DateTime.Now.AddMonths(1);
                    rowComissao.com_loja = objCntrUsuario.SelecionaUsuario(DropDownListNomeOper.SelectedValue).usu_loja;
                    rowComissao.com_usuario = objCntrUsuario.SelecionaUsuario(DropDownListNomeOper.SelectedValue).usu_cod;
                    rowComissao.com_status = "A";

                    cntrComissao objCntrComissao = new cntrComissao();
                    objCntrComissao.Salva(rowComissao);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso", "alert('Relatório aberto com sucesso!'); window.location='ListaComissao.aspx';", true);
                }
                else
                {
                    DS_Site.ContratoDataTable dtContrato = new DS_Site.ContratoDataTable();
                    DS_Site.ContratoRow rowContrato = dtContrato.NewContratoRow();

                    rowContrato.con_numero = TextBoxContrato.Text.Trim();
                    rowContrato.con_data_liberacao = Convert.ToDateTime(string.Format("{0:d}", TextBoxData.Text));
                    rowContrato.con_taxa = Convert.ToDouble(DropDownListComissao.SelectedValue);
                    rowContrato.con_valor = Convert.ToDecimal(TextBoxValor.Text);
                    rowContrato.con_tipo = DropDownListTipo.SelectedValue;
                    rowContrato.con_proposta = DropDownListPro.SelectedValue;
                    rowContrato.con_comissao = cod;

                    cntrContrato objCntrContrato = new cntrContrato();
                    if (objCntrContrato.Salva(rowContrato))
                    {
                        DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();
                        cntrProposta objCntrProposta = new cntrProposta();
                        DS_Site.PropostaRow rowProposta = dtProposta.NewPropostaRow();

                        rowProposta = objCntrProposta.SelecionaProposta(DropDownListPro.SelectedValue);
                        rowProposta.pro_bancos = DropDownListBanco.SelectedValue;
                        rowProposta.pro_tipo = DropDownListTipo.SelectedValue;
                        rowProposta.pro_plano = DropDownListPlano.SelectedValue;
                        rowProposta.pro_solicitado = Convert.ToDecimal(TextBoxValor.Text);
                        rowProposta.pro_prestacao = Convert.ToDecimal(TextBoxValorPrestacao.Text); 
                        rowProposta.pro_status = "F";

                        if (objCntrProposta.Salva(rowProposta))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso", "alert('Adicionado com sucesso!'); window.location='CadComissao.aspx?pg=" + cod + "';", true);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaComissao.aspx");
        }

        private void CarregaCorretores()
        {
            DS_Site.UsuarioDataTable dtUsuario = cntrUsuario.SelecionaOperadorOuCorretor("Operador","Corretor");
            cntrLoja objCntrLoja = new cntrLoja();

            foreach (DS_Site.UsuarioRow rowUsuario in dtUsuario.Rows)
            {
                if(rowUsuario.usu_funcao.Equals("Operador"))
                    DropDownListNomeOper.Items.Add(new System.Web.UI.WebControls.ListItem(rowUsuario.usu_nome + " - " + rowUsuario.usu_funcao + " - " + objCntrLoja.SelecionaLoja(rowUsuario.usu_loja).loj_cidade, rowUsuario.usu_cod));
                else
                DropDownListNomeOper.Items.Add(new System.Web.UI.WebControls.ListItem(rowUsuario.usu_nome_completo + " - " + rowUsuario.usu_cod + " - " + objCntrLoja.SelecionaLoja(rowUsuario.usu_loja).loj_cidade, rowUsuario.usu_cod));
            }
            DropDownListNomeOper.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        }

        private void CarregaPropostasAprovadas()
        {
            DS_Site.PropostaDataTable dtProposta = cntrProposta.SelecionaPropostaUsuarioStatus(DropDownListNomeOper.SelectedValue, "A");
            cntrCliente objCntrCliente = new cntrCliente();

            foreach (DS_Site.PropostaRow rowProposta in dtProposta.Rows)
            {
                DropDownListPro.Items.Add(new System.Web.UI.WebControls.ListItem(objCntrCliente.SelecionaCliente(rowProposta.pro_cliente).cli_nome + " - " + objCntrCliente.SelecionaCliente(rowProposta.pro_cliente).cli_cpf + " - " + string.Format("Proposta N.{0:00}", Convert.ToInt32(rowProposta.pro_cod)), rowProposta.pro_cod));
            }
            DropDownListPro.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        }

        protected void DropDownListPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DropDownListPro.SelectedValue))
            {
                cntrProposta objCntrProposta = new cntrProposta();
                cntrCliente objCntrCliente = new cntrCliente();

                DS_Site.PropostaRow rowProposta = objCntrProposta.SelecionaProposta(DropDownListPro.SelectedValue);

                TextBoxNome.Text = objCntrCliente.SelecionaCliente(rowProposta.pro_cliente).cli_nome;
                TextBoxCpf.Text = objCntrCliente.SelecionaCliente(rowProposta.pro_cliente).cli_cpf;
                DropDownListBanco.SelectedValue = rowProposta.pro_bancos;
                DropDownListPlano.SelectedValue = rowProposta.pro_plano;
                TextBoxValor.Text = string.Format("{0:n}", rowProposta.pro_solicitado);
                DropDownListTipo.SelectedValue = rowProposta.pro_tipo;
                TextBoxValorPrestacao.Text = string.Format("{0:n}", rowProposta.pro_prestacao);
            }
            else
            {
                TextBoxNome.Text = TextBoxCpf.Text = TextBoxValor.Text = TextBoxData.Text = TextBoxContrato.Text = TextBoxPag.Text = string.Empty;
                DropDownListTipo.SelectedIndex = -1;
                DropDownListComissao.SelectedIndex = -1;
                DropDownListPlano.SelectedIndex = -1;
                DropDownListBanco.SelectedIndex = -1;
            }
        }

        protected void DropDownListComissao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DropDownListComissao.SelectedValue) && !string.IsNullOrEmpty(TextBoxValor.Text))
            {
                TextBoxPag.Text = string.Format("{0:n}", Convert.ToDecimal(TextBoxValor.Text) * Convert.ToDecimal(DropDownListComissao.SelectedValue) / 100);
            }
            else
            {
                DropDownListComissao.SelectedIndex = -1;
                TextBoxPag.Text = string.Empty;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Text = string.Format("{0:n}", Convert.ToDecimal(GridView1.DataKeys[e.Row.RowIndex].Values[2].ToString()) * Convert.ToDecimal(GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString()) / 100);
                
                bool situacao = !string.IsNullOrEmpty(fechado) && fechado.Equals("A");
                Button btnExclui = e.Row.Cells[6].Controls[0] as Button;
                btnExclui.Enabled = situacao;

                e.Row.Cells[0].Enabled = !situacao;

                if (situacao)
                    btnExclui.OnClientClick = "if (confirm('Tem certeza que deseja incluir este registro?') == false) return false;";
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            cntrContrato objCntrContrato = new cntrContrato();

            var contrato = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            var proposta = objCntrContrato.SelecionaContrato(contrato);

            try
            {

                if (cntrContrato.Exclui(contrato))
                {
                    DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();
                    DS_Site.PropostaRow rowProposta = dtProposta.NewPropostaRow();
                    cntrProposta objCntrProposta = new cntrProposta();

                    rowProposta = objCntrProposta.SelecionaProposta(proposta.con_proposta);
                    rowProposta.pro_status = "A";

                    if (objCntrProposta.Salva(rowProposta))
                    {
                        CarregaGrid();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso", "alert('Removido com sucesso!'); window.location='CadComissao.aspx?pg=" + cod + "';", true);
                    }

                }
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
                DS_Site.ContratoDataTable dtContrato = cntrContrato.SelecionaContratoComissao(cod);
                GridView1.DataSource = dtContrato;
                GridView1.DataBind();

                Panel3.Visible = dtContrato.Count > 0;
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Decimal Total = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {
                Total += Decimal.Parse(row.Cells[5].Text);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = "Total";
                e.Row.Cells[5].Text = string.Format("{0:c}", Total);
            }
        }

        protected void ButtonEncerrar_Click(object sender, EventArgs e)
        {
            cntrComissao objCntrComissao = new cntrComissao();
            cntrUsuario objCntrUsuario = new cntrUsuario();

            Decimal Total = 0;
            var comissao = objCntrComissao.SelecionaComissao(cod);
            var corretor = objCntrUsuario.SelecionaUsuario(comissao.com_usuario);

            DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();
            DS_Site.ComissaoRow rowComissao = dtComissao.NewComissaoRow();
            rowComissao = comissao;
            rowComissao.com_data_fechamento = DateTime.Now;
            rowComissao.com_status = "F";

            objCntrComissao.Salva(rowComissao);

            CarregaGrid();

            foreach (GridViewRow row in GridView1.Rows)
            {
                Total += Decimal.Parse(row.Cells[5].Text);
            }

            if (objCntrUsuario.SelecionaUsuario(comissao.com_usuario).usu_funcao.Equals("Corretor"))
            {

                cntrWebsite objCntrWebsite = new cntrWebsite();
                DS_Site.WebsiteRow Site = objCntrWebsite.SelecionaWebSite();
                try
                {
                    string UrlSite = string.Concat("http://", HttpContext.Current.Request.Url.Authority);
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
                                        "<td align='center'><strong>RELATÓRIO DE COMISSÃO</strong></td>" +
                                        "</tr>" +
                                        "</table>" +
                                        "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                        "<td bgcolor='#F9F9F9' valign='top' style='border:0;'>" +
                                        "<table border='0' cellspacing='10' cellpadding='0'>" +
                                          "<tr>" +
                                            "<td width='599'><p>Prezado(a) <strong>" + corretor.usu_nome_completo + "</strong>,</p>" +
                                              "<p>Já está disponível para conferência o relatório com suas comissões.<br />Acesse sua <a href='" + UrlSite +
                                              "/Login.aspx' target='_blank'>área restrita</a> do site " + HttpContext.Current.Request.Url.Authority + " para obter mais detalhes." +
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
                                            "<td>Data do fechamento:</td>" +
                                            "<td>" + string.Format("{0:G}", comissao.com_data_fechamento) + "</td>" +
                                          "</tr>" +
                                          "<tr>" +
                                            "<td>Total de comissão:</td>" +
                                            "<td> " + string.Format("{0:c}", Total) + "</td>" +
                                            "</tr>" +
                                          "</table>" +
                                        "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                        "<td bgcolor='#F9F9F9' valign='top' style='border:0'>" +
                                        "<table border='0' cellspacing='10' cellpadding='0'>" +
                                        "<tr>" +
                                        "<td width='100'>IP do emissor:</td>" +
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

                    Util.Util.EnviaEmail(
                        Site.web_titulo + "<" + Site.web_email + ">",
                        corretor.usu_nome_completo + "<" + corretor.usu_email + ">",
                        "Relatório",
                        CorpoEmail.ToString());

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso", "alert('Relatório de comissão fechado com sucesso!'); window.location='ListaComissao.aspx';", true);
                }
                catch (Exception ex)
                {
                    throw (new Exception(ex.Message));
                }
            }

        }

        protected void ButtonReabrir_Click(object sender, EventArgs e)
        {
            DS_Site.ComissaoDataTable dtComissao = new DS_Site.ComissaoDataTable();
            cntrComissao objCntrComissao = new cntrComissao();

            DS_Site.ComissaoRow rowComissao = dtComissao.NewComissaoRow();
            rowComissao = objCntrComissao.SelecionaComissao(cod);
            rowComissao.com_data_abertura = DateTime.Now;
            rowComissao.com_status = "A";

            objCntrComissao.Salva(rowComissao);

            CarregaGrid();
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso", "alert('Relatório de comissão aberto com sucesso!'); window.location='ListaComissao.aspx';", true);
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            cntrUsuario objCntrUsuario = new cntrUsuario();
            DS_Site.UsuarioRow rowUsuario = objCntrUsuario.SelecionaUsuario(DropDownListNomeOper.SelectedValue);
            try
            {
                try
                {
                    Response.ContentType = "application/pdf";
                    Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
                    Response.AppendHeader("Content-Type", "application/pdf");
                    Response.AppendHeader("Content-Disposition", "attachment; filename=Recibo-comissao-" + Util.Util.SubstituiCaractEspacAcentos(rowUsuario.usu_nome_completo + " " + rowUsuario.usu_cod).ToLower() + ".pdf");
                    Response.OutputStream.Write(GeraFormularioRelatorio().GetBuffer(), 0, GeraFormularioRelatorio().GetBuffer().Length);
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

        private MemoryStream GeraFormularioRelatorio()
        {
            cntrWebsite objCntrWebsite = new cntrWebsite();
            DS_Site.WebsiteRow rowWebsite = objCntrWebsite.SelecionaWebSite();

            cntrComissao objCntrComissao = new cntrComissao();
            DS_Site.ComissaoRow rowComissao = objCntrComissao.SelecionaComissao(cod);

            cntrCliente objCntrCliente = new cntrCliente();
            cntrProposta objCntrProposta = new cntrProposta();
            cntrUsuario objCntrUsuario = new cntrUsuario();

            Decimal ValorTotal = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                ValorTotal += Decimal.Parse(row.Cells[5].Text);
            }

            string imagePath = Server.MapPath("~/Arquivos/image/");

            Document document = new Document(PageSize.A4, 36, 36, 36, 36);

            MemoryStream memoryStream = new MemoryStream();

            PdfWriter pdfW = PdfWriter.GetInstance(document, memoryStream);

            document.AddTitle("Formulário de contratos faturados do corretor");
            document.AddAuthor("Maciço CRED");
            document.AddSubject("Fechamento de Relatório - www.macicocred.com.br");
            document.AddKeywords("relatorio, corretor, vendas, macicocred, rwd");
            document.AddHeader("Corretor", "Relatório");
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

            Cell celDireiro = new Cell(new Chunk("Data fechamento: " + string.Format("{0:G}", rowComissao.com_data_fechamento), FontFactory.GetFont("Arial", 9)));
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

            Cell cell = new Cell(new Phrase("RECIBO DE COMISSÃO", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 18, Font.BOLD)));
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

            Util.Util extenco = new Util.Util();
            extenco.SetNumero(ValorTotal);

            Paragraph paragrafo1 = new Paragraph();
            paragrafo1.Add(new Phrase("Recebi do correspondente " + rowWebsite.web_titulo + " a quantia de " + extenco.ToString() + ", conforme valor abaixo especificado, referente ao pagamento de serviços prestados no período de " + string.Format("{0:d}", rowComissao.com_data_abertura) + " a " + string.Format("{0:d}", rowComissao.com_data_fechamento) + ", " +
                "declarando que não trabalho com exclusividade pessoal para a empresa, e que não tenho, nem aceito vínculo empregatício com a mesma, estando livre "+
                "na condição de vendedor autônomo, avulso ou freelancer, para prestar serviços ao mesmo tempo para outras empresas até mesmo concorrentes, confirmando neste "+
                "ato plena e total quitação do valor ora recebido, e nada tendo a reclamar, a qualquer título no futuro.", FontFactory.GetFont("Arial", 12)));

            paragrafo1.Alignment = Element.ALIGN_JUSTIFIED;
            paragrafo1.SetLeading(1.0f, 1.0f);
            celula1.AddElement(paragrafo1);
            celula1.PaddingTop = 5;
            celula1.PaddingLeft = 5;
            celula1.PaddingRight = 5;
            celula1.PaddingBottom = 10;
            tabela1.AddCell(celula1);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela2 = new PdfPTable(8);
            tabela2.WidthPercentage = 100;
            tabela2.SetWidths(new int[] { 105, 170, 75, 60, 30, 65, 30, 60 });

            PdfPCell celula2 = new PdfPCell();

            tabela2.AddCell(new Phrase("Banco", FontFactory.GetFont("Arial", 8, Font.BOLD)));

            tabela2.AddCell(new Phrase("Cliente", FontFactory.GetFont("Arial", 8, Font.BOLD)));

            tabela2.AddCell(new Phrase("CPF", FontFactory.GetFont("Arial", 8, Font.BOLD)));

            tabela2.AddCell(new Phrase("Liberação", FontFactory.GetFont("Arial", 8, Font.BOLD)));

            tabela2.AddCell(new Phrase("Plano", FontFactory.GetFont("Arial", 8, Font.BOLD)));

            tabela2.AddCell(new Phrase("Valor", FontFactory.GetFont("Arial", 8, Font.BOLD)));

            tabela2.AddCell(new Phrase("Perc", FontFactory.GetFont("Arial", 8, Font.BOLD)));

            tabela2.AddCell(new Phrase("Comissão", FontFactory.GetFont("Arial", 8, Font.BOLD)));

            /* ------------------------------------------------------------------------------------- */

            DS_Site.ContratoDataTable dtContrato = cntrContrato.SelecionaContratoComissao(cod);

            foreach (DS_Site.ContratoRow rowContrato in dtContrato.Rows)
            {
                tabela2.AddCell(new Phrase(objCntrProposta.SelecionaProposta(rowContrato.con_proposta).pro_banco_emprestimo, FontFactory.GetFont("Arial Narrow", 8)));

                tabela2.AddCell(new Phrase(objCntrCliente.SelecionaCliente(objCntrProposta.SelecionaProposta(rowContrato.con_proposta).pro_cliente).cli_nome, FontFactory.GetFont("Arial Narrow", 8)));

                tabela2.AddCell(new Phrase(objCntrCliente.SelecionaCliente(objCntrProposta.SelecionaProposta(rowContrato.con_proposta).pro_cliente).cli_cpf, FontFactory.GetFont("Arial", 8)));

                tabela2.AddCell(new Phrase(string.Format("{0:d}", rowContrato.con_data_liberacao), FontFactory.GetFont("Arial", 8)));

                tabela2.AddCell(new Phrase(objCntrProposta.SelecionaProposta(rowContrato.con_proposta).pro_plano, FontFactory.GetFont("Arial", 8)));

                tabela2.AddCell(new Phrase(string.Format("{0:c}", rowContrato.con_valor), FontFactory.GetFont("Arial", 8)));

                tabela2.AddCell(new Phrase(string.Format("{0:N1}%", rowContrato.con_taxa), FontFactory.GetFont("Arial", 8)));

                tabela2.AddCell(new Phrase(string.Format("{0:c}", (rowContrato.con_valor * (decimal)rowContrato.con_taxa) / 100), FontFactory.GetFont("Arial", 8)));
            }

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela3 = new PdfPTable(1);
            tabela3.WidthPercentage = 100;

            PdfPCell celula3 = new PdfPCell();
            celula3.Border = Rectangle.NO_BORDER;
            celula3.PaddingTop = 10;
            celula3.PaddingBottom = 10;
            tabela3.AddCell(celula3);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela4 = new PdfPTable(2);
            tabela4.WidthPercentage = 100;
            tabela4.SetWidths(new int[] { 298, 298 });

            PdfPCell celula4 = new PdfPCell();
            celula4 = new PdfPCell(new Phrase("VALOR TOTAL ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14, Font.NORMAL)));
            celula4.HorizontalAlignment = 2;
            celula4.PaddingTop = 5;
            celula4.PaddingLeft = 5;
            celula4.PaddingRight = 5;
            celula4.PaddingBottom = 5;
            celula4.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.LEFT_BORDER;
            tabela4.AddCell(celula4);

            celula4 = new PdfPCell(new Phrase(string.Format("{0:c}", ValorTotal), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14, Font.BOLD)));
            celula4.HorizontalAlignment = 0;
            celula4.PaddingTop = 5;
            celula4.PaddingLeft = 5;
            celula4.PaddingRight = 5;
            celula4.PaddingBottom = 10;
            celula4.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER;
            tabela4.AddCell(celula4);

            /* ------------------------------------------------------------------------------------- */

            PdfPTable tabela10 = new PdfPTable(2);
            tabela10.WidthPercentage = 100;
            tabela10.SetWidths(new int[] { 298, 298 });

            PdfPCell celula10VaziaEsquerda = new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10VaziaEsquerda.Border = Rectangle.NO_BORDER;
            celula10VaziaEsquerda.FixedHeight = 50;
            tabela10.AddCell(celula10VaziaEsquerda);

            PdfPCell celula10VaziaDireita = new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10VaziaDireita.Border = Rectangle.NO_BORDER;
            celula10VaziaDireita.FixedHeight = 50;
            tabela10.AddCell(celula10VaziaDireita);

            PdfPCell celula10Esquerda1 = new PdfPCell(new Phrase("______________________________", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Esquerda1.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Esquerda1.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Esquerda1);

            PdfPCell celula10Direita1 = new PdfPCell(new Phrase("______________________________", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Direita1.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Direita1.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Direita1);

            PdfPCell celula10Esquerda2 = new PdfPCell(new Phrase("Empresa\n" + rowWebsite.web_titulo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Esquerda2.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Esquerda2.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Esquerda2);

            PdfPCell celula10Direita2 = new PdfPCell(new Phrase("Corretor\n"+objCntrUsuario.SelecionaUsuario(rowComissao.com_usuario).usu_nome_completo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, Font.NORMAL)));
            celula10Direita2.HorizontalAlignment = Element.ALIGN_CENTER;
            celula10Direita2.Border = Rectangle.NO_BORDER;
            tabela10.AddCell(celula10Direita2);

            /* ------------------------------------------------------------------------------------- */

            document.Add(tableTimble);
            document.Add(tableCabecalho);
            document.Add(tableTitulo);
            document.Add(tabela1);
            document.Add(tabela2);
            document.Add(tabela3);
            document.Add(tabela4);
            document.Add(tabela10);

            document.Close();

            return memoryStream;
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
    }
}