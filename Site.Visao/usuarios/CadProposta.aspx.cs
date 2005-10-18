using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site.Controle;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Site.Util;

namespace Site.Visao.usuarios
{
    public partial class CadProposta : System.Web.UI.Page
    {
        static string clienteProposta;
        static DateTime dataClienteCadastro;
        static string cpfClienteCadastro;
        static string nomeClienteCadastro;
        static string emailClienteCadastro;
        static string senhaClienteCadastro;

        static string usuarioProposta;
        static string statusProposta;
        static DateTime dataPropostaCadastro;

        static string arq1, arq2, arq3, arq4, arq5, pdfDocumentos;
        static string pdfDocumentosCad;
        static string caminho;

        static string caminhoArquivo;

        static string[] _status = { "N", "R", "C", "A", "D", "F" };

        static string cod;
        static string status;

        cntrCliente objCntrCliente = new cntrCliente();
        cntrProposta objCntrProposta = new cntrProposta();
        cntrLoja objCntrLoja = new cntrLoja();
        cntrUsuario objCntrUsuario = new cntrUsuario();

        DS_Site.ClienteDataTable dtCliente = new DS_Site.ClienteDataTable();
        DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            Button btn = ((Button)LoginView1.FindControl("ButtonAceitar") as Button);
            Button btnNegar = ((Button)LoginView1.FindControl("ButtonNegar") as Button);

            if (User.IsInRole("Administrador"))
            {
                btn.OnClientClick = @"if (confirm('ATENÇÃO!\nAo aprovar esta proposta, não poderá fazer qualquer outra alteração. Deseja aprovar?') == false) return false;";
                btnNegar.OnClientClick = @"if (confirm('ATENÇÃO!\nAo negar esta proposta, não poderá fazer qualquer outra alteração. Deseja negar?') == false) return false;";
            }

            if (string.IsNullOrEmpty(Request.QueryString["pg"]))
            {
                cod = "";
            }
            else
            {
                cod = Request.QueryString["pg"];
            }

            if (string.IsNullOrEmpty(Request.QueryString["status"]))
            {
                status = "";
            }
            else
            {
                status = Request.QueryString["status"].ToUpper();
            }

            if (!"".Equals(status))
            {
                string _existe = "";
                foreach (string s in _status)
                {
                    if (s.Equals(status))
                    {
                        _existe = s;
                    }
                }
                if ("".Equals(_existe))
                {
                    Response.Redirect("Default.aspx");
                }

                if (status == "N")
                {
                    if (User.IsInRole("Administrador"))
                    {
                        ButtonSalvar.Text = "Recusar";
                        if ((User.IsInRole("Administrador")) && (User.IsInRole("Operador")) || (User.IsInRole("Administrador")) && (User.IsInRole("Corretor")) || (User.IsInRole("Administrador")) && (User.IsInRole("Operador")) && (User.IsInRole("Corretor")))
                            ButtonSalvar.Text = "Corrigir";
                    }
                    else
                    {
                        ButtonSalvar.Text = "Corrigir";
                    }
                }
                if (status == "C")
                {
                    if ((User.IsInRole("Operador")) || (User.IsInRole("Corretor")))
                    {
                        ButtonSalvar.Text = "Corrigir";
                        if ((User.IsInRole("Administrador")) && (User.IsInRole("Operador")) || (User.IsInRole("Administrador")) && (User.IsInRole("Corretor")) || (User.IsInRole("Administrador")) && (User.IsInRole("Operador")) && (User.IsInRole("Corretor")))
                            ButtonSalvar.Text = "Recusar";
                    }
                    else
                    {
                        ButtonSalvar.Text = "Recusar";
                    }
                }
                if (status == "R")
                {
                    if (User.IsInRole("Administrador"))
                    {
                        ButtonSalvar.Text = "Recusar";
                        ButtonSalvar.Enabled = false;
                        if ((User.IsInRole("Administrador")) && (User.IsInRole("Operador")) || (User.IsInRole("Administrador")) && (User.IsInRole("Corretor")) || (User.IsInRole("Administrador")) && (User.IsInRole("Operador")) && (User.IsInRole("Corretor")))
                        {
                            ButtonSalvar.Text = "Corrigir";
                            ButtonSalvar.Enabled = true;
                        }
                    }
                    else
                    {
                        ButtonSalvar.Text = "Corrigir";
                    }
                }
                if (status == "A" || status == "D" || status == "F")
                {
                    ButtonSalvar.Enabled = false;
                    btn.Enabled = false;
                    btnNegar.Enabled = false;
                }

            }
            if (!"".Equals(cod) && "".Equals(status))
            {
                Response.Redirect("CadProposta.aspx");
            }
            if ("".Equals(cod) && !"".Equals(status))
            {
                Response.Redirect("CadProposta.aspx");
            }

