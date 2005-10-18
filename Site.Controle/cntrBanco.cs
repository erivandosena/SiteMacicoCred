using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrBanco
    {
        public cntrBanco()
        {

        }

        Banco objBanco;

        public Boolean Salva(DS_Site.BancoRow pBanco)
        {
            Boolean flagReturn = false;
            if (pBanco.ban_cod == null || pBanco.ban_cod == "")
            {
                this.objBanco = new Banco();
                this.objBanco.ban_nome = pBanco.ban_nome;
                this.objBanco.ban_site = pBanco.ban_site;
                this.objBanco.ban_logo = pBanco.ban_logo;

                try
                {
                    flagReturn = this.objBanco.Insere();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            else
            {
                this.objBanco = Banco.RecuperaBanco(pBanco.ban_cod);
                this.objBanco.ban_cod = pBanco.ban_cod;
                this.objBanco.ban_nome = pBanco.ban_nome;
                this.objBanco.ban_site = pBanco.ban_site;
                this.objBanco.ban_logo = pBanco.ban_logo;

                try
                {
                    flagReturn = this.objBanco.Atualiza();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return flagReturn;
        }

        public static Boolean Exclui(string pCod)
        {
            Boolean flagReturn = false;

            //verifica se este objeto a excluir possui dependencias com outros objetos
            if (Proposta.RecuperaPropostaBanco(Banco.RecuperaBanco(pCod)).Count > 0 )
                return flagReturn;
            else

            try
            {
                flagReturn = Banco.Deleta(pCod);
            }
            catch (Exception e)
            {
                throw e;
            }
            return flagReturn;
        }

        public DS_Site.BancoRow SelecionaBanco(string pCod)
        {
            DS_Site.BancoDataTable dtBanco = new DS_Site.BancoDataTable();
            DS_Site.BancoRow rowBanco = dtBanco.NewBancoRow();

            try
            {
                this.objBanco = Banco.RecuperaBanco(pCod);
                rowBanco.ban_cod = pCod;
                rowBanco.ban_nome = this.objBanco.ban_nome;
                rowBanco.ban_site = this.objBanco.ban_site;
                rowBanco.ban_logo = this.objBanco.ban_logo;
            }
            catch (Exception e)
            {
                throw e;
            }

            return rowBanco;
        }

        public static DS_Site.BancoDataTable SelecionaBancos()
        {
            DS_Site.BancoDataTable dtBanco = new DS_Site.BancoDataTable();

            try
            {
                IList listBancos = Banco.RecuperaBancos();
                for (int i = 0; i < listBancos.Count; i++)
                {
                    Banco objBanco = (Banco)listBancos[i];
                    dtBanco.AddBancoRow(
                    objBanco.ban_cod,
                    objBanco.ban_nome,
                    objBanco.ban_site,
                    objBanco.ban_logo);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dtBanco;
        }

    }
}
