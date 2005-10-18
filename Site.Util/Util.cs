using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// Summary description for Util
/// </summary>
/// 

namespace Site.Util
{

    public class Util
    {
        public Util()
        {
            //Valores por extenso
            numeroLista = new List<int>();
        }

        //Valores por extenso
        public Util(Decimal dec)
        {
            numeroLista = new List<int>();
            SetNumero(dec);
        }

        //Valores por extenso
        private List<int> numeroLista;
        private Int32 num;

        //Remove acentos
        public static string RemoveAcento(string palavra)
        {
            string palavraSemAcento = null;
            string caracterComAcento = "áàãâäéèêëíìîïóòõôöúùûüçÁÀÃÂÄÉÈÊËÍÌÎÏÓÒÕÖÔÚÙÛÜÇ";
            string caracterSemAcento = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC";

            for (int i = 0; i < palavra.Length; i++)
            {
                if (caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0)
                {
                    int car = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)));
                    palavraSemAcento += caracterSemAcento.Substring(car, 1);
                }
                else
                {
                    palavraSemAcento += palavra.Substring(i, 1);
                }
            }

            return palavraSemAcento;
        }

        //Substitui caracteres especiais e acentos com exceção do ponto "."
        public static string SubstituiCaractEspacAcentos(string palavra)
        {
            string palavraSemAcento = null;
            string caracterComAcento = @"!@#$%¨&*()-+?:{}][ºª='`´;/§\|~^äåáâàãäáâàãéêëèéêëèíîïìíîïìöóôòõöóôòõüúûüúûùç ÄÅÁÂÀÃÄÁÂÀÃÉÊËÈÉÊËÈÍÎÏÌÍÎÏÌÖÓÔÒÕÖÓÔÒÕÜÚÛÜÚÛÙÇ";
            string caracterSemAcento = "-------------------------------aaaaaaaaaaaeeeeeeeeiiiiiiiioooooooooouuuuuuuc-aaaaaaaaaaaeeeeeeeeiiiiiiiioooooooooouuuuuuuc";

            for (int i = 0; i < palavra.Length; i++)
            {
                if (caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0)
                {
                    int car = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)));
                    palavraSemAcento += caracterSemAcento.Substring(car, 1);
                }
                else
                {
                    palavraSemAcento += palavra.Substring(i, 1);
                }
            }

            return palavraSemAcento;
        }

        //Url SEO
        public static string GeraURL(object Title, object strId)
        {
            string strTitle = Title.ToString();

            #region Generate SEO Friendly URL based on Title
            //Trim Start and End Spaces.
            strTitle = strTitle.Trim();

            //Trim "-" Hyphen
            strTitle = strTitle.Trim('-');

            strTitle = strTitle.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            strTitle = strTitle.Replace("c#", "C-Sharp");
            strTitle = strTitle.Replace("vb.net", "VB-Net");
            strTitle = strTitle.Replace("asp.net", "Asp-Net");

            //Replace . with - hyphen
            strTitle = strTitle.Replace(".", "-");

            //Replace Special-Characters
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                {
                    strTitle = strTitle.Replace(strChar, string.Empty);
                }
            }

            //Replace all spaces with one "-" hyphen
            strTitle = strTitle.Replace(" ", "-");

            //Replace multiple "-" hyphen with single "-" hyphen.
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");

            //Run the code again...
            //Trim Start and End Spaces.
            strTitle = strTitle.Trim();

            //Trim "-" Hyphen
            strTitle = strTitle.Trim('-');
            #endregion

            //Append ID at the end of SEO Friendly URL
            strTitle = SubstituiCaractEspacAcentos(strTitle) +"-" + strId + ".aspx";

            return strTitle;
        }

        //Envio de e-mail
        public static void EnviaEmail(string De, string Para, string Assunto, string Mensagem)
        {
            using (MailMessage email = new MailMessage())
            {
                email.From = new MailAddress(De);
                email.To.Add(Para);
                email.Subject = Assunto;
                email.IsBodyHtml = true;
                email.Body = Mensagem;
                email.SubjectEncoding = Encoding.GetEncoding("iso-8859-1");
                email.BodyEncoding = Encoding.GetEncoding("iso-8859-1");
                SmtpClient smtp = new SmtpClient();
                smtp.Send(email);
            }
        }

        //Envio de e-mail com anexo
        public static void EnviaEmailAnexo(string De, string Para, string Assunto, string Mensagem, string aNome, MemoryStream aArquivo)
        {
            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            MemoryStream memoryStream = new MemoryStream(aArquivo.GetBuffer());
            Attachment anexo = new Attachment(memoryStream, aNome);

            try
            {
                email.From = new MailAddress(De);
                email.To.Add(Para);
                email.Subject = Assunto;
                email.IsBodyHtml = true;
                email.Attachments.Add(anexo);
                email.Body = Mensagem;
                email.SubjectEncoding = Encoding.GetEncoding("iso-8859-1");
                email.BodyEncoding = Encoding.GetEncoding("iso-8859-1");

                try
                {
                    smtp.Send(email);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            finally
            {
                email.Dispose();
                anexo.Dispose();
                memoryStream.Flush();
            }
           
        }

        //Envio de e-mail com dados
        public static void EnviaEmailDados(string De, string Para, string Assunto, string Usuario, string Senha)
        {
            using (MailMessage email = new MailMessage())
            {
                email.From = new MailAddress(De);
                email.To.Add(Para);
                email.Subject = Assunto;
                email.IsBodyHtml = true;
                email.Body = "<font face='Trebuchet MS', Georgia, 'Times New Roman', Times, serif'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='600' align='center'>" +
                "<tr><td valign='top'><table border='0' cellpadding='0' cellspacing='0' align='left'>" +
                "<tr><td><a href='http://www.jardsonbrito.com.br' target='_blank'>" +
                "<img border='0' src='http://www.jardsonbrito.com.br/Arquivos/image/logoweb.png'></a>" +
                "</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td>" +
                " <strong><font face='Tahoma' color='#595957'><h2>www.jardsonbrito.com.br</h2></font></strong>" +
                "</td></tr></table></td></tr><tr><td valign='top'><hr style='height: 8px; color: #E1BD4B' />" +
                "</td></tr><tr><td valign='top'>&nbsp;</td></tr><tr><td valign='top'>" +
                " Por favor, dirija-se ao site e <a href='http://www.jardsonbrito.com.br/Login.aspx'" +
                " title='faça login' target='_blank'>faça login</a> utilizando as seguintes informa&ccedil;&otilde;es." +
                "<br />Usu&aacute;rio: <strong>" + Usuario + "</strong><br />Senha: <strong>" + Senha + "</strong>" +
                "</td></tr><tr><td valign='top'>&nbsp;</td></tr><tr><td valign='top'><hr style='height: 8px; color: #649515' />" +
                "</td></tr><tr><td valign='top' align='center'><font face='Tahoma' size='1' color='#333333'>&copy; Todos os direitos reservados. Produzido" +
                " por: <a href='http://www.rwd.net.br' title='RAMOS Web Designer - Criação de Sites' target='_blank'>RAMOS Web Designer</a></font>" +
                "</td></tr></table></font>";
                email.SubjectEncoding = Encoding.GetEncoding("iso-8859-1");
                email.BodyEncoding = Encoding.GetEncoding("iso-8859-1");
                SmtpClient smtp = new SmtpClient();
                smtp.Send(email);
            }
        }

        //valida e-mail
        public static bool ValidaEmail(string sEmail)
        {
            if (sEmail == null)
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(sEmail, @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|[a-zA-Z]{2})$",
                RegexOptions.IgnorePatternWhitespace);
            }
        }

        
        //Valores por extenso
        //array de 2 linhas e 14 colunas[2][14]
        private static readonly String[,] qualificadores = new String[,] {
                {"centavo", "centavos"},//[1][0] e [1][1]
                {"", ""},//[2][0],[2][1]
                {"mil", "mil"},
                {"milhão", "milhões"},
                {"bilhão", "bilhões"},
                {"trilhão", "trilhões"},
                {"quatrilhão", "quatrilhões"},
                {"quintilhão", "quintilhões"},
                {"sextilhão", "sextilhões"},
                {"setilhão", "setilhões"},
                {"octilhão","octilhões"},
                {"nonilhão","nonilhões"},
                {"decilhão","decilhões"}
		};

        private static readonly String[,] numeros = new String[,] {
                {"zero", "um", "dois", "três", "quatro",
                 "cinco", "seis", "sete", "oito", "nove",
                 "dez","onze", "doze", "treze", "quatorze",
                 "quinze", "dezesseis", "dezessete", "dezoito", "dezenove"},
                {"vinte", "trinta", "quarenta", "cinqüenta", "sessenta",
                 "setenta", "oitenta", "noventa",null,null,null,null,null,null,null,null,null,null,null,null},
                {"cem", "cento",
                 "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos",
                 "setecentos", "oitocentos", "novecentos",null,null,null,null,null,null,null,null,null,null}
        };

        public void SetNumero(Decimal dec)
        {
            dec = Decimal.Round(dec, 2);
            dec = dec * 100;
            num = Convert.ToInt32(dec);
            numeroLista.Clear();

            if (num == 0)
            {
                numeroLista.Add(0);
                numeroLista.Add(0);
            }
            else
            {
                AddRemainder(100);
                while (num != 0)
                    AddRemainder(1000);
            }
        }

        private void AddRemainder(Int32 divisor)
        {
            Int32 div = num / divisor;
            Int32 mod = num % divisor;
            var newNum = new Int32[] { div, mod };

            numeroLista.Add(mod);
            num = div;
        }

        private bool TemMaisGrupos(Int32 ps)
        {
            while (ps > 0)
            {
                if (numeroLista[ps] != 00 && !TemMaisGrupos(ps - 1))
                    return true;

                ps--;
            }
            return true;
        }

        private bool EhPrimeiroGrupoUm()
        {
            return (numeroLista[numeroLista.Count - 1] == 1);
        }

        private bool EhUltimoGrupo(Int32 ps)
        {
            return ((ps > 0) && (numeroLista[ps] != 0) || !TemMaisGrupos(ps - 1));
        }

        private bool EhGrupoZero(Int32 ps)
        {

            if (ps <= 0 || ps >= numeroLista.Count)
                return true;

            return (numeroLista[ps] == 0);
        }

        private bool EhUnicoGrupo()
        {
            if (numeroLista.Count <= 3) return false;

            if (!EhGrupoZero(1) && !EhGrupoZero(2)) return false;

            bool hasOne = false;

            for (Int32 i = 3; i < numeroLista.Count; i++)
            {
                if (numeroLista[i] != 0)
                {
                    if (hasOne) return false;

                    hasOne = true;
                }
            }
            return true;
        }

        private String NumToString(Int32 numero, Int32 escala)
        {
            Int32 unidade = (numero % 10);
            Int32 dezena = (numero % 100);
            Int32 centena = (numero / 100);
            var buf = new StringBuilder();

            if (numero != 0)
            {
                if (centena != 0)
                {
                    if (dezena == 0 && centena == 1)
                        buf.Append(numeros[2, 0]);
                    else
                        buf.Append(numeros[2, centena]);
                }

                if (buf.Length > 0 && dezena != 0)
                    buf.Append(" e ");

                if (dezena > 19)
                {
                    dezena = dezena / 10;
                    buf.Append(numeros[1, dezena - 2]);
                    if (unidade != 0)
                    {
                        buf.Append(" e ");
                        buf.Append(numeros[0, unidade]);
                    }
                }
                else if (centena == 0 || dezena != 0)
                    buf.Append(numeros[0, dezena]);

                buf.Append(" ");
                if (numero == 1)
                    buf.Append(qualificadores[escala, 0]);
                else
                    buf.Append(qualificadores[escala, 1]);

            }
            return buf.ToString();
        }

        public override String ToString()
        {
            var buf = new StringBuilder();

            for (var count = numeroLista.Count - 1; count > 0; count--)
            {
                if (buf.Length > 0 && !EhGrupoZero(count))
                    buf.Append(" e ");

                buf.Append(NumToString(numeroLista[count], count));
            }

            if (buf.Length > 0)
            {
                while (buf.ToString().EndsWith(" "))
                    buf.Length = buf.Length - 1;

                if (EhUnicoGrupo())
                    buf.Append(" de ");

                if (EhPrimeiroGrupoUm())
                    buf.Insert(0, "h");

                if (numeroLista.Count == 2 && (numeroLista[1] == 1))
                    buf.Append(" real");
                else
                    buf.Append(" reais");

                if (numeroLista[0] != 0)
                    buf.Append(" e ");
            }

            if (numeroLista[0] != 0)
                buf.Append(NumToString(numeroLista[0], 0));

            return buf.ToString();
        }

    }
}