            if (!IsPostBack)
            {
                DropDownListBanco.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
                DropDownListBanco.AppendDataBoundItems = true;

                try
                {
                    if (!"".Equals(cod))
                    {
                        DS_Site.PropostaRow rowProposta = objCntrProposta.SelecionaProposta(cod);

                        TextBoxNb.Text = rowProposta.pro_nb;
                        TextBoxNit.Text = rowProposta.pro_nit;
                        DropDownListEspecie.SelectedValue = rowProposta.pro_especie;
                        DropDownListFormaRec.SelectedValue = rowProposta.pro_forma_receb_benef;
                        DropDownListBancoRec.SelectedValue = rowProposta.pro_banco;
                        TextBoxAgencia.Text = rowProposta.pro_agencia;
                        TextBoxOperacao.Text = rowProposta.pro_operacao;
                        TextBoxConta.Text = rowProposta.pro_conta;
                        TextBoxSolicitado.Text = rowProposta.pro_solicitado.ToString();
                        TextBoxPrestacao.Text = rowProposta.pro_prestacao.ToString();
                        DropDownListPlano.SelectedValue = rowProposta.pro_plano;
                        DropDownListLibEmp.SelectedValue = rowProposta.pro_liber_emprestimo;
                        DropDownListBancoEmp.SelectedValue = rowProposta.pro_banco_emprestimo;
                        TextBoxCidadeBancoEmp.Text = rowProposta.pro_cidade_emprestimo;
                        TextBoxAgenciaEmp.Text = rowProposta.pro_agencia_emprestimo;
                        TextBoxOpAgenciaEmp.Text = rowProposta.pro_operacao_emprestimo;
                        TextBoxContaEmp.Text = rowProposta.pro_conta_emprestimo;
                        BuscaAgente(rowProposta.pro_usuario);
                        TextBoxObs.Text = rowProposta.pro_observacoes;
                        caminhoArquivo = Server.MapPath("~/App_Data/Documentos/") + rowProposta.pro_doc1;
                        statusProposta = rowProposta.pro_status;
                        pdfDocumentosCad = rowProposta.pro_doc1;
                        CarregaCliente(rowProposta.pro_cliente);
                        DropDownListBanco.SelectedValue = rowProposta.pro_bancos;
                        DropDownListTipo.SelectedValue = rowProposta.pro_tipo;
                        dataPropostaCadastro = rowProposta.pro_data;

                        ExibeRecebimentoBeneficio();
                        ExibeLiberacaoEmprestimo();

                        if (!string.IsNullOrEmpty(rowProposta.pro_doc1))
                        {
                            ButtonExcluiArq.Enabled = true;
                            Label48.Visible = true;
                            Label48.Text = Label48.Text + rowProposta.pro_doc1;
                        }
                        else
                        {
                            ButtonExcluiArq.Enabled = false;
                        }

                        if (!rowProposta.pro_status.Equals(status))
                        {
                            Response.Redirect("Default.aspx");
                        }
                    }
                    else
                    {
                        clienteProposta = string.Empty;
                        usuarioProposta = string.Empty;
                        cpfClienteCadastro = string.Empty;
                        nomeClienteCadastro = string.Empty;
                        emailClienteCadastro = string.Empty;
                        senhaClienteCadastro = string.Empty;
                        arq1 = arq2 = arq3 = arq4 = arq5 = string.Empty;
                        pdfDocumentosCad = string.Empty;
                        caminho = string.Empty;
                        statusProposta = string.Empty;
                        cod = string.Empty;
                        status = string.Empty;

                        ButtonAltera.Enabled = !string.IsNullOrEmpty(clienteProposta);

                        if (User.IsInRole("Administrador"))
                        {
                            btn.Enabled = false;
                            if ("".Equals(cod))
                            {
                                btnNegar.Enabled = false;
                            }
                        }

                        BuscaAgente(string.Empty);
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("Default.aspx");
                }
            }

        }

