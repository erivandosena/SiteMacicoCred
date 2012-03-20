using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site.Controle;

namespace Site.Visao.administradores
{
    public partial class Default : System.Web.UI.Page
    {
        cntrPagina objCntrPagina = new cntrPagina();
        cntrLoja objCntrLoja = new cntrLoja();
        cntrUsuario objCntrUsuario = new cntrUsuario();
        cntrCliente objCntrCliente = new cntrCliente();
        cntrBanco objCntrBanco = new cntrBanco();
        cntrProposta objCntrProposta = new cntrProposta();

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelPaginas.Text = cntrPagina.Seleciona().Count.ToString();
            LabelLojas.Text = cntrLoja.SelecionaLojas().Count.ToString();
            LabelUsuarios.Text = cntrUsuario.SelecionaUsuarios().Count.ToString();
            LabelClientes.Text = cntrCliente.SelecionaClientes().Count.ToString();
            LabelBancos.Text = cntrBanco.SelecionaBancos().Count.ToString();
            LabelCorretores.Text = cntrUsuario.SelecionaUsuariosPorFuncao("Corretor").Count.ToString();
            LabelPropostasNovas.Text = cntrProposta.SelecionaPropostaStatus("N").Count.ToString();
            LabelPropNegadas.Text = cntrProposta.SelecionaPropostaStatus("D").Count.ToString();
            LabelPropAprovadas.Text = cntrProposta.SelecionaPropostaStatus("A").Count.ToString();
            LabelPropFaturadas.Text = cntrProposta.SelecionaPropostaStatus("F").Count.ToString();
        }
        
    }
}