using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Thermas_Piratininga_2014_Responsivo
{
    public partial class Associado_Financeiro : System.Web.UI.Page
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

                #region PLANOS
                string sql = "SELECT DATE_FORMAT(VP.PLAN_AQUISICAO,'%d/%m/%Y') AS AQUISICAO, DATE_FORMAT(VP.PLAN_VCTO,'%d/%m/%Y') AS VENCIMENTO, P.PLA_DESC AS DESCRICAO, C.COR_NOME CORRETOR FROM VCTO_PLANOS AS VP LEFT JOIN CORRETOR AS C ON VP.PLAN_CORRETOR = C.ID INNER JOIN PLANOS AS P ON P.ID = VP.PLAN_TIPO INNER JOIN USERS AS US ON VP.PLAN_USUARIO = US.USU_ID WHERE VP.TIT_SER = '" + serie + "' AND VP.TIT_NUM = '" + titulo + "' ORDER BY VP.ID DESC;";
                DataTable dt = r.SelecionaBancoMYSQL(sql, "constr_MySQL_Thermas");
                if (dt.Rows.Count > 0)
                {
                    gvPlanos.DataSource = dt;
                    gvPlanos.DataBind();
                }
                else lblPlanos.Text = "<i>Nenhum Plano encontrado.</i>";
                #endregion

                #region FINANCEIRO - BOLETOS
                string sql_consuta_boleto = "SELECT b.bol_nossonum AS BOLETO, CONCAT('R$ ', REPLACE(REPLACE(REPLACE(FORMAT(b.bol_valor, 2),'.',';'),',','.'),';',',')) AS VALOR, t.tb_tpnome AS \"DESCRICAO\", BA.NOME AS \"SITUACAO\", DATE_FORMAT(b.bol_vencimento,'%d/%m/%Y') AS VENCIMENTO, DATE_FORMAT(b.bol_dtpagamento,'%d/%m/%Y') AS PAGAMENTO, b.bol_cart AS \"REFERENTE CARTEIRA\" FROM boleto b left join tipobol t on b.bol_tpcob = t.id INNER JOIN BAIXA AS BA ON BA.ID = B.BOL_STATUS WHERE b.bol_serie = '" + serie + "' and b.bol_titulo = '" + titulo + "' ORDER BY b.id ASC;";

                DataTable dtBoleto = r.SelecionaBancoMYSQL(sql_consuta_boleto, "constr_MySQL_Thermas");
                if (dtBoleto.Rows.Count > 0)
                {
                    gvFinanceiro.DataSource = dtBoleto;
                    gvFinanceiro.DataBind();
                }
                else lblFinanceiro.Text = "<i>Nenhum registro encontrado.</i>";
                #endregion
            }
            catch (Exception er)
            {
                Response.Write(er.Message);
            }
        }

    }
}