        private DS_Site.UsuarioRow BuscaAgente(string codigo)
        {
            cntrUsuario objCntrUsuario = new cntrUsuario();
            DS_Site.UsuarioRow rowUsuario = objCntrUsuario.SelecionaUsuarioNome(User.Identity.Name);

            if (string.IsNullOrEmpty(codigo))
            {
                usuarioProposta = rowUsuario.usu_cod;
                TextBoxCodCorretor.Text = string.Empty;

                TextBoxAgente.Text = "Corretor".Equals(rowUsuario.usu_funcao) ? rowUsuario.usu_nome_completo + " (Cod. " + rowUsuario.usu_cod + ")" : rowUsuario.usu_nome;
            }
            else
            {
                rowUsuario = objCntrUsuario.SelecionaUsuarioPorCodigo(codigo);
                if (rowUsuario.usu_cod != null)
                {
                    usuarioProposta = rowUsuario.usu_cod;
                    TextBoxCodCorretor.Text = string.Empty;

                    TextBoxAgente.Text = "Corretor".Equals(rowUsuario.usu_funcao) ? rowUsuario.usu_nome_completo + " (Cod. " + rowUsuario.usu_cod + ")" : rowUsuario.usu_nome;
                }
            }

            ButtonCorretor.Enabled = !User.IsInRole("Corretor");
            return rowUsuario;
        }

        private void CarregaCliente(string pCod)
        {
            DS_Site.ClienteRow rowCliente = objCntrCliente.SelecionaCliente(pCod);

            TextBoxNome.Text = rowCliente.cli_nome;
            TextBoxMae.Text = rowCliente.cli_mae;
            TextBoxPai.Text = rowCliente.cli_pai;
            TextBoxCpf.Text = rowCliente.cli_cpf;
            TextBoxRg.Text = rowCliente.cli_rg;
            TextBoxRgDtaEmis.Text = string.Format("{0:d}", rowCliente.cli_dt_emissao);
            TextBoxNatural.Text = rowCliente.cli_naturalidade;
            DropDownListRgUf.SelectedValue = rowCliente.cli_natural_uf;
            TextBoxDatNasc.Text = string.Format("{0:d}", rowCliente.cli_nasc);
            DropDownListSexo.Text = rowCliente.cli_sexo;
            TextBoxTel.Text = rowCliente.cli_telefone;
            TextBoxTel2.Text = rowCliente.cli_telefone2;
            TextBoxEndereco.Text = rowCliente.cli_endereco;
            TextBoxReferencia.Text = rowCliente.cli_referencia;
            TextBoxCep.Text = rowCliente.cli_cep;
            TextBoxBairro.Text = rowCliente.cli_bairro;
            TextBoxCidade.Text = rowCliente.cli_cidade;
            DropDownListUf.Text = rowCliente.cli_uf;
            TextBoxRenda.Text = rowCliente.cli_renda.ToString();
            dataClienteCadastro = rowCliente.cli_data_cadastro;
            emailClienteCadastro = rowCliente.cli_email;
            senhaClienteCadastro = rowCliente.cli_senha;
            cpfClienteCadastro = rowCliente.cli_cpf;
            nomeClienteCadastro = rowCliente.cli_nome;
            clienteProposta = rowCliente.cli_cod;
            TextBoxNb1.Text = rowCliente.cli_nb1;
            TextBoxNb2.Text = rowCliente.cli_nb2;
            if ("".Equals(TextBoxNb.Text.Trim())) TextBoxNb.Text = rowCliente.cli_nb1;

            if (rowCliente.cli_cod == null)
            {
                ButtonAltera.Enabled = true;
                Panel1.Visible = false;
            }
            else
            {
                ButtonAltera.Enabled = true;
                Panel1.Visible = true;
            }

        }

        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(status))
            {
                if (status == "N")
                {
                    statusProposta = "R";
                    if ((User.IsInRole("Administrador")) && (User.IsInRole("Operador")) || (User.IsInRole("Administrador")) && (User.IsInRole("Corretor")) || (User.IsInRole("Administrador")) && (User.IsInRole("Operador")) && (User.IsInRole("Corretor")))
                        statusProposta = "C";
                }
                if (status == "C")
                {
                    statusProposta = "R";
                }
                if (status == "R")
                {
                    statusProposta = "C";
                }
                if (status == "A")
                {
                    statusProposta = "A";
                }
                if (status == "D")
                {
                    statusProposta = "D";
                }
            }
            else
            {
                statusProposta = "N";
            }

