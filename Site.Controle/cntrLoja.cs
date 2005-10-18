using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Site.Modelo;

namespace Site.Controle
{
    public class cntrLoja
    {
        public cntrLoja()
        {

        }

        Loja objLoja;

        public Boolean Salva(DS_Site.LojaRow pLoja)
        {
            Boolean flagReturn = false;
            if (pLoja.loj_cod == null || pLoja.loj_cod == "")
            {
                this.objLoja = new Loja();
                this.objLoja.loj_nome = pLoja.loj_nome;
                this.objLoja.loj_endereco = pLoja.loj_endereco;
                this.objLoja.loj_cidade = pLoja.loj_cidade;
                this.objLoja.loj_estado = pLoja.loj_estado;
                this.objLoja.loj_cep = pLoja.loj_cep;
                this.objLoja.loj_telefone = pLoja.loj_telefone;
                this.objLoja.loj_email = pLoja.loj_email;
                this.objLoja.loj_foto = pLoja.loj_foto;

                try
                {
                    flagReturn = this.objLoja.Insere();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            else
            {
                this.objLoja = Loja.RecuperaLoja(pLoja.loj_cod);
                this.objLoja.loj_cod = pLoja.loj_cod;
                this.objLoja.loj_nome = pLoja.loj_nome;
                this.objLoja.loj_endereco = pLoja.loj_endereco;
                this.objLoja.loj_cidade = pLoja.loj_cidade;
                this.objLoja.loj_estado = pLoja.loj_estado;
                this.objLoja.loj_cep = pLoja.loj_cep;
                this.objLoja.loj_telefone = pLoja.loj_telefone;
                this.objLoja.loj_email = pLoja.loj_email;
                this.objLoja.loj_foto = pLoja.loj_foto;

                try
                {
                    flagReturn = this.objLoja.Atualiza();
                }
                catch (Exception e)
                {
                    // Tratar Mensagens de Erro aqui!!!
                    throw e;
                }
            }
            return flagReturn;
        }

        public static Boolean Exclui(string pCod)
        {
            Boolean flagReturn = false;

            //verifica se este objeto a excluir possui dependencias com outros objetos
            if (Usuario.RecuperaUsuarioLoja(Loja.RecuperaLoja(pCod)).Count > 0 || Comissao.RecuperaComissaoLoja(Loja.RecuperaLoja(pCod)).Count > 0) 
                return flagReturn;
            else

            try
            {
                flagReturn = Loja.Deleta(pCod);
            }
            catch (Exception e)
            {
                // Tratar Mensagens de Erro aqui!!!
                throw e;
            }
            return flagReturn;
        }

        public DS_Site.LojaRow SelecionaLoja(string pCod)
        {
            DS_Site.LojaDataTable dtLoja = new DS_Site.LojaDataTable();
            DS_Site.LojaRow rowLoja = dtLoja.NewLojaRow();

            try
            {
                this.objLoja = Loja.RecuperaLoja(pCod);
                rowLoja.loj_cod = pCod;
                rowLoja.loj_nome = this.objLoja.loj_nome;
                rowLoja.loj_endereco = this.objLoja.loj_endereco;
                rowLoja.loj_cidade = this.objLoja.loj_cidade;
                rowLoja.loj_estado = this.objLoja.loj_estado;
                rowLoja.loj_cep = this.objLoja.loj_cep;
                rowLoja.loj_telefone = this.objLoja.loj_telefone;
                rowLoja.loj_email = this.objLoja.loj_email;
                rowLoja.loj_foto = this.objLoja.loj_foto;

            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return rowLoja;
        }

        public static DS_Site.LojaDataTable SelecionaLojas()
        {
            DS_Site.LojaDataTable dtLoja = new DS_Site.LojaDataTable();

            try
            {
                IList listLojas = Loja.RecuperaLojas();
                for (int i = 0; i < listLojas.Count; i++)
                {
                    Loja objLoja = (Loja)listLojas[i];
                    dtLoja.AddLojaRow(
                    objLoja.loj_cod,
                    objLoja.loj_nome,
                    objLoja.loj_endereco,
                    objLoja.loj_cidade,
                    objLoja.loj_estado,
                    objLoja.loj_cep,
                    objLoja.loj_telefone,
                    objLoja.loj_email,
                    objLoja.loj_foto);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtLoja;
        }

        /*
        public static DS_Site.LojaDataTable SelecionaLojaNome(string pNome)
        {
            DS_Site.LojaDataTable dtLoja = new DS_Site.LojaDataTable();

            try
            {
                IList listLojas = Loja.RecuperaLojasTipo(pNome);
                for (int i = 0; i < listLojas.Count; i++)
                {
                    Loja objLoja = (Loja)listLojas[i];
                    dtLoja.AddLojaRow(
                    objLoja.loj_cod,
                    objLoja.loj_nome,
                    objLoja.loj_endereco,
                    objLoja.loj_cidade,
                    objLoja.loj_estado,
                    objLoja.loj_cep,
                    objLoja.loj_telefone,
                    objLoja.loj_email,
                    objLoja.loj_foto);
                }
            }
            catch (Exception e)
            {
                // Tratar Mensagem de erro aqui
                throw e;
            }

            return dtLoja;
        }
        */
    }
}
