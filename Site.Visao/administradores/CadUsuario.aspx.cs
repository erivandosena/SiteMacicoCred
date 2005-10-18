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
    public partial class CadUsuario : System.Web.UI.Page
    {
        private string cod;
        private static string roles = "";
        private static string nomeAnterior = "";
        private static string emailAnterior = "";
        private static string senhaAnterior = "";
        private static string cpfAnterior = "";
        private static string senhaEmail = "";

        cntrUsuario objCntrUsuario = new cntrUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["pg"]))
            {
                cod = "";
            }
            else
            {
                cod = Request.QueryString["pg"];
            }

            if (!User.IsInRole("Administrador"))
            {
                if (User.IsInRole("Operador") || User.IsInRole("Corretor"))
                {
                    cod = objCntrUsuario.SelecionaUsuarioNome(User.Identity.Name).usu_cod;

                    TextBoxNomeComp.Enabled = false;
                    TextBoxCpf.Enabled = false;
                    DropDownListLocal.Enabled = false;
                    Label5.Visible = false;
                    CheckBoxListFuncao.Visible = false;
                }
            }

            if (!Page.IsPostBack)
            {
                DropDownListLocal.AppendDataBoundItems = true;
                DropDownListLocal.Items.Insert(0, new ListItem(String.Empty, String.Empty));

                try
                {
                    if (!"".Equals(cod))
                    {
                        DS_Site.UsuarioRow rowUsuario = objCntrUsuario.SelecionaUsuario(cod);

                        TextBoxNome.Text = rowUsuario.usu_nome;
                        TextBoxEmail.Text = rowUsuario.usu_email;
                        DropDownListLocal.SelectedValue = rowUsuario.usu_loja;
                        TextBoxNomeComp.Text = rowUsuario.usu_nome_completo;
                        TextBoxCpf.Text = rowUsuario.usu_cpf;
                        TextBoxRg.Text = rowUsuario.usu_rg;
                        TextBoxDatNasc.Text = rowUsuario.usu_data_nascimento;
                        TextBoxEndereco.Text = rowUsuario.usu_endereco_res;
                        TextBoxEnderecoCom.Text = rowUsuario.usu_endereco_com;
                        TextBoxCep.Text = rowUsuario.usu_cep;
                        TextBoxBairro.Text = rowUsuario.usu_bairro;
                        TextBoxCidade.Text = rowUsuario.usu_cidade;
                        DropDownListUf.SelectedValue = rowUsuario.usu_uf;
                        TextBoxTel.Text = rowUsuario.usu_tel_fixo;
                        TextBoxTel2.Text = rowUsuario.usu_tel_cel;
                        DropDownListBanco.SelectedValue = rowUsuario.usu_banco;
                        TextBoxAgencia.Text = rowUsuario.usu_agencia;
                        TextBoxOperacao.Text = rowUsuario.usu_operacao;
                        TextBoxConta.Text = rowUsuario.usu_conta;
                        DropDownListTipo.SelectedValue = rowUsuario.usu_tipo_conta;

                        senhaAnterior = rowUsuario.usu_senha;
                        nomeAnterior = rowUsuario.usu_nome;
                        emailAnterior = rowUsuario.usu_email;
                        cpfAnterior = rowUsuario.usu_cpf;

                        roles = rowUsuario.usu_funcao;
                        string[] arrayFuncoes = rowUsuario.usu_funcao.Split(',');
                        for (int i = 0; i < arrayFuncoes.Length; i++)
                        {
                            CheckBoxListFuncao.Items.FindByText(arrayFuncoes[i]).Selected = true;
                        }
                        Panel1.Visible = LabelCodigo.Visible = "Corretor".Equals(roles);
                        LabelCodigo.Text = LabelCodigo.Text + "<br />" + rowUsuario.usu_cod;

                    }
                    else
                    {
                        DropDownListLocal.SelectedIndex = 0;
                        roles = "";
                        senhaAnterior = "";
                        senhaEmail = "";
                    }

                }
                catch (Exception)
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        private void carregaFuncoes()
        {
            string[] array = { "Administrador", "Operador", "Corretor" };
            CheckBoxListFuncao.DataSource = array;
            CheckBoxListFuncao.DataBind();
        }
        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DS_Site.UsuarioDataTable dtUsuario = new DS_Site.UsuarioDataTable();
                DS_Site.UsuarioRow rowUsuario = dtUsuario.NewUsuarioRow();

                if ("".Equals(senhaAnterior))
                {
                    senhaAnterior = FormsAuthentication.HashPasswordForStoringInConfigFile(GeraSenha(), "MD5").ToString();

                }

                if (!"".Equals(TextBoxSenha.Text.Trim()))
                {
                    senhaAnterior = FormsAuthentication.HashPasswordForStoringInConfigFile(TextBoxSenha.Text.Trim(), "MD5").ToString();
                    senhaEmail = TextBoxSenha.Text.Trim();
                }

                rowUsuario.usu_cod = cod;
                rowUsuario.usu_nome = TextBoxNome.Text.Trim();
                rowUsuario.usu_senha = senhaAnterior;
                rowUsuario.usu_email = TextBoxEmail.Text.Trim().ToLower();
                rowUsuario.usu_loja = DropDownListLocal.SelectedValue;
                rowUsuario.usu_ativo = true;
                rowUsuario.usu_funcao = roles;
                rowUsuario.usu_nome_completo = TextBoxNomeComp.Text.Trim().ToUpper();
                rowUsuario.usu_cpf = TextBoxCpf.Text.Trim();
                rowUsuario.usu_rg = TextBoxRg.Text.Trim();
                rowUsuario.usu_data_nascimento = TextBoxDatNasc.Text.Trim();
                rowUsuario.usu_endereco_res = TextBoxEndereco.Text.Trim().ToUpper();
                rowUsuario.usu_endereco_com = TextBoxEnderecoCom.Text.Trim().ToUpper();
                rowUsuario.usu_cep = TextBoxCep.Text.Trim();
                rowUsuario.usu_bairro = TextBoxBairro.Text.Trim().ToUpper();
                rowUsuario.usu_cidade = TextBoxCidade.Text.Trim().ToUpper();
                rowUsuario.usu_uf = DropDownListUf.SelectedValue;
                rowUsuario.usu_tel_fixo = TextBoxTel.Text.Trim();
                rowUsuario.usu_tel_cel = TextBoxTel2.Text.Trim();
                rowUsuario.usu_banco = DropDownListBanco.SelectedValue;
                rowUsuario.usu_agencia = TextBoxAgencia.Text.Trim();
                rowUsuario.usu_operacao = TextBoxOperacao.Text.Trim();
                rowUsuario.usu_conta = TextBoxConta.Text.Trim();
                rowUsuario.usu_tipo_conta = DropDownListTipo.SelectedValue;

                cntrUsuario objCntrUsuario = new cntrUsuario();
                DS_Site.UsuarioRow rowUsuarioNomeExistente = objCntrUsuario.SelecionaUsuarioNome(TextBoxNome.Text.Trim());
                DS_Site.UsuarioRow rowUsuarioEmailExistente = objCntrUsuario.SelecionaUsuarioEmail(TextBoxEmail.Text.Trim().ToLower());
                DS_Site.UsuarioRow rowUsuarioCpfExistente = objCntrUsuario.SelecionaUsuarioCpf(TextBoxCpf.Text.Trim());

                if ("".Equals(cod)) //Verifica se já existem usuario, e-mail, cpf ao inserir
                {
                    if (rowUsuarioNomeExistente.usu_cod == null && !TextBoxEmail.Text.Trim().ToLower().Equals(rowUsuarioEmailExistente.usu_email) && !TextBoxCpf.Text.Trim().Equals(rowUsuarioCpfExistente.usu_cpf))
                    {
                        salva(rowUsuario);
                    }
                    else
                    {
                        if (rowUsuarioNomeExistente.usu_nome != null)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta1", "alert('O usuário " + TextBoxNome.Text + " já está cadastrado! Tente outro.');", true);
                            TextBoxNome.Focus();
                        }
                        else
                            if (rowUsuarioEmailExistente.usu_nome != null)
                            {
                                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta2", "alert('O e-mail " + TextBoxEmail.Text + " já está cadastrado! Tente outro.');", true);
                                TextBoxEmail.Focus();
                            }
                            else
                                if (rowUsuarioCpfExistente.usu_cpf != null)
                                {
                                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta3", "alert('O cpf " + TextBoxCpf.Text + " já está cadastrado! Tente outro.');", true);
                                    TextBoxCpf.Focus();
                                }
                    }
                }
                else // Ou verifica se já existem usuario, e-mail, cpf ao atualizar
                {
                    if (!TextBoxNome.Text.Trim().Equals(nomeAnterior)) //Verifica se foi alterado o usuario
                    {
                        if (rowUsuarioNomeExistente.usu_cod == null) //Verifica se o usuario ja existe
                        {
                            if (!TextBoxEmail.Text.Trim().ToLower().Equals(emailAnterior)) //Verifica se foi alterado o e-mail
                            {
                                if (rowUsuarioEmailExistente.usu_email == null) //Verifica se o e-mail ja existe
                                {
                                    if (!TextBoxCpf.Text.Trim().Equals(cpfAnterior)) //Verifica se foi alterado o cpf
                                    {
                                        if (rowUsuarioCpfExistente.usu_cpf == null) //Verifica se o cpf ja existe
                                        {
                                            salva(rowUsuario);
                                        }
                                        else
                                        {
                                            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta4", "alert('O CPF " + TextBoxCpf.Text + " já está cadastrado! Tente outro.');", true);
                                            TextBoxCpf.Focus();
                                        }
                                    }
                                    else
                                    {
                                        salva(rowUsuario);
                                    }
                                }
                                else
                                {
                                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta5", "alert('O e-mail " + TextBoxEmail.Text + " já está cadastrado! Tente outro.');", true);
                                    TextBoxEmail.Focus();
                                }
                            }
                            else
                            {
                                salva(rowUsuario);
                            }

                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta6", "alert('O usuário " + TextBoxNome.Text + " já está cadastrado! Tente outro.');", true);
                        }
                    }
                    else //Ou se não foi alterado o usuario, verifica se foi alterado o e-mail, cpf
                        if (!TextBoxEmail.Text.Trim().ToLower().Equals(emailAnterior)) //Verifica se foi alterado o e-mail
                        {
                            if (rowUsuarioEmailExistente.usu_email == null) //Verifica se o e-mail ja existe
                            {
                                if (!TextBoxCpf.Text.Trim().Equals(cpfAnterior)) //Verifica se foi alterado o cpf
                                {
                                    if (rowUsuarioCpfExistente.usu_cpf == null) //Verifica se o cpf ja existe
                                    {
                                        salva(rowUsuario);
                                    }
                                    else
                                    {
                                        Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta7", "alert('O CPF " + TextBoxCpf.Text + " já está cadastrado! Tente outro.');", true);
                                        TextBoxCpf.Focus();
                                    }
                                }
                                else
                                {
                                    salva(rowUsuario);
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta8", "alert('O e-mail " + TextBoxEmail.Text + " já está cadastrado! Tente outro.');", true);
                                TextBoxEmail.Focus();
                            }
                        }
                        else
                        {
                            if (!TextBoxCpf.Text.Trim().Equals(cpfAnterior)) //Verifica se foi alterado o cpf
                            {
                                if (rowUsuarioCpfExistente.usu_cpf == null) //Verifica se o cpf ja existe
                                {
                                    salva(rowUsuario);
                                }
                                else
                                {
                                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta9", "alert('O CPF " + TextBoxCpf.Text + " já está cadastrado! Tente outro.');", true);
                                    TextBoxCpf.Focus();
                                }
                            }
                            else
                            {
                                salva(rowUsuario);
                            }
                        }

                }

            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }

        }

        void salva(DS_Site.UsuarioRow rowUsuario)
        {
            if (roles.Length > 0)
            {
                if ("Corretor".Equals(roles) && TextBoxNomeComp.Text.Length < 10)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta1", "alert('Nome completo é obrigatório!');", true);
                    TextBoxNomeComp.Focus();
                }
                else
                    if ("Corretor".Equals(roles) && TextBoxCpf.Text.Length < 14)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta2", "alert('CPF é obrigatório!');", true);
                        TextBoxCpf.Focus();
                    }
                    else
                    {
                        if (objCntrUsuario.Salva(rowUsuario))
                        {
                            if (!"".Equals(senhaEmail))
                                EnviaEmail();
                        }
                        Retorna();
                    }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta3", "alert('Selecione o perfil!');", true);
                CheckBoxListFuncao.Focus();
            }
        }


        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Retorna();
        }
        void Retorna()
        {
            Response.Redirect("ListaUsuarios.aspx", false);
        }

        protected void CheckBoxListFuncao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selecionados = "";
            for (int i = 0; i < CheckBoxListFuncao.Items.Count; i++)
            {
                roles = "";
                if (CheckBoxListFuncao.Items[i].Selected)
                {
                    selecionados += CheckBoxListFuncao.Items[i].Text + ",";
                }
            }
            if (selecionados.Length > 0 && "".Equals(roles) || selecionados.Length > 0 && !"".Equals(cod))
            {
                roles = selecionados.Substring(0, selecionados.Length - 1);
                Panel1.Visible = "Corretor".Equals(roles);

                if ("Administrador,Operador,Corretor".Equals(roles) || "Administrador,Corretor".Equals(roles) || "Operador,Corretor".Equals(roles))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alerta15", "alert('O perfil de Administrador ou Operador não pode também ser Corretor!');", true);
                    CheckBoxListFuncao.SelectedIndex = -1;
                    CheckBoxListFuncao.Focus();
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "erroUsuario", "alert('Selecione o perfil!');", true);
                CheckBoxListFuncao.Focus();
            }
        }

        protected void CheckBoxListFuncao_Init(object sender, EventArgs e)
        {
            carregaFuncoes();
        }

        private string GeraSenha()
        {
            int Tamanho = 6; // Numero de digitos da senha
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
            senhaEmail = senha;

            return senha;
        }

        void EnviaEmail()
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
                                    "<td align='center'><strong>ACESSO AO SITE</strong></td>" +
                                    "</tr>" +
                                    "</table>" +
                                    "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                    "<td bgcolor='#F9F9F9' valign='top' style='border:0;'>" +
                                    "<table border='0' cellspacing='10' cellpadding='0'>" +
                                      "<tr>" +
                                        "<td width='599'><p>Prezado(a) <strong>" + TextBoxNomeComp.Text.ToUpper() + "</strong>,</p>" +
                                          "<p>Segue nome de usuário e senha para acesso na <a href='" + UrlSite + "/Login.aspx' target='_blank'>área restrita</a> do site " + HttpContext.Current.Request.Url.Authority + "<br />" +
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
                                        "<td width='100'>Usuário:</td>" +
                                        "<td>" + TextBoxNome.Text.Trim() + "</td>" +
                                      "</tr>" +
                                      "<tr>" +
                                        "<td>Senha:</td>" +
                                        "<td>" + senhaEmail + "</td>" +
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
                    TextBoxNome.Text.ToUpper() + "<" + TextBoxEmail.Text.ToLower() + ">",
                    "Informações de Login",
                    CorpoEmail.ToString());
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }

    }
}