            if (!string.IsNullOrEmpty(clienteProposta))
            {
                SalvaCadastro();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "clienteAusente", "alert('É obrigatório indicar um proponente!');", true);
                TextBoxNumeroCpf.Focus();
            }
        }

        private void SalvaCadastro()
        {
            DS_Site.ClienteRow rowCliente = dtCliente.NewClienteRow();
            DS_Site.PropostaRow rowProposta = dtProposta.NewPropostaRow();

            if (FileUpload1.HasFile)
            {
                arq1 = Util.Util.SubstituiCaractEspacAcentos(FileUpload1.FileName).ToLower();
            }
            if (FileUpload2.HasFile)
            {
                arq2 = Util.Util.SubstituiCaractEspacAcentos(FileUpload2.FileName).ToLower();
            }
            if (FileUpload3.HasFile)
            {
                arq3 = Util.Util.SubstituiCaractEspacAcentos(FileUpload3.FileName).ToLower();
            }
            if (FileUpload4.HasFile)
            {
                arq4 = Util.Util.SubstituiCaractEspacAcentos(FileUpload4.FileName).ToLower();
            }
            if (FileUpload5.HasFile)
            {
                arq5 = Util.Util.SubstituiCaractEspacAcentos(FileUpload5.FileName).ToLower();
            }

            bool isValido = true;

            try
            {
                //Salva imagens no disco
                caminho = Server.MapPath("~\\App_Data\\Documentos\\");
                if (FileUpload1.HasFile)
                {
                    FileUpload1.PostedFile.SaveAs(caminho + arq1);
                }
                if (FileUpload2.HasFile)
                {
                    FileUpload2.PostedFile.SaveAs(caminho + arq2);
                }
                if (FileUpload3.HasFile)
                {
                    FileUpload3.PostedFile.SaveAs(caminho + arq3);
                }
                if (FileUpload4.HasFile)
                {
                    FileUpload4.PostedFile.SaveAs(caminho + arq4);
                }
                if (FileUpload5.HasFile)
                {
                    FileUpload5.PostedFile.SaveAs(caminho + arq5);
                }

                //Cria e salva o PDF
                if (FileUpload1.HasFile || FileUpload2.HasFile || FileUpload3.HasFile || FileUpload4.HasFile || FileUpload5.HasFile)
                {
                    FileInfo arquivoExistente = new FileInfo(caminhoArquivo);
                    if (arquivoExistente.Exists)
                    {
                        arquivoExistente.Delete();
                    }

                    string pdf = GeraDocsPDF();

                    pdfDocumentos = pdf.Substring(pdf.LastIndexOf("\\") + 1);

                    //Exclui as imagens do disco
                    FileInfo[] imgs = new FileInfo[5];
                    imgs[0] = new FileInfo(Server.MapPath("~/App_Data/Documentos/") + arq1);
                    imgs[1] = new FileInfo(Server.MapPath("~/App_Data/Documentos/") + arq2);
                    imgs[2] = new FileInfo(Server.MapPath("~/App_Data/Documentos/") + arq3);
                    imgs[3] = new FileInfo(Server.MapPath("~/App_Data/Documentos/") + arq4);
                    imgs[4] = new FileInfo(Server.MapPath("~/App_Data/Documentos/") + arq5);

                    arq1 = string.Empty;
                    arq2 = string.Empty;
                    arq3 = string.Empty;
                    arq4 = string.Empty;
                    arq5 = string.Empty;

                    foreach (FileInfo arquivo in imgs)
                    {
                        if (arquivo.Exists)
                        {
                            arquivo.Delete();
                        }
                    }
                }

                IncluiCampos(rowCliente, rowProposta);

                if (isValido)
                {
                    objCntrCliente.Salva(rowCliente);

                    if (objCntrProposta.Salva(rowProposta))
                    {
                        if ("".Equals(cod))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso1", "alert('Proposta submetida com sucesso!'); window.location='CadProposta.aspx';", true);
                        }

                        if (!"".Equals(status))
                        {
                            if ((status == "N") || (status == "R") || (status == "C") || (status == "A"))
                            {
                                status = "";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Sucesso2", "alert('Proposta submetida com sucesso!'); window.location='ListaPropostas.aspx';", true);
                            }
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "erroArquivo1", "alert('Formato inválido do arquivo de imagem!');", true);
                }
            }
            catch (IOException)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "erroArquivo2", "alert('Erro ao tratar arquivo!');", true);
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "erroSalvar1", "alert('Erro ao enviar dados!');", true);
            }

        }

        private void IncluiCampos(DS_Site.ClienteRow rowCliente, DS_Site.PropostaRow rowProposta)
        {
            if (rowCliente != null)
            {
                rowCliente.cli_cod = clienteProposta;
                rowCliente.cli_nome = nomeClienteCadastro;
                rowCliente.cli_mae = TextBoxMae.Text.Trim().ToUpper();
                rowCliente.cli_pai = TextBoxPai.Text.Trim().ToUpper();
                rowCliente.cli_cpf = cpfClienteCadastro;
                rowCliente.cli_rg = TextBoxRg.Text.Trim();
                rowCliente.cli_dt_emissao = Convert.ToDateTime(string.Format("{0:d}", TextBoxRgDtaEmis.Text.Trim()));
                rowCliente.cli_naturalidade = TextBoxNatural.Text.Trim().ToUpper();
                rowCliente.cli_natural_uf = DropDownListRgUf.Text.Trim();
                rowCliente.cli_nasc = Convert.ToDateTime(string.Format("{0:d}", TextBoxDatNasc.Text.Trim()));
                rowCliente.cli_sexo = DropDownListSexo.Text.Trim();
                rowCliente.cli_telefone = TextBoxTel.Text.Trim();
                rowCliente.cli_telefone2 = TextBoxTel2.Text.Trim();
                rowCliente.cli_endereco = TextBoxEndereco.Text.Trim().ToUpper();
                rowCliente.cli_referencia = TextBoxReferencia.Text.Trim().ToUpper();
                rowCliente.cli_cep = TextBoxCep.Text.Trim();
                rowCliente.cli_bairro = TextBoxBairro.Text.Trim().ToUpper();
                rowCliente.cli_cidade = TextBoxCidade.Text.Trim().ToUpper();
                rowCliente.cli_uf = DropDownListUf.Text.Trim();
                rowCliente.cli_renda = Convert.ToDecimal(TextBoxRenda.Text.Trim());
                rowCliente.cli_data_cadastro = dataClienteCadastro;
                rowCliente.cli_email = emailClienteCadastro;
                rowCliente.cli_senha = senhaClienteCadastro;
            }

            rowProposta.pro_cod = cod;
            rowProposta.pro_nb = TextBoxNb.Text.Trim();
            rowProposta.pro_nit = TextBoxNit.Text.Trim();
            rowProposta.pro_especie = DropDownListEspecie.Text.ToUpper();
            rowProposta.pro_forma_receb_benef = DropDownListFormaRec.Text.ToUpper();
            rowProposta.pro_banco = DropDownListBancoRec.Text.Trim();
            rowProposta.pro_agencia = TextBoxAgencia.Text.Trim();
            rowProposta.pro_operacao = TextBoxOperacao.Text.Trim();
            rowProposta.pro_conta = TextBoxConta.Text.Trim();
            rowProposta.pro_solicitado = Convert.ToDecimal(!string.IsNullOrEmpty(TextBoxSolicitado.Text.Trim()) ? TextBoxSolicitado.Text.Trim() : "0,00");
            rowProposta.pro_prestacao = Convert.ToDecimal(!string.IsNullOrEmpty(TextBoxPrestacao.Text.Trim()) ? TextBoxPrestacao.Text.Trim() : "0,00");
            rowProposta.pro_plano = DropDownListPlano.Text.ToUpper();
            rowProposta.pro_liber_emprestimo = DropDownListLibEmp.Text.ToUpper();
            rowProposta.pro_banco_emprestimo = DropDownListBancoEmp.Text.ToUpper();
            rowProposta.pro_cidade_emprestimo = TextBoxCidadeBancoEmp.Text.Trim().ToUpper();
            rowProposta.pro_agencia_emprestimo = TextBoxAgenciaEmp.Text.Trim();
            rowProposta.pro_operacao_emprestimo = TextBoxOpAgenciaEmp.Text.Trim();
            rowProposta.pro_conta_emprestimo = TextBoxContaEmp.Text.Trim();
            rowProposta.pro_usuario = usuarioProposta;
            rowProposta.pro_observacoes = TextBoxObs.Text.Trim();
            rowProposta.pro_doc1 = pdfDocumentos;
            rowProposta.pro_status = statusProposta;
            rowProposta.pro_cliente = clienteProposta;
            rowProposta.pro_bancos = DropDownListBanco.SelectedValue;
            rowProposta.pro_tipo = DropDownListTipo.SelectedValue;
            if ("".Equals(cod))
                rowProposta.pro_data = DateTime.Now;
            else
                rowProposta.pro_data = dataPropostaCadastro;
        }

        protected void ButtonAceitar_Click(object sender, EventArgs e)
        {
            statusProposta = "A";
            SalvaCadastro();
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaPropostas.aspx");
        }

        protected void ButtonExcluiArq_Click(object sender, EventArgs e)
        {
            try
            {
                cntrProposta objCntrProposta = new cntrProposta();
                var Proposta = objCntrProposta.SelecionaProposta(cod);

                DS_Site.PropostaDataTable dtProposta = new DS_Site.PropostaDataTable();
                DS_Site.PropostaRow rowProposta = dtProposta.NewPropostaRow();
                rowProposta = Proposta;
                rowProposta.pro_doc1 = string.Empty;

                if (objCntrProposta.Salva(rowProposta))
                {
                    FileInfo arquivo = new FileInfo(caminhoArquivo);

                        if (arquivo.Exists)
                        {
                            arquivo.Delete();
                        }
                }

                Label48.Visible = false;
                ButtonExcluiArq.Enabled = false;
            }
            catch (IOException)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "erroExcluir2", "alert('Erro ao excluir arquivo!');", true);
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "erroSalvar2", "alert('Erro ao enviar dados!');", true);
            }

        }

        protected void ButtonBusca_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)LoginView1.FindControl("ButtonAceitar") as Button);
            Button btnNegar = ((Button)LoginView1.FindControl("ButtonNegar") as Button);

            if (User.IsInRole("Administrador"))
            {
                btn.Enabled = false;
                btnNegar.Enabled = false;
            }

            BuscaCliente(TextBoxNumeroCpf.Text.Trim());
        }

        protected void ButtonAltera_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadCliente.aspx?pg=" + clienteProposta, false);
        }

        protected void ButtonNegar_Click(object sender, EventArgs e)
        {
            statusProposta = "D";
            SalvaCadastro();
        }

        protected void DropDownListFormaRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExibeRecebimentoBeneficio();
        }

        protected void DropDownListLibEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExibeLiberacaoEmprestimo();
        }

        private void ExibeRecebimentoBeneficio()
        {
            if (DropDownListFormaRec.SelectedIndex == 2 || "".Equals(DropDownListFormaRec.SelectedValue))
            {

                Panel2.Visible = false;
                DropDownListBancoRec.SelectedIndex = -1;
                TextBoxAgencia.Text = string.Empty;
                TextBoxOperacao.Text = string.Empty;
                TextBoxConta.Text = string.Empty;
            }
            else
            {
                Panel2.Visible = true;
            }
        }

        private void ExibeLiberacaoEmprestimo()
        {
            if (DropDownListLibEmp.SelectedIndex == 1 || "".Equals(DropDownListLibEmp.SelectedValue))
            {

                Panel3.Visible = true;
                TextBoxAgenciaEmp.Text = string.Empty;
                TextBoxOpAgenciaEmp.Text = string.Empty;
                TextBoxContaEmp.Text = string.Empty;
                Panel4.Visible = false;
            }
            else
            {
                Panel3.Visible = true;
                Panel4.Visible = true;
            }
            if ("".Equals(DropDownListLibEmp.SelectedValue))
            {
                Panel3.Visible = false;
                Panel4.Visible = false;
                DropDownListBancoEmp.SelectedIndex = -1;
                TextBoxCidadeBancoEmp.Text = string.Empty;
                TextBoxAgenciaEmp.Text = string.Empty;
                TextBoxOpAgenciaEmp.Text = string.Empty;
                TextBoxContaEmp.Text = string.Empty;
            }
        }

        protected void ButtonCorretor_Click(object sender, EventArgs e)
        {
            if (TextBoxCodCorretor.Text.Length > 0)
            {
                var corretor = BuscaAgente(TextBoxCodCorretor.Text.Trim());
                if (corretor.usu_cod == null || !"Corretor".Equals(corretor.usu_funcao))
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Aviso1", "alert('Corretor não localizado!');", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Aviso2", "alert('Informe o código do corretor!');", true);
                TextBoxCodCorretor.Focus();
            }
        }

        private void BuscaCliente(string cpf)
        {
            if (cpf.Length > 13)
            {

                DS_Site.ClienteRow rowClienteCpf = objCntrCliente.SelecionaClienteCpf(cpf);

                if (rowClienteCpf.cli_cod == null)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "naoEncontrado", "alert('Nenhum registro encontrato com o CPF Nº " + cpf + "');", true);
                    TextBoxNumeroCpf.Focus();
                }
                else
                {
                    TextBoxNumeroCpf.Text = string.Empty;
                    clienteProposta = rowClienteCpf.cli_cod;
                    CarregaCliente(clienteProposta);
                    TextBoxNb.Focus();
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "campoVazio", "alert('Informe um número completo!');", true);
                TextBoxNumeroCpf.Focus();
            }
        }

        private string GeraDocsPDF()
        {
            string docsPath = Server.MapPath("~/App_Data/Documentos/");
            string arquivoPDF = docsPath + GeraCodigo().ToLower() + ".pdf";

            Document document = new Document(PageSize.A4, 36, 36, 36, 36);

            PdfWriter pdfW = PdfWriter.GetInstance(document, new FileStream(arquivoPDF, FileMode.Create));
            pdfW.SetEncryption(PdfWriter.STRENGTH128BITS, "12344321", "12344321", PdfWriter.AllowAssembly);

            document.AddTitle("www.macicocred.com.br");
            document.AddAuthor("Maciço CRED");
            document.AddCreationDate();
            document.AddProducer();

            document.Open();

            /* ------------------------------------------------------------------------------------- */

            if (!string.IsNullOrEmpty(arq1) && File.Exists(docsPath + arq1))
            {
                iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(docsPath + arq1);
                img1.Alignment = Element.ALIGN_CENTER;

                if (img1.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                }

                document.NewPage();
                document.Add(img1);
            }
            if (!string.IsNullOrEmpty(arq2) && File.Exists(docsPath + arq2))
            {
                iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(docsPath + arq2);
                img2.Alignment = Element.ALIGN_CENTER;

                if (img2.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                }

                document.NewPage();
                document.Add(img2);
            }
            if (!string.IsNullOrEmpty(arq3) && File.Exists(docsPath + arq3))
            {
                iTextSharp.text.Image img3 = iTextSharp.text.Image.GetInstance(docsPath + arq3);
                img3.Alignment = Element.ALIGN_CENTER;

                if (img3.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                }

                document.NewPage();
                document.Add(img3);
            }
            if (!string.IsNullOrEmpty(arq4) && File.Exists(docsPath + arq4))
            {
                iTextSharp.text.Image img4 = iTextSharp.text.Image.GetInstance(docsPath + arq4);
                img4.Alignment = Element.ALIGN_CENTER;

                if (img4.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                }

                document.NewPage();
                document.Add(img4);
            }
            if (!string.IsNullOrEmpty(arq5) && File.Exists(docsPath + arq5))
            {
                iTextSharp.text.Image img5 = iTextSharp.text.Image.GetInstance(docsPath + arq5);
                img5.Alignment = Element.ALIGN_CENTER;

                if (img5.Width > 595)
                {
                    document.SetPageSize(iTextSharp.text.PageSize.A5.Rotate());
                }

                document.NewPage();
                document.Add(img5);
            }

            document.Close();

            return arquivoPDF;
        }

        private string GeraCodigo()
        {
            int Tamanho = 8; // Numero de digitos da senha
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

            return senha;
        }

    }
}