using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace Thermas_Piratininga_2014_Responsivo
{
    public partial class Associado_Dados : System.Web.UI.Page
    {
        Rotinas r = new Rotinas();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!r.ValidarSession(this, "session_associado_serie"))
                    Response.Redirect("Default.aspx");

                if (!r.ValidarSession(this, "session_associado_titulo"))
                    Response.Redirect("Default.aspx");

                string serie = Session["session_associado_serie"].ToString();
                string titulo = Session["session_associado_titulo"].ToString();

                lblTitulo.Text = serie.ToUpper() + " - " + titulo.ToUpper();

                #region DADOS DO TITULO
                string html = string.Empty;
                string sql = "SELECT T.TIT_NOME, T.TIT_NUMCART, P.PAR_NOME, C.CARD_VCEX, C.CARD_STA, C.CARD_VCTO, T.TIT_SER, T.TIT_NUMCART, T.TIT_CPF, T.TIT_RG, T.TIT_DTNASC, T.TIT_SEXO, T.TIT_ESTCIVIL, T.TIT_ENDERECO, T.TIT_BAIRRO, T.TIT_COMP, T.TIT_CEP, CID.CID_NOME, T.TIT_TELEFONE, T.TIT_CELULAR, T.TIT_EMAIL, T.TIT_EMAIL2, T.TIT_OBS, T.TIT_TWITTER, T.TIT_DTAQUISICAO, T.TIT_NACIONALIDADE, T.TIT_PROFISSAO, CID.CID_UF, T.TIT_CARTEMIT, T.TIT_CONVENIO, T.TIT_CIDADE, C.CARD_VAL, T.TIT_DTNASC, T.TIT_STA FROM TITULO AS T left JOIN PARENTE AS P ON T.TIT_PARENT = P.ID LEFT JOIN CARTAO AS C ON T.TIT_NUMCART = C.CARD_COD INNER JOIN SERIE AS S ON T.TIT_SER = S.ID LEFT JOIN CIDADE AS CID ON CID.ID = T.TIT_CIDADE WHERE S.SER_ABV = '" + serie + "' AND T.TIT_NUM = " + titulo + " AND T.TIT_CLA = 1;";
                DataTable dt = r.SelecionaBancoMYSQL(sql, "constr_MySQL_Thermas");
                if (dt.Rows.Count > 0)
                {
                    html += "<b>Titular:</b> " + dt.Rows[0]["TIT_NOME"].ToString().Replace("null", string.Empty) + "<br />";
                    html += "<b>CPF:</b> " + dt.Rows[0]["TIT_CPF"].ToString().Replace("null", string.Empty) + "<br />";
                    html += "<b>Endereço:</b> " + dt.Rows[0]["TIT_ENDERECO"].ToString().Replace("null", string.Empty) + "<br />";
                    html += "<b>Bairro:</b> " + dt.Rows[0]["TIT_BAIRRO"].ToString().Replace("null", string.Empty) + " <b>Complemento:</b> " + dt.Rows[0]["TIT_COMP"].ToString().Replace("null", string.Empty) + "<br />";
                    html += "<b>CEP:</b> " + dt.Rows[0]["TIT_CEP"].ToString().Replace("null", string.Empty) + " <b>Cidade:</b> " + dt.Rows[0]["CID_NOME"].ToString().Replace("null", string.Empty) + "<br />";
                    html += "<b>Telefone:</b> " + dt.Rows[0]["TIT_TELEFONE"].ToString().Replace("null", string.Empty) + " <b>Celular:</b> " + dt.Rows[0]["TIT_CELULAR"].ToString().Replace("null", string.Empty) + "<br />";

                    if (!string.IsNullOrEmpty(dt.Rows[0]["TIT_EMAIL"].ToString()))
                        html += "<b>E-mail:</b> " + dt.Rows[0]["TIT_EMAIL"].ToString().Replace("null", string.Empty) + "<br />";
                }
                lblDados.Text = html;
                #endregion

                #region DADOS DOS DEPENDENTES
                sql = "SELECT T.TIT_NOME AS NOME, T.TIT_NUMCART AS CARTEIRA, CONCAT('R$ ', REPLACE(REPLACE(REPLACE(FORMAT(C.CARD_VAL, 2),'.',';'),',','.'),';',',')) AS \"CREDITO CARTEIRA\", P.PAR_NOME AS TIPO, DATE_FORMAT(C.CARD_VCEX,'%d/%m/%Y') AS \"VENC EXAME\", DATE_FORMAT(C.CARD_VCTO,'%d/%m/%Y') AS \"VENC CARTEIRA\", DATE_FORMAT(T.TIT_DTNASC,'%d/%m/%Y') AS NASCIMENTO FROM TITULO AS T left JOIN PARENTE AS P ON T.TIT_PARENT = P.ID LEFT JOIN CARTAO AS C ON T.TIT_NUMCART = C.CARD_COD INNER JOIN SERIE AS S ON T.TIT_SER = S.ID LEFT JOIN CIDADE AS CID ON CID.ID = T.TIT_CIDADE WHERE S.SER_ABV = '" + serie + "' AND T.TIT_NUM = " + titulo + "";
                dt = r.SelecionaBancoMYSQL(sql, "constr_MySQL_Thermas");
                if (dt.Rows.Count > 0)
                {
                    gvDadosCadastrais.DataSource = dt;
                    gvDadosCadastrais.DataBind();
                }
                #endregion

                #region FOTOS DOS ASSOCIADOS
                string html_fotos = string.Empty;
                string caminho_virtual_fotos = ConfigurationManager.AppSettings["caminho_virtual_fotos"].ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string nome = dt.Rows[i]["NOME"].ToString();
                    string carteira = dt.Rows[i]["CARTEIRA"].ToString();
                    html_fotos += "<a class=\"fresco\" data-fresco-group=\"foto\" data-fresco-caption=\"" + nome + "\" href=\"" + caminho_virtual_fotos + serie + "-" + titulo + "/" + carteira + ".jpg\" title=\"" + nome + "\"><img src=\"" + caminho_virtual_fotos + serie + "-" + titulo + "/" + carteira + ".jpg\" alt=\"" + nome + "\" width=\"180px\" height=\"150px\" /></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                }
                lblFotos.Text = html_fotos;
                #endregion

                #region DADOS DOS CONVIDADOS DO MES
                string sql_convidados = "SELECT DATE_FORMAT(OP_DATA,'%d/%m/%Y') AS \"EMITIDO EM\", OP_VISITANTE AS CONVIDADO, OP_CARTAO AS \"EMITIDO POR\" FROM operacoes WHERE op_tipo = 'C' AND OP_SERIE = '" + serie + "' AND OP_TITULO = " + titulo + " AND (DATE_FORMAT(OP_DATA,'%m') ='" + DateTime.Now.ToString("MM") + "' AND DATE_FORMAT(OP_DATA,'%Y') = '" + DateTime.Now.Year.ToString() + "') AND (OP_NUM_OP = 5 OR OP_NUM_OP = 6 OR OP_NUM_OP = 7) group by id ;";
                DataTable dtConvidados = r.SelecionaBancoMYSQL(sql_convidados, "constr_MySQL_Thermas");
                if (dtConvidados.Rows.Count > 0)
                {
                    gvConvidados.DataSource = dtConvidados;
                    gvConvidados.DataBind();
                }
                else
                {
                    lblConvidados.Text = "<i>Nenhum convite foi emitido esse mês.</i>";
                }
                #endregion



            }
            catch (Exception er)
            {
                Response.Write(er.Message);
            }
        }
    }


